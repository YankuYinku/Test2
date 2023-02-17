namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogPriceDto
    {
        public string? PriceGroupCode { get; set; }

        public decimal SalesPrice { get; set; }

        public string? CurrencyCode { get; set; }

        public int PerQuantity { get; set; }

        public ProductCatalogUnitDto? UnitOfMeasurement { get; set; }

        public DateTimeOffset ValidFrom { get; set; }
    }
}