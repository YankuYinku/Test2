using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.IbsscToken.Queries;

public class RetrieveUserAccessIbsscTokenByUserEmailQuery : IQuery<UserAccessIbsscTokenDto>
{
    public string UserEmail { get; set; } = string.Empty;
}