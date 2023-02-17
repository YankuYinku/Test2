namespace apetito.meinapetito.Portal.Contracts.Root.Users.Permissions;

public class PermissionsSetDto
{
    public IList<PermissionDto> UserPermissions { get; }
    public IList<CustomerNumberWithPermissionsDto> CustomerNumberWithPermissions { get; }
    public IList<PermissionDto> AllPermissions { get; }

    public PermissionsSetDto(IList<PermissionDto> userPermissions, IDictionary<string, IList<PermissionDto>> permissionDtos)
    {
        CustomerNumberWithPermissions = permissionDtos.Select(a => new CustomerNumberWithPermissionsDto
        {
            CustomerNumber = a.Key,
            Permissions = a.Value
        }).ToList();

        UserPermissions = userPermissions;

        AllPermissions = UserPermissions.Union(CustomerNumberWithPermissions.SelectMany(a => a.Permissions)).Distinct().ToList();
    }
}