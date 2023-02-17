namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models
{
    public class RetrieveOrderQuery
    {
        public string? SearchTerm { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? Supplier { get; set; } = "apetito"; 
        public int? CustomerNumber { get; set; } = 0;
        public IList<int>? CustomerNumbers { get; set; }
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public OrderStatus Status { get; set; } = new OrderStatus();
        public int Skip => (Page - 1) * PageSize;
        public int Take => PageSize;
    }
}