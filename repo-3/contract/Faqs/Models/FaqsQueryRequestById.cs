namespace apetito.meinapetito.Portal.Contracts.Faqs.Models;

public class FaqsQueryRequestById
{
    public string? Search { get; set; }
    public IList<string>? SaleChannels { get; set; }
    public IList<string>? OrderSystems { get; set; }
    public IList<string>? Sortiments { get; set; }
    public string Id { get; set; }
}