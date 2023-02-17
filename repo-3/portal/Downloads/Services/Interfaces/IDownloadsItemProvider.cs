using apetito.meinapetito.Portal.Contracts.Downloads.Models;

namespace apetito.meinapetito.Portal.Application.Downloads.Services.Interfaces;

public interface IDownloadsItemProvider
{
    Task<GetDownloadItemsResult> GetItemsAsync(DownloadsQuery request);
    Task<IList<DownloadFileCategoryDto>> GetCategoriesAsync(string languageCode);
}