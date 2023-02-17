using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;
using apetito.meinapetito.Portal.Contracts.Root.Users.Permissions;
using apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;

namespace apetito.meinapetito.Portal.Contracts.Root.Users.Current;

public class UserDto
{
    private IList<PermissionDto> _allPermissions;

    public UserDto(string userEmail, IEnumerable<CustomerDto> customersOfUser)
    {
        UserEmail = userEmail;
        Customers = customersOfUser.ToList();
        All = new ();
        LegacyBearerToken = new ();
        IbsscToken = new();
    }

    public string UserEmail { get; set; }

    public UserAccessBearerTokenDto LegacyBearerToken { get; set; }

    public UserAccessIbsscTokenDto IbsscToken { get; set; }
    
    public AllCustomersDto All { get; set; }

    public IList<CustomerDto> Customers { get; set; }
    
    public void SetPermissions(PermissionsSetDto permissions)
    {
        _allPermissions = permissions.AllPermissions;
        
        var customerPermissions = permissions.CustomerNumberWithPermissions.ToDictionary(c => c.CustomerNumber);
        foreach (var item in Customers)
        {
            item.Permissions = customerPermissions[item.CustomerNumber.ToString()].Permissions;
        }
    }

    public void Summarize()
    {
        All = new AllCustomersDto();

        All.AdministratedCustomerNumbers = Customers.Where(a => a.Role == "Administrator")
            .Select(a => a.CustomerNumber).Distinct();
        All.ContactPortals = Customers.Select(c => c.ContactPortal).Distinct();
        All.LanguageCodes = Customers.Select(c => c.LanguageCode).Distinct();
        All.OrderSystems = Customers.Select(c => c.OrderSystem).Distinct();
        All.EffectiveOrderSystems = Customers.SelectMany(c => c.EffectiveOrderSystems).Distinct();
        All.Sortiments = Customers.SelectMany(c => c.Sortiments).DistinctBy(a=> a.Code);
        All.Permissions = _allPermissions;
    }

    public List<string> SortimentCodes() => Customers.SelectMany(c => c.Sortiments).Select(s => s.Code).Distinct().ToList();
   

    public void EnrichSortiments(IEnumerable<SortimentDto> sortiments)
    {    
        var sortimentsDictionary = sortiments.ToDictionary(a => a.Code);

        foreach (var sortiment in All.Sortiments)
        {
            var hasEnrichment = sortimentsDictionary.TryGetValue(sortiment.Code, out var filledSortiment);
            if (hasEnrichment)
                sortiment.Enrich(filledSortiment);
        }
        foreach (var customer in Customers)
        {
            foreach (var sortiment in customer.Sortiments)
            {
                var hasEnrichment = sortimentsDictionary.TryGetValue(sortiment.Code, out var filledSortiment);
                if (hasEnrichment)
                    sortiment.Enrich(filledSortiment);
            }
        }
    }
}