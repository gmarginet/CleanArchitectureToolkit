namespace Cat.Messaging.Abstractions;

/// <summary>
/// A message that belongs to a session. Messages with the same session ID are handled in order, one receiver at a time.
/// Implement it on a message that goes to an entity that needs sessions, see <see cref="CatMessageAttribute.RequiresSession"/>.
/// </summary>
public interface ICatSessionMessage : ICatMessage
{
    /// <summary>
    /// The session this message belongs to, such as an order number.
    /// </summary>
    public string SessionId { get; }
}
