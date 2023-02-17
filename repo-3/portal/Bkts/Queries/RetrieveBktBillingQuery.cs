using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;

namespace apetito.meinapetito.Portal.Application.Bkts.Queries;

public class RetrieveBktBillingQuery : IQuery<BktBillingResult>
{
    public IList<string> Excludes { get; init; } = new List<string>();
}