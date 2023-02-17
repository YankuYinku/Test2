using apetito.meinapetito.Portal.Contracts.Root.Users.Permissions;
using apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;

namespace apetito.meinapetito.Portal.Contracts.Root.Users.Current;

public class AllCustomersDto
{
    public IEnumerable<string> OrderSystems { get; set; } = new List<string>();
    public IEnumerable<string> EffectiveOrderSystems { get; set; } = new List<string>();
    public IEnumerable<string> LanguageCodes { get; set; } = new List<string>();

    public IEnumerable<string>  ContactPortals { get; set; } = new List<string>();
    public IEnumerable<int>  AdministratedCustomerNumbers { get; set; } = new List<int>();
    
    public IEnumerable<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();

    public IEnumerable<SortimentDto> Sortiments { get; set; } = new List<SortimentDto>();
}