using System.ComponentModel.DataAnnotations;

namespace apetito.meinapetito.Portal.Contracts.ProductCatalog.Models
{
    public class GetArticleDetailsRequestModel
    {
        [Required]
        public string? ArticleId { get; set; }
    }
}