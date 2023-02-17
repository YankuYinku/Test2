namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardArticleDto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DashboardImageDto? Image { get; set; }
        public DashboardArticleDetailsDto? Details { get; set; }
    }
}