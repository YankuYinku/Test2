namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models.Availability;

public class ArticleWithQuantityDto
{
    public string ArticleNumber { get; set; } = string.Empty;
    public int Quantity { get; set; }
}