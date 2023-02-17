using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;

namespace apetito.meinapetito.Portal.Application.Bkts.Queries;

public class RetrieveToleranceDeviationQuery : IQuery<BktToleranceDeviationResult>
{
    public MonthlyRecordsRequest MonthlyRecordsRequest { get; }

    public RetrieveToleranceDeviationQuery(MonthlyRecordsRequest monthlyRecordsRequest)
    {
        MonthlyRecordsRequest = monthlyRecordsRequest;
    }
}