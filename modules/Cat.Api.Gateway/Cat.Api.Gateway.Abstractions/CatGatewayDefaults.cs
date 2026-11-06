using System;

namespace Cat.Api.Gateway.Abstractions;

/// <summary>
/// The names and values that the gateway and the services must agree on.
/// </summary>
/// <remarks>
/// The gateway writes them, and a service that checks the gateway assertion reads them. Both sides use this class,
/// so a name never drifts apart.
/// </remarks>
public static class CatGatewayDefaults
{
    /// <summary>
    /// The header that carries the gateway assertion to a service. The gateway always removes this header from
    /// the incoming request, so a client can never set it.
    /// </summary>
    public const string AssertionHeaderName = "X-Cat-Gateway-Assertion";

    /// <summary>
    /// The header that carries the correlation id of a request through the gateway and the services.
    /// </summary>
    public const string CorrelationIdHeaderName = "X-Correlation-Id";

    /// <summary>
    /// The path where the gateway publishes the public keys that sign the gateway assertion.
    /// </summary>
    public const string DefaultJwksPath = "/.well-known/cat-gateway/jwks.json";

    /// <summary>
    /// The issuer of the gateway assertion, unless the gateway configures another name.
    /// </summary>
    public const string DefaultIssuer = "cat-gateway";

    /// <summary>
    /// The signing algorithm of the gateway assertion. It is the only algorithm a service accepts.
    /// </summary>
    public const string SigningAlgorithm = "ES256";

    /// <summary>
    /// How long a gateway assertion is valid, unless the gateway configures another lifetime.
    /// </summary>
    public static readonly TimeSpan DefaultAssertionLifetime = TimeSpan.FromSeconds(30);
}
