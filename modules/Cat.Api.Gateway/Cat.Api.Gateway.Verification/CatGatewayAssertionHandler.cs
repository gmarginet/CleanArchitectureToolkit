using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Cat.Api.Gateway.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Cat.Api.Gateway.Verification;

/// <summary>
/// Checks the gateway assertion of a request: the signature, the issuer, the audience and the lifetime.
/// </summary>
/// <remarks>
/// The handler accepts one algorithm only, <c>ES256</c>. A token that asks for another algorithm fails, so a
/// caller cannot trick the service into a weaker check.
/// </remarks>
internal sealed class CatGatewayAssertionHandler : AuthenticationHandler<CatGatewayVerificationOptions>
{
    private static readonly JsonWebTokenHandler TokenHandler = new();

    private readonly CatGatewayKeyProvider _keys;

    public CatGatewayAssertionHandler(
        IOptionsMonitor<CatGatewayVerificationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        CatGatewayKeyProvider keys)
        : base(options, logger, encoder)
    {
        _keys = keys;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(CatGatewayDefaults.AssertionHeaderName, out var values) || values.Count == 0)
            return AuthenticateResult.NoResult();

        if (values.Count > 1) return AuthenticateResult.Fail("The request has more than one gateway assertion.");

        var token = values[0]!;
        string? keyId;
        try
        {
            keyId = new JsonWebToken(token).Kid;
        }
        catch (Exception)
        {
            return AuthenticateResult.Fail("The gateway assertion is not a token.");
        }

        var parameters = new TokenValidationParameters
        {
            ValidIssuer = Options.Issuer,
            ValidAudience = Options.Audience,
            ValidAlgorithms = [CatGatewayDefaults.SigningAlgorithm],
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            RequireSignedTokens = true,
            RequireExpirationTime = true,
            ClockSkew = Options.ClockSkew,
            IssuerSigningKeys = await _keys.GetKeysAsync(keyId, Context.RequestAborted)
        };

        var result = await TokenHandler.ValidateTokenAsync(token, parameters);
        if (!result.IsValid)
        {
            Logger.LogWarning("A gateway assertion was rejected: {Reason}", result.Exception?.GetType().Name ?? "invalid");
            return AuthenticateResult.Fail("The gateway assertion is not valid.");
        }

        var principal = new ClaimsPrincipal(new ClaimsIdentity(
            new List<Claim> { new(ClaimTypes.Name, Options.Issuer) },
            Scheme.Name));
        return AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name));
    }
}
