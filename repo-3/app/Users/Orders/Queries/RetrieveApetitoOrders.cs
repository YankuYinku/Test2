using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.ApetitoOrders;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries;

public class RetrieveApetitoOrders : IQuery<IList<OrderSummaryDto>>
{
    public IList<int> CustomerNumbers { get; set; }
    public DateTime? OrderDateFrom { get; set; }
    public DateTime? OrderDateTo { get; set; }
    public bool? Status { get; set; }
    public string? Search { get; set; }
}