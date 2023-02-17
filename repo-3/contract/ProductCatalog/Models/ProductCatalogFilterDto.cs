namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogFilterDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public GetProductsGraphQlQueryDto? Request { get; init; }
    }
}