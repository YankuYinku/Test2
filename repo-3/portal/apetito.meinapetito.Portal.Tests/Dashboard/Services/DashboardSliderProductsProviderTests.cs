using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apetito.ArticleGateway.Contracts.Querying;
using apetito.ArticleGateway.Contracts.v1.Article;
using apetito.ArticleGateway.Contracts.v1.Querying;
using apetito.iProDa3.Contracts.ApiClient.RequestModels;
using apetito.iProDa3.Contracts.ApiClient.V1;
using apetito.meinapetito.Portal.Application.Dashboard.Enums;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Implementations;
using apetito.meinapetito.Portal.Application.Dashboard.Services.Interfaces;
using apetito.meinapetito.Portal.Contracts.Dashboard.Models;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using Additive = apetito.ArticleGateway.Contracts.v1.Article.Additive;
using Article = apetito.ArticleGateway.Contracts.v1.Article.Article;
using Diet = apetito.ArticleGateway.Contracts.v1.Article.Diet;

namespace apetito.meinapetito.Portal.Tests.Dashboard.Services;

public class DashboardSliderProductsProviderTests
{
    private readonly DashboardSliderProductsProvider _provider;
    private readonly IiProDa3ArticlesV1RestClient _api;
    private readonly IDashboardPhotoPathBuilder _photoPathBuilder;

    public DashboardSliderProductsProviderTests()
    {
        _api = Substitute.For<IiProDa3ArticlesV1RestClient>();
        _photoPathBuilder = Substitute.For<IDashboardPhotoPathBuilder>();
        var mapper = Substitute.For<IMapper>();
        _provider = new DashboardSliderProductsProvider(_api,mapper);
    }

    public Task<IList<DashboardArticleDto>> Act(GetProductsRequestModel request) => _provider.GetProductsAsync(request);

    [Test]
    public async Task provide_products_for_slider_should_be_succeed()
    {
        const string photoPathBuilderResult = "photoPathBuilderResult";
        _photoPathBuilder.BuildPhotoPath(Arg.Any<string>(), ImageSize.Big).Returns(photoPathBuilderResult);

        var api = Substitute.For<IiProDa3ArticlesV1RestClient>();

        _api.Returns(api);

        const string additiveAbbreviation = "additiveAbbreviation";
        const string additiveCode = "additiveCode";
        const string additiveDescription = "additiveDescription";

        const string allergenAbbreviation = "allergenAbbreviation";
        const string allergenCode = "allergenCode";
        const string allergenDescription = "allergenDescription";

        const string dietAbbreviation = "dietAbbreviation";
        const string dietCode = "dietCode";
        const string dietDescription = "dietDescription";

        const string componentCode = "componentCode";
        const bool componentDeclare = false;
        const string componentDescription = "componentDescription";
        const string componentGroupPrefix = "componentGroupPrefix";
        const string componentCountryOfOrigin = "componentCountryOfOrigin";
        const int componentQuantityInPercent = 5;

        const string nutrientCode = "nutrientCode";
        const string nutrientAbbreviation = "nutrientAbbreviation";
        const string nutrientDescription = "nutrientDescription";
        const decimal nutrientPer100Grams = 21;

        const string nutrientUnitAbbreviation = "nutrientUnitAbbreviation";
        const string nutrientUnitCode = "nutrientUnitCode";
        const string nutrientUnitDescription = "nutrientUnitCode";
        var nutrientUnit = new ArticleGateway.Contracts.v1.Article.Unit
        {
            Abbreviation = nutrientUnitAbbreviation,
            Code = nutrientUnitCode,
            Description = nutrientUnitDescription,
        };
        const decimal nutrientPortionSizeInGrams = 22;
        const string designationText = "designationText";
        const string designationAdditionalText = "designationAdditionalText";
        const string designationCode= "designationCode";
        const string sealAbbreviation = "sealAbbreviation";
        const string sealDescription = "sealDescription";
        var sealOrigin = SealTypeEnum.MarketingDepartment;
        const string preparationFeatureCode = "preparationFeatureCode";
        const string preparationFeatureAbbreviation = "preparationFeatureAbbreviation";
        const string preparationFeatureDescription = "preparationFeatureDescription";
        const string preparationFeatureFoodSystem = "preparationFeatureFoodSystem";
        const string sortimentAbbreviation = "sortimentAbbreviation";
        const string sortimentCode = "sortimentCode";
        const string sortimentDescription = "sortimentDescription";

        const string articleNumber = "articleNumber";

        const string alergenText = "alergenText";
        const string ingridientsText = "ingridientsText";
        const string priceCurrencyCode = "priceCurrencyCode";
        const int pricePerQuantity = 7;
        const string priceGroupCode = "TK";
        const decimal priceSalesPrice = 12;

        const string priceUnitAbbreviation = "priceUnitAbbreviation";
        const string priceUnitCode = "priceUnitCode";
        const string priceUnitDescription = "priceUnitDescription";
        const string priceUnitPrintDescription = "priceUnitPrintDescription";
        var priceUnitOfMeasurement = new ArticleGateway.Contracts.v1.Article.Unit()
        {
            Abbreviation = priceUnitAbbreviation,
            Code = priceUnitCode,
            Description = priceUnitDescription,
            PrintDescription = priceUnitPrintDescription
        };
        

        const string sealCode = "sealCode";
        const string priceClassAbbreviation = "priceClassAbbreviation";
        const string priceClassDescription = "priceClassDescription";
        const string priceClassCode = "priceClassCode";
        const string ingredientExtraInformationAbbreviation = "ingredientExtraInformationAbbreviation";
        const string ingredientExtraInformationCode = "ingredientExtraInformationCode";
        const string ingredientExtraInformationDescription = "ingredientExtraInformationDescription";
        var dateTimeOffset = DateTimeOffset.Now;
        var dateTimeOffset2 = DateTimeOffset.MinValue;
        var dateTimeOffset3 = DateTimeOffset.MaxValue;
        Article firstItem = new ()
        {
            Identity = new IdentityInformationList(),
            ArticleNumber = articleNumber,
            Details = new ArticleDetails
            {
                {
                    "Additives", new AdditiveList()
                    {
                        Items = new List<Additive>
                        {
                            new Additive
                            {
                                Abbreviation = additiveAbbreviation,
                                Code = additiveCode,
                                Description = additiveDescription,
                            }
                        }
                    }
                },
                {
                    "Allergens", new AllergenList()
                    {
                        Items = new List<Allergen>
                        {
                            new Allergen
                            {
                                Abbreviation = allergenAbbreviation,
                                Code = allergenCode,
                                Description = allergenDescription,
                            }
                        }
                    }
                },
                {
                    "Diets", new DietList()
                    {
                        Items = new List<Diet>
                        {
                            new Diet
                            {
                                Abbreviation = dietAbbreviation,
                                Code = dietCode,
                                Description = dietDescription,
                            }
                        }
                    }
                },
                {
                    "Ingredients", new IngredientSummary()
                    {
                        AllergenText = alergenText,
                        IngredientText = ingridientsText,
                        Components = new CompontentList
                        {
                            Items = new List<Component>
                            {
                                new Component
                                {
                                    Code = componentCode,
                                    Declare = componentDeclare,
                                    Description = componentDescription,
                                    GroupPrefix = componentGroupPrefix,
                                    CountryOfOrigin = componentCountryOfOrigin,
                                    QuantityInPercent = componentQuantityInPercent
                                }
                            }
                        },
                        IngredientExtraInfos = new IngredientExtraInformationList
                        {
                            Items = new List<IngredientExtraInformation>
                            {
                                new IngredientExtraInformation
                                {
                                    Abbreviation = ingredientExtraInformationAbbreviation,
                                    Code = ingredientExtraInformationCode,
                                    Description = ingredientExtraInformationDescription
                                }
                            }
                        }
                    }
                },
                {
                    "Nutrients", new NutrientList()
                    {
                        Items = new List<Nutrient>
                        {
                            new Nutrient
                            {
                                Code = nutrientCode,
                                Abbreviation = nutrientAbbreviation,
                                Description = nutrientDescription,
                                Per100Grams = nutrientPer100Grams,
                                Unit = nutrientUnit,
                                PortionSizeInGrams = nutrientPortionSizeInGrams
                            }
                        }
                    }
                },
                {
                    "Designations", new DesignationsList()
                    {
                        Items = new List<Designation>
                        {
                            new Designation
                            {
                                Code = designationCode,
                                Text = designationText,
                                AdditionalText = designationAdditionalText
                            }
                        }
                    }
                },
                {
                    "Seals", new SealList()
                    {
                        Items = new List<Seal>
                        {
                            new Seal
                            {
                                Code = sealCode,
                                Abbreviation = sealAbbreviation,
                                Description = sealDescription,
                                Origin = sealOrigin
                            }
                        }
                    }
                },
                {
                    "PreparationFeatures", new PreparationFeatureList()
                    {
                        Items = new List<PreparationFeature>
                        {
                            new PreparationFeature
                            {
                                Code = preparationFeatureCode,
                                Abbreviation = preparationFeatureAbbreviation,
                                Description = preparationFeatureDescription,
                                FoodSystem = preparationFeatureFoodSystem
                            }
                        }
                    }
                },
                {
                    "Sortiments", new SortimentList()
                    {
                        Items = new List<SortimentArticleAssignment>
                        {
                            new SortimentArticleAssignment
                            {
                                Sortiment = new Sortiment
                                {
                                    Abbreviation = sortimentAbbreviation,
                                    Code = sortimentCode,
                                    Description = sortimentDescription,
                                },
                                Validity = new ValidityPeriod
                                {
                                    ValidFrom = dateTimeOffset,
                                    ValidUntil = dateTimeOffset2,
                                    VisibleFrom = dateTimeOffset3
                                }
                            }
                        },
                    }
                },
                {
                    "Prices", new PriceList()
                    {
                        Items = new List<Price>
                        {
                            new Price
                            {
                                CurrencyCode = priceCurrencyCode,
                                PerQuantity = pricePerQuantity,
                                SalesPrice = priceSalesPrice,
                                PriceGroupCode = priceGroupCode,
                                UnitOfMeasurement = priceUnitOfMeasurement
                            }
                        }
                    }
                },
                {
                    "PriceClasses", new PriceClassList()
                    {
                        Items = new List<PriceClass>{
                            new PriceClass
                            {
                                Abbreviation = priceClassAbbreviation,
                                Code = priceClassCode,
                                Description = priceClassDescription,
                            }
                        }
                    }
                }
            }
        };


        var result = new ArticleQueryResult(new Query(), new ArticleFilterSummary(), 15,
            new List<Article>
            {
                firstItem
            });
        
            api.RetrieveArticlesAsync<ArticleQueryResult>(Arg.Any<RetrieveArticlesQuery>()).Returns(result);


            var actResult = await Act(new GetProductsRequestModel
            {
                Acs = new List<string>(),
                Additives = new List<string>(),
                Allergens = new List<string>(),
                Categories = new List<string>(),
                Diets = new List<string>(),
                Distinct = true,
                Expand = new List<string>(),
                Filter = "filter",
                Ids = new List<string>(),
                Page = 1,
                Seals = new List<string>(),
                Search = "",
                Sortiments = new List<string>(),
                ArticleIds = new List<string?>(),
                CustomerNumber = 1,
                FoodForms = new List<string>(),
                PageSize = 1,
                PriceGroups = new List<string>(),
                SourceApis = new List<string>(),
                OutletArticleWithoutStock = true,
                GetArticleInLastValidSortiment = false
            });


            var item = actResult.FirstOrDefault();

            item.ShouldNotBeNull();
            item.Id.ShouldBe(articleNumber);

            item.Details.ShouldNotBeNull();

            item.Details.Designations.ShouldNotBeNull();
            var designationDto = item.Details.Designations.FirstOrDefault();

            designationDto.ShouldNotBeNull();
            designationDto.Text.ShouldBe(designationText);
            designationDto.Code.ShouldBe(designationCode);
            designationDto.AdditionalText.ShouldBe(designationAdditionalText);
            
           
            
            item.Details.Price.ShouldNotBeNull();
            var priceDto = item.Details.Price;

            priceDto.ShouldNotBeNull();
            
            priceDto.CurrencyCode.ShouldBe(priceCurrencyCode);
            priceDto.PerQuantity.ShouldBe(pricePerQuantity);
            priceDto.SalesPrice.ShouldBe(priceSalesPrice);
            priceDto.PriceGroupCode.ShouldBe(priceGroupCode);
            priceDto.UnitOfMeasurement.ShouldNotBeNull();
            priceDto.UnitOfMeasurement.Abbreviation.ShouldBe(priceUnitAbbreviation);
            priceDto.UnitOfMeasurement.Code.ShouldBe(priceUnitCode);
            priceDto.UnitOfMeasurement.Description.ShouldBe(priceUnitDescription);
            priceDto.UnitOfMeasurement.PrintDescription.ShouldBe(priceUnitPrintDescription);

            
            item.Details.Seals.ShouldNotBeNull();
            var sealDto = item.Details.Seals.FirstOrDefault();

            sealDto.ShouldNotBeNull();
            sealDto.Abbreviation.ShouldBe(sealAbbreviation);
            sealDto.Description.ShouldBe(sealDescription);
            sealDto.Code.ShouldBe(sealCode);
            sealDto.Origin.ShouldBe(sealOrigin.ToString());

            item.Details.Sortiments.ShouldNotBeNull();
            var sortimentDto = item.Details.Sortiments.FirstOrDefault();

            sortimentDto.ShouldNotBeNull();
            sortimentDto.Sortiment.ShouldNotBeNull();
            sortimentDto.Sortiment.Abbreviation.ShouldBe(sortimentAbbreviation);
            sortimentDto.Sortiment.Code.ShouldBe(sortimentCode);
            sortimentDto.Sortiment.Description.ShouldBe(sortimentDescription);
            
            sortimentDto.Validity.ShouldNotBeNull();
            
            sortimentDto.Validity.ValidFrom.ShouldBe(dateTimeOffset);
            sortimentDto.Validity.ValidUntil.ShouldBe(dateTimeOffset2);
            sortimentDto.Validity.VisibleFrom.ShouldBe(dateTimeOffset3);
            
        
            
    }
}