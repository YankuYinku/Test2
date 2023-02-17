namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardNutrientDto
    {
        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? Abbreviation { get; set; }

        public decimal Per100Grams { get; set; }

        public decimal PerPortion { get; set; }

        public decimal PortionSizeInGrams{ get; set; }
        
        public DashboardUnitDto? Unit { get; set; }

    }
}