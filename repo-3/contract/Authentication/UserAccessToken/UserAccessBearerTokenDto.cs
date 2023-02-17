namespace apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;

public class UserAccessBearerTokenDto
{
    public UserAccessBearerTokenDto()
    {
        Token = string.Empty;
    }

    public string Token { get; set; }
}