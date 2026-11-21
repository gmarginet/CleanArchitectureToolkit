using System.Threading;
using System.Threading.Tasks;
using Cat.EventProcessor.Abstractions;
using Cat.Inbox.Abstractions;

namespace Cat.EventProcessor.Inbox;

/// <summary>
/// <see cref="ICatHandledMessages"/> on top of the <see cref="ICatInboxStore"/> of <c>Cat.Inbox</c>.
/// </summary>
internal sealed class InboxHandledMessages : ICatHandledMessages
{
    private readonly ICatInboxStore _store;

    public InboxHandledMessages(ICatInboxStore store)
    {
        _store = store;
    }

    public Task<bool> WasHandledAsync(string messageId, CancellationToken cancellationToken = default) =>
        _store.ExistsAsync(messageId, cancellationToken);

    public void MarkHandled(string messageId, string messageType) => _store.Add(messageId, messageType);
}