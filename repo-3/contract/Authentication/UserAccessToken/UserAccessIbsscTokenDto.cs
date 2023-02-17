namespace apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;

public class UserAccessIbsscTokenDto
{
    public UserAccessIbsscTokenDto()
    {
        Token = string.Empty;
    }

    public string Token { get; set; }
}