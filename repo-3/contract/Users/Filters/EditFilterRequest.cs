namespace apetito.meinapetito.Portal.Contracts.Root.Users.Filters;

public class EditFilterRequest
{
    public Guid FilterId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}