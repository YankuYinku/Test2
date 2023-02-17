namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models.Filters;

public class FilterBlockDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string AdditionalName { get; set; } = string.Empty;
    public IList<FilterEntryDto> FilterEntries { get; set; } = new List<FilterEntryDto>();
}