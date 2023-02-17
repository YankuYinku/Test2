namespace apetito.meinapetito.Portal.Contracts.Root.Users.OrderSystems;

public class RetrieveOrderSystemsGraphQlQueryDto
{
    public string UserEmail { get; set; } = string.Empty;
    public ICollection<int>? CustomerNumbers { get; set; } = new List<int>();
}