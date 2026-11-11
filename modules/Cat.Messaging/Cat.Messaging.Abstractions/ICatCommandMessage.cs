namespace Cat.Messaging.Abstractions;

/// <summary>
/// Marks a message as a command message: do this.
/// One receiver must do it, and it must not get lost when the receiver is down. It goes to a queue.
/// </summary>
public interface ICatCommandMessage : ICatMessage
{
}
