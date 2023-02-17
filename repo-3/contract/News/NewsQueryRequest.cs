namespace apetito.meinapetito.Portal.Contracts.News;

public class NewsQueryRequest
{
    public IList<int>? CustomerNumbers { get; set; } = new List<int>();
    public string? Category { get; set; }
    public IList<string>? Sortiments { get; set; } = new List<string>();
    public IList<string>? Keywords { get; set; } = new List<string>();
    public IList<string>? Areas { get; set; } = new List<string>();
    public IList<string>? OrderSystems { get; set; } = new List<string>();
    public string? SortOrder { get; set; } = string.Empty;
    public string LanguageCode { get; set; } = string.Empty;
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }
}