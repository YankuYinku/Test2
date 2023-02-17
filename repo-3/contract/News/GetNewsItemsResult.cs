namespace apetito.meinapetito.Portal.Contracts.News;

public class GetNewsItemsResult
{
    public IList<NewsDto> Items { get; set; }
    public int PageSize { get; set; }
    public int OverallItems { get; set; }
    public int OverallItemsInAllCategories { get; set; }
    public int OverallPages { get; set; }
    public IList<NewsCategoriesWithCountDto> CategoriesSummarization { get; set; }
}