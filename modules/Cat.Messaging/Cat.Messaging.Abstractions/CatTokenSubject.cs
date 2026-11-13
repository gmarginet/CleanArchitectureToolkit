namespace Cat.Messaging.Abstractions;

/// <summary>
/// Whose token a message carries.
/// </summary>
public enum CatTokenSubject
{
    /// <summary>
    /// The user or the caller that the work is done for. The sender asks for it for a message that goes out now.
    /// </summary>
    CurrentUser = 0,

    /// <summary>
    /// The sending system, not a user. The sender asks for it for a message that has a scheduled time,
    /// because a token of a user is expired when the bus delivers the message.
    /// </summary>
    System = 1
}
