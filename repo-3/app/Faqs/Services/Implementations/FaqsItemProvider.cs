using apetito.meinapetito.Cache.Faqs.Contracts.Faqs.ApiClients;
using apetito.meinapetito.Cache.Faqs.Contracts.Faqs.Models;
using apetito.meinapetito.Portal.Application.Faqs.Services.Interfaces;
using apetito.meinapetito.Portal.Contracts.Faqs.Models;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Faqs.Services.Implementations;

public class FaqsItemProvider : IFaqsItemProvider
{
    private readonly IFaqsCacheApiClient _faqsCacheApiClient;
    private readonly IMapper _mapper;

    public FaqsItemProvider(IFaqsCacheApiClient faqsCacheApiClient, IMapper mapper)
    {
        _faqsCacheApiClient = faqsCacheApiClient;
        _mapper = mapper;
    }

    public async Task<GetFaqsItemsResult> GetAsync(FaqsQuery query)
    {
        GetFaqsCacheItemsResult result = await _faqsCacheApiClient.GetFaqsGroupsAsync(new FaqsCacheQueryRequest
        {
            LanguageCode = query.LanguageCode,
            Sortiments = query.Sortiments,
            OrderSystems = query.OrderSystems,
            DistributionChannels = query.SaleChannels
        });

        return _mapper.Map<GetFaqsItemsResult>(result);
    }

    public async Task<GetFaqsItemsResult> GetByIdAsync(string id, FaqsQuery query)
    {
        GetFaqsCacheItemsResult result = await _faqsCacheApiClient.GetFaqsGroupsByIdAsync(new FaqsCacheQueryByIdRequest()
        {
            Id = id,
            Sortiments = query.Sortiments,
            OrderSystems = query.OrderSystems,
            DistributionChannels = query.SaleChannels
        });

        return _mapper.Map<GetFaqsItemsResult>(result);
    }

    public async Task<GetFaqsItemsResult> GetBySlugAsync(string slug, FaqsQuery query)
    {
        GetFaqsCacheItemsResult result = await _faqsCacheApiClient.GetFaqsGroupsBySlugAsync(new FaqsCacheQueryBySlugRequest()
        {
            Slug = slug,
            Sortiments = query.Sortiments,
            OrderSystems = query.OrderSystems,
            DistributionChannels = query.SaleChannels
        });

        return _mapper.Map<GetFaqsItemsResult>(result);
    }
}