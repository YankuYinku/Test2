#pragma warning disable CS8618
namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class AddItemToBasketRequestModel
    {
        public string ArticleId { get; set; }
        public int Quantity { get; set; }
        public string? Sortiment { get; set; }
    }
}