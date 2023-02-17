namespace apetito.meinapetito.Portal.Contracts.Downloads.Models;

public class DownloadsQuery
{
    public string Search { get; set; }
    public string? LanguageCode { get; set; } = "de-DE";
    public int Page { get; set; }
    public int PageSize { get; set; }
    public IList<string> Sortiments { get; set; }
    public IList<string> Categories { get; set; }
    public IList<string> CustomerNumbers { get; set; }
    public IList<string> Keywords { get; set; }
    public IList<string> Areas { get; set; }
    public IList<string> OrderSystems { get; set; }
}