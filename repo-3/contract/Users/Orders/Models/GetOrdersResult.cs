namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models
{
    public class OrderSummaryDto
    {
        public int OrderId { get; set; }
        public string? Id { get; set; }
        public string? Supplier { get; set; }
        public int CustomerNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public int OrderPositionCount { get; set; }
        public decimal? TotalAmount { get; set; } 
    }
    public class SupplierSummarization
    {
        public string Supplier { get; set; }
        public int Amount { get; set; }
    }
}
