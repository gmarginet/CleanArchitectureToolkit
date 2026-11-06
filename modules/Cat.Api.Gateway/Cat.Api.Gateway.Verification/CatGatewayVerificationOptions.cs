using System;
using Cat.Api.Gateway.Abstractions;
using Microsoft.AspNetCore.Authentication;

namespace Cat.Api.Gateway.Verification;

/// <summary>
/// The settings of a service that only accepts calls that come from the gateway. They bind to the
/// <c>CatGatewayVerification</c> section.
/// </summary>
/// <remarks>
/// The service needs the public key of the gateway. Give it the address where the gateway publishes its keys
/// (<see cref="JwksAddress"/>), a fixed key (<see cref="PublicKeyPems"/>), or both. The settings are read when the
/// service starts.
/// </remarks>
public sealed class CatGatewayVerificationOptions : AuthenticationSchemeOptions
{
    /// <summary>
    /// The name of the configuration section.
    /// </summary>
    public const string SectionName = "CatGatewayVerification";

    /// <summary>
    /// The name of this service, as the gateway knows it. The assertion is for one service only, and the service
    /// rejects an assertion that names another one.
    /// </summary>
    public string? Audience { get; set; }

    /// <summary>
    /// The issuer of the assertion. It must match <c>Assertion:Issuer</c> of the gateway. The default is
    /// <c>cat-gateway</c>.
    /// </summary>
    public string Issuer { get; set; } = CatGatewayDefaults.DefaultIssuer;

    /// <summary>
    /// The address of the keys of the gateway, such as <c>https://gateway/.well-known/cat-gateway/jwks.json</c>.
    /// Use HTTPS when the network between the service and the gateway is not trusted. Whoever can change the
    /// answer can sign assertions.
    /// </summary>
    public string? JwksAddress { get; set; }

    /// <summary>
    /// Public keys as PEM text (P-256). Use it instead of, or next to, <see cref="JwksAddress"/>.
    /// </summary>
    public string[] PublicKeyPems { get; set; } = [];

    /// <summary>
    /// How long the service keeps the downloaded keys. The default is 10 minutes.
    /// </summary>
    public TimeSpan JwksRefreshInterval { get; set; } = TimeSpan.FromMinutes(10);

    /// <summary>
    /// The shortest time between two downloads, also when an assertion has an unknown key. It stops a caller from
    /// making the service download the keys over and over. The default is 30 seconds.
    /// </summary>
    public TimeSpan JwksMinimumRefreshInterval { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>
    /// How much the clocks of the gateway and the service may differ. The default is 10 seconds.
    /// </summary>
    public TimeSpan ClockSkew { get; set; } = TimeSpan.FromSeconds(10);
}
