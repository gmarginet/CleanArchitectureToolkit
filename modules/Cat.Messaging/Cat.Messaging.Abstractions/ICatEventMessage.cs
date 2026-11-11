namespace Cat.Messaging.Abstractions;

/// <summary>
/// Marks a message as an event: something happened.
/// Many services may listen, and the sender does not care if nobody does. It goes to a topic.
/// </summary>
public interface ICatEventMessage : ICatMessage
{
}
