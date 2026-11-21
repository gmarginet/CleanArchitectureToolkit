using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// Sends messages that carry the token of the system, and never the token of a user. Use it for work that has no user,
/// such as a webhook of a payment provider that hands its work off as a message.
/// </summary>
/// <remarks>
/// Running as the system is never a default. Only the code that injects this interface can do it, so a handler that runs for a user
/// cannot do it by accident, and a search for the type finds every place that does. The receiver still checks the policy of the
/// message type against the system token. <see cref="ICatMessageSender"/> stays as it is.
/// </remarks>
public interface ICatSystemMessageSender
{
    /// <summary>
    /// Publishes an event to its topic, with the token of the system.
    /// </summary>
    /// <param name="message">The event to publish.</param>
    /// <param name="scheduledAt">The moment the bus must deliver the event. Null means as soon as possible.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the event is sent, or stored when the outbox is on.</returns>
    public Task PublishAsync(ICatEventMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a command message to its queue, with the token of the system.
    /// </summary>
    /// <param name="message">The command message to send.</param>
    /// <param name="scheduledAt">The moment the bus must deliver the message. Null means as soon as possible.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the message is sent, or stored when the outbox is on.</returns>
    public Task SendAsync(ICatCommandMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default);
}