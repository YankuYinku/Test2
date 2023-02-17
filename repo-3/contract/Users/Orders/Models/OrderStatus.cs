namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;

public class OrderStatus
{
    public bool HasValue => Field is not null;
    private OrderStatusEnum? Field { get; }
    public OrderStatusEnum Value => Field ?? throw new Exception("Cannot get not existing value for Order Status");

    public OrderStatus()
    {
    }
    public OrderStatus(string? orderStatus)
    {
        if (string.IsNullOrWhiteSpace(orderStatus))
        {
            return;
        }
        
        if (!Enum.TryParse(typeof(OrderStatusEnum),orderStatus, out var obj))
        {
            throw new Exception("Invalid value for orderStatus");
        }
        Field = (OrderStatusEnum)(obj ?? OrderStatusEnum.Failed);
    }
}