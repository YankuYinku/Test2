namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public record BuildQueryParameterModel
    {
        public BuildQueryParameterModel(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public string Value { get; }
    }
}