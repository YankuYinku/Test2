namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogContentWeightSalesUnitDto
    {
        public int? NumberOfSubpackagingUnits { get; set; }

        public ProductCatalogUnitDto? SubpackagingUnit { get; set; }

        public string? Prefix { get; set; }
    }
}