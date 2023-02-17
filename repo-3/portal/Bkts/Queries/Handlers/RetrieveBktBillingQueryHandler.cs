using System.Diagnostics;
using apetito.BKT.Contracts.ApiClient;
using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Bkts.Queries.Handlers;

public class RetrieveBktBillingQueryHandler : IQueryHandler<RetrieveBktBillingQuery, BktBillingResult>
{
    private readonly IBktRestApi _bktRestApi;
    private readonly IMapper _mapper;
    private readonly ILogger<RetrieveBktBillingQueryHandler> _logger;

    public RetrieveBktBillingQueryHandler(IBktRestApi bktRestApi, IMapper mapper, ILogger<RetrieveBktBillingQueryHandler> logger)
    {
        _bktRestApi = bktRestApi;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BktBillingResult> Execute(RetrieveBktBillingQuery query)
    {
        var bktBillingResult = new BktBillingResult();
        
        if (query.Excludes.Contains(ExcludeValue))
        {
            return bktBillingResult;
        }
        
        try
        {
            Stopwatch stopwatch = new ();
            stopwatch.Start();
            var contractAccounts = await _bktRestApi.GetDebitorsOfUserAsync();

            foreach (var contactAccount in contractAccounts)
            {
                var item = _mapper.Map<BktAccountItem>(contactAccount);
                bktBillingResult.BillingItems.Add(item);
            }
            stopwatch.Stop();
            _logger.LogWarning("Get BKT data takes {0} ms", stopwatch.ElapsedMilliseconds);

        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex,"BKT api is not reachable. Returned empty set of data");
        }

        return bktBillingResult;
    }

    private const string ExcludeValue = "bkt";
}