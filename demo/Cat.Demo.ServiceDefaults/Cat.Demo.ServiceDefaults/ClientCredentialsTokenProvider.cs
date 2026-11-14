using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.ServiceDefaults;

/// <summary>Gives a demo service a token for work that has no user, such as the jobs of the Scheduler or the answer to a message.</summary>
public interface IClientTokenProvider
{
    /// <summary>Gets an access token for the service itself, or null when none can be had.</summary>
    Task<string?> GetTokenAsync(CancellationToken cancellationToken = default);
}

/// <summary>The settings for the client credentials token of a demo service.</summary>
/// <param name="TokenEndpoint">The token endpoint of the identity provider.</param>
/// <param name="ClientId">The client id of the service.</param>
/// <param name="ClientSecret">The secret of the client.</param>
public record ClientCredentialsSettings(string TokenEndpoint, string ClientId, string ClientSecret);

/// <summary>
/// Asks the identity provider for a client credentials token and keeps it until shortly before it expires.
/// A failed request gives null and a warning in the log. The call that needed the token then gets a 401, as it would without this provider.
/// </summary>
public class ClientCredentialsTokenProvider : IClientTokenProvider
{
    /// <summary>The name of the <see cref="HttpClient"/> that asks for the token.</summary>
    public const string HttpClientName = "client-credentials-token";

    private static readonly TimeSpan Margin = TimeSpan.FromSeconds(30);

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ClientCredentialsSettings _settings;
    private readonly TimeProvider _timeProvider;
    private readonly ILogger<ClientCredentialsTokenProvider> _logger;
    private readonly SemaphoreSlim _lock = new(1, 1);
    private string? _token;
    private DateTimeOffset _expiresAt;

    public ClientCredentialsTokenProvider(
        IHttpClientFactory httpClientFactory,
        ClientCredentialsSettings settings,
        TimeProvider timeProvider,
        ILogger<ClientCredentialsTokenProvider> logger)
    {
        _httpClientFactory = httpClientFactory;
        _settings = settings;
        _timeProvider = timeProvider;
        _logger = logger;
    }

    public async Task<string?> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_token is not null && _timeProvider.GetUtcNow() < _expiresAt)
            {
                return _token;
            }

            try
            {
                using var client = _httpClientFactory.CreateClient(HttpClientName);
                using var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "client_credentials",
                    ["client_id"] = _settings.ClientId,
                    ["client_secret"] = _settings.ClientSecret
                });
                using var response = await client.PostAsync(_settings.TokenEndpoint, content, cancellationToken).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("The identity provider answered {StatusCode} to the client credentials request of {ClientId}.", (int)response.StatusCode, _settings.ClientId);
                    return null;
                }

                using var json = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false), cancellationToken: cancellationToken).ConfigureAwait(false);
                _token = json.RootElement.GetProperty("access_token").GetString();
                var seconds = json.RootElement.TryGetProperty("expires_in", out var expiresIn) ? expiresIn.GetInt32() : 60;
                _expiresAt = _timeProvider.GetUtcNow() + TimeSpan.FromSeconds(seconds) - Margin;
                return _token;
            }
            catch (Exception exception) when (!cancellationToken.IsCancellationRequested
                                       && exception is HttpRequestException or JsonException or KeyNotFoundException or TaskCanceledException)
            {
                _logger.LogWarning(exception, "The client credentials token of {ClientId} could not be fetched.", _settings.ClientId);
                return null;
            }
        }
        finally
        {
            _lock.Release();
        }
    }
}
