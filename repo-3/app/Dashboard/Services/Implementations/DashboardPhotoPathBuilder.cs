using apetito.meinapetito.Portal.Application.Dashboard.Enums;
using apetito.meinapetito.Portal.Application.Dashboard.Options;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace apetito.meinapetito.Portal.Application.Dashboard.Services.Implementations
{
    public class DashboardPhotoPathBuilder : IDashboardPhotoPathBuilder
    {
        private readonly DashboardPhotoBuilderOptions _options;

        public DashboardPhotoPathBuilder(IOptions<DashboardPhotoBuilderOptions> options)
        {
            _options = options.Value;
        }

        public string BuildPhotoPath(string articleId, ImageSize imageSize)
            => $"{string.Format(_options?.ProductImagePath ?? string.Empty, SizeConverting[imageSize])}{articleId}.jpg";

        private static readonly Dictionary<ImageSize, string> SizeConverting = new()
        {
            {ImageSize.Big, "300x300"},
            {ImageSize.Middle, "300x300"},
            {ImageSize.Small, "300x300"}
        };
    }
}