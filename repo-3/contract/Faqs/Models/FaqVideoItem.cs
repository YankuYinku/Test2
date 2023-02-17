namespace apetito.meinapetito.Portal.Contracts.Faqs.Models;

public class FaqVideoItem : FaqItemDto
{
    public string? Type { get; set; }
    public string? Teaser { get; set; }
    public string? Fulltext { get; set; }
    public FaqVideo? Video { get; set; }
    public string? Length { get; set; }
}