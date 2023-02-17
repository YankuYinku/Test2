namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class CloseMonthDayRequest
{
    public long DayId { get; set; }
    public IList<long> BktRecords { get; set; }
}