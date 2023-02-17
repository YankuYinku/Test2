namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class SubmitMonthRequest
{
    public int Id { get; set; }
    public DateTime Month { get; set; }
    public bool? IsSubmitted { get; set; }

    public bool IsConfirmed { get; set; }
}