namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models.Availability;

public class AvailabilityCheckResultDto
{
    public IList<ArticleWithAllowedQuantityDto> Available { get; set; }
    public IList<ArticleWithAllowedQuantityDto> NotAvailable { get; set; }
}