using System;
using System.Collections.Generic;
using System.Linq;

namespace Cat.Users.Abstractions;

/// <summary>
/// A plain, immutable <see cref="ICatUser"/>.
/// It is the anonymous user, the system user of a worker, or any user a developer builds by hand.
/// </summary>
public sealed class CatUser : ICatUser
{
    /// <summary>
    /// The role of the system user.
    /// </summary>
    public const string SystemRole = "system";

    private readonly HashSet<string> _roles;

    /// <summary>
    /// Creates a user.
    /// </summary>
    /// <param name="userId">The id of the user.</param>
    /// <param name="name">The display name of the user.</param>
    /// <param name="isAuthenticated">True when the caller is known.</param>
    /// <param name="roles">The roles of the user.</param>
    public CatUser(string userId, string name, bool isAuthenticated, IEnumerable<string>? roles = null)
    {
        UserId = userId ?? string.Empty;
        Name = name ?? string.Empty;
        IsAuthenticated = isAuthenticated;
        _roles = new HashSet<string>(roles ?? Enumerable.Empty<string>(), StringComparer.Ordinal);
    }

    /// <summary>
    /// The user that is not authenticated: no id, no name and no roles.
    /// A rule that needs a login denies it.
    /// </summary>
    public static CatUser Anonymous { get; } = new(string.Empty, string.Empty, false);

    /// <summary>
    /// Creates the named user of a worker. It is authenticated and has the role <see cref="SystemRole"/>.
    /// </summary>
    /// <param name="serviceName">The name of the service, used as the id and the name of the user.</param>
    /// <returns>The system user.</returns>
    public static CatUser System(string serviceName) => new(serviceName, serviceName, true, new[] { SystemRole });

    /// <inheritdoc />
    public string UserId { get; }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public bool IsAuthenticated { get; }

    /// <inheritdoc />
    public bool IsInRole(string role) => _roles.Contains(role);
}
