namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models;

public class ConversionUnitListDto
{
    public ProductCatalogUnitDto? BaseUnit { get; set; }
    public ProductCatalogAmountInUnitDto? PiecesPerCarton { get; set; }
    public ProductCatalogAmountInUnitDto? LayersPerPallet { get; set; }
    public ProductCatalogAmountInUnitDto? CartonsPerPallet { get; set; }
}