namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models;

public class ProductCatalogSuggestedPortionDto
{
    public ProductCatalogUnitDto? Unit { get; set; }
    public int? Size { get; set; }
    public decimal? PricePerPortion { get; set; }
    public decimal? PortionsPerSalesUnit { get; set; }
}