namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardComponentDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public bool Declare { get; set; }

        public decimal QuantityInPercent { get; set; }

        public string? GroupPrefix { get; set; }

        public string? CountryOfOrigin { get; set; }
    }
}