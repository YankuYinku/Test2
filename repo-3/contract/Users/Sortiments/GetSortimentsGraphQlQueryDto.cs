namespace apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;

public record GetSortimentsGraphQlQueryDto
{
    public GetSortimentsGraphQlQueryDto()
    {
        UserEmail = string.Empty;
        CustomerNumbers = new List<int>();
    }

    public string UserEmail { get; set; }
    public ICollection<int>? CustomerNumbers { get; set; }
}