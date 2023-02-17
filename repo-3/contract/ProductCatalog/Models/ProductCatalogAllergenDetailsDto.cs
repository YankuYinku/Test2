namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogAllergenDetailsDto
    {
        public string? ParentAllergenCode { get; set; }

        public int Level { get; set; }

        public bool IsTrace { get; set; }

        // ReSharper disable once InconsistentNaming
        public bool IsEUAllergen { get; set; }

        public int SortOrder { get; set; }
    }
}