namespace apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;

public class SortimentsCodesDto
{
    public SortimentsCodesDto()
    {
        Items = new List<string>();
    }

    public List<string> Items { get; set; }
}