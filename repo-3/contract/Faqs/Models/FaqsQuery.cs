namespace apetito.meinapetito.Portal.Contracts.Faqs.Models;

public class FaqsQuery
{
    public string LanguageCode { get; set; } = "de-de";
    public IList<string> SaleChannels { get; set; } = new List<string>();
    public IList<string> OrderSystems { get; set; } = new List<string>();
    public IList<string> Sortiments { get; set; } = new List<string>();
}