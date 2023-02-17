namespace apetito.meinapetito.Portal.Data.Root.MainCustomerAdmins.PortalUsers;

public class PortalUserData
{
    public Guid PortalUserId { get; set; }
    public string IconUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }
    public string AzureADB2CUserId { get; set; }
}