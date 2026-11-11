using System.Threading;
using System.Threading.Tasks;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// Sends a message to a broker. Every broker gets its own project that implements it,
/// such as <c>Cat.Messaging.AzureServiceBus</c>.
/// </summary>
public interface ICatMessageTransport
{
    /// <summary>
    /// Sends a message to its queue or topic.
    /// </summary>
    /// <param name="message">The message to send.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the broker accepted the message.</returns>
    public Task SendAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default);
}
