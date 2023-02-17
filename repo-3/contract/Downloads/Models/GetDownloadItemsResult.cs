namespace apetito.meinapetito.Portal.Contracts.Downloads.Models;

public class GetDownloadItemsResult
{
    public IList<DownloadsCacheItemDto> Items { get; set; }
    public int PageSize { get; set; }
    public int OverallItems { get; set; }
    public int OverallPages { get; set; }
    public IList<DownloadCategoriesWithCountDto> CategoriesSummarization { get; set; }
}