using apetito.meinapetito.Portal.Contracts.ProductCatalog.Consts;

namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public record GetProductsRequestModel
    {
        public int Page { get; init; } = DefaultParameterValues.DefaultPage;
        public int PageSize { get; init; } = DefaultParameterValues.DefaultPageSize;
        public string? Search { get; init; }
        public string? Filter { get; init; }
        public int? CustomerNumber { get; init; }
        public IList<string> Categories { get; init; } = new List<string>();
        public bool? GetArticleInLastValidSortiment { get; init; }
        public bool? OutletArticleWithoutStock { get; init; }
        public bool? Distinct { get; init; }
        public IList<string> Sortiments { get; init; }= new List<string>();
        
        public List<string?> ArticleIds { get; init; }= new();
        public IList<string> Ids { get; init; }= new List<string>();
        public IList<string> Acs { get; init; }= new List<string>();
        public IList<string> FoodForms { get; init; }= new List<string>();
        public IList<string> Diets { get; init; }= new List<string>();
        public IList<string> Allergens { get; init; }= new List<string>();
        public IList<string> Additives { get; init; }= new List<string>();
        public IList<string> Seals { get; init; }= new List<string>();
        public IList<string> Expand { get; init; }= new List<string>();
        public IList<string> PriceGroups { get; init; }= new List<string>();
        public IList<string> SourceApis { get; init; } = new List<string>();
    }
}