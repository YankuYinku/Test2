using System.Diagnostics;
using apetito.CQS;
using apetito.iProDa3.Contracts;
using apetito.iProDa3.Contracts.Model;
using apetito.iProDa3.Contracts.Models.Sortiments;
using apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;
using AutoMapper;
using SortimentDto = apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments.SortimentDto;

namespace apetito.meinapetito.Portal.Application.Root.Users.Current.Sortiments.Queries.Handlers;

public class RetrieveSortimentsOfUserEmailQueryHandler
    : IQueryHandler<RetrieveSortimentsOfUserEmailQuery, IEnumerable<SortimentDto>>
{
    private readonly ILogger<RetrieveSortimentsOfUserEmailQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IIProDa3SortimentRestClient _iProDa3SortimentRestClient;

    public RetrieveSortimentsOfUserEmailQueryHandler(ILogger<RetrieveSortimentsOfUserEmailQueryHandler> logger,
        IMapper mapper, IIProDa3SortimentRestClient iProDa3SortimentRestClient)
    {
        _logger = logger;
        _mapper = mapper;
        _iProDa3SortimentRestClient = iProDa3SortimentRestClient;
    }

    public async Task<IEnumerable<SortimentDto>> Execute(RetrieveSortimentsOfUserEmailQuery query)
    {
        if (!query.SortimentCodes.Any())
        {
            return new List<SortimentDto>();
        }

        Stopwatch stopwatch = new ();
        stopwatch.Start();
        
        List<SortimentResponse> sortimentsFromIProda;

        try
        {
            sortimentsFromIProda = await _iProDa3SortimentRestClient.GetSortimentsQuery(
                new SortimentQuery
                {
                    SortimentCodes = query.SortimentCodes.ToList()
                });

            _logger.LogError("fake sortiments cause iproda3 is offline");
        }
        catch (Exception e)
        {
            _logger.LogError("Error while retrieving sortiments from iProDa3", e);
            sortimentsFromIProda = query.SortimentCodes.Select(s => new SortimentResponse()
            {
                Code = s,
                Beschreibung = s,
                Sortimentsart = s.StartsWith("WM")
                    ? SortimentResponseSortimentType.PromotionalMaterial
                    : SortimentResponseSortimentType.Food,
                Programm = s.StartsWith("WM") ? "WERBEMITTEL" : s,
            }).ToList();
        }

        var mappedSortiments = _mapper.Map<IEnumerable<SortimentDto>>(sortimentsFromIProda);

        stopwatch.Stop();
        _logger.LogWarning("Get IProda sortiments takes {0} ms", stopwatch.ElapsedMilliseconds);

        
        return mappedSortiments;
    }
}