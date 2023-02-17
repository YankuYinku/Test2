using apetito.CQS;
using apetito.meinapetito.Order.Contracts.Orders.ApiClients;
using apetito.meinapetito.Order.Contracts.Orders.Models;
using apetito.meinapetito.Portal.Application.ProductCatalog.Services.Interfaces;
using apetito.meinapetito.Portal.Application.Root.Users.Orders.Options;
using apetito.meinapetito.Portal.Contracts.ProductCatalog;
using apetito.meinapetito.Portal.Contracts.ProductCatalog.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.ApetitoOrders;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries.Handlers;

public class RetrieveApetitoOrderDetailsHandler : IQueryHandler<RetrieveApetitoOrderDetails,ApetitoOrderDto>
{
    private readonly IApetitoOrdersClient _apetitoOrdersClient;
    private readonly IMapper _mapper;
    private readonly OrderAzureFunctionApiKeys _orderAzureFunctionApiKeys;
    private readonly IApetitoProductsProvider _apetitoProductsProvider;
    public RetrieveApetitoOrderDetailsHandler(IApetitoOrdersClient apetitoOrdersClient, IMapper mapper, OrderAzureFunctionApiKeys orderAzureFunctionApiKeys, IApetitoProductsProvider apetitoProductsProvider)
    {
        _apetitoOrdersClient = apetitoOrdersClient;
        _mapper = mapper;
        _orderAzureFunctionApiKeys = orderAzureFunctionApiKeys;
        _apetitoProductsProvider = apetitoProductsProvider;
    }

    public async Task<ApetitoOrderDto> Execute(RetrieveApetitoOrderDetails query)
    {
        if (!query.CustomerNumbers.Any())
        {
            throw new Exception("CustomerNumbers cannot be an empty collection");
        }

        var details = await _apetitoOrdersClient.RetrieveApetitoOrderWithPositionsAsync(new RetrieveApetitoOrderDetailsRequest()
        {
            Code = _orderAzureFunctionApiKeys.RetrievieApetitoOrderDetailsKey,
            CustomerNumbers = query.CustomerNumbers.Select(a => a.ToString()).ToList(),
            OrderId = query.OrderId
        });
        
        IList<string> articleNumbers = details.Positions.Select(a => string.IsNullOrWhiteSpace(a.ArticleId) ? string.Empty : a.ArticleId).ToList();
        

        var articles = await _apetitoProductsProvider.GetProductsAsync(new GetCatalogProductsRequest()
        {
            Page = 1,
            PageSize = details.Positions.Count,
            Sortiments = query.Sortiments,
            ArticleIds = articleNumbers,
            ExpectedArticleType = ArticleTypeRequestEnum.Product,
            LanguageCode = query.LanguageCode
        });

        var mappedDetails = _mapper.Map<ApetitoOrderDto>(details);

        foreach (var detail in mappedDetails.Positions)
        {
            var articleCandidate = articles.Articles?.FirstOrDefault(a => a.Id == detail.ArticleId);

            if (articleCandidate is null)
            {
                continue;
            }

            detail.Title = articleCandidate.Title;
        }
        
        return mappedDetails;
    }
}