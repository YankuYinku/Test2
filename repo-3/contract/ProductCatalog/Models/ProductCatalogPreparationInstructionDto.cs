namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class ProductCatalogPreparationInstructionDto
    {
        public string? Code { get; set; }

        public string? PreparationInstructionText { get; set; }
        public int LabelOrder { get; set; }
    }
}