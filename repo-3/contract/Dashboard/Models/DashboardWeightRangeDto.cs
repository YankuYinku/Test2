namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardWeightRangeDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? Abbreviation { get; set; }

        public string? Prefix { get; set; }

        public decimal LowerBound { get; set; }

        public decimal UpperBound { get; set; }

        public DashboardUnitDto? Unit { get; set; }
    }
}