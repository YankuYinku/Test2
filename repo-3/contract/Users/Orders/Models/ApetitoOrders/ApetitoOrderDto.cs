namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.ApetitoOrders
{
    public class ApetitoOrderDto
    {
        public ApetitoOrderHeaderDto Header { get; set; }
        public IList<ApetitoOrderPositionDto> Positions { get; set; }
    }
}
