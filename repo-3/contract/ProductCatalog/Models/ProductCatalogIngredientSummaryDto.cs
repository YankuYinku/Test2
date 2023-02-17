namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogIngredientSummaryDto
    {
        public string? IngredientText { get; set; }
        public string? IngredientContainsText { get; set; }
        public string? IngredientWithoutContainsText { get; set; }

        public string? AllergenText { get; set; }

        public string? TraceText { get; set; }
        public IList<ProductCatalogComponentDto>? Compontents { get; set; }
    }
}