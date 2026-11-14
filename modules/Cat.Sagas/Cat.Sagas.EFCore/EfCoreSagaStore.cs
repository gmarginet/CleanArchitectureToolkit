using Cat.Sagas.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Sagas.EFCore;

/// <summary>
/// <see cref="ICatSagaStore"/> on a <c>DbContext</c> of the service. Every call saves at once with <c>SaveChangesAsync</c>,
/// so other pending changes of the context are saved with it.
/// </summary>
/// <typeparam name="TDbContext">The context that holds the saga table, see <see cref="ModelBuilderExtensions.AddCatSagas"/>.</typeparam>
internal sealed class EfCoreSagaStore<TDbContext> : ICatSagaStore
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;

    /// <summary>
    /// Creates the store.
    /// </summary>
    /// <param name="dbContext">The context of the current scope.</param>
    public EfCoreSagaStore(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public Task<CatSagaInstance?> FindAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<CatSagaInstance>().AsNoTracking().FirstOrDefaultAsync(row => row.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddAsync(CatSagaInstance instance, CancellationToken cancellationToken = default)
    {
        instance.Version = 1;
        var entry = _dbContext.Set<CatSagaInstance>().Add(instance);

        try
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException)
        {
            entry.State = EntityState.Detached;
            instance.Version = 0;

            if (await _dbContext.Set<CatSagaInstance>().AsNoTracking().AnyAsync(row => row.Id == instance.Id, cancellationToken))
            {
                throw new CatSagaConcurrencyException(instance.Id);
            }

            throw;
        }

        entry.State = EntityState.Detached;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(CatSagaInstance instance, CancellationToken cancellationToken = default)
    {
        var loadedVersion = instance.Version;
        instance.Version = loadedVersion + 1;

        var entry = _dbContext.Set<CatSagaInstance>().Attach(instance);
        entry.State = EntityState.Modified;
        entry.Property(row => row.Version).OriginalValue = loadedVersion;

        try
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            entry.State = EntityState.Detached;
            instance.Version = loadedVersion;
            throw new CatSagaConcurrencyException(instance.Id);
        }

        entry.State = EntityState.Detached;
    }
}
