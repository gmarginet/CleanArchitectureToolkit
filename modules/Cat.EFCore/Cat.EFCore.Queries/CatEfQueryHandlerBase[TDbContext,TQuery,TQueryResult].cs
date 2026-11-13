using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.Queries;

/// <summary>
/// Base class for query handlers that read from Entity Framework Core.
/// It holds the <see cref="DbContext"/> and gives out entity sets without change tracking.
/// </summary>
/// <typeparam name="TDbContext">The context type. Any <see cref="Microsoft.EntityFrameworkCore.DbContext"/> works, also a scaffolded one.</typeparam>
/// <typeparam name="TQuery">The query this handler can answer.</typeparam>
/// <typeparam name="TQueryResult">The type of the data the handler returns.</typeparam>
public abstract class CatEfQueryHandlerBase<TDbContext, TQuery, TQueryResult> : ICatQueryHandler<TQuery, TQueryResult>
    where TDbContext : DbContext
    where TQuery : class, ICatQuery<TQueryResult>
{
    /// <summary>
    /// Creates the handler.
    /// </summary>
    /// <param name="dbContext">The context to read from.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="dbContext"/> is <c>null</c>.</exception>
    protected CatEfQueryHandlerBase(TDbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// The context to read from.
    /// </summary>
    protected TDbContext DbContext { get; }

    /// <summary>
    /// Tells whether <see cref="Set{TEntity}"/> tracks the entities it returns. The default is <c>false</c>.
    /// Override it in a handler that needs tracking.
    /// </summary>
    protected virtual bool TrackChanges => false;

    /// <summary>
    /// Gives the entities of one type to start a query on.
    /// They are not tracked, unless <see cref="TrackChanges"/> is <c>true</c>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <returns>A query on the entity set.</returns>
    protected IQueryable<TEntity> Set<TEntity>() where TEntity : class
    {
        IQueryable<TEntity> set = DbContext.Set<TEntity>();
        return TrackChanges ? set : set.AsNoTracking();
    }

    /// <inheritdoc />
    public abstract Task<ICatResponse<TQueryResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
