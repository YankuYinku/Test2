using apetito.meinapetito.Portal.Application.Dashboard.Options;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces;
using prismic;

namespace apetito.meinapetito.Portal.Application.Dashboard.Services.Implementations
{
    public class PrismicApiClientCallExecutor : IPrismicApiClientCallExecutor
    {
        private readonly PrismicOptions _prismicOptions;

        public PrismicApiClientCallExecutor(PrismicOptions options)
        {
            _prismicOptions = options;
        }

        public async Task<Document> ExecuteAsync(string? documentId)
        {
            var api = await Api.Get(_prismicOptions.Endpoint, _prismicOptions.AccessToken);
            
            return await api.GetByID(documentId);
        }
    }
}