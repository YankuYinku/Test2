using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.Claims;
using apetito.meinapetito.Portal.Contracts.Root.Users.Permissions;

namespace apetito.meinapetito.Portal.Application.Root.Users.Current.Permissions.Queries;

public class RetrieveClaimsPermissionsQuery : IQuery<PermissionsSetDto>
{
    public string UserEmail { get; set; } = string.Empty;
    public UserAndCustomerClaimsDto ClaimsDto { get; set; } = new UserAndCustomerClaimsDto();
}