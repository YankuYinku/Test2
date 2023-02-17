namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class BktToleranceDeviationResult
{
    public bool IsPlausible { get; set; }

    public IList<BktMaterialAmountDeviationResult> MaterialAmountDeviations { get; set; }

    public int ToleranceRelative { get; set; }
}