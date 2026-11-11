using System;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// A message type the service receives, with its settings.
/// </summary>
public class CatReceiveRegistration
{
    /// <summary>
    /// Creates a registration.
    /// </summary>
    /// <param name="messageType">The message type.</param>
    /// <param name="options">The settings of the message type.</param>
    public CatReceiveRegistration(Type messageType, CatReceiveOptions options)
    {
        MessageType = messageType;
        Options = options;
    }

    /// <summary>
    /// The message type.
    /// </summary>
    public Type MessageType { get; }

    /// <summary>
    /// The settings of the message type.
    /// </summary>
    public CatReceiveOptions Options { get; }
}
