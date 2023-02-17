namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public record GetProductsGraphQlQueryModel
    {
        public string? LanguageCode { get; set; }
        public string? SortimentType { get; set; }
        public bool? GetArticleInLastValidSortiment { get; init; }
        public bool? OutletArticleWithoutStock { get; init; }
        public bool? Distinct { get; init; }
        public IList<string>? Sortiments { get; init; }
        public int? Page { get; init; }
        public int? PageSize { get; init; }
        public string? Filter { get; init; }
        public int? CustomerNumber { get; init; }
        public string? Search { get; init; }
        public IList<string>? ArticleIds { get; init; }
        public IList<string>? Ids { get; init; }
        public IList<string>? Acs { get; init; }
        public IList<string>? Categories { get; init; }
        public IList<string>? FoodForms { get; init; }
        public IList<string>? Diets { get; init; }
        public IList<string>? Allergens { get; init; }
        public IList<string>? Additives { get; init; }
        public IList<string>? Seals { get; init; }
        public IList<string>? Expand { get; init; }
        public IList<string>? PriceGroups { get; init; }
        public IList<string>? SourceApis { get; init; }
    }
}