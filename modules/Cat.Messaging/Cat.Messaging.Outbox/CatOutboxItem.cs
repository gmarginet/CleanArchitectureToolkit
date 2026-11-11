using System;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging.Outbox;

/// <summary>
/// A message that waits in the outbox to be sent.
/// </summary>
public class CatOutboxItem
{
    /// <summary>
    /// The ID of the outbox row. The store uses it to mark the row as sent.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The stored message.
    /// </summary>
    public CatOutgoingMessage Message { get; set; } = new CatOutgoingMessage();
}
