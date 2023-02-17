namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class GetMonthlyRecordsResult
{
    public bool IsMonthly { get; set; }
    public bool IsSubmitted { get; set; }
    public DateTime? DateOfSubmission { get; set; }
    public bool IsLate { get; set; }
    public bool IsToleranceActive { get; set; }
    public int ToleranceRelative { get; set; }
    public IList<DailyInfoDto> Days { get; set; }
}