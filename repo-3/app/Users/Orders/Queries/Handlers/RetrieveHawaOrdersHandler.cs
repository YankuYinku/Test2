using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;
using apetito.Order.Hawa.Contracts.ApiClient;
using apetito.Order.Hawa.Contracts.Models;
using AutoMapper;
using RestEase;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries.Handlers;

public class RetrieveHawaOrdersHandler : IQueryHandler<RetrieveHawaOrders,IList<OrderSummaryDto>>
{
    private readonly IHawaOrderRestApi _hawaOrderRestApi;
    private readonly IMapper _mapper;

    public RetrieveHawaOrdersHandler(IHawaOrderRestApi hawaOrderRestApi, IMapper mapper)
    {
        _hawaOrderRestApi = hawaOrderRestApi;
        _mapper = mapper;
    }

    public async Task<IList<OrderSummaryDto>> Execute(RetrieveHawaOrders query)
    {
        var hawaOrders = _hawaOrderRestApi.GetOrdersAsync(new OrderQuery()
        {
            CustomerNumbers = query.CustomerNumbers?.Select(a => a.ToString()).ToList(),
            SearchTerm = query.SearchTerm,
            OrderDateFrom = query.OrderDateFrom,
            OrderDateTo = query.OrderDateTo,
        });

        var filteredHawaOrders = await hawaOrders;
        
        if (query.Status.HasValue)
        {
            filteredHawaOrders = filteredHawaOrders.Where(EnumWithExpressionsDictionary[query.Status.Value]).ToList();
        }

        IDictionary<string, IList<OrderDto>> dic = new Dictionary<string, IList<OrderDto>>();

        foreach (var item in filteredHawaOrders)
        {
            if (!dic.ContainsKey(ComplicatedKey(item)))
            {
                dic.Add(ComplicatedKey(item),new List<OrderDto>());
            }
            
            dic[ComplicatedKey(item)].Add(item);
        }

        
        var orderStatuses = new Dictionary<string, OrderStatusEnum>();
        
        foreach (var hawaOrder in filteredHawaOrders)
        {
            foreach (var expressions in EnumWithExpressionsDictionary)
            {
                if (expressions.Value.Invoke(hawaOrder))
                {
                    orderStatuses.Add(ComplicatedKey(hawaOrder), expressions.Key);
                    break;
                }
            }
        }


        var remappedHawaOrders = filteredHawaOrders.Select(o => _mapper.Map<OrderSummaryDto>(o)).ToList();

        foreach(var remappedHawaOrder in remappedHawaOrders)
        {
            remappedHawaOrder.Status = orderStatuses[ComplicatedKey(remappedHawaOrder)].ToString();
        }
        

        return remappedHawaOrders;
    }

    private static readonly IDictionary<OrderStatusEnum, Func<OrderDto, bool>> EnumWithExpressionsDictionary =
        new Dictionary<OrderStatusEnum, Func<OrderDto, bool>>
        {
            {OrderStatusEnum.InProgress,ExpressionForInProgressOrder},
            {OrderStatusEnum.Failed, ExpressionForFailedOrder},
            {OrderStatusEnum.SucceededPartially, ExpressionForSucceededPartiallyOrder},
            {OrderStatusEnum.Succeeded, ExpressionForSucceededOrder}
        };

    private static bool ExpressionForFailedOrder(OrderDto dto)
    {
        return dto.ErrorCode.HasValue;
    } 
    private static bool ExpressionForSucceededPartiallyOrder(OrderDto dto)
    {
        return dto.HasOrderPositionsWithErrorCodes && !dto.ErrorCode.HasValue;
    } 
    private static bool ExpressionForSucceededOrder(OrderDto dto)
    {
        return !dto.HasOrderPositionsWithErrorCodes && !dto.ErrorCode.HasValue;
    } 
    private static bool ExpressionForInProgressOrder(OrderDto dto)
    {
        return !ExpressionForFailedOrder(dto) &&
             !ExpressionForSucceededPartiallyOrder(dto) &&
              !ExpressionForSucceededOrder(dto) &&
            dto.Status.IsAcceptedByDistributor && !dto.Status.IsSendToSupplier;
    }


    private static string ComplicatedKey(OrderDto orderDto) => $"{orderDto.Id}||{orderDto.OrderNumber}";
    private static string ComplicatedKey(OrderSummaryDto orderDto) => $"{orderDto.OrderId}||{orderDto.Id}";
    
}