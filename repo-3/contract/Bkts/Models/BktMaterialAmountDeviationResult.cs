namespace apetito.meinapetito.Portal.Contracts.Bkts.Models;

public class BktMaterialAmountDeviationResult
{
    public int MaterialNumber { get; set; }

    public double SetPointAmount { get; set; }

    public double ActualAmount { get; set; }
}