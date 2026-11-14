using System;
using System.Collections.Generic;
using Cat.Messaging.Abstractions;
using Cat.Sagas.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// The saga that runs in this scope. The runner and the dispatcher set it before the workflow runs, and the wait step uses it
/// to hand over its request message and its wait, so the messages go out only after the state is saved.
/// </summary>
public sealed class CatSagaContext : ICatSagaContext
{
    /// <inheritdoc />
    public Guid InstanceId { get; private set; }

    internal List<CatPendingMessage> Pending { get; } = new List<CatPendingMessage>();

    internal List<CatSagaWait> Waits { get; } = new List<CatSagaWait>();

    internal void Begin(Guid instanceId)
    {
        InstanceId = instanceId;
        Pending.Clear();
        Waits.Clear();
    }
}

/// <summary>
/// A message a step wants to send, with the moment the bus must deliver it.
/// </summary>
internal sealed class CatPendingMessage
{
    public CatPendingMessage(ICatMessage message, DateTimeOffset? scheduledAt)
    {
        Message = message;
        ScheduledAt = scheduledAt;
    }

    public ICatMessage Message { get; }

    public DateTimeOffset? ScheduledAt { get; }
}
