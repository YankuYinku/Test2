namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class CloseMonthRequest
{
    public IList<CloseMonthDayRequest> Days { get; set; }
}