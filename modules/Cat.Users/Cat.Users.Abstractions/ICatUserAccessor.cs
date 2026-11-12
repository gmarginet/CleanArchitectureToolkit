namespace Cat.Users.Abstractions;

/// <summary>
/// Holds the user of the current scope.
/// A worker, such as the event processor or the scheduler, sets the user for the work it starts.
/// </summary>
public interface ICatUserAccessor
{
    /// <summary>
    /// The user of the current scope.
    /// When nobody has set a user, this is the user of the HTTP request when there is one, and the anonymous user otherwise.
    /// Running as the system is never a default. A worker sets <see cref="CatUser.System"/> on purpose.
    /// </summary>
    ICatUser User { get; set; }
}
