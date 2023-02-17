namespace apetito.meinapetito.Portal.Data.Root.MainCustomerAdmins.CustomerNumbers;

public class PortalUserCustomerNumbersData
{
    public Guid PortalUserCustomerNumbersId { get; set; }
    
    public Guid PortalUserReferenceId { get; set; }

    public virtual ICollection<PortalUserCustomerNumbersEntryData> CustomerNumbers { get; set; }
}