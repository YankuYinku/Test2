namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.HawaOrders;

public class HawaSupplierDto
{
    public int Id { get; set; }
    public int ApetitoCreditorId { get; set; }
    public string? ApetitoCreditorNr { get; set; }
    public string? Name { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public string? VatId { get; set; }
}