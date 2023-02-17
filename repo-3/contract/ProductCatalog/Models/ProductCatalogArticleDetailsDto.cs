namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogArticleDetailsDto
    {
        public IList<ProductCatalogAdditiveDto>? Additives { get; set; }
        public IList<ProductCatalogAllergenDto>? Allergens { get; set; }
        public IList<ProductCatalogDietDto>? Diets { get; set; }
        public ProductCatalogIngredientSummaryDto? Ingredients { get; set; }
        public IList<ProductCatalogNutrientDto>? Nutrients { get; set; }
        public IList<ProductCatalogDesignationDto>? Designations { get; set; }
        public IList<ProductCatalogPreparationFeatureDto>? PreparationFeatures { get; set; }
        public IList<ProductCatalogPreparationInstructionDto>? PreparationInstructions { get; set; }
        public IList<ProductCatalogPriceClassDto>? PriceClasses { get; set; }
        public IList<ProductCatalogSealDto>? Seals { get; set; }
        public IList<ProductCatalogSortimentAssignmentDto>? Sortiments { get; set; }
        public ProductCatalogWeightComponentsDto? WeightComponents { get; set; }
        public IList<ProductCatalogPreparationInstructionDto>? Instructions { get; set; }
        public IList<ProductCatalogCategoryDto>? Categories { get; set; }
        public IList<ProductCatalogPriceDto>? Prices { get; set; }
        public ProductCatalogPriceDto? Price { get; set; }
        public string? NutriScorePhotoPath { get; set; }
        public NutriScorePhotoDto? NutriScorePhoto { get; set; }
        public ProductCatalogLogisticDto? Logistics { get; set; }
        public ProductCatalogTaxanomyDto? Taxanomy { get; set; }
    }
}