namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class GetProductListResultDto
    {
        public int OverallResults { get; init; }
        public int OverallItemsInAllCategories { get; init; }
        public int OverallPages { get; init; }
        public IEnumerable<ProductCatalogArticleDto>? Articles { get; init; }
        public IEnumerable<CategoriesWithCountDto>? CategoriesSummarization { get; init; }
    }
}