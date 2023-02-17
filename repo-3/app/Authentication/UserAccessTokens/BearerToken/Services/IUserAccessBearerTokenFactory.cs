using System.Security.Claims;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.BearerToken.Services;

public interface IUserAccessBearerTokenFactory
{
    UserAccessBearerTokenDto Create();
    
    IUserAccessBearerTokenFactory WithClaims(IEnumerable<Claim> claims);

    IUserAccessBearerTokenFactory WithClaim(Claim claim);

    IUserAccessBearerTokenFactory WithDurationInMinutes(int minutes);
    
    IUserAccessBearerTokenFactory WithAudience(string audience);
}