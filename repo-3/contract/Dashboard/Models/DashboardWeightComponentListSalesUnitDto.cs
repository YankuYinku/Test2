namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardWeightComponentListSalesUnitDto
    {
        public IList<DashboardWeightComponentDto>? WeightComponents { get; set; }
        public DashboardContentWeightSalesUnitDto? Content { get; set; }

        public DashboardWeightComponentDto? TotalWeight { get; set; }
    }
}