using System.Threading;
using System.Threading.Tasks;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// Takes the message from the sender. By default it hands the message straight to the <see cref="ICatMessageTransport"/>.
/// The outbox replaces it with one that stores the message, so the sender does not change.
/// </summary>
public interface ICatOutgoingMessageSink
{
    /// <summary>
    /// Takes a message that is ready to leave the service.
    /// </summary>
    /// <param name="message">The message to take.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the message is sent or stored.</returns>
    public Task AcceptAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default);
}
