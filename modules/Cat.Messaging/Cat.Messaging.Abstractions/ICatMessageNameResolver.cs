using System;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// Finds the names a message type uses on the bus, by convention or from <see cref="CatMessageAttribute"/>.
/// </summary>
public interface ICatMessageNameResolver
{
    /// <summary>
    /// Gets the name of the queue or topic, and the subject, of a message type.
    /// </summary>
    /// <param name="messageType">The message type.</param>
    /// <returns>The name from <see cref="CatMessageAttribute.Name"/>, or the name of the type.</returns>
    public string GetName(Type messageType);

    /// <summary>
    /// Tells whether a message type goes to an entity that needs sessions.
    /// </summary>
    /// <param name="messageType">The message type.</param>
    /// <returns>True when <see cref="CatMessageAttribute.RequiresSession"/> is set.</returns>
    public bool RequiresSession(Type messageType);

    /// <summary>
    /// Tells whether a message type is an event or a command message.
    /// </summary>
    /// <param name="messageType">The message type.</param>
    /// <returns>The kind of the message.</returns>
    /// <exception cref="ArgumentException">The type is neither an <see cref="ICatEventMessage"/> nor an <see cref="ICatCommandMessage"/>, or it is both.</exception>
    public CatMessageKind GetKind(Type messageType);
}
