namespace Cat.EventProcessor.Inbox.EFCore;

/// <summary>
/// Remembers which messages the service handled. The store works on the context of the current scope,
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
    public Task<bool> ExistsAsync(string messageId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds the message to the inbox. It does not save by itself. The <c>SaveChanges</c> of the handler saves it with the work.
    /// </summary>
    /// <param name="messageId">The ID of the message.</param>
    /// <param name="messageType">The name of the message type.</param>
    public void Add(string messageId, string messageType);
}
