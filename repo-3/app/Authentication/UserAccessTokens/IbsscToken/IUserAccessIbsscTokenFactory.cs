using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.IbsscToken;

public interface IUserAccessIbsscTokenFactory
{
    UserAccessIbsscTokenDto Create();
    IUserAccessIbsscTokenFactory WithEmail(string email);
}