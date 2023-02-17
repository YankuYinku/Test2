namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class MealInfoDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<MealParticipantInfoDto> MealParticipantInfos { get; set; } = new List<MealParticipantInfoDto>();
}