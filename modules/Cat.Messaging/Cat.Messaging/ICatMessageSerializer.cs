using System;

namespace Cat.Messaging;

/// <summary>
/// The small internal seam around the serializer. Only System.Text.Json sits behind it for now.
/// </summary>
internal interface ICatMessageSerializer
{
    /// <summary>
    /// The content type that goes on every message, so a receiver knows how to read the body.
    /// </summary>
    string ContentType { get; }

    /// <summary>
    /// Serializes a message with its runtime type, so the properties of a derived type are not lost.
    /// </summary>
    byte[] Serialize(object message, Type messageType);
}
