using System.Net;
using apetito.meinapetito.Cache.Downloads.Contracts.Downloads.ApiClients;
using apetito.meinapetito.Cache.Downloads.Contracts.Downloads.Models;
using apetito.meinapetito.Portal.Application.Downloads.Services.Interfaces;
using apetito.meinapetito.Portal.Contracts.Downloads.Models;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Downloads.Services.Implementations;

public class DownloadsItemProvider : IDownloadsItemProvider
{
    private readonly IDownloadsCacheApiClient _downloadsCacheApiClient;
    private readonly IMapper _mapper;

    public DownloadsItemProvider(IDownloadsCacheApiClient downloadsCacheApiClient, IMapper mapper)
    {
        _downloadsCacheApiClient = downloadsCacheApiClient;
        _mapper = mapper;
    }

    public async Task<GetDownloadItemsResult> GetItemsAsync(DownloadsQuery request)
    {
        GetDownloadCacheItemsResult result = await _downloadsCacheApiClient.GetDownloadsAsync(
            new DownloadsCacheQueryRequest
            {
                DistributionChannels = request.Areas,
                Keywords = request.Keywords,
                Page = request.Page,
                Search = request.Search,
                Sortiments = request.Sortiments,
                CustomerNumbers = request.CustomerNumbers,
                Categories = request.Categories.Select(WebUtility.UrlEncode).ToList(),
                OrderSystems = request.OrderSystems,
                PageSize = request.PageSize,
                LanguageCode = request.LanguageCode
            });

        return _mapper.Map<GetDownloadItemsResult>(result);
    }

    public async Task<IList<DownloadFileCategoryDto>> GetCategoriesAsync(string languageCode)
    {
        IList<DownloadCacheFileCategoryDto> result = await _downloadsCacheApiClient.GetDownloadsCategoriesAsync(languageCode);

        return result.Select(a => _mapper.Map<DownloadFileCategoryDto>(a)).ToList();
    }
}