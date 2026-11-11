using System;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// A message that travels over the bus.
/// Inherit <see cref="CatEventMessage"/> or <see cref="CatCommandMessage"/> when you can.
/// Implement <see cref="ICatEventMessage"/> or <see cref="ICatCommandMessage"/> when the type cannot inherit.
/// </summary>
public interface ICatMessage
{
    /// <summary>
    /// Identifies this message. It is copied to the message ID of the bus, which duplicate detection uses.
    /// </summary>
    public Guid MessageId { get; }

    /// <summary>
    /// Follows a business flow across services. Create it at the start of a flow and copy it to every message that follows from it.
    /// </summary>
    public Guid CorrelationId { get; }

    /// <summary>
    /// The moment the thing happened or the work was asked for.
    /// </summary>
    public DateTimeOffset OccurredAt { get; }
}
