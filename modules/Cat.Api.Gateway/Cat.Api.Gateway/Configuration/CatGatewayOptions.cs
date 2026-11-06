using System;
using System.Collections.Generic;
using Cat.Api.Gateway.Abstractions;

namespace Cat.Api.Gateway.Configuration;

/// <summary>
/// The configuration of the gateway. It binds to the <c>CatGateway</c> section.
/// </summary>
/// <remarks>
/// <para>
/// You describe the services behind the gateway, and the gateway derives the routes from them. The service name
/// is the first part of the path, so a service called <c>catalog</c> gets every request that starts with
/// <c>/catalog</c>.
/// </para>
/// <para>
/// A change of <see cref="Services"/> and <see cref="Defaults"/> is picked up while the gateway runs. A change that
/// is not valid is logged and ignored, and the gateway keeps the last good configuration. The other sections are
/// read when the gateway starts.
/// </para>
/// </remarks>
public sealed class CatGatewayOptions
{
    /// <summary>
    /// The name of the configuration section.
    /// </summary>
    public const string SectionName = "CatGateway";

    /// <summary>
    /// How the gateway checks the token of a caller.
    /// </summary>
    public CatGatewayAuthenticationOptions Authentication { get; set; } = new();

    /// <summary>
    /// The values a service gets when it does not set its own.
    /// </summary>
    public CatGatewayServiceDefaults Defaults { get; set; } = new();

    /// <summary>
    /// The services behind the gateway, by name.
    /// </summary>
    public Dictionary<string, CatGatewayServiceOptions> Services { get; set; } =
        new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// The keys and the lifetime of the gateway assertion.
    /// </summary>
    public CatGatewayAssertionOptions Assertion { get; set; } = new();

    /// <summary>
    /// How many requests a caller may send.
    /// </summary>
    public CatGatewayRateLimitOptions RateLimit { get; set; } = new();

    /// <summary>
    /// Which browser origins may call the gateway.
    /// </summary>
    public CatGatewayCorsOptions Cors { get; set; } = new();

    /// <summary>
    /// The limits on a request.
    /// </summary>
    public CatGatewayLimitsOptions Limits { get; set; } = new();

    /// <summary>
    /// Which headers the gateway removes or trusts.
    /// </summary>
    public CatGatewayHeadersOptions Headers { get; set; } = new();
}

/// <summary>
/// How the gateway checks the token of a caller. The gateway uses the standard ASP.NET Core JWT bearer
/// authentication, so every OpenID Connect provider works.
/// </summary>
public sealed class CatGatewayAuthenticationOptions
{
    /// <summary>
    /// The address of the identity provider, such as the realm address of Keycloak.
    /// </summary>
    public string? Authority { get; set; }

    /// <summary>
    /// The audience a token must have.
    /// </summary>
    public string? Audience { get; set; }

    /// <summary>
    /// Whether the address of the identity provider must use HTTPS. The default is <c>true</c>.
    /// </summary>
    public bool RequireHttpsMetadata { get; set; } = true;
}

/// <summary>
/// The values a service gets when it does not set its own.
/// </summary>
public sealed class CatGatewayServiceDefaults
{
    /// <summary>
    /// Whether the gateway sends a gateway assertion to the services. The default is <c>false</c>.
    /// </summary>
    public bool GatewayOnly { get; set; }

    /// <summary>
    /// How long the gateway waits for a service to answer. The default is 30 seconds.
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}

/// <summary>
/// One service behind the gateway.
/// </summary>
public sealed class CatGatewayServiceOptions
{
    /// <summary>
    /// The address of the service. It can hold a path, which the gateway keeps in front of the path of the request.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// The addresses of the instances of the service, when there is more than one. Use this or
    /// <see cref="Address"/>.
    /// </summary>
    public string[] Addresses { get; set; } = [];

    /// <summary>
    /// The path the gateway listens on for this service. The default is <c>/</c> followed by the name of the service.
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// Whether the gateway removes <see cref="Path"/> before it calls the service. The default is <c>true</c>.
    /// </summary>
    public bool StripPrefix { get; set; } = true;

    /// <summary>
    /// The endpoints that need no token, such as <c>GET /books/**</c>. Every other endpoint of the service needs a
    /// valid token.
    /// </summary>
    /// <remarks>
    /// A pattern is an optional list of http methods separated by commas (or <c>*</c>), a space and a path. In the
    /// path, <c>*</c> stands for one segment and <c>**</c> for the rest of the path. The path is relative to
    /// <see cref="Path"/>.
    /// </remarks>
    public string[] Anonymous { get; set; } = [];

    /// <summary>
    /// Whether the gateway sends a gateway assertion to this service. The default comes from
    /// <see cref="CatGatewayServiceDefaults.GatewayOnly"/>.
    /// </summary>
    public bool? GatewayOnly { get; set; }

    /// <summary>
    /// How long the gateway waits for the service to answer. The default comes from
    /// <see cref="CatGatewayServiceDefaults.Timeout"/>.
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>
    /// The path the gateway calls to check the health of the service. Leave it empty to skip the check.
    /// </summary>
    public string? HealthCheckPath { get; set; }

    /// <summary>
    /// How often the gateway checks the health of the service. The default is 15 seconds.
    /// </summary>
    public TimeSpan HealthCheckInterval { get; set; } = TimeSpan.FromSeconds(15);
}

/// <summary>
/// The keys and the lifetime of the gateway assertion.
/// </summary>
public sealed class CatGatewayAssertionOptions
{
    /// <summary>
    /// The name of the issuer. A service checks it. The default is <c>cat-gateway</c>.
    /// </summary>
    public string Issuer { get; set; } = CatGatewayDefaults.DefaultIssuer;

    /// <summary>
    /// How long an assertion is valid. The default is 30 seconds.
    /// </summary>
    public TimeSpan Lifetime { get; set; } = CatGatewayDefaults.DefaultAssertionLifetime;

    /// <summary>
    /// The private signing key, as a PEM text of an elliptic curve key (P-256). Keep it in a secret store.
    /// </summary>
    public string? PrivateKeyPem { get; set; }

    /// <summary>
    /// The path of a file with the private signing key. Use this or <see cref="PrivateKeyPem"/>.
    /// </summary>
    public string? PrivateKeyPemFile { get; set; }

    /// <summary>
    /// The public keys of earlier signing keys. The gateway still publishes them, so a service accepts the
    /// assertions that are already out while you replace the signing key.
    /// </summary>
    public string[] PreviousPublicKeyPems { get; set; } = [];

    /// <summary>
    /// The path where the gateway publishes the public keys. The default is <c>/.well-known/cat-gateway/jwks.json</c>.
    /// </summary>
    public string JwksPath { get; set; } = CatGatewayDefaults.DefaultJwksPath;
}

/// <summary>
/// How many requests a caller may send. The gateway counts per remote address.
/// </summary>
public sealed class CatGatewayRateLimitOptions
{
    /// <summary>
    /// Whether the gateway limits the requests. The default is <c>true</c>.
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// The number of requests a caller may send in one <see cref="Window"/>. The default is 300.
    /// </summary>
    public int PermitLimit { get; set; } = 300;

    /// <summary>
    /// The length of the window. The default is one minute.
    /// </summary>
    public TimeSpan Window { get; set; } = TimeSpan.FromMinutes(1);
}

/// <summary>
/// Which browser origins may call the gateway. Cross-origin calls stay off until you list an origin.
/// </summary>
public sealed class CatGatewayCorsOptions
{
    /// <summary>
    /// The origins that may call the gateway, such as <c>https://shop.example.com</c>.
    /// </summary>
    public string[] AllowedOrigins { get; set; } = [];

    /// <summary>
    /// The methods a browser may use. The default is every method.
    /// </summary>
    public string[] AllowedMethods { get; set; } = [];

    /// <summary>
    /// The headers a browser may send. The default is every header.
    /// </summary>
    public string[] AllowedHeaders { get; set; } = [];

    /// <summary>
    /// Whether a browser may send credentials such as cookies. The default is <c>false</c>.
    /// </summary>
    public bool AllowCredentials { get; set; }
}

/// <summary>
/// The limits on a request.
/// </summary>
public sealed class CatGatewayLimitsOptions
{
    /// <summary>
    /// The largest request body in bytes. The default is 10 MB.
    /// </summary>
    public long MaxRequestBodySize { get; set; } = 10 * 1024 * 1024;
}

/// <summary>
/// Which headers the gateway removes or trusts.
/// </summary>
public sealed class CatGatewayHeadersOptions
{
    /// <summary>
    /// Headers the gateway removes from every request, on top of its own list. Use it for the headers your
    /// services read as an identity. The gateway always removes <c>X-Cat-Gateway-Assertion</c>, <c>X-User</c>,
    /// <c>X-User-Id</c>, <c>X-Forwarded-User</c>, <c>X-Authenticated-User</c>, <c>X-Remote-User</c> and
    /// <c>X-Original-User</c>.
    /// </summary>
    public string[] StripHeaders { get; set; } = [];

    /// <summary>
    /// Whether the gateway trusts the <c>X-Forwarded-*</c> headers of an earlier proxy in front of it and adds to
    /// them. The default is <c>false</c>, and then the gateway replaces them, so a caller cannot fake an address.
    /// </summary>
    public bool TrustForwardedHeaders { get; set; }
}
