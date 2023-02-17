namespace apetito.meinapetito.Portal.Contracts.Faqs.Models;

public class FaqGroupDto
{
    public string? Id { get; set; }
    public string? Slug { get; set; }
    public string? Title { get; set; }
    public string? Blob { get; set; }
    public string? ShortTitle { get; set; }
    public string? IntroText { get; set; }
    public IList<FaqDto>? Faqs { get; set; }
}