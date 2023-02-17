using apetito.iProDa3.Contracts.Model;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Root.Users.Current.Sortiments.MappingProfiles;

public class SortimentsMappingProfile : Profile
{
    public SortimentsMappingProfile()
    {
        CreateMap<apetito.Customers.Contracts.CustomersOfUser.Models.SortimentDto, apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments.SortimentDto>();

        CreateMap<SortimentResponse, Contracts.Root.Users.Sortiments.SortimentDto>()
            .ForMember(a => a.Code, opts => opts.MapFrom(a => a.Code))
            .ForMember(a => a.Description, opts => opts.MapFrom(a => a.Beschreibung))
            .ForMember(a => a.Program, opts => opts.MapFrom(a => a.Programm))
            .ForMember(a => a.Type, opts => opts.MapFrom(a => a.Sortimentsart.ToString()));
        
    }
}