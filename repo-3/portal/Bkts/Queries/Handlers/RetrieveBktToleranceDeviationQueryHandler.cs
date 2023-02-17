using apetito.BKT.Contracts.ApiClient;
using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Bkts.Queries.Handlers;

public class
    RetrieveBktToleranceDeviationQueryHandler : IQueryHandler<RetrieveToleranceDeviationQuery,
        BktToleranceDeviationResult>
{
    private readonly IBktRestApi _bktRestApi;
    private readonly IMapper _mapper;

    public RetrieveBktToleranceDeviationQueryHandler(IBktRestApi bktRestApi, IMapper mapper)
    {
        _bktRestApi = bktRestApi;
        _mapper = mapper;
    }

    public async Task<BktToleranceDeviationResult> Execute(RetrieveToleranceDeviationQuery query)
    {
        var toleranceDeviationResult = await _bktRestApi.GetToleranceDeviationAsync(
            query.MonthlyRecordsRequest.CustomerNumber,
            query.MonthlyRecordsRequest.AccountingMonth);

        var bktToleranceDeviationMappedResult = _mapper.Map<BktToleranceDeviationResult>(toleranceDeviationResult);

        return bktToleranceDeviationMappedResult;
    }
}