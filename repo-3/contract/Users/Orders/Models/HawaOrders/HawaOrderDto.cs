namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.HawaOrders
{
    public class HawaOrderDto
    {
        public int Id { get; set; }

        public string? OrderNumber { get; set; }

        public string? Email { get; set; }

        public HawaCustomerDto Customer { get; set; }

        public HawaSupplierDto Supplier { get; set; }

        public string? Description { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool IsSelfpayer { get; set; }

        internal string? OrderingUserBearerToken { get; set; }
        public HawaOrderTotalsDto Totals { get; set; }

        public HawaOrderStatusDto Status { get; set; }
        public List<HawaOrderPositionDto> OrderPositions { get; set; }
        public List<HawaOrderPositionDto> FailedOrderPositions { get; set; }
        public string? ErrorCode { get; set; }
        public bool HasOrderPositionsWithErrorCodes => FailedOrderPositions.Any();
    }
}