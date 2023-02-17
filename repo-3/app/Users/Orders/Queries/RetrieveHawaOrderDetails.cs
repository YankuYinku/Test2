using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.HawaOrders;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries;

public class RetrieveHawaOrderDetails : IQuery<HawaOrderDto>
{
    public string Id { get; set; }
}