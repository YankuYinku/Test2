namespace apetito.meinapetito.Portal.Contracts.Root.Users.AssignedUsers;

public class AssignedUserDto
{
    public string? Id { get; set; }
    public string? Type { get; set; }
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ShortName { get; set; }
    public string? IconUrl { get; set; }
    public IList<CustomerNumberWithRoleDto> CustomerNumbers { get; set; }
    public string? Status { get; set; }
    public bool IsSap { get; set; }
}