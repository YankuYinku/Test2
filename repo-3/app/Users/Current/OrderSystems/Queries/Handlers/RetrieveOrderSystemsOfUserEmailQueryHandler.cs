using apetito.CQS;
using apetito.Customers.Contracts.CustomersOfUser.ApiClients;
using apetito.Customers.Contracts.CustomersOfUser.ApiClients.RequestModels;
using apetito.Customers.Contracts.CustomersOfUser.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.OrderSystems;

namespace apetito.meinapetito.Portal.Application.Root.Users.Current.OrderSystems.Queries.Handlers;

public class RetrieveOrderSystemsOfUserEmailQueryHandler : IQueryHandler<RetrieveOrderSystemsOfUserEmailQuery,
    OrderSystemsDto>
{
    private readonly ICustomerServiceRestClient _customerServiceRestClient;

    public RetrieveOrderSystemsOfUserEmailQueryHandler(ICustomerServiceRestClient customerServiceRestClient)
    {
        _customerServiceRestClient = customerServiceRestClient;
    }

    public async Task<OrderSystemsDto> Execute(RetrieveOrderSystemsOfUserEmailQuery query)
        => CreateOrderSystemsDto(await RetrieveCustomersWhere(query.UserEmail, new RetrieveCustomersOfUserQuery()),
            query.CustomerNumbers);

    private static OrderSystemsDto CreateOrderSystemsDto(IEnumerable<CustomerOfUserDto> customers,
        ICollection<int> customerNumbers)
        => new()
        {
            Items = FilterAndCreateOrderSystems(customers, customerNumbers).ToList()
        };

    private static IEnumerable<string>
        FilterAndCreateOrderSystems(IEnumerable<CustomerOfUserDto> customers, ICollection<int> customerNumbers) =>
        customerNumbers.Any()
            ? customers.Where(c => customerNumbers.Contains(c.CustomerNumber)).Select(c 
                => c.OrderSystem)
            : customers.Select(c => c.OrderSystem);

    private Task<IList<CustomerOfUserDto>> RetrieveCustomersWhere(string email, RetrieveCustomersOfUserQuery query) =>
        _customerServiceRestClient.RetrieveCustomerDataOfUserAsync(email, query);
}