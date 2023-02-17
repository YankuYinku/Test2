using apetito.ArticleGateway.Contracts.v1.Querying;
using apetito.iProDa3.Contracts.ApiClient.RequestModels;
using apetito.iProDa3.Contracts.ApiClient.V1;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces;
using apetito.meinapetito.Portal.Contracts.Dashboard.Models;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Dashboard.Services.Implementations
{
    public class DashboardSliderProductsProvider : IDashboardSliderProductsServiceClient
    {
        private readonly IiProDa3ArticlesV1RestClient _api;
        private readonly IMapper _mapper;

        public DashboardSliderProductsProvider(IiProDa3ArticlesV1RestClient api, IMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        public async Task<IList<DashboardArticleDto>> GetProductsAsync(GetProductsRequestModel request)
        {
            var convertedResult = await CallApi(request);

            var products = _mapper.Map<IList<DashboardArticleDto>>(convertedResult.Items);
            
            return products ?? new List<DashboardArticleDto>();
        }

        private async Task<ArticleQueryResult> CallApi(GetProductsRequestModel request)
        {
            var result = await _api.RetrieveArticlesAsync<ArticleQueryResult>(_mapper.Map<RetrieveArticlesQuery>(request));

            return result;
        }
    }
}