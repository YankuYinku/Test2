using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.BearerToken.Queries;

public class RetrieveUserAccessBearerTokenByUserEmailQuery : IQuery<UserAccessBearerTokenDto>
{
    public string UserEmail { get; set; } = string.Empty;
}