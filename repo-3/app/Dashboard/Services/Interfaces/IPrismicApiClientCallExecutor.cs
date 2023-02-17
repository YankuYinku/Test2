using prismic;

namespace apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces
{
    public interface IPrismicApiClientCallExecutor
    {
        Task<Document> ExecuteAsync(string? documentId);
    }
}