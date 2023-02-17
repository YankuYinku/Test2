using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;

namespace apetito.meinapetito.Portal.Application.Bkts.Queries;

public class RetrieveToleranceQuery : IQuery<BktToleranceCheckResult>
{
    public MonthlyRecordsRequest MonthlyRecordsRequest { get; }
    public RetrieveToleranceQuery(MonthlyRecordsRequest monthlyRecordsRequest)
    {
        MonthlyRecordsRequest = monthlyRecordsRequest;
    }
}