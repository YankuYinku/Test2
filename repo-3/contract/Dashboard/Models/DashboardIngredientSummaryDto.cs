namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardIngredientSummaryDto
    {
        public string? IngredientText { get; set; }

        public string? AllergenText { get; set; }

        public string? TraceText { get; set; }
        public IList<DashboardIngredientExtraInformationDto>? IngredientExtraInfos { get; set; }
        public IList<DashboardComponentDto>? Components { get; set; }
    }
}