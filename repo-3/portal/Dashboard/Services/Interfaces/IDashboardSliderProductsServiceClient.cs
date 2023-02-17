using apetito.meinapetito.Portal.Contracts.Dashboard.Models;

namespace apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces
{
    public interface IDashboardSliderProductsServiceClient
    {
        Task<IList<DashboardArticleDto>> GetProductsAsync(GetProductsRequestModel request);
    }
}