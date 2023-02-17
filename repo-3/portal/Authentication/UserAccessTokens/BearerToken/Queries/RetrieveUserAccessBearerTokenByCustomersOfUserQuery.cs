using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;
using apetito.meinapetito.Portal.Contracts.Root.Users.Customers;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.BearerToken.Queries;

public class RetrieveUserAccessBearerTokenByCustomersOfUserQuery : IQuery<UserAccessBearerTokenDto>
{
    public RetrieveUserAccessBearerTokenByCustomersOfUserQuery(CustomersOfUserDto customers)
    {
        Customers = customers;
    }

    public CustomersOfUserDto Customers { get; }
}