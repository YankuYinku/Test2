namespace apetito.meinapetito.Portal.Contracts.Root.Users.Permissions;

public class CustomerNumberWithPermissionsDto
{
    public string CustomerNumber { get; set; }
    public IList<PermissionDto> Permissions { get; set; }
}