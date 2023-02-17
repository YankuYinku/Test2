using apetito.meinapetito.Portal.Contracts.Bkts.Models;

namespace apetito.meinapetito.Portal.Application.Bkts.Services.Interfaces;

public interface IBktRecordUpdater
{
    Task<BktRecordResult> UpdateBktRecordAsync(BktRecordRequest bktRecordRequest);
    Task<BktRecordDayResult> UpdateBktRecordDayAsync(BktRecordDayRequest bktRecordDayRequest);
    Task CloseMonthAsync(CloseMonthRequest request);
    Task OpenMonthAsync(OpenMonthRequest request);
    Task SubmitMonthAsync(SubmitMonthRequest request);
}