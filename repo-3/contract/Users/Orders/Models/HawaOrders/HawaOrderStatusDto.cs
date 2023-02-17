namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.HawaOrders;

public class HawaOrderStatusDto
{
    public int OrderId { get; set; }

    public string? ErrorMessage { get; set; }

    public bool IsAcceptedByDistributor => AcceptedDistributor.HasValue;

    public DateTime? AcceptedDistributor { get; set; }

    public bool IsSendToSupplier => SendToSupplier.HasValue;

    public DateTime? SendToSupplier { get; set; }
}