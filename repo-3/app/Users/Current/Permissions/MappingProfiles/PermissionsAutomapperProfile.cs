using apetito.Authorization.Contracts.ClaimsPermissions;
using apetito.meinapetito.Portal.Contracts.Root.Users.Permissions;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Root.Users.Current.Permissions.MappingProfiles;

public class PermissionsAutomapperProfile : Profile
{
    public PermissionsAutomapperProfile()
    {
        CreateMap<ClaimPermissionDto, PermissionDto>();
    }
}