namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogWeightRangeDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? Abbreviation { get; set; }

        public string? Prefix { get; set; }

        public decimal LowerBound { get; set; }

        public decimal UpperBound { get; set; }

        public ProductCatalogUnitDto? Unit { get; set; }
    }
}