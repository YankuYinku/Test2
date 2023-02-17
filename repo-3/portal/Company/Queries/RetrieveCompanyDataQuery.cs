using apetito.CQS;
using apetito.Customers.Contracts.Company.Models;

namespace apetito.meinapetito.Portal.Application.Root.Company.Queries;

public class RetrieveCompanyDataQuery : IQuery<AllCompanyDataDto>
{
    public int CustomerNumber { get; set; }

    public IEnumerable<string> Includes { get; set; } = Enumerable.Empty<string>();
    
}