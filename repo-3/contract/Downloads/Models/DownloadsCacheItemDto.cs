namespace apetito.meinapetito.Portal.Contracts.Downloads.Models;

public class DownloadsCacheItemDto
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string FullTextSearch { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Type { get; set; }
    public DownloadFileDto? File { get; set; }
    public DownloadFilePreviewDto? FilePreview { get; set; }
    public IList<DownloadFileCategoryDto> Categories { get; set; } = new List<DownloadFileCategoryDto>();
    public IList<string?> Areas { get; set; } = new List<string?>();
    public IList<DownloadFileSortimentDto?>? Sortiments { get; set; } = new List<DownloadFileSortimentDto?>();
    public IList<string?> Keywords { get; set; } = new List<string?>();
    public IList<string?> OrderSystems { get; set; }= new List<string?>();
    public IList<decimal?> CustomerNumbers { get; set; } = new List<decimal?>();
    public decimal? MaterialNumber { get; set; } = null;
}