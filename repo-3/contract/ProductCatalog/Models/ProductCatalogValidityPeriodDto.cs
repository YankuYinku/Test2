namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogValidityPeriodDto
    {
        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidUntil { get; set; }

        public DateTimeOffset? VisibleFrom { get; set; }
    }
}