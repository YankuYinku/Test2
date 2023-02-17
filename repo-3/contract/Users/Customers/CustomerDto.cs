using apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;

namespace apetito.meinapetito.Portal.Contracts.Root.Users.Customers;
public class CustomerDto
{
    public int CustomerNumber { get; set; }
    public string Role { get; set; } = string.Empty;
    public string OrderSystem { get; set; } = string.Empty; 
    public IList<string> EffectiveOrderSystems { get; set; } = new List<string>();
    public string LanguageCode { get; set; } = string.Empty;
    public string ContactPortal { get; set; } = string.Empty;
    public List<SortimentDto> Sortiments { get; set; } = new List<SortimentDto>();
    public List<string> AdditionalRoles { get; set; } = new List<string>();
}