namespace Cat.Users;

/// <summary>
/// The names of the claims that the user is built from.
/// The defaults fit a token with a flat <c>roles</c> claim, such as the one the demo gets from Keycloak.
/// A developer on another identity provider changes the values.
/// </summary>
public class CatUsersOptions
{
    /// <summary>
    /// The claim with the id of the user. The default is <c>sub</c>.
    /// </summary>
    public string UserIdClaimType { get; set; } = "sub";

    /// <summary>
    /// The claim with the display name. The default is <c>name</c>. When it is missing, <c>preferred_username</c> is used.
    /// </summary>
    public string NameClaimType { get; set; } = "name";

    /// <summary>
    /// The claim that holds the roles, one claim per role. The default is <c>roles</c>.
    /// Use the same value as the role claim type of the token validation, so that a role policy and <see cref="Abstractions.ICatUser.IsInRole(string)"/> read the same claim.
    /// </summary>
    public string RoleClaimType { get; set; } = "roles";
}
