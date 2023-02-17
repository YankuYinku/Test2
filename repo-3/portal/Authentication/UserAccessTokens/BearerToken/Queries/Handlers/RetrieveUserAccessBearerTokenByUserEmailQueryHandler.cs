using System.Security.Claims;
using apetito.CQS;
using apetito.meinapetito.Portal.Application.Root.Users.Current.Customers.Queries;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;
using apetito.meinapetito.Portal.Contracts.Root.Users.Customers;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.BearerToken.Queries.Handlers;

public class RetrieveUserAccessBearerTokenByUserEmailQueryHandler : IQueryHandler<RetrieveUserAccessBearerTokenByUserEmailQuery, UserAccessBearerTokenDto>
{
    private const string ClaimTypeCustomerId = "customerId";
    private const string ClaimTypeLocale = "locale";
    
    private readonly ILogger<RetrieveUserAccessBearerTokenByCustomersOfUserQueryHandler> _logger;
    private readonly IQueryHandler<RetrieveCustomersOfUserQuery, CustomersOfUserDto> _customersOfUsersQuery;
    private readonly IQueryHandler<RetrieveUserAccessBearerTokenByCustomersOfUserQuery, UserAccessBearerTokenDto> _userAccessBearerTokenQuery;

    public RetrieveUserAccessBearerTokenByUserEmailQueryHandler(
        ILogger<RetrieveUserAccessBearerTokenByCustomersOfUserQueryHandler> logger, 
        IQueryHandler<RetrieveCustomersOfUserQuery, CustomersOfUserDto> customersOfUsersQuery,
        IQueryHandler<RetrieveUserAccessBearerTokenByCustomersOfUserQuery, UserAccessBearerTokenDto> userAccessBearerTokenQuery) 
    {
        _logger = logger;
        _customersOfUsersQuery = customersOfUsersQuery;
        _userAccessBearerTokenQuery = userAccessBearerTokenQuery;
    }
    
    public async Task<UserAccessBearerTokenDto> Execute(RetrieveUserAccessBearerTokenByUserEmailQuery query)
    {
        var customersOfUsers = await _customersOfUsersQuery.Execute(new RetrieveCustomersOfUserQuery()
        {
            UserEmail = query.UserEmail
        });

        return await _userAccessBearerTokenQuery.Execute(
            new RetrieveUserAccessBearerTokenByCustomersOfUserQuery(customersOfUsers));
    }

}