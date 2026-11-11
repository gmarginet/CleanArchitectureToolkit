namespace Cat.Messaging.Abstractions;

/// <summary>
/// The kind of a message, which decides between a queue and a topic.
/// </summary>
public enum CatMessageKind
{
    /// <summary>
    /// A command message. It goes to a queue.
    /// </summary>
    Command = 0,

    /// <summary>
    /// An event. It goes to a topic.
    /// </summary>
    Event = 1
}
