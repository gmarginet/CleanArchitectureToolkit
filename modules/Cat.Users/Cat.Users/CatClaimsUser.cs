using System;
using System.Linq;
using System.Security.Claims;
using Cat.Users.Abstractions;

namespace Cat.Users;

/// <summary>
/// An <see cref="ICatUser"/> read from the claims of a <see cref="ClaimsPrincipal"/>.
/// The gateway and the service validate the token. This class only reads it.
/// </summary>
public class CatClaimsUser : ICatUser
{
    private readonly ClaimsPrincipal _principal;
    private readonly CatUsersOptions _options;

    /// <summary>
    /// Creates the user.
    /// </summary>
    /// <param name="principal">The principal of the token.</param>
    /// <param name="options">The names of the claims.</param>
    public CatClaimsUser(ClaimsPrincipal principal, CatUsersOptions options)
    {
        _principal = principal ?? throw new ArgumentNullException(nameof(principal));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <inheritdoc />
    public bool IsAuthenticated => _principal.Identity?.IsAuthenticated == true;

    /// <inheritdoc />
    public string UserId => _principal.FindFirst(_options.UserIdClaimType)?.Value ?? string.Empty;

    /// <inheritdoc />
    public string Name =>
        _principal.FindFirst(_options.NameClaimType)?.Value
        ?? _principal.FindFirst("preferred_username")?.Value
        ?? string.Empty;

    /// <inheritdoc />
    public bool IsInRole(string role) =>
        _principal.FindAll(_options.RoleClaimType).Any(claim => string.Equals(claim.Value, role, StringComparison.Ordinal));
}
