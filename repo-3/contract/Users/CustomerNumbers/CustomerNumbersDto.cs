namespace apetito.meinapetito.Portal.Contracts.Root.Users.CustomerNumbers;

public class CustomerNumbersDto
{
    public CustomerNumbersDto()
    {
        Items = new List<int>();
    }

    public List<int> Items { get; set; }
}