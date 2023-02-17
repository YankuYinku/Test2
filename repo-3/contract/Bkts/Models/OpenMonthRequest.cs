namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class OpenMonthRequest
{
    public IList<OpenMonthDayRequest> Days { get; set; }
}