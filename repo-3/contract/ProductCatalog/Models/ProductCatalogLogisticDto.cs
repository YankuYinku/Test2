namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models;

public class ProductCatalogLogisticDto
{
    public ProductCatalogUnitDto? SalesUnit { get; set; }
    public ProductCatalogUnitDto? BaseUnit { get; set; }
    public Decimal BaseUnitsInSalesUnit { get; set; }
    public ConversionUnitListDto ConversionUnits { get; set; }
}