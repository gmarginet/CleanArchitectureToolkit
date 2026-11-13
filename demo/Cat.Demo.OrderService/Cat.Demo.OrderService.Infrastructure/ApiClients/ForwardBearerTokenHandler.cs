using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Cat.Demo.OrderService.Infrastructure.ApiClients;

/// <summary>
/// Passes the <c>Authorization</c> header of the request that Orders is handling on to the call it makes.
/// The gateway and the other services check the token of the user again.
/// Without a user token, for example in a job of the Scheduler, it asks <see cref="IClientTokenProvider"/> for a client credentials token,
/// so the job acts as Orders itself. Without a provider there is no token, and the gateway answers 401.
/// </summary>
public class ForwardBearerTokenHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IClientTokenProvider? _clientTokens;

    public ForwardBearerTokenHandler(IHttpContextAccessor httpContextAccessor, IClientTokenProvider? clientTokens = null)
    {
        _httpContextAccessor = httpContextAccessor;
        _clientTokens = clientTokens;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization is null)
        {
            var authorization = _httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString();
            if (!string.IsNullOrEmpty(authorization))
            {
                request.Headers.TryAddWithoutValidation(HeaderNames.Authorization, authorization);
            }
            else if (_clientTokens is not null)
            {
                var token = await _clientTokens.GetTokenAsync(cancellationToken).ConfigureAwait(false);
                if (token is not null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
        }

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
