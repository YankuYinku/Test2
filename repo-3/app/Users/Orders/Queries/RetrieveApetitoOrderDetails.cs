using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.ApetitoOrders;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries;

public class RetrieveApetitoOrderDetails : IQuery<ApetitoOrderDto>
{
    public int OrderId { get; init; }
    public IList<int> CustomerNumbers { get; init; } = new List<int>();
    public string LanguageCode { get; set; }
    public IList<string> Sortiments { get; set; }
}