using System;
using System.Collections.Generic;
using Cat.Messaging.Abstractions;
using Cat.Sagas.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// The saga that runs in this scope. The runner and the dispatcher set it before the workflow runs, and the wait step uses it
/// to hand over its request message, so the message goes out only after the state is saved.
/// </summary>
public sealed class CatSagaContext : ICatSagaContext
{
    /// <inheritdoc />
    public Guid InstanceId { get; private set; }

    internal List<ICatMessage> Pending { get; } = new List<ICatMessage>();

    internal string? WaitingFor { get; set; }

    internal void Begin(Guid instanceId)
    {
        InstanceId = instanceId;
        Pending.Clear();
        WaitingFor = null;
    }
}
