using System;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// Overrides the conventions of a message type.
/// Without it the queue, topic and subject use the name of the message type, and sessions are off.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, Inherited = false)]
public sealed class CatMessageAttribute : Attribute
{
    /// <summary>
    /// The name of the queue or topic, and the subject of the message. When it is null the name of the type is used.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Whether the queue needs sessions. Only a command message uses it, because it goes to a queue.
    /// The message must implement <see cref="ICatSessionMessage"/> too.
    /// </summary>
    public bool RequiresSession { get; set; }
}
