using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries;

public class RetrieveHawaOrders : IQuery<IList<OrderSummaryDto>>
{
    public DateTime? OrderDateFrom { get; set; }
    public DateTime? OrderDateTo { get; set; }
    public string? SearchTerm { get; set; }
    public string? Supplier { get; set; }
    public IList<int>? CustomerNumbers { get; set; }
    public OrderStatus Status { get; set; }
}