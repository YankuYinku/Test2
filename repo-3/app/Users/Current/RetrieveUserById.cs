using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.AssignedUsers;
using apetito.meinapetito.Portal.Contracts.Root.Users.Current;

namespace apetito.meinapetito.Portal.Application.Root.Users.Current;

public class RetrieveUserById : IQuery<IList<CustomerDto>>
{
    public Guid Id { get; set; }
}