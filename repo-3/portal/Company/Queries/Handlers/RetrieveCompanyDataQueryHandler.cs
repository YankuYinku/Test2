using apetito.CQS;
using apetito.Customers.Contracts.Company.ApiClients;
using apetito.Customers.Contracts.Company.ApiClients.RequestModels;
using apetito.Customers.Contracts.Company.Models;

namespace apetito.meinapetito.Portal.Application.Root.Company.Queries.Handlers;

public class RetrieveCompanyDataQueryHandler : IQueryHandler<RetrieveCompanyDataQuery, AllCompanyDataDto>
{
    private readonly ICompanyServiceRestClient _companyServiceRestClient;

    public RetrieveCompanyDataQueryHandler(ICompanyServiceRestClient companyServiceRestClient)
    {
        _companyServiceRestClient = companyServiceRestClient;
    }
    
    public async Task<AllCompanyDataDto> Execute(RetrieveCompanyDataQuery query)
    {
        return await _companyServiceRestClient.RetrieveCompanyDataAsync(new RetrieveCompanyQuery()
        {
            CustomerNumber = query.CustomerNumber,
            Includes = query.Includes
        });
    }
}