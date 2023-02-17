using apetito.meinapetito.Portal.Application.Root.Users.Claims;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Root.Users.Current;

public class CurrentUserMappingProfile : Profile
{
    public CurrentUserMappingProfile()
    {
        CreateMap<Contracts.Root.Users.Customers.CustomerDto, Contracts.Root.Users.Current.CustomerDto>()
            .ForMember(a => a.Role, opts =>
                opts.MapFrom(z =>
                    UserClaimFactory.GetPortalUserRoleBasedOnContactPortal(z.ContactPortal)));
    }
}
