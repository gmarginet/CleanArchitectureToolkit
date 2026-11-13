using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;

namespace Cat.UnitTesting.Messaging;

/// <summary>
/// A message sender for unit tests. It records the events that were published and the commands that were sent,
/// in one list and in order. It sends nothing.
/// </summary>
public class FakeMessageSender : ICatMessageSender
{
    /// <summary>
    /// Every message that was published or sent, in order.
    /// </summary>
    public List<SentMessage> Sent { get; } = new List<SentMessage>();

    /// <summary>
    /// Gives the messages of one type, in order. The type can be a message class, or <see cref="ICatEventMessage"/> or <see cref="ICatCommandMessage"/>.
    /// </summary>
    /// <typeparam name="T">The message type.</typeparam>
    /// <returns>The messages of this type.</returns>
    public IEnumerable<T> Of<T>() => Sent.Select(sent => sent.Message).OfType<T>();

    /// <summary>
    /// Clears the recorded messages.
    /// </summary>
    public void Reset() => Sent.Clear();

    /// <inheritdoc />
    public Task PublishAsync(ICatEventMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default)
    {
        Sent.Add(new SentMessage(message, scheduledAt));
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task SendAsync(ICatCommandMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default)
    {
        Sent.Add(new SentMessage(message, scheduledAt));
        return Task.CompletedTask;
    }
}

/// <summary>
/// One message that the <see cref="FakeMessageSender"/> got.
/// </summary>
public sealed class SentMessage
{
    /// <summary>
    /// Creates a record of one message.
    /// </summary>
    /// <param name="message">The event or command message.</param>
    /// <param name="scheduledAt">The time the caller asked to send it at, or <c>null</c> for now.</param>
    public SentMessage(ICatMessage message, DateTimeOffset? scheduledAt)
    {
        Message = message;
        ScheduledAt = scheduledAt;
    }

    /// <summary>
    /// The event or command message.
    /// </summary>
    public ICatMessage Message { get; }

    /// <summary>
    /// The time the caller asked to send it at, or <c>null</c> for now.
    /// </summary>
    public DateTimeOffset? ScheduledAt { get; }
}
