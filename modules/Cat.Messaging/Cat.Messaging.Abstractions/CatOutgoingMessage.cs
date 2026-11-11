using System;
using System.Collections.Generic;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// A message that is ready to leave the service: serialized, with the name of its entity and its properties.
/// It is what the transport sends and what the outbox stores. It knows nothing about a specific broker.
/// </summary>
public class CatOutgoingMessage
{
    /// <summary>
    /// The name of the queue or the topic the message goes to.
    /// </summary>
    public string EntityName { get; set; } = string.Empty;

    /// <summary>
    /// Whether <see cref="EntityName"/> is a queue (command) or a topic (event).
    /// </summary>
    public CatMessageKind Kind { get; set; }

    /// <summary>
    /// The serialized message.
    /// </summary>
    public byte[] Body { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// The content type of <see cref="Body"/>, such as <c>application/json</c>. A receiver uses it to pick the deserializer.
    /// </summary>
    public string ContentType { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the message, from <see cref="ICatMessage.MessageId"/>.
    /// </summary>
    public Guid MessageId { get; set; }

    /// <summary>
    /// The ID of the business flow, from <see cref="ICatMessage.CorrelationId"/>.
    /// </summary>
    public Guid CorrelationId { get; set; }

    /// <summary>
    /// The subject of the message. A receiver uses it to find the message type.
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// The session of the message, from <see cref="ICatSessionMessage.SessionId"/>. Null when the message has no session.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary>
    /// The moment the bus must deliver the message. Null means as soon as possible.
    /// </summary>
    public DateTimeOffset? ScheduledAt { get; set; }

    /// <summary>
    /// Extra properties of the message, such as the headers a receiver needs.
    /// </summary>
    public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
}
