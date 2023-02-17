namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models
{
    public class OrdersQueryRequest
    {
        public string? SearchTerm { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Supplier { get; set; } = "apetito";
        public IList<int>? CustomerNumbers { get; set; } = new List<int>();
        public DateTime OrderDateFrom { get; set; } = DateTime.UtcNow.AddDays(-30);
        public DateTime OrderDateTo { get; set; } = DateTime.UtcNow;
        public string? Status { get; set; }
    }
}
