namespace apetito.meinapetito.Portal.Contracts.Root.Users.Claims;

public class UserAndCustomerClaimsDto
{
    public List<UserClaim> UserClaims { get; private set;} = new List<UserClaim>();
    public IDictionary<int, List<UserClaim>> CustomerClaims { get; } = new Dictionary<int, List<UserClaim>>();
    public bool ContainsCustomerSpecificClaims => CustomerClaims.Any();

    public UserAndCustomerClaimsDto()
    {
        
    }

    public UserAndCustomerClaimsDto(IDictionary<int,List<UserClaim>> customerClaims)
    {
        CustomerClaims = customerClaims;
        UserClaims = CustomerClaims.SelectMany(c => c.Value).Distinct().ToList();
    }

    public UserAndCustomerClaimsDto(List<UserClaim> claims)
    {
        UserClaims = claims;
        CustomerClaims = new Dictionary<int, List<UserClaim>>();
    }

    public void AddClaimsForUser(params UserClaim[] claims)
    {
        UserClaims.AddRange(claims);
        UserClaims = UserClaims.Distinct().ToList();
    }

    public void SetClaimsForCustomer(int customerNumber, List<UserClaim> customerClaims)
    {
        if (!CustomerClaims.ContainsKey(customerNumber))
        {
            CustomerClaims.Add(customerNumber, customerClaims.Distinct().ToList());
        }
        else
        {
            CustomerClaims[customerNumber] = customerClaims.Distinct().ToList();
        }
    }
}