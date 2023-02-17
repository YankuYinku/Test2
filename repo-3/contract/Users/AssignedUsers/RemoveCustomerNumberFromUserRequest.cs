namespace apetito.meinapetito.Portal.Contracts.Root.Users.AssignedUsers;

public class RemoveCustomerNumberFromUserRequest
{
    public Guid UserId { get; set; }
    public IList<int> CustomerNumbers { get; set; }
}