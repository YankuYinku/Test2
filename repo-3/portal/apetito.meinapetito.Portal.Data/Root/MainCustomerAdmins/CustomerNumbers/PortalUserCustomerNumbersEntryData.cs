namespace apetito.meinapetito.Portal.Data.Root.MainCustomerAdmins.CustomerNumbers;

public class PortalUserCustomerNumbersEntryData
{
    public Guid PortalUserCustomerNumbersId { get; set; }
    public Guid PortalUserCustomerNumbersEntryId { get; set; }
    public Guid PortalUserReferenceId { get; set; }
    public int CustomerNumber { get; set; }
    public string Role { get; set; }
    public string LanguageCode { get; set; }
    public string OrderSystem { get; set; }

}