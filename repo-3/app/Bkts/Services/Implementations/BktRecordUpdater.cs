using System.Text;
using apetito.BKT.Contracts.ApiClient;
using apetito.BKT.Contracts.Models;
using apetito.meinapetito.Portal.Application.Bkts.Services.Interfaces;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace apetito.meinapetito.Portal.Application.Bkts.Services.Implementations;

public class BktRecordUpdater : IBktRecordUpdater
{
    private readonly IBktRestApi _bktPostApiClient;
    private readonly IMapper _mapper;
    public BktRecordUpdater(IBktRestApi bktPostApiClient, IMapper mapper)
    {
        _bktPostApiClient = bktPostApiClient;
        _mapper = mapper;
    }

    public async Task<BktRecordResult> UpdateBktRecordAsync(BktRecordRequest bktRecordRequest)
    {
        var result =  await _bktPostApiClient.PutRecordAsync(bktRecordRequest.Id, new BktRecord()
        {
            Id = bktRecordRequest.Id,
            NumberOfParticipants = bktRecordRequest.NumberOfParticipants
        });

        return new BktRecordResult()
        {
            Id = result.Id,
            NumberOfParticipants = result.NumberOfParticipants
        };
    }

    public async Task<BktRecordDayResult> UpdateBktRecordDayAsync(BktRecordDayRequest bktRecordDayRequest)
    {
        var result = await _bktPostApiClient.PutRecordDayAsync(bktRecordDayRequest.Id, new BktRecordDay()
        {
            Id = bktRecordDayRequest.Id,
            IsClosed = bktRecordDayRequest.IsClosed
        });

        return new BktRecordDayResult()
        {
            Id = result.Id,
            IsClosed = result.IsClosed
        };
    }

    public async Task CloseMonthAsync(CloseMonthRequest closeMonthRequest)
    {
        IList<long> daysToClose = closeMonthRequest.Days.Select(a => a.DayId).ToList();
        IList<long> recordsToClose = closeMonthRequest.Days.SelectMany(a => a.BktRecords).ToList();

        await _bktPostApiClient.PutRecordsAsync(recordsToClose.Select(a => new BktRecord
        {
            Id = a,
            NumberOfParticipants = 0
        }).ToList());

        await _bktPostApiClient.PutRecordDaysAsync(daysToClose.Select(a => new BktRecordDay()
        {
            Id = a,
            IsClosed = true
        }).ToList());
    }

    public async Task OpenMonthAsync(OpenMonthRequest request)
    {
        IList<long> daysToClose = request.Days.Select(a => a.DayId).ToList();
        
        await _bktPostApiClient.PutRecordDaysAsync(daysToClose.Select(a => new BktRecordDay()
        {
            Id = a,
            IsClosed = false
        }).ToList());
    }

    public async Task SubmitMonthAsync(SubmitMonthRequest request)
    {
        request.IsSubmitted = true;
        
        await _bktPostApiClient.SubmitMonthAsync(request.Id,new MonthInfo()
        {
            Id = request.Id,
            Month = request.Month,
            IsSubmitted = request.IsSubmitted == true
        });
    }
}