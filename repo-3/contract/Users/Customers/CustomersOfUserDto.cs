namespace apetito.meinapetito.Portal.Contracts.Root.Users.Customers;
public class CustomersOfUserDto
{

    public CustomersOfUserDto() : this(string.Empty)
    {
        
    }

    public CustomersOfUserDto(string userEmail)
    {
        UserEmail = userEmail;
        Customers = new List<CustomerDto>();
        Roles = new List<string>();
    }
    
    public string UserEmail { get; set; }

    public IEnumerable<CustomerDto> Customers { get; set; }

    public IEnumerable<string> Roles { get; set; }

}