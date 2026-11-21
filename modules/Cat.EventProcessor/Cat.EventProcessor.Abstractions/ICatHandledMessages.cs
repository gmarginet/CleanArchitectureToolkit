using System.Threading;
using System.Threading.Tasks;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// Remembers the messages that were handled, so the receiver can skip a message that comes again.
/// The receiver asks the container for it when <see cref="CatReceiveOptions.UseInbox"/> is on.
/// Register it with the project <c>Cat.EventProcessor.Inbox</c>, which uses the inbox of <c>Cat.Inbox</c>.
/// </summary>
/// <remarks>
/// <see cref="MarkHandled"/> only adds a row to the unit of work of the current scope. The handler saves it
/// with the work, in one <c>SaveChanges</c>, so a message that fails leaves nothing behind.
/// </remarks>
public interface ICatHandledMessages
{
    /// <summary>
    /// Tells whether the message was handled before.
    /// </summary>
    /// <param name="messageId">The id of the message.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>True when the message was handled before.</returns>
    Task<bool> WasHandledAsync(string messageId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a row for the message to the unit of work of the current scope. It does not save.
    /// </summary>
    /// <param name="messageId">The id of the message.</param>
    /// <param name="messageType">The name of the message type.</param>
    void MarkHandled(string messageId, string messageType);
}