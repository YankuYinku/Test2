namespace apetito.meinapetito.Portal.Contracts.Root.Users.AssignedUsers;

public class InviteUserRequest
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string LanguageCode { get; set; }
    public IList<CustomerNumberWithRoleRequest> CustomerNumberRoleAssignments { get; set; }
}