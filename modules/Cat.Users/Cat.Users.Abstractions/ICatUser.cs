namespace Cat.Users.Abstractions;

/// <summary>
/// The user behind a request or a message.
/// Business logic knows only this interface, never the HTTP context or the token.
/// </summary>
public interface ICatUser
{
    /// <summary>
    /// The id of the user at the identity provider. Empty when the user is not authenticated.
    /// </summary>
    string UserId { get; }

    /// <summary>
    /// The display name of the user. Empty when it is not known.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// True when the caller is known. Anonymous work is not authenticated.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Tells whether the user has the role.
    /// </summary>
    /// <param name="role">The name of the role. The comparison is case sensitive.</param>
    /// <returns>True when the user has the role.</returns>
    bool IsInRole(string role);
}
