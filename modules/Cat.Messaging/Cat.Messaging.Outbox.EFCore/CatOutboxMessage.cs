using Cat.Messaging.Abstractions;

namespace Cat.Messaging.Outbox.EFCore;

/// <summary>
/// One row of the outbox table.
/// </summary>
public class CatOutboxMessage
{
    /// <summary>
    /// The ID of the row.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// When the row was added.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// When the message was sent to the transport. Null while it is pending.
    /// </summary>
    public DateTimeOffset? SentAt { get; set; }

    /// <summary>
    /// The queue or topic name.
    /// </summary>
    public string EntityName { get; set; } = string.Empty;

    /// <summary>
    /// Whether the message is a command message (queue) or an event (topic).
    /// </summary>
    public CatMessageKind Kind { get; set; }

    /// <summary>
    /// The serialized message.
    /// </summary>
    public byte[] Body { get; set; } = [];

    /// <summary>
    /// The content type of the body.
    /// </summary>
    public string ContentType { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the message.
    /// </summary>
    public Guid MessageId { get; set; }

    /// <summary>
    /// The ID of the business flow.
    /// </summary>
    public Guid CorrelationId { get; set; }

    /// <summary>
    /// The subject of the message.
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// The session of the message, if it has one.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary>
    /// The moment the bus must deliver the message, if it is scheduled.
    /// </summary>
    public DateTimeOffset? ScheduledAt { get; set; }

    /// <summary>
    /// The extra properties of the message, as JSON. Null when there are none.
    /// </summary>
    public string? PropertiesJson { get; set; }
}
