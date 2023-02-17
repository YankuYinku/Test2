namespace apetito.meinapetito.Portal.Contracts.Root.Users.AssignedUsers;

public class CustomerNumberDetails
{
    public string LanguageCode { get; set; }
    public string OrderSystem { get; set; }
    public string Role { get; set; }
    public IList<string> Sortiments { get; set; }
}