using apetito.meinapetito.Portal.Contracts.Dashboard.Models;

namespace apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces
{
    public interface ISliderProductDataProvider
    {
        Task<IDictionary<string,PrismicDataModel>> GetSliderDataAsync();
    }
}