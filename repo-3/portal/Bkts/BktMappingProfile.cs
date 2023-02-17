using apetito.BKT.Contracts.Models;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Bkts;

public class BktMappingProfile : Profile
{
    public BktMappingProfile()
    {
        CreateMap<ContractAccount, BktAccountItem>()
            .ForMember(dest => dest.CustomerId,
                opts => opts.MapFrom(opt => opt.Id));
        CreateMap<ToleranceDeviationResult, BktToleranceDeviationResult>();
        CreateMap<MaterialAmountDeviation, BktMaterialAmountDeviationResult>();
    }
}