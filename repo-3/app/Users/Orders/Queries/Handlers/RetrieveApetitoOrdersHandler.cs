using apetito.CQS;
using apetito.meinapetito.Order.Contracts.Orders.ApiClients;
using apetito.meinapetito.Order.Contracts.Orders.Models;
using apetito.meinapetito.Portal.Application.Root.Users.Orders.Options;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.ApetitoOrders;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries.Handlers;

public class RetrieveApetitoOrdersHandler : IQueryHandler<RetrieveApetitoOrders,IList<OrderSummaryDto>>
{
    private readonly IApetitoOrdersClient _apetitoOrdersClient;
    private readonly IMapper _mapper;
    private readonly OrderAzureFunctionApiKeys _orderAzureFunctionApiKeys;
    public RetrieveApetitoOrdersHandler(IApetitoOrdersClient apetitoOrdersClient, IMapper mapper, OrderAzureFunctionApiKeys orderAzureFunctionApiKeys)
    {
        _apetitoOrdersClient = apetitoOrdersClient;
        _mapper = mapper;
        _orderAzureFunctionApiKeys = orderAzureFunctionApiKeys;
    }

    public async Task<IList<OrderSummaryDto>> Execute(RetrieveApetitoOrders query)
    {
        var result = await _apetitoOrdersClient.RetrieveApetitoOrderHeadersAsync(new RetrieveApetitoOrdersRequest()
        {
            CustomerNumbers = query.CustomerNumbers.Select(a=> a.ToString()).ToList(),
            Code =_orderAzureFunctionApiKeys.RetrievieApetitoOrdersKey,
            Status = query.Status,
            OrderDateFrom = query.OrderDateFrom?.ToString() ?? string.Empty,
            OrderDateTo = query.OrderDateTo?.ToString() ?? string.Empty,
            Search = query.Search
        });

        var apetitoHeaderObjects =  result.Select(_mapper.Map<ApetitoOrderHeaderDto>).ToList();
        
        var remappedApetitoOrders = apetitoHeaderObjects.Select(_mapper.Map<OrderSummaryDto>).ToList();

        return remappedApetitoOrders;
    }
}