using System.Security.Claims;
using Cat.EventProcessor.Abstractions;
using Cat.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cat.EventProcessor.Authorization;

/// <summary>
/// Validates the token of a message with the JWT bearer options of the service, the same way the HTTP side does,
/// with one difference: the lifetime is checked against the time the bus received the message, not against the clock now.
/// </summary>
internal sealed class CatMessageTokenValidator
{
    private readonly IOptionsMonitor<JwtBearerOptions> _jwtOptions;
    private readonly IOptions<CatUsersOptions> _usersOptions;
    private readonly IOptions<CatMessageAuthorizationOptions> _options;

    public CatMessageTokenValidator(IOptionsMonitor<JwtBearerOptions> jwtOptions, IOptions<CatUsersOptions> usersOptions,
        IOptions<CatMessageAuthorizationOptions> options)
    {
        _jwtOptions = jwtOptions;
        _usersOptions = usersOptions;
        _options = options;
    }

    /// <summary>
    /// Validates the token.
    /// </summary>
    /// <returns>The principal, or null with the reason of the failure.</returns>
    public async Task<(ClaimsPrincipal? Principal, string Failure)> ValidateAsync(string token, CatIncomingMessage message,
        CancellationToken cancellationToken)
    {
        var jwt = _jwtOptions.Get(_options.Value.AuthenticationScheme);
        var parameters = jwt.TokenValidationParameters.Clone();

        if (jwt.ConfigurationManager != null)
        {
            var configuration = await jwt.ConfigurationManager.GetConfigurationAsync(cancellationToken).ConfigureAwait(false);
            var issuers = new[] { configuration.Issuer };
            parameters.ValidIssuers = parameters.ValidIssuers?.Concat(issuers) ?? issuers;
            parameters.IssuerSigningKeys = parameters.IssuerSigningKeys?.Concat(configuration.SigningKeys) ?? configuration.SigningKeys;
        }

        // The roles come from the claim of Cat.Users, so a role policy and ICatUser.IsInRole read the same claim.
        parameters.RoleClaimType = _usersOptions.Value.RoleClaimType;

        if (message.IsScheduled)
        {
            // The token of a scheduled message was made when it was sent and is expired when the bus delivers it.
            // The signature, the issuer and the audience are still checked.
            parameters.ValidateLifetime = false;
        }
        else
        {
            var arrival = message.EnqueuedTime ?? DateTimeOffset.UtcNow;
            parameters.ValidateLifetime = true;
            parameters.LifetimeValidator = (notBefore, expires, _, validation) =>
                IsAlive(notBefore, expires, arrival.UtcDateTime, validation.ClockSkew);
        }

        string failure = "No token handler accepted the token.";
        foreach (var handler in jwt.TokenHandlers)
        {
            var result = await handler.ValidateTokenAsync(token, parameters).ConfigureAwait(false);
            if (result.IsValid)
            {
                return (new ClaimsPrincipal(result.ClaimsIdentity), string.Empty);
            }

            failure = result.Exception?.Message ?? failure;
        }

        return (null, failure);
    }

    private static bool IsAlive(DateTime? notBefore, DateTime? expires, DateTime arrival, TimeSpan skew)
    {
        if (expires.HasValue && expires.Value.ToUniversalTime() + skew < arrival)
        {
            return false;
        }

        return !notBefore.HasValue || notBefore.Value.ToUniversalTime() - skew <= arrival;
    }
}
