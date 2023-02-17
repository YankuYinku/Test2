using System.Collections.Generic;
using System.Threading.Tasks;
using apetito.meinapetito.Portal.Application.Dashboard.Options;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Implementations.Prismic;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces;
using apetito.meinapetito.Portal.Contracts.Dashboard.Models;
using NSubstitute;
using NUnit.Framework;
using prismic;
using prismic.fragments;
using Shouldly;

namespace apetito.meinapetito.Portal.Tests.Dashboard.Services
{
    public class PrismicDataProvider
    {
        private readonly SliderProductDataProvider _sliderProductDataProvider;
        private readonly IPrismicApiClientCallExecutor _callExecutor;

        private async Task<IDictionary<string,PrismicDataModel>> Act() => await _sliderProductDataProvider.GetSliderDataAsync();
        
        public PrismicDataProvider()
        {
            _callExecutor = Substitute.For<IPrismicApiClientCallExecutor>();
            
            _sliderProductDataProvider = new SliderProductDataProvider(_callExecutor, new PrismicOptions());
        }

        [Test]
        public async Task provide_data_should_be_succeed()
        {

            IList<string> items = new List<string>
            {
                "1234",
                "4321",
                "134",
                "16542"
            };
            
            IDictionary<string, Fragment> insideFragments = new Dictionary<string, Fragment>();

            foreach (var item in items)
            {
                insideFragments.Add(new KeyValuePair<string, Fragment>(item,new Text(item)));
            }
            
            
            IDictionary<string, Fragment> fragments = new Dictionary<string, Fragment>
            {
                {"",new SliceZone(new List<Slice>()
                {
                    new CompositeSlice("type","label",new Group(new List<GroupDoc>
                    {
                     new GroupDoc(insideFragments)   
                    }),new GroupDoc(insideFragments)),
                })},
                
                {"1",new SliceZone(new List<Slice>()
                {
                    new SimpleSlice("type","label",new Color("FFFFFF"))
                })},
                
                {"3",new Text("aaa")},
                
            };
            Document document = new ProxyDocument(fragments);
            
            _callExecutor.ExecuteAsync("").Returns(document);
        
            var result = await Act();

            foreach (var item in result)
            {
                items.ShouldContain(item.Key);
            }
        }
    }
}