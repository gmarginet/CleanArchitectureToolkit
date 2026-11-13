namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// The answer of the authorization of a message.
/// </summary>
public sealed class CatAuthorizationResult
{
    /// <summary>
    /// The reason of a message that has no valid token or whose caller is not known.
    /// </summary>
    public const string UnauthorizedReason = "Unauthorized";

    /// <summary>
    /// The reason of a message whose caller is known but is not allowed.
    /// </summary>
    public const string ForbiddenReason = "Forbidden";

    private CatAuthorizationResult(bool succeeded, string reason, string description)
    {
        Succeeded = succeeded;
        Reason = reason;
        Description = description;
    }

    /// <summary>
    /// True when the handler may run.
    /// </summary>
    public bool Succeeded { get; }

    /// <summary>
    /// A short reason for the dead letter queue, <see cref="UnauthorizedReason"/> or <see cref="ForbiddenReason"/>. Empty on success.
    /// </summary>
    public string Reason { get; }

    /// <summary>
    /// A longer description for the dead letter queue. Empty on success.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// The handler may run.
    /// </summary>
    public static CatAuthorizationResult Success { get; } = new CatAuthorizationResult(true, string.Empty, string.Empty);

    /// <summary>
    /// The message has no valid token, or the caller is not known and the message type needs a caller.
    /// </summary>
    /// <param name="description">What went wrong.</param>
    /// <returns>The failed result.</returns>
    public static CatAuthorizationResult Unauthorized(string description) =>
        new CatAuthorizationResult(false, UnauthorizedReason, description);

    /// <summary>
    /// The caller is known and is not allowed.
    /// </summary>
    /// <param name="description">What went wrong.</param>
    /// <returns>The failed result.</returns>
    public static CatAuthorizationResult Forbidden(string description) =>
        new CatAuthorizationResult(false, ForbiddenReason, description);
}
