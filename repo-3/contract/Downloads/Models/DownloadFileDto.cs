namespace apetito.meinapetito.Portal.Contracts.Downloads.Models;

public class DownloadFileDto
{
    public string? Url { get; set; }
    public long Size { get; set; }
    public string? SizeValue { get; set; }
    public string? Type { get; set; }
    public string? TypeDescription { get; set; }
    public string? DisplayName { get; set; }
}