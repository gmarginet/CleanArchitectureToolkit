using System;
using System.Collections.Generic;
using Cat.Users.Abstractions;

namespace Cat.UnitTesting.Users;

/// <summary>
/// A user for unit tests. The test sets the id, the name, the login state and the roles.
/// It starts as a logged in user without roles. Use <see cref="CatUser"/> when the user never changes during the test.
/// Derive from it to add the properties of your own application, such as an email address.
/// </summary>
public class FakeUser : ICatUser
{
    /// <summary>
    /// The id of the user. It starts as <c>test-user</c>.
    /// </summary>
    public string UserId { get; set; } = "test-user";

    /// <summary>
    /// The display name of the user. It starts as <c>Test User</c>.
    /// </summary>
    public string Name { get; set; } = "Test User";

    /// <summary>
    /// Whether the user is logged in. It starts as <c>true</c>.
    /// </summary>
    public bool IsAuthenticated { get; set; } = true;

    /// <summary>
    /// The roles of the user. Add to it or remove from it during the test.
    /// </summary>
    public HashSet<string> Roles { get; } = new HashSet<string>(StringComparer.Ordinal);

    /// <summary>
    /// Gives the user these roles.
    /// </summary>
    /// <param name="roles">The roles to add.</param>
    /// <returns>The user, so calls can be chained.</returns>
    public FakeUser InRole(params string[] roles)
    {
        foreach (var role in roles)
        {
            Roles.Add(role);
        }

        return this;
    }

    /// <inheritdoc />
    public bool IsInRole(string role) => Roles.Contains(role);
}
