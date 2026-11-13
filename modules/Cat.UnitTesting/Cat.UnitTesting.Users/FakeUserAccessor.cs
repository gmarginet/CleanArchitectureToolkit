using Cat.Users.Abstractions;

namespace Cat.UnitTesting.Users;

/// <summary>
/// A user accessor for unit tests. The test sets <see cref="User"/> at any moment.
/// It starts with <see cref="CatUser.Anonymous"/>, like a request without a login.
/// </summary>
public class FakeUserAccessor : ICatUserAccessor
{
    /// <summary>
    /// The current user.
    /// </summary>
    public ICatUser User { get; set; } = CatUser.Anonymous;
}
