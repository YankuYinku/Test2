using System.Diagnostics;
using apetito.CQS;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.IbsscToken.Queries.Handlers;

public class RetrieveUserAccessIbsscTokenByUserEmailQueryHandler : IQueryHandler<RetrieveUserAccessIbsscTokenByUserEmailQuery, UserAccessIbsscTokenDto>
{
    private readonly ILogger<RetrieveUserAccessIbsscTokenByUserEmailQueryHandler> _logger;
    private readonly IUserAccessIbsscTokenFactory _userAccessIbsscTokenFactory;

    public RetrieveUserAccessIbsscTokenByUserEmailQueryHandler(ILogger<RetrieveUserAccessIbsscTokenByUserEmailQueryHandler> logger, IUserAccessIbsscTokenFactory ibsscTokenFactory)
    {
        _logger = logger;
        _userAccessIbsscTokenFactory = ibsscTokenFactory;
    }
    
    public Task<UserAccessIbsscTokenDto> Execute(RetrieveUserAccessIbsscTokenByUserEmailQuery query)
    {
        try
        {
            Stopwatch stopwatch = new ();
            stopwatch.Start();
            
            var result = Task.FromResult(_userAccessIbsscTokenFactory
                .WithEmail(query.UserEmail)
                .Create());
            
            stopwatch.Stop();
            _logger.LogWarning("Exchange Ibssc token takes {0} ms", stopwatch.ElapsedMilliseconds);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetUserIbsscToken {Message}", ex.Message);
            return Task.FromResult(new UserAccessIbsscTokenDto());
        }
    }
}