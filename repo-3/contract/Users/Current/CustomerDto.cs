using apetito.meinapetito.Portal.Contracts.Root.Users.Customers;
using apetito.meinapetito.Portal.Contracts.Root.Users.Permissions;
using apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;

namespace apetito.meinapetito.Portal.Contracts.Root.Users.Current;

public class CustomerDto
{
    public int CustomerNumber { get; set; }
    public string OrderSystem { get; set; } = string.Empty;
    public IList<string> EffectiveOrderSystems { get; set; } = new List<string>();
    public string LanguageCode { get; set; } = string.Empty;
    public string ContactPortal { get; set; } = string.Empty;
    public string Role { get; set; }
    public List<SortimentDto> Sortiments { get; set; } = new List<SortimentDto>();
    public IList<PermissionDto>  Permissions { get; set; } = new List<PermissionDto>();
    
    public List<string> AdditionalRoles { get; set; } = new List<string>();
}