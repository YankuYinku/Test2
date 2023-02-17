using apetito.BKT.Contracts.ApiClient;
using apetito.meinapetito.Portal.Application.Bkts.Services.Interfaces;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace apetito.meinapetito.Portal.Application.Bkts.Services.Implementations;

public class MonthlyRecordsProvider : IMonthlyRecordsProvider
{
    private readonly IMapper _mapper;
    private readonly IBktRestApi _bktPostApiClient;

    public MonthlyRecordsProvider(IMapper mapper, IBktRestApi bktPostApiClient)
    {
        _mapper = mapper;
        _bktPostApiClient = bktPostApiClient;
    }

    public async Task<GetMonthlyRecordsResult> GetMonthlyRecords(MonthlyRecordsRequest monthlyRecordsRequest)
    {
        var response = await _bktPostApiClient.GetMonthlyRecords(monthlyRecordsRequest.CustomerNumber,monthlyRecordsRequest.AccountingMonth);
        
        var result = new GetMonthlyRecordsResult
        {
            Days = response.Select(_mapper.Map<DailyInfoDto>).ToList()
        };

        return result;
    }

    public async Task<IList<MonthInfoDto>> GetMonthsAsync(long contractAccountId)
    {
        var result = await _bktPostApiClient.GetBktMonthsInfo(contractAccountId);

        return result.Select(a => _mapper.Map<MonthInfoDto>(a)).ToList();
    }
}