using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Users.Orders.Models.HawaOrders;
using apetito.Order.Hawa.Contracts.ApiClient;
using AutoMapper;

namespace apetito.meinapetito.Portal.Application.Root.Users.Orders.Queries.Handlers;

public class RetrieveHawaOrderDetailsHandler : IQueryHandler<RetrieveHawaOrderDetails,HawaOrderDto>
{
    private readonly IHawaOrderRestApi _hawaOrderRestApi;
    private readonly IMapper _mapper;

    public RetrieveHawaOrderDetailsHandler(IMapper mapper,IHawaOrderRestApi hawaOrderRestApi)
    {
        _mapper = mapper;
        _hawaOrderRestApi = hawaOrderRestApi;
    }

    public async Task<HawaOrderDto> Execute(RetrieveHawaOrderDetails query)
    {
        var details = await _hawaOrderRestApi.GetOrderByOrderNumber(query.Id);

        return _mapper.Map<HawaOrderDto>(details);
    }
}