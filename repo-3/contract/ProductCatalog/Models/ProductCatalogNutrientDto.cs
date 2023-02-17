namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogNutrientDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? Abbreviation { get; set; }

        public decimal Per100Grams { get; set; }

        public decimal PerPortion { get; set; }

        public decimal PortionSizeInGrams{ get; set; }
        
        public ProductCatalogUnitDto? Unit { get; set; }

    }
}