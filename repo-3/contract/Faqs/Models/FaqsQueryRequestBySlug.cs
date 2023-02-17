namespace apetito.meinapetito.Portal.Contracts.Faqs.Models;

public class FaqsQueryRequestBySlug
{
    public string? Search { get; set; }
    public IList<string>? SaleChannels { get; set; }
    public IList<string>? OrderSystems { get; set; }
    public IList<string>? Sortiments { get; set; }
    public string Slug { get; set; }
}