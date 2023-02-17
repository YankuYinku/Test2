namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models
{
    public class OrderDetailsQueryRequest
    {
        public string OrderId { get; set; }
        public IList<int> CustomerNumbers { get; set; }
        public string? LanguageCode { get; set; }
        public IList<string>? Sortiments { get; set; }
    }
}
