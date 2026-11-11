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
    /// The extra properties of the message.
    /// </summary>
    public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
}
