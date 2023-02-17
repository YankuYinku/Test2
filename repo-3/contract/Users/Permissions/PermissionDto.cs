namespace apetito.meinapetito.Portal.Contracts.Root.Users.Permissions;

public class PermissionDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is PermissionDto permissionDto)
        {
            return permissionDto.Name == Name;
        }
        return false;
    }
}