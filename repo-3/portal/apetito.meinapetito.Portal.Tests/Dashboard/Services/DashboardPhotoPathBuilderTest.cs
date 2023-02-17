using apetito.meinapetito.Portal.Application.Dashboard.Enums;
using apetito.meinapetito.Portal.Application.Dashboard.Options;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Implementations;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;

namespace apetito.meinapetito.Portal.Tests.Dashboard.Services
{
    public class DashboardPhotoPathBuilderTest
    {
        private readonly DashboardPhotoPathBuilder _builder;
        private const string BaseUrl = "basePath/";
        private string Act(string articleId) => _builder.BuildPhotoPath(articleId, ImageSize.Big);
        
        public DashboardPhotoPathBuilderTest()
        {
            _builder = new DashboardPhotoPathBuilder(new OptionsWrapper<DashboardPhotoBuilderOptions>(new DashboardPhotoBuilderOptions
            {
                ProductImagePath = BaseUrl
            }));
        }

        [Test]
        public void create_photo_path_should_be_succeed()
        {
            var articleId = "articleId";

            var result = Act(articleId);

            var expectedResult = string.Format("{0}Gross/{1}.jpg", BaseUrl, articleId);
            
            result.ShouldBe(expectedResult);
        }
    }
}