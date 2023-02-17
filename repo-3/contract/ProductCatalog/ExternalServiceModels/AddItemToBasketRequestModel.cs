namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.ExternalServiceModels;

public class AddItemToBasketRequestModel
{
    public string? ArticleNumber { get; set; }
    public int Quantity { get; set; }
    public string? Sortiment { get; set; }
}