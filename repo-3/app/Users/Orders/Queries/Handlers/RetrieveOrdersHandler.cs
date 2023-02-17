using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.ApetitoOrders;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries.Handlers;

public class RetrieveOrdersHandler : IQueryHandler<RetrieveOrders, RetrieveOrdersQueryResult>
{
    private readonly IQueryHandler<RetrieveApetitoOrders, IList<OrderSummaryDto>> _apetitoOrdersQueryHandler;
    private readonly IQueryHandler<RetrieveHawaOrders, IList<OrderSummaryDto>> _hawaOrdersQueryHandler;
    private readonly ILogger<RetrieveOrdersHandler> _logger;

    public RetrieveOrdersHandler(IQueryHandler<RetrieveApetitoOrders, IList<OrderSummaryDto>> queryHandler,
        IQueryHandler<RetrieveHawaOrders, IList<OrderSummaryDto>> hawaOrdersQueryHandler, 
        ILogger<RetrieveOrdersHandler> logger)
    {
        _apetitoOrdersQueryHandler = queryHandler;
        _hawaOrdersQueryHandler = hawaOrdersQueryHandler;
        _logger = logger;
    }

    public async Task<RetrieveOrdersQueryResult> Execute(RetrieveOrders query)
    {
        var apetitoOrders = GetApetitoOrders(query);

        var hawaOrders = GetHawaOrders(query);

        var orders = new List<OrderSummaryDto>();

        orders.AddRange(await hawaOrders);
        orders.AddRange(await apetitoOrders);


        _logger.LogInformation($"Querying objects from: {query.OrderDateFrom.ToString()} to: {query.OrderDateTo.ToString()}");

        var orderedOrders = orders.OrderByDescending(a => a.OrderDate).ToList();

        var supplierSummarization = PrepareSupplierSummarizations(orders);

        var countBeforeSupplier = orders.Count;

        if (!string.IsNullOrWhiteSpace(query.Supplier))
        {
            orderedOrders = orderedOrders.Where(o => o.Supplier?.ToLower() == query.Supplier.ToLower()).ToList();
        }

        return new RetrieveOrdersQueryResult
        {
            Orders = orderedOrders.Skip(query.Skip).Take(query.Take).ToList(),
            OverallPages = (int) Math.Ceiling((decimal) orderedOrders.Count / query.PageSize),
            OverallResults = orderedOrders.Count,
            OverallItemsInAllCategories = countBeforeSupplier,
            SupplierSummarizations = supplierSummarization
        };
    }

    private static List<SupplierSummarization> PrepareSupplierSummarizations(List<OrderSummaryDto> orders)
    {
        IDictionary<string, int> suppliersDictionary = new Dictionary<string, int>();

        foreach (var order in orders)
        {
            string currentSupplier = order.Supplier ?? string.Empty;

            if (!suppliersDictionary.ContainsKey(currentSupplier))
            {
                suppliersDictionary.Add(currentSupplier, 1);
                continue;
            }

            suppliersDictionary[currentSupplier]++;
        }

        return suppliersDictionary.Select(a => new SupplierSummarization
        {
            Supplier = a.Key,
            Amount = a.Value
        }).ToList();
    }

    private async Task<IList<OrderSummaryDto>> GetApetitoOrders(RetrieveOrders query)
    {
        if (query.Status.HasValue && query.Status.Value is OrderStatusEnum.InProgress or OrderStatusEnum.SucceededPartially)
        {
            return new List<OrderSummaryDto>();
        }

        bool? requiredStatusValue = query.Status.HasValue
            ? query.Status.Value switch
            {
                OrderStatusEnum.Failed => true,
                OrderStatusEnum.Succeeded => false,
                OrderStatusEnum.InProgress => ThrowException(query.Status),
                OrderStatusEnum.SucceededPartially => ThrowException(query.Status),
                _ => throw new ArgumentOutOfRangeException()
            }
            : null;

        return await _apetitoOrdersQueryHandler.Execute(new RetrieveApetitoOrders()
        {
            CustomerNumbers = query.CustomerNumbers ?? new List<int>(),
            OrderDateFrom = query.OrderDateFrom,
            OrderDateTo = query.OrderDateTo,
            Status = requiredStatusValue,
            Search = query.SearchTerm
        });
    }

    private static bool? ThrowException(OrderStatus orderStatus) =>
        throw new Exception($"In apetito order context order cannot be {orderStatus.Value.ToString()}");
    
    private async Task<IList<OrderSummaryDto>> GetHawaOrders(RetrieveOrders query)
    {
        return await _hawaOrdersQueryHandler.Execute(new RetrieveHawaOrders
        {
            Status = query.Status,
            CustomerNumbers = query.CustomerNumbers,
            SearchTerm = query.SearchTerm,
            Supplier = query.Supplier,
            OrderDateFrom = query.OrderDateFrom,
            OrderDateTo = query.OrderDateTo
        });
    }
}