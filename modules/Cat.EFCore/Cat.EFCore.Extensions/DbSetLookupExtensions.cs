using System.Linq.Expressions;
using Cat.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EFCore.Extensions;

/// <summary>
/// Lookup methods for entities that derive from <see cref="CatEntityBase"/>.
/// They give the same result on every database and read the primary key from the EF Core model,
/// so the code does not depend on which column is the key.
/// </summary>
/// <remarks>
/// Use these methods instead of the built-in <c>Find</c>. An instance method wins over an extension method,
/// so the extension methods cannot be called <c>Find</c>, and <c>set.Find(guid)</c> always binds to the built-in one.
/// </remarks>
public static class DbSetLookupExtensions
{
    /// <summary>
    /// Finds an entity by its <see cref="CatEntityBase.Id"/>. It looks in the change tracker first, like <c>Find</c>, and then queries the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="set">The set to look in.</param>
    /// <param name="id">The id to look for.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The tracked entity, or <c>null</c> when none has this id.</returns>
    public static ValueTask<TEntity?> FindByIdAsync<TEntity>(
        this DbSet<TEntity> set,
        Guid id,
        CancellationToken cancellationToken = default)
        where TEntity : CatEntityBase
    {
        return FindAsync(set, nameof(CatEntityBase.Id), id, e => e.Id == id, cancellationToken);
    }

    /// <summary>
    /// Finds an entity by its <see cref="CatEntityBase.SequenceId"/>. It looks in the change tracker first, and then queries the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="set">The set to look in.</param>
    /// <param name="sequenceId">The sequence number to look for.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The tracked entity, or <c>null</c> when none has this sequence number.</returns>
    public static ValueTask<TEntity?> FindBySequenceIdAsync<TEntity>(
        this DbSet<TEntity> set,
        int sequenceId,
        CancellationToken cancellationToken = default)
        where TEntity : CatEntityBase
    {
        return FindAsync(set, nameof(CatEntityBase.SequenceId), sequenceId, e => e.SequenceId == sequenceId, cancellationToken);
    }

    private static async ValueTask<TEntity?> FindAsync<TEntity>(
        DbSet<TEntity> set,
        string propertyName,
        object value,
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
        where TEntity : CatEntityBase
    {
        if (set is null) throw new ArgumentNullException(nameof(set));

        var context = ((IInfrastructure<IServiceProvider>)set).Instance.GetRequiredService<ICurrentDbContext>().Context;
        var key = context.Model.FindEntityType(typeof(TEntity))?.FindPrimaryKey();

        // The requested column is the key: Find looks in the change tracker and in the database.
        if (key is { Properties.Count: 1 } && key.Properties[0].Name == propertyName)
        {
            return await set.FindAsync(new[] { value }, cancellationToken).ConfigureAwait(false);
        }

        // Otherwise look in the change tracker first, like Find does, and then query.
        var compiled = predicate.Compile();
        foreach (var entry in context.ChangeTracker.Entries<TEntity>())
        {
            if (entry.State == EntityState.Detached || !compiled(entry.Entity)) continue;

            // A tracked entity that is marked as deleted counts as gone, like it does for Find.
            return entry.State == EntityState.Deleted ? null : entry.Entity;
        }

        return await set.FirstOrDefaultAsync(predicate, cancellationToken).ConfigureAwait(false);
    }
}
