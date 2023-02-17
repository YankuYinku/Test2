namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardWeightComponentDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public decimal? Weight { get; set; }

        public DashboardUnitDto? Unit { get; set; }
    }
}