using Cat.Outbox.Abstractions;
using System.Text.Json;
using Cat.Messaging.Abstractions;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Cat.Outbox.EFCore;

/// <summary>
/// <see cref="ICatOutboxStore"/> on a <c>DbContext</c> of the service.
/// </summary>
/// <typeparam name="TDbContext">The context that holds the outbox table, see <see cref="ModelBuilderExtensions.AddCatOutbox"/>.</typeparam>
internal sealed class EfCoreOutboxStore<TDbContext> : ICatOutboxStore
    where TDbContext : DbContext
{
    private const string DiagnosticIdProperty = "Diagnostic-Id";

    private readonly TDbContext _dbContext;

    /// <summary>
    /// Creates the store.
    /// </summary>
    /// <param name="dbContext">The context of the current scope. The command handler uses the same one.</param>
    public EfCoreOutboxStore(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public Task AddAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<CatOutboxMessage>().Add(new CatOutboxMessage
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTimeOffset.UtcNow,
            EntityName = message.EntityName,
            Kind = message.Kind,
            Body = message.Body,
            ContentType = message.ContentType,
            MessageId = message.MessageId,
            CorrelationId = message.CorrelationId,
            Subject = message.Subject,
            SessionId = message.SessionId,
            ScheduledAt = message.ScheduledAt,
            PropertiesJson = message.Properties.Count == 0 ? null : JsonSerializer.Serialize(message.Properties),
            TraceParent = CurrentTraceParent()
        });

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<CatOutboxItem>> GetPendingAsync(int maxCount, CancellationToken cancellationToken = default)
    {
        var rows = await _dbContext.Set<CatOutboxMessage>()
            .AsNoTracking()
            .Where(row => row.SentAt == null)
            .OrderBy(row => row.CreatedAt)
            .Take(maxCount)
            .ToListAsync(cancellationToken);

        return rows.Select(row => new CatOutboxItem
        {
            Id = row.Id,
            Message = new CatOutgoingMessage
            {
                EntityName = row.EntityName,
                Kind = row.Kind,
                Body = row.Body,
                ContentType = row.ContentType,
                MessageId = row.MessageId,
                CorrelationId = row.CorrelationId,
                Subject = row.Subject,
                SessionId = row.SessionId,
                ScheduledAt = row.ScheduledAt,
                Properties = ReadProperties(row)
            }
        }).ToList();
    }

    private static Dictionary<string, string> ReadProperties(CatOutboxMessage row)
    {
        var properties = row.PropertiesJson is null
            ? new Dictionary<string, string>()
            : JsonSerializer.Deserialize<Dictionary<string, string>>(row.PropertiesJson)
              ?? new Dictionary<string, string>();

        if (row.TraceParent is not null && !properties.ContainsKey(DiagnosticIdProperty))
        {
            properties[DiagnosticIdProperty] = row.TraceParent;
        }

        return properties;
    }

    private static string? CurrentTraceParent()
    {
        var activity = Activity.Current;
        return activity is { IdFormat: ActivityIdFormat.W3C } ? activity.Id : null;
    }

    /// <inheritdoc />
    public async Task MarkSentAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<CatOutboxMessage>()
            .Where(row => row.Id == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(row => row.SentAt, DateTimeOffset.UtcNow), cancellationToken);
    }

    /// <inheritdoc />
    public Task<int> DeleteOlderThanAsync(DateTimeOffset sentBefore, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<CatOutboxMessage>().Where(row => row.SentAt < sentBefore).ExecuteDeleteAsync(cancellationToken);
    }
}
