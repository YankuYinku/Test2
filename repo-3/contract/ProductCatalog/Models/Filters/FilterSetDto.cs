namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models.Filters;

public class FilterSetDto
{
    public IList<FilterBlockDto> FilterBlocks { get; set; } = new List<FilterBlockDto>();
}