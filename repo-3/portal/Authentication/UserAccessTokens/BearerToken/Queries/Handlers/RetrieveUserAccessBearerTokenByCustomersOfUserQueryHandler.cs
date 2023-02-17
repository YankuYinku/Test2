using System.Diagnostics;
using System.Security.Claims;
using apetito.CQS;
using apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.BearerToken.Services;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;
using apetito.meinapetito.Portal.Contracts.Root.Users.Customers;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.BearerToken.Queries.Handlers;

public class RetrieveUserAccessBearerTokenByCustomersOfUserQueryHandler : IQueryHandler<RetrieveUserAccessBearerTokenByCustomersOfUserQuery, UserAccessBearerTokenDto>
{
    private const string ClaimTypeCustomerId = "customerId";
    private const string ClaimTypeLocale = "locale";
    
    private readonly ILogger<RetrieveUserAccessBearerTokenByCustomersOfUserQueryHandler> _logger;
    private readonly IUserAccessBearerTokenFactory _userAccessBearerTokenFactory;

    public RetrieveUserAccessBearerTokenByCustomersOfUserQueryHandler(ILogger<RetrieveUserAccessBearerTokenByCustomersOfUserQueryHandler> logger, IUserAccessBearerTokenFactory userAccessBearerTokenFactory)
    {
        _logger = logger;
        _userAccessBearerTokenFactory = userAccessBearerTokenFactory;
    }
    
    public Task<UserAccessBearerTokenDto> Execute(RetrieveUserAccessBearerTokenByCustomersOfUserQuery query)
    {
        var userData = query.Customers;
        
        try
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
         
            var token = _userAccessBearerTokenFactory
                .WithAudience("https://api.apetito.de")
                .WithClaim(CreateNameIdClaim(userData))
                .WithClaim(GetAndCreateLocaleClaim(userData))
                .WithClaims(GetAndCreateCustomerIdClaims(userData))
                .WithDurationInMinutes(1440)
                .Create();

            stopwatch.Stop();
            _logger.LogWarning("Exchange Bearer token takes {0} ms", stopwatch.ElapsedMilliseconds);
            
            return Task.FromResult(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetLegacyUserBearerToken {Message}", ex.Message);
            return Task.FromResult(new UserAccessBearerTokenDto());
        }
    }
    
    private static Claim CreateNameIdClaim(CustomersOfUserDto user) => new(ClaimTypes.NameIdentifier, user.UserEmail);

    private Claim GetAndCreateLocaleClaim(CustomersOfUserDto user)
    {
        _logger.LogDebug("Get locale for {@Email}", new {Email = user.UserEmail});
        return CreateClaim(ClaimTypeLocale, user.Customers.FirstOrDefault()?.LanguageCode ?? string.Empty);
    }

    private IEnumerable<Claim> GetAndCreateCustomerIdClaims(CustomersOfUserDto user)
    {
        _logger.LogDebug("Get customer numbers for {@Email}", new {Email = user.UserEmail});
        return user.Customers.Select(c => CreateClaim(ClaimTypeCustomerId, c.CustomerNumber.ToString()));
    }

    private static Claim CreateClaim(string claimType, string value)
    {
        return new Claim(claimType, value);
    }
}