namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogWeightComponentDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public decimal? Weight { get; set; }

        public ProductCatalogUnitDto? Unit { get; set; }
    }
}