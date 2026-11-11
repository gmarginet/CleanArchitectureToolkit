using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging;

/// <summary>
/// Default <see cref="ICatOutgoingMessageSink"/>. Sends the message to the transport at once, with no outbox.
/// </summary>
internal sealed class DirectMessageSink : ICatOutgoingMessageSink
{
    private readonly ICatMessageTransport _transport;

    /// <summary>
    /// Creates the sink.
    /// </summary>
    /// <param name="transport">The transport that sends to the broker.</param>
    public DirectMessageSink(ICatMessageTransport transport)
    {
        _transport = transport;
    }

    /// <inheritdoc />
    public Task AcceptAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default)
    {
        return _transport.SendAsync(message, cancellationToken);
    }
}
