using Microsoft.EntityFrameworkCore;

namespace Cat.EventProcessor.Inbox.EFCore;

/// <summary>
/// <see cref="ICatInboxStore"/> on a <c>DbContext</c> of the service.
/// </summary>
/// <typeparam name="TDbContext">The context that holds the inbox table, see <see cref="ModelBuilderExtensions.AddCatInbox"/>.</typeparam>
internal sealed class EfCoreInboxStore<TDbContext> : ICatInboxStore
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;

    /// <summary>
    /// Creates the store.
    /// </summary>
    /// <param name="dbContext">The context of the current scope. The handler uses the same one.</param>
    public EfCoreInboxStore(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public Task<bool> ExistsAsync(string messageId, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<CatInboxMessage>().AsNoTracking().AnyAsync(row => row.MessageId == messageId, cancellationToken);
    }

    /// <inheritdoc />
    public void Add(string messageId, string messageType)
    {
        _dbContext.Set<CatInboxMessage>().Add(new CatInboxMessage
        {
            MessageId = messageId,
            MessageType = messageType,
            HandledAt = DateTimeOffset.UtcNow
        });
    }
}
