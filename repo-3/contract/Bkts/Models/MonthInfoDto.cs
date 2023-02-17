namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class MonthInfoDto
{
    public int Id { get; set; }
    public DateTime Month { get; set; }
    public bool IsSubmitted { get; set; }
    public DateTime? DateOfSubmission { get; set; }
}