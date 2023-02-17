namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class MealParticipantInfoDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? NumberOfParticipants { get; set; }
    public long BktRecordId { get; set; }
}