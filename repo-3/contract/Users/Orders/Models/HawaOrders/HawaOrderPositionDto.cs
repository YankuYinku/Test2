namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.HawaOrders;

public class HawaOrderPositionDto
{
    public int ArticleId { get; set; }
    public string? ArticleNumber { get; set; }
    public string? Category { get; set; }
    public int SupplierId { get; set; }
    public int OrderingUnitId { get; set; }
    public int PositionNr { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal PriceNet { get; set; }
    public decimal Vat { get; set; }
    public decimal PriceGross { get; set; }
    public int VatPercent { get; set; }
    public decimal PositionNetPrice { get; set; }
    public decimal PositionGrossPrice { get; set; }
    public decimal PositionVat { get; set; }
    public string? Comment { get; set; }
    public string? BasicSalesUnit { get; set; }
    public int BasicQuantity { get; set; }
    public bool Available { get; set; }
    public string? ErrorCode { get; set; }
}