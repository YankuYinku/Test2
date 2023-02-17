namespace apetito.meinapetito.Portal.Application.Root.Authentication.LegacyTokenExchange;

public interface IMeinApetitoTokenExchanger
{
    Task<string?> ExchangeAsync(string? token);
}