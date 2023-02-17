using apetito.meinapetito.Portal.Contracts.Faqs.Models;

namespace apetito.meinapetito.Portal.Application.Faqs.Services.Interfaces;

public interface IFaqsItemProvider
{
    Task<GetFaqsItemsResult> GetAsync(FaqsQuery query);
    Task<GetFaqsItemsResult> GetByIdAsync(string id, FaqsQuery query);
    Task<GetFaqsItemsResult> GetBySlugAsync(string slug, FaqsQuery query);
}