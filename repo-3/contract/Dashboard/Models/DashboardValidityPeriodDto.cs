namespace apetito.meinapetito.Portal.Contracts.Dashboard.Models
{
    public class DashboardValidityPeriodDto
    {
        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidUntil { get; set; }

        public DateTimeOffset? VisibleFrom { get; set; }
    }
}