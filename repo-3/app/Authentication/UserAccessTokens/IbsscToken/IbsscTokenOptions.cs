namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.IbsscToken
{
    public class IbsscTokenOptions
    {
        public IbsscTokenOptions()
        {
            Secret = string.Empty;
        }
        public string Secret { get; set; }
    }
}