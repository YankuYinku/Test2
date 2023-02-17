using apetito.meinapetito.Portal.Application.Dashboard.Enums;

namespace apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces
{
    public interface IDashboardPhotoPathBuilder
    {
        string BuildPhotoPath(string articleId, ImageSize imageSize);
    }
}