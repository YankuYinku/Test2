namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.ApetitoOrders;

public class ApetitoOrderPositionDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string? ArticleId { get; set; }
    public decimal? Amount { get; set; }
    public int? Quantity { get; set; }
    public int? ConsumptionDay { get; set; }
    public int? SizeIndex { get; set; }
    public long? MenuPlanComponentOrderId { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string? Sortiment { get; set; }
    public decimal? PlannedQuantity { get; set; }
    public decimal? StockQuantity { get; set; }
    public bool? ShowPriceInConfirmation { get; set; }
    public Guid? TableGuestId { get; set; }
    public DateTime? ConsumptionDate { get; set; }
}