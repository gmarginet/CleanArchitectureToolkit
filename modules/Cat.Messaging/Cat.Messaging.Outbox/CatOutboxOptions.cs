using System;

namespace Cat.Messaging.Outbox;

/// <summary>
/// Settings of the outbox sender.
/// </summary>
public class CatOutboxOptions
{
    /// <summary>
    /// How long the sender waits before it looks for pending messages again. The default is 5 seconds.
    /// </summary>
    public TimeSpan PollInterval { get; set; } = TimeSpan.FromSeconds(5);

    /// <summary>
    /// The maximum number of messages the sender takes in one round. The default is 50.
    /// </summary>
    public int BatchSize { get; set; } = 50;
}
