using apetito.meinapetito.Portal.Application.Dashboard.Options;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces;
using apetito.meinapetito.Portal.Contracts.Dashboard.Models;
using prismic.fragments;

namespace apetito.meinapetito.Portal.Application.Dashboard.Services.Implementations.Prismic
{
    public class SliderProductDataProvider : ISliderProductDataProvider
    {
        private readonly PrismicOptions _prismicOptions;
        private readonly IPrismicApiClientCallExecutor _prismicApiClientCallExecutor;
        public SliderProductDataProvider(IPrismicApiClientCallExecutor prismicApiClientCallExecutor, PrismicOptions prismicOptions)
        {
            _prismicApiClientCallExecutor = prismicApiClientCallExecutor;
            _prismicOptions = prismicOptions;
        }

        public async Task<IDictionary<string,PrismicDataModel>> GetSliderDataAsync()
        {
            var expectedDocumentId = _prismicOptions.DocumentId;
            
            var document = await _prismicApiClientCallExecutor.ExecuteAsync(expectedDocumentId);

            var fragments = document.Fragments.Values;

            var prismicDataModels = new Dictionary<string, PrismicDataModel>();
            
            foreach (var fragment in fragments)
            {
                if (fragment is not SliceZone sliceZone)
                {
                    continue;
                }
                
                var compositeSlice = sliceZone.Slices[0] as CompositeSlice;

                if (compositeSlice is null)
                {
                    continue;
                }
                
                var fragmentsCollection = compositeSlice.GetItems().GroupDocs
                    .Select(group => @group.Fragments.Values);

                foreach (var items in fragmentsCollection)
                {
                    var articleFragments = items.ToArray();

                    if (articleFragments[0] is not Text articleNumber)
                    {
                        continue;
                    }

                    if (articleFragments[1] is not Number oldPrice)
                    {
                        continue;
                    }

                    var prismicDataModel = new PrismicDataModel
                        {
                            ArticleNumber = articleNumber.Value,
                            OldPrice = oldPrice.Value
                        };

                    if (!prismicDataModels.ContainsKey(articleNumber.Value))
                    {
                        prismicDataModels.Add(articleNumber.Value, prismicDataModel);
                    }
                    else
                    {
                        prismicDataModels[articleNumber.Value] = prismicDataModel;
                    }
                }
            }

            return prismicDataModels;
        }
    }
}