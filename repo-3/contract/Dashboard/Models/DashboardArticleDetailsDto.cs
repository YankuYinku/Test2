namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardArticleDetailsDto
    {
        public IList<DashboardDesignationDto>? Designations { get; set; }
        public IList<DashboardSealDto>? Seals { get; set; }
        public IList<DashboardSortimentAssignmentDto>? Sortiments { get; set; }
        public DashboardWeightComponentsDto? WeightComponents { get; set; }
        public DashboardPriceDto? Price { get; set; }
        public decimal? OldPrice { get; set; }
    }
}