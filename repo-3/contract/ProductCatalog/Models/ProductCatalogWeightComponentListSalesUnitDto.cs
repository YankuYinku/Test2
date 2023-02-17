namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogWeightComponentListSalesUnitDto
    {
        public IList<ProductCatalogWeightComponentDto>? WeightComponents { get; set; }
        public ProductCatalogContentWeightSalesUnitDto? Content { get; set; }

        public ProductCatalogWeightComponentDto? TotalWeight { get; set; }
    }
}