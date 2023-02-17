namespace apetito.meinapetito.Portal.Contracts.Root.Users.AssignedUsers;

public class EditUserRequest
{
    public Guid UserId { get; set; }

    public IList<CustomerNumberWithRoleRequest>? CustomerNumberRoleAssignments { get; set; } =
        new List<CustomerNumberWithRoleRequest>();
}