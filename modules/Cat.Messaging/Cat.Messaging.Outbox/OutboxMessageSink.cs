using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging.Outbox;

/// <summary>
/// <see cref="ICatOutgoingMessageSink"/> that stores the message in the outbox instead of sending it.
/// </summary>
internal sealed class OutboxMessageSink : ICatOutgoingMessageSink
{
    private readonly ICatOutboxStore _store;

    /// <summary>
    /// Creates the sink.
    /// </summary>
    /// <param name="store">The outbox storage of the current scope.</param>
    public OutboxMessageSink(ICatOutboxStore store)
    {
        _store = store;
    }

    /// <inheritdoc />
    public Task AcceptAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default)
    {
        return _store.AddAsync(message, cancellationToken);
    }
}
