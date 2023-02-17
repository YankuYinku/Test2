namespace apetito.meinapetito.Portal.Data.Root.MainCustomerAdmins.CustomerNumbers.Sortiments;

public class PortalUserCustomerNumberEntrySortimentData
{
    public Guid PortalUserCustomerNumbersEntryReferenceId { get; set; }
    public Guid PortalUserReferenceId { get; set; }
    public Guid PortalUserCustomerNumbersEntrySortimentId { get; set; }
    public virtual ICollection<PortalUserCustomerNumberEntrySortimentEntryData> Sortiments { get; set; }
}