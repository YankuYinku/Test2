namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class BktBillingResult
{
    public IList<BktAccountItem> BillingItems { get; set; } = new List<BktAccountItem>();
}