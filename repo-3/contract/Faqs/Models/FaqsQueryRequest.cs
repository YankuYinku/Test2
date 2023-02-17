namespace apetito.meinapetito.Portal.Contracts.Faqs.Models;

public class FaqsQueryRequest
{
    public string? Search { get; set; }
    public string? LanguageCode { get; set; } = "de-de";
    
    public IList<string>? SaleChannels { get; set; }
    public IList<string>? OrderSystems { get; set; }
    public IList<string>? Sortiments { get; set; }
}