namespace apetito.meinapetito.Portal.Contracts.Root.Users.AssignedUsers;

public class ChangeUserRoleRequest
{
    public Guid UserId { get; set; }
    public string Role { get; set; }
    public int CustomerNumber { get; set; }
}