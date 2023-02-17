namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogWeightInUnitDto
    {
        public decimal? Weight { get; set; }

        public ProductCatalogUnitDto? Unit { get; set; }
    }
}