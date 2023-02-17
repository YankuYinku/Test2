namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public record ProductCatalogImageDto
    {
        public string? Small { get; set; }
        public string? Big { get; set; }
        public string? Middle { get; set; }
    }
}