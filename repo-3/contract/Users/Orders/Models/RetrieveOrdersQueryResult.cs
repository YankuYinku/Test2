namespace apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;

public class RetrieveOrdersQueryResult
{
    public List<OrderSummaryDto> Orders { get; set; }
    public List<SupplierSummarization> SupplierSummarizations { get; set; }
    public int OverallItemsInAllCategories { get; set; }
    public int OverallPages { get; set; }
    public int OverallResults { get; set; }
}