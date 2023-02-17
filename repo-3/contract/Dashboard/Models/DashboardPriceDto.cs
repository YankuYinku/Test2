namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardPriceDto
    {
        public string? PriceGroupCode { get; set; }

        public decimal SalesPrice { get; set; }

        public string? CurrencyCode { get; set; }

        public int PerQuantity { get; set; }

        public DashboardUnitDto? UnitOfMeasurement { get; set; }

        public DateTimeOffset ValidFrom { get; set; }
    }
}