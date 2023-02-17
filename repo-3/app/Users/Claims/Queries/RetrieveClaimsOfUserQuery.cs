using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Claims;
using apetito.meinapetito.Portal.Contracts.Root.Users.Customers;

namespace apetito.meinapetito.Portal.Application.Root.Users.Claims.Queries;

public class RetrieveClaimsOfUserQuery : IQuery<UserAndCustomerClaimsDto>
{
    public RetrieveClaimsOfUserQuery()
    {
        UserEmail = string.Empty;
        CustomersOfUserDto = new CustomersOfUserDto();
        BktBillings = new BktBillingResult();
    }

    public string UserEmail { get; set; }
    public BktBillingResult BktBillings { get; set; }
    public CustomersOfUserDto CustomersOfUserDto { get; set; }

}