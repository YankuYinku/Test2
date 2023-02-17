namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogAmountInUnitDto
    {
        public decimal Amount { get; set; }

        public ProductCatalogUnitDto? Unit { get; set; }
    }
}