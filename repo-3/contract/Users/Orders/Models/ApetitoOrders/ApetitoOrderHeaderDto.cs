namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.ApetitoOrders;

public class ApetitoOrderHeaderDto
{
    public int Id { get; set; }
    public string? CustomerNumber { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public bool Approval { get; set; } = false;
    public bool Exported { get; set; } = false;
    public bool? Status { get; set; } = false;
    public string? DeliveryToCustomerNumber { get; set; }
    public string? DeliveryMaterialToCustomerNumber { get; set; }
    public string? Comment { get; set; }
    public string? ExternalComment { get; set; }
    public string? Email { get; set; }
    public decimal TotalAmount { get; set; }
    public int OrderPositionCount { get; set; }
}