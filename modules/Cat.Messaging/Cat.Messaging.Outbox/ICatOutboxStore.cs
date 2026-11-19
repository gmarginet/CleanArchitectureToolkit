using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging.Outbox;

/// <summary>
/// Stores the messages of the outbox. <c>Cat.Messaging.Outbox.EFCore</c> has the implementation for EF Core.
/// </summary>
public interface ICatOutboxStore
{
    /// <summary>
    /// Adds a message to the outbox. It does not save by itself.
    /// The unit of work that saves the data saves the message too, which is the whole point of the outbox.
    /// </summary>
    /// <param name="message">The message to store.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the message is added.</returns>
    public Task AddAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the messages that are not sent yet, oldest first.
    /// </summary>
    /// <param name="maxCount">The maximum number of messages to get.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The pending messages.</returns>
    public Task<IReadOnlyList<CatOutboxItem>> GetPendingAsync(int maxCount, CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks a message as sent and saves that.
    /// </summary>
    /// <param name="id">The <see cref="CatOutboxItem.Id"/> of the message.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the change is saved.</returns>
    public Task MarkSentAsync(System.Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the rows that were sent before the given time. A row that is not sent yet is never deleted.
    /// It runs at once and does not wait for a <c>SaveChanges</c>.
    /// Call it from your own job. Keep a sent row for a while, so you can still look up a message that went missing.
    /// </summary>
    /// <param name="sentBefore">The time limit. A row sent before this time is deleted.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of deleted rows.</returns>
    public Task<int> DeleteOlderThanAsync(System.DateTimeOffset sentBefore, CancellationToken cancellationToken = default);
}
