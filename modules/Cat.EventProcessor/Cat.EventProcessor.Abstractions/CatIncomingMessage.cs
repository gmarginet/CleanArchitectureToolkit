using System;
using System.Collections.Generic;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// A message that arrived from the broker, before it is turned into a service request. It knows nothing about a specific broker.
/// </summary>
public class CatIncomingMessage
{
    /// <summary>
    /// The serialized message.
    /// </summary>
    public byte[] Body { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// The content type of the body, such as <c>application/json</c>. Empty is read as JSON.
    /// </summary>
    public string ContentType { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the message, as the sender set it.
    /// </summary>
    public string MessageId { get; set; } = string.Empty;

    /// <summary>
    /// How many times the bus delivered the message, this one included.
    /// </summary>
    public int DeliveryCount { get; set; } = 1;

    /// <summary>
    /// The moment the bus received the message. The bus sets it, so the sender cannot fake it.
    /// For a scheduled message the emulator sets the scheduled time. Null when the broker does not tell.
    /// </summary>
    public DateTimeOffset? EnqueuedTime { get; set; }

    /// <summary>
    /// True when the sender gave the message a scheduled time. The token of such a message is checked without its lifetime,
    /// because the token was made when the message was sent and it is expired when the bus delivers the message.
    /// </summary>
    public bool IsScheduled { get; set; }

    /// <summary>
    /// The extra properties of the message.
    /// </summary>
    public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
}
