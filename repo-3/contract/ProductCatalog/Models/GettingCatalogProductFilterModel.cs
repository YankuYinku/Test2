namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models;

public class GettingCatalogProductFilterModel
{
    public Guid? Id { get; }
    public string Name { get; }
    public GetProductsGraphQlQueryModel? Value { get; }

    public GettingCatalogProductFilterModel(Guid? id, string name, GetProductsGraphQlQueryModel? value)
    {
        Id = id;
        Name = name;
        Value = value;
    }
}