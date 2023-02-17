namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models.Availability;

public class ArticleWithAllowedQuantityDto
{
    public string ArticleNumber { get; set; } = string.Empty;
    public decimal AllowedQuantity { get; set; }
}