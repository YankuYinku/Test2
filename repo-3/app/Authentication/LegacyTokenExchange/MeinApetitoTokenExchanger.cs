using apetito.meinapetito.Portal.Application.ProductCatalog.Services.Interfaces;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.LegacyTokenExchange;

public class MeinApetitoTokenExchanger : IMeinApetitoTokenExchanger
{
    private readonly IMeinApetitoApi _api;
    private readonly ILogger<MeinApetitoTokenExchanger> _logger;

    public MeinApetitoTokenExchanger(IMeinApetitoApi api, ILogger<MeinApetitoTokenExchanger> logger)
    {
        _api = api;
        _logger = logger;
    }

    public async Task<string?> ExchangeAsync(string? token)
    {
        _logger.LogInformation($"Starting to exchange token: {token}");
        
        var result = await _api.ExchangeAsync(string.Format(TokenTemplate,token));

        _logger.LogInformation($"Result token after exchange is: {result.Token}");
        
        return result.Token;
    }

    private const string TokenTemplate = "Bearer {0}";
}