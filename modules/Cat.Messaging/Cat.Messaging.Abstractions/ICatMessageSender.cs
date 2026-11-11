using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// The entry point for sending messages. Call it from a command handler, with the outbox on when a lost message is not acceptable.
/// </summary>
public interface ICatMessageSender
{
    /// <summary>
    /// Publishes an event to its topic.
    /// </summary>
    /// <param name="message">The event to publish.</param>
    /// <param name="scheduledAt">The moment the bus must deliver the event. Null means as soon as possible.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the event is sent, or stored when the outbox is on.</returns>
    public Task PublishAsync(ICatEventMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a command message to its queue.
    /// </summary>
    /// <param name="message">The command message to send.</param>
    /// <param name="scheduledAt">The moment the bus must deliver the message. Null means as soon as possible.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the message is sent, or stored when the outbox is on.</returns>
    public Task SendAsync(ICatCommandMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default);
}
