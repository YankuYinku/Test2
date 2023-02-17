namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogComponentDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public bool Declare { get; set; }

        public decimal QuantityInPercent { get; set; }

        public string? GroupPrefix { get; set; }

        public string? CountryOfOrigin { get; set; }
    }
}