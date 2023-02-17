namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogSortimentAssignmentDto
    {
        public ProductCatalogSortimentDto? Sortiment { get; set; }
        public ProductCatalogValidityPeriodDto? Validity { get; set; }
        public ProductCatalogSortimentEvecatcherDto? Eyecacher { get; set; }
        public ProductCatalogSuggestedPortionDto? SuggestedPortion { get; set; }
        public ProductCatalogPromotionalCodeDto? PromotionalCode { get; set; }
        public ProductCatalogOutletArticleTypeDto? OutletArticleType { get; set; }
        public int? ChargableQuantity { get; set; }
    }
}