using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;
using Cat.Sql.Cdc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Sql.Cdc.Messaging;

/// <summary>
/// Sends the changes as event messages through <see cref="ICatMessageSender"/>.
/// The message id is always the id of the change, so the bus can drop a repeat.
/// It sends straight to the transport and does not use an outbox: the position of the reader is the safety net, and a failed send repeats the change.
/// </summary>
public class CatMessagingChangeSink : ICatChangeSink
{
    private readonly IServiceScopeFactory _scopeFactory;

    /// <summary>
    /// Creates the sink.
    /// </summary>
    /// <param name="scopeFactory">Gives a scope for every message, because the message sender is scoped.</param>
    public CatMessagingChangeSink(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    /// <inheritdoc />
    /// <exception cref="InvalidOperationException">The message is not an event message, or it has another id than the change and cannot be set.</exception>
    public async Task SendAsync(CatChange change, object message, CancellationToken cancellationToken = default)
    {
        var eventMessage = message switch
        {
            CatChange => Convert(change),
            ICatEventMessage typed => typed,
            _ => throw new InvalidOperationException(
                $"The message type {message.GetType().Name} of table '{change.Table}' must implement ICatEventMessage to be sent through Cat.Messaging.")
        };

        if (eventMessage is CatEventMessage settable)
        {
            settable.MessageId = change.MessageId;
        }
        else if (eventMessage.MessageId != change.MessageId)
        {
            throw new InvalidOperationException(
                $"The message {eventMessage.GetType().Name} of table '{change.Table}' must use the MessageId of the change. Derive from CatEventMessage or copy change.MessageId.");
        }

        using var scope = _scopeFactory.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ICatMessageSender>();
        await sender.PublishAsync(eventMessage, null, cancellationToken).ConfigureAwait(false);
    }

    private static CatCdcChangeMessage Convert(CatChange change)
    {
        return new CatCdcChangeMessage
        {
            Table = change.Table,
            Operation = change.Operation,
            TransactionId = System.Convert.ToHexString(change.TransactionId),
            TransactionTime = change.TransactionTime,
            Keys = change.Keys,
            Old = change.Old,
            New = change.New,
            OccurredAt = change.TransactionTime
        };
    }
}
