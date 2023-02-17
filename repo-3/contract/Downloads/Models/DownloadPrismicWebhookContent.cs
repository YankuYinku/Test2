namespace apetito.meinapetito.Portal.Contracts.Downloads.Models;

public class DownloadPrismicWebhookContent
{
    public string? ApiUrl { get; set; }
    public string? Domain { get; set; }
    public string? Secret { get; set; }
    public string? Type { get; set; }
    public IList<string>? Documents { get; set; }
}