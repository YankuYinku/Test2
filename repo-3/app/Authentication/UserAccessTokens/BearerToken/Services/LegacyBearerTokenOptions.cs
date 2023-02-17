namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.BearerToken.Services
{
    public class LegacyBearerTokenOptions
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }
}
