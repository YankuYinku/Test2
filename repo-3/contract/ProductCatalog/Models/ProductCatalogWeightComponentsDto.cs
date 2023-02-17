namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogWeightComponentsDto
    {
        public ProductCatalogWeightInUnitDto? NetWeightAfterLoss { get; set; }
        public ProductCatalogWeightComponentListSalesUnitDto? WeightsPerSaleseUnit { get; set; }
        public IList<ProductCatalogWeightComponentDto>? WeightsPerSingleUnit { get; set; }
        public IList<ProductCatalogWeightRangeDto>? WeightRanges { get; set; }
    }
}