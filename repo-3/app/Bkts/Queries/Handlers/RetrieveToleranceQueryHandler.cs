using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;

namespace apetito.meinapetito.Portal.Application.Bkts.Queries.Handlers;

public class RetrieveToleranceQueryHandler : IQueryHandler<RetrieveToleranceQuery,BktToleranceCheckResult>
{
    private readonly IQueryHandler<RetrieveToleranceDeviationQuery,
        BktToleranceDeviationResult> _queryHandler;

    public RetrieveToleranceQueryHandler(IQueryHandler<RetrieveToleranceDeviationQuery, BktToleranceDeviationResult> queryHandler)
    {
        _queryHandler = queryHandler;
    }

    public async Task<BktToleranceCheckResult> Execute(RetrieveToleranceQuery query)
    {
        var result = await _queryHandler.Execute(new RetrieveToleranceDeviationQuery(query.MonthlyRecordsRequest));

        return new BktToleranceCheckResult
        {
            IsPlausible = result.IsPlausible
        };
    }
}