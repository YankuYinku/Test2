namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models.Carts;

public class AddItemsToBasketResultDto
{
    public IList<string> SucceededArticles { get; set; }
    public IList<string> FailedArticles { get; set; }
}