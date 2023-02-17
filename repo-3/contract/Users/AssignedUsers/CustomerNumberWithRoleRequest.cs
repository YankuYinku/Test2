namespace apetito.meinapetito.Portal.Contracts.Root.Users.AssignedUsers;

public class CustomerNumberWithRoleRequest
{
    public string Role { get; set; }
    public int CustomerNumber { get; set; }
}