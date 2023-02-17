namespace apetito.meinapetito.Portal.Contracts.News;

public class NewsDto
{
    public string? Id { get; set; }
    public string? Headline { get; set; }
    public string? Teaser { get; set; }
    public NewsImageDto? Image { get; set; }
    public string FullTextSearch { get; set; } = string.Empty;
    public string? DetailsTitle { get; set; }
    public string? DetailsBody { get; set; }
    public string? DetailsImage { get; set; }
    public string? PublishedAt { get; set; }
    public IList<NewsCategoryDto> Categories { get; set; } = new List<NewsCategoryDto>();
    public IList<string?> Areas { get; set; } = new List<string?>();
    public IList<NewsSortimentDto?>? Sortiments { get; set; } = new List<NewsSortimentDto?>();
    public IList<string?> Keywords { get; set; } = new List<string?>();
    public IList<string?> OrderSystems { get; set; }= new List<string?>();
    public IList<decimal?> CustomerNumbers { get; set; } = new List<decimal?>();
   
}