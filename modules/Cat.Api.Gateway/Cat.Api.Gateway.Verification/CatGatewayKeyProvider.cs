using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Cat.Api.Gateway.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Cat.Api.Gateway.Verification;

/// <summary>
/// Gives the public keys of the gateway: the configured keys, and the keys it downloads from the gateway.
/// </summary>
internal sealed class CatGatewayKeyProvider : IDisposable
{
    internal const string HttpClientName = "CatGatewayJwks";

    private readonly CatGatewayVerificationOptions _options;
    private readonly IHttpClientFactory? _httpClientFactory;
    private readonly TimeProvider _time;
    private readonly ILogger _logger;
    private readonly IReadOnlyList<SecurityKey> _configuredKeys;
    private readonly List<ECDsa> _owned = [];
    private readonly SemaphoreSlim _download = new(1, 1);
    private IReadOnlyList<SecurityKey> _downloaded = [];
    private DateTimeOffset _lastDownload = DateTimeOffset.MinValue;
    private DateTimeOffset _refreshAt = DateTimeOffset.MinValue;

    public CatGatewayKeyProvider(
        CatGatewayVerificationOptions options,
        IHttpClientFactory? httpClientFactory,
        TimeProvider time,
        ILogger<CatGatewayKeyProvider> logger)
    {
        _options = options;
        _httpClientFactory = httpClientFactory;
        _time = time;
        _logger = logger;
        _configuredKeys = options.PublicKeyPems.Select(CreateKey).ToList();

        if (options.JwksAddress is not null &&
            Uri.TryCreate(options.JwksAddress, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttp)
            logger.LogWarning(
                "The gateway keys are downloaded over HTTP. Whoever can change that answer can sign gateway assertions. Use HTTPS when the network is not trusted.");
    }

    /// <summary>
    /// Gives the keys to check an assertion with.
    /// </summary>
    /// <param name="keyId">The key id in the header of the assertion, if it has one.</param>
    /// <param name="cancellationToken">A token to cancel the download.</param>
    public async Task<IReadOnlyList<SecurityKey>> GetKeysAsync(string? keyId, CancellationToken cancellationToken)
    {
        if (_options.JwksAddress is null) return _configuredKeys;

        var now = _time.GetUtcNow();
        var snapshot = Volatile.Read(ref _downloaded);
        var expired = now >= _refreshAt;
        var unknownKey = keyId is not null && snapshot.All(k => k.KeyId != keyId) &&
                         _configuredKeys.All(k => k.KeyId != keyId) &&
                         now - _lastDownload >= _options.JwksMinimumRefreshInterval;

        if (expired || unknownKey)
        {
            await _download.WaitAsync(cancellationToken);
            try
            {
                // Another request may have downloaded the keys while this one waited.
                now = _time.GetUtcNow();
                if (now >= _refreshAt || now - _lastDownload >= _options.JwksMinimumRefreshInterval && unknownKey)
                    await DownloadAsync(now, cancellationToken);
            }
            finally
            {
                _download.Release();
            }

            snapshot = Volatile.Read(ref _downloaded);
        }

        return _configuredKeys.Concat(snapshot).ToList();
    }

    public void Dispose()
    {
        _download.Dispose();
        foreach (var key in _owned) key.Dispose();
    }

    private async Task DownloadAsync(DateTimeOffset now, CancellationToken cancellationToken)
    {
        _lastDownload = now;

        try
        {
            using var client = _httpClientFactory?.CreateClient(HttpClientName) ?? new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            var json = await client.GetStringAsync(_options.JwksAddress, cancellationToken);

            var keys = new JsonWebKeySet(json).GetSigningKeys()
                .Where(key => key is ECDsaSecurityKey { KeySize: 256 })
                .ToList();
            if (keys.Count == 0) throw new InvalidOperationException("The answer holds no P-256 key.");

            Volatile.Write(ref _downloaded, keys);
            _refreshAt = now + _options.JwksRefreshInterval;
        }
        catch (Exception exception) when (exception is not OperationCanceledException || !cancellationToken.IsCancellationRequested)
        {
            // Keep the keys we have. Try again after the minimum interval.
            _refreshAt = now + _options.JwksMinimumRefreshInterval;
            _logger.LogWarning(exception, "The gateway keys could not be downloaded from {Address}.", _options.JwksAddress);
        }
    }

    private SecurityKey CreateKey(string pem)
    {
        var key = ECDsa.Create();
        key.ImportFromPem(pem);
        if (key.KeySize != 256)
        {
            key.Dispose();
            throw new InvalidOperationException("A public key of the gateway must be an elliptic curve key on P-256.");
        }

        _owned.Add(key);
        var parameters = key.ExportParameters(false);
        return new ECDsaSecurityKey(key) { KeyId = CatGatewayKeyId.ForP256(parameters.Q.X!, parameters.Q.Y!) };
    }
}
