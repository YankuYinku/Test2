namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models.Filters;

public class FilterEntryDto
{
    public string FilterType { get; set; } = string.Empty;
    public int FilterTypeCode { get; set; } 
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}