using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Configuration;
using Microsoft.FeatureManagement;

namespace apetito.meinapetito.Portal.Application.Root.Configuration.Queries.Handlers;

public class RetrieveFeatureFlagNamesQueryHandler : IQueryHandler<RetrieveFeatureFlagNamesQuery, FeatureFlagNamesDto>
{
    private readonly IFeatureManagerSnapshot _featureManager;

    public RetrieveFeatureFlagNamesQueryHandler(IFeatureManagerSnapshot featureManager)
    {
        _featureManager = featureManager;
    }
    
    public async Task<FeatureFlagNamesDto> Execute(RetrieveFeatureFlagNamesQuery query)
    {
        var flagNames = await _featureManager.GetFeatureNamesAsync().ToListAsync();
        return new FeatureFlagNamesDto()
        {
            Items = flagNames
        };
    }
}