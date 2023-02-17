namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardWeightComponentsDto
    {
        public DashboardWeightInUnitDto? NetWeightAfterLoss { get; set; }
        public DashboardWeightComponentListSalesUnitDto? WeightsPerSaleseUnit { get; set; }
        public IList<DashboardWeightComponentDto>? WeightsPerSingleUnit { get; set; }
        public IList<DashboardWeightRangeDto>? WeightRanges { get; set; }
    }
}