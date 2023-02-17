namespace apetito.meinapetito.Portal.Contracts.Faqs.Models;

public class FaqSimpleItem : FaqItemDto
{
    public string? Type { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public FaqImage? Image { get; set; }
}