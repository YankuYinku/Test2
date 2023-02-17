namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogArticleDto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Sortiments { get; set; }
        public string? Categories { get; set; }
        public ProductCatalogImageDto? Image { get; set; }
        public ProductCatalogImagePathsDto? ImagePaths { get; set; }
        public ProductCatalogArticleDetailsDto? Details { get; set; }
    }
}