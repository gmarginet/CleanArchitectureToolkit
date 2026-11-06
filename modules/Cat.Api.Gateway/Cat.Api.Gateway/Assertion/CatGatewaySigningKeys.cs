using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Cat.Api.Gateway.Abstractions;
using Cat.Api.Gateway.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Cat.Api.Gateway.Assertion;

/// <summary>
/// Holds the signing key of the gateway, creates the gateway assertions and publishes the public keys.
/// </summary>
/// <remarks>
/// The key is read when the gateway starts. A key you configure is used as it is. In the Development environment,
/// the gateway generates a key when you configure none. That key changes with every start, and two gateway
/// instances would not share it, so production needs a configured key.
/// </remarks>
internal sealed class CatGatewaySigningKeys : IDisposable
{
    private readonly ECDsa? _key;
    private readonly string? _keyId;
    private readonly string? _jwks;
    private readonly string _issuer;
    private readonly TimeSpan _lifetime;
    private readonly TimeProvider _time;
    private readonly JsonWebTokenHandler _handler = new();
    private readonly ConcurrentDictionary<string, (string Token, DateTimeOffset RefreshAt)> _cache = new();

    public CatGatewaySigningKeys(
        CatGatewayAssertionOptions options,
        IHostEnvironment environment,
        ILogger<CatGatewaySigningKeys> logger,
        TimeProvider? time = null)
    {
        _issuer = options.Issuer;
        _lifetime = options.Lifetime;
        _time = time ?? TimeProvider.System;

        var pem = ReadPrivateKeyPem(options);
        if (pem is not null)
        {
            _key = ECDsa.Create();
            _key.ImportFromPem(pem);
            if (_key.KeySize != 256)
                throw new InvalidOperationException("Assertion: the signing key must be an elliptic curve key on P-256.");
        }
        else if (environment.IsDevelopment())
        {
            _key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            logger.LogWarning(
                "No gateway assertion key is configured, so the gateway generated one for development. It changes with every start.");
        }

        if (_key is null) return;

        var parameters = _key.ExportParameters(false);
        _keyId = CatGatewayKeyId.ForP256(parameters.Q.X!, parameters.Q.Y!);
        _jwks = BuildJwks(parameters, options.PreviousPublicKeyPems);
    }

    /// <summary>
    /// Whether the gateway has a key to sign with.
    /// </summary>
    public bool HasKey => _key is not null;

    /// <summary>
    /// The public keys as a JSON Web Key Set. It never holds a private key.
    /// </summary>
    public string GetJwks() => _jwks ?? throw new InvalidOperationException("The gateway has no signing key.");

    /// <summary>
    /// Gives an assertion for a service. The gateway reuses an assertion until half of its life has passed.
    /// </summary>
    /// <param name="audience">The name of the service the assertion is for.</param>
    public string GetAssertion(string audience)
    {
        if (_key is null) throw new InvalidOperationException("The gateway has no signing key.");

        var now = _time.GetUtcNow();
        if (_cache.TryGetValue(audience, out var cached) && now < cached.RefreshAt) return cached.Token;

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _issuer,
            Audience = audience,
            IssuedAt = now.UtcDateTime,
            NotBefore = now.UtcDateTime,
            Expires = (now + _lifetime).UtcDateTime,
            SigningCredentials = new SigningCredentials(
                new ECDsaSecurityKey(_key) { KeyId = _keyId },
                CatGatewayDefaults.SigningAlgorithm)
        };

        var token = _handler.CreateToken(descriptor);
        _cache[audience] = (token, now + TimeSpan.FromTicks(_lifetime.Ticks / 2));
        return token;
    }

    public void Dispose() => _key?.Dispose();

    private static string? ReadPrivateKeyPem(CatGatewayAssertionOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.PrivateKeyPem)) return options.PrivateKeyPem;
        if (!string.IsNullOrWhiteSpace(options.PrivateKeyPemFile)) return File.ReadAllText(options.PrivateKeyPemFile);
        return null;
    }

    private static string BuildJwks(ECParameters current, IEnumerable<string> previousPublicKeys)
    {
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStartObject();
            writer.WriteStartArray("keys");
            WriteKey(writer, current);

            foreach (var pem in previousPublicKeys)
            {
                using var previous = ECDsa.Create();
                previous.ImportFromPem(pem);
                WriteKey(writer, previous.ExportParameters(false));
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        return Encoding.UTF8.GetString(stream.ToArray());
    }

    private static void WriteKey(Utf8JsonWriter writer, ECParameters parameters)
    {
        var x = parameters.Q.X!;
        var y = parameters.Q.Y!;

        writer.WriteStartObject();
        writer.WriteString("kty", "EC");
        writer.WriteString("use", "sig");
        writer.WriteString("alg", CatGatewayDefaults.SigningAlgorithm);
        writer.WriteString("crv", "P-256");
        writer.WriteString("kid", CatGatewayKeyId.ForP256(x, y));
        writer.WriteString("x", CatGatewayKeyId.ToBase64Url(x));
        writer.WriteString("y", CatGatewayKeyId.ToBase64Url(y));
        writer.WriteEndObject();
    }
}
