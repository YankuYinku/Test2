namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class DailyInfoDto
{
    public long BktRecordDayId { get; set; }
    public DateTime? Day { get; set; }
    public bool IsClosed { get; set; }
    public bool IsVoucher { get; set; }
    public List<MealInfoDto> MealInfos { get; set; }
}