using System.Threading;
using System.Threading.Tasks;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// Remembers which messages the service handled. The receiver calls it for a message type that has
/// <see cref="CatReceiveOptions.UseInbox"/> on. The store works on the context of the current scope,
/// the same one the handler uses, so the row is saved by the <c>SaveChanges</c> of the handler.
/// </summary>
public interface ICatInboxStore
{
    /// <summary>
    /// Tells whether the message was handled before.
    /// </summary>
    /// <param name="messageId">The ID of the message.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>True when the inbox holds the message.</returns>
    Task<bool> ExistsAsync(string messageId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds the message to the inbox. It does not save by itself. The <c>SaveChanges</c> of the handler saves it with the work.
    /// </summary>
    /// <param name="messageId">The ID of the message.</param>
    /// <param name="messageType">The name of the message type.</param>
    void Add(string messageId, string messageType);
}
