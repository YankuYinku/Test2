using apetito.meinapetito.Portal.Contracts.Bkts.Enums;

namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class BktAccountItem
{
    public int CustomerId { get; set; }
    public BillingType BillingType { get; set; }
    public bool BktIsActive { get; set; }
}