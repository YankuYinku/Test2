namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.HawaOrders;

public class HawaOrderTotalsDto
{
    public int TotalQuantity { get; set; }
    public decimal TotalNetPrice { get; set; }
    public decimal TotalGrossPrice { get; set; }
    public decimal TotalVat { get; set; }
    public decimal TotalVat7Price { get; set; }
    public decimal TotalVat19Price { get; set; }
    public decimal IncludedVat19 { get; set; }
    public decimal IncludedVat7 { get; set; }
}