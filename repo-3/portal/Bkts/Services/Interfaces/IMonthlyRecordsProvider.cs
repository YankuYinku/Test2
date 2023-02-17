using apetito.meinapetito.Portal.Contracts.Bkts.Models;

namespace apetito.meinapetito.Portal.Application.Bkts.Services.Interfaces;

public interface IMonthlyRecordsProvider
{
    Task<GetMonthlyRecordsResult> GetMonthlyRecords(MonthlyRecordsRequest monthlyRecordsRequest);
    Task<IList<MonthInfoDto>> GetMonthsAsync(long contractAccountId);
}