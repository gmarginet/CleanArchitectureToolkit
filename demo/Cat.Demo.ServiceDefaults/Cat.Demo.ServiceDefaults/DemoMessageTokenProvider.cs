using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Cat.Demo.ServiceDefaults;

/// <summary>
/// Gives the token that travels with a message of a demo service.
/// A message for the user gets the token of the request that the service is handling. Without a request, for example in the listener
/// that answers a message, and for a message with a scheduled time, it gets the client credentials token of the service itself.
/// Without a client credentials token the message goes out without a token.
/// </summary>
public class DemoMessageTokenProvider : ICatTokenProvider
{
    private const string BearerPrefix = "Bearer ";

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IClientTokenProvider? _clientTokens;

    public DemoMessageTokenProvider(IHttpContextAccessor httpContextAccessor, IClientTokenProvider? clientTokens = null)
    {
        _httpContextAccessor = httpContextAccessor;
        _clientTokens = clientTokens;
    }

    public async Task<string?> GetTokenAsync(CatTokenSubject subject, CancellationToken cancellationToken = default)
    {
        if (subject == CatTokenSubject.CurrentUser)
        {
            var authorization = _httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString();
            if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith(BearerPrefix, System.StringComparison.OrdinalIgnoreCase))
            {
                return authorization.Substring(BearerPrefix.Length).Trim();
            }
        }

        return _clientTokens is null
            ? null
            : await _clientTokens.GetTokenAsync(cancellationToken).ConfigureAwait(false);
    }
}
