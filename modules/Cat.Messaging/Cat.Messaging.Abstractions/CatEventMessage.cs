using System;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// Base class for an event, such as <c>OrderPlaced</c>.
/// A new instance gets a new <see cref="MessageId"/>, a new <see cref="CorrelationId"/> and the current time.
/// Set <see cref="CorrelationId"/> to the ID of the flow when the event belongs to a flow that already started.
/// </summary>
public abstract class CatEventMessage : ICatEventMessage
{
    /// <inheritdoc />
    public Guid MessageId { get; set; } = Guid.NewGuid();

    /// <inheritdoc />
    public Guid CorrelationId { get; set; } = Guid.NewGuid();

    /// <inheritdoc />
    public DateTimeOffset OccurredAt { get; set; } = DateTimeOffset.UtcNow;
}
