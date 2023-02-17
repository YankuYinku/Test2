using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Claims;
using apetito.meinapetito.Portal.Contracts.Root.Users.Customers;

namespace apetito.meinapetito.Portal.Application.Root.Users.Claims.Queries.Handlers;
public class RetrieveClaimsOfUserQueryHandler : IQueryHandler<RetrieveClaimsOfUserQuery, UserAndCustomerClaimsDto>
{
    public async Task<UserAndCustomerClaimsDto> Execute(RetrieveClaimsOfUserQuery query)
    {
        return await ComputeUserClaims(query.UserEmail, query.CustomersOfUserDto,query.BktBillings);
    }

     private Task<UserAndCustomerClaimsDto> ComputeUserClaims(string email, CustomersOfUserDto customersOfUserDto,BktBillingResult bktBillingResult)
    {
        var result = new UserAndCustomerClaimsDto();

        result.AddClaimsForUser(UserClaimFactory.DeriveClaimsFromEmail(email).ToArray());
        
        if (!customersOfUserDto.Customers.Any())
        {
            result.AddClaimsForUser(UserClaimFactory.DeriveApplicantClaims().ToArray());
            return Task.FromResult(result);
        }

        result.AddClaimsForUser(UserClaimFactory.DeriveClaimsFromRoles(customersOfUserDto.Roles).ToArray());

        foreach (var customer in customersOfUserDto.Customers)
        {
            var customerClaims = new List<UserClaim>();
            customerClaims.AddRange(UserClaimFactory.DeriveClaimsFromCustomerNumber(customer.CustomerNumber));
            customerClaims.AddRange(UserClaimFactory.DeriveClaimsFromOrderSystem(customer.OrderSystem));
            customerClaims.AddRange(UserClaimFactory.DeriveClaimsFromContactPortal(customer.ContactPortal));

            var bktBilling = bktBillingResult.BillingItems.FirstOrDefault(a => a.CustomerId == customer.CustomerNumber && a.BktIsActive);
            
            if (bktBilling is not null)
            {
                customerClaims.Add(UserClaimFactory.DeriveClaimFromBktBillings());
                customerClaims.Add(UserClaimFactory.DeriveClaimFromBktBillingTypes(bktBilling.BillingType));
            }
            
            result.SetClaimsForCustomer(customer.CustomerNumber, customerClaims);
        }

        return Task.FromResult(result);
    }
}