namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public record GetCatalogProductDetailsRequestModel
    {
        public string? ArticleId { get; }

        public GetCatalogProductDetailsRequestModel(string? articleId)
        {
            ArticleId = articleId;
        }
    }
}