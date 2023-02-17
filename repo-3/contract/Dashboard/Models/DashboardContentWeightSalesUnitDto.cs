namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardContentWeightSalesUnitDto
    {
        public int? NumberOfSubpackagingUnits { get; set; }

        public DashboardUnitDto? SubpackagingUnit { get; set; }

        public string? Prefix { get; set; }
    }
}