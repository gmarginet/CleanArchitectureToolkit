using Cat.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.EFCore.Extensions;

/// <summary>
/// Holds the part of the Cat table setup that every database shares.
/// The provider projects call it and add the calls that only their database knows.
/// </summary>
internal static class CatEntityConfigurator
{
    /// <summary>
    /// Configures the table and makes <see cref="CatEntityBase.SequenceId"/> read-only after the first save.
    /// Then runs the calls of the database provider and the extra configuration of the developer, in that order.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="schemaName">The name of the schema.</param>
    /// <param name="entityTypeBuildAction">Optional extra configuration for the entity.</param>
    /// <param name="tableBuildAction">Optional extra configuration for the table.</param>
    internal static void ConfigureCatEntityBase<TEntity>(
        ModelBuilder modelBuilder,
        string tableName,
        string schemaName,
        Action<EntityTypeBuilder<TEntity>>? entityTypeBuildAction,
        Action<TableBuilder<TEntity>>? tableBuildAction)
        where TEntity : CatEntityBase
    {
        modelBuilder.Entity<TEntity>(e =>
        {
            e.ToTable(tableName, schemaName, t =>
            {
                tableBuildAction?.Invoke(t);
            });

            e.Property(x => x.SequenceId)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            entityTypeBuildAction?.Invoke(e);
        });
    }

    /// <summary>
    /// Configures a table that someone else owns and excludes it from migrations.
    /// Then runs the configuration of the database provider, which sets the key on <see cref="CatReferenceEntityBase.Id"/>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="schemaName">The name of the schema.</param>
    /// <param name="entityTypeBuildAction">The configuration of the database provider.</param>
    internal static void ConfigureCatReferenceEntityBase<TEntity>(
        ModelBuilder modelBuilder,
        string tableName,
        string schemaName,
        Action<EntityTypeBuilder<TEntity>>? entityTypeBuildAction)
        where TEntity : CatReferenceEntityBase
    {
        modelBuilder.Entity<TEntity>(e =>
        {
            e.ToTable(tableName, schemaName, t =>
            {
                t.ExcludeFromMigrations();
            });

            entityTypeBuildAction?.Invoke(e);
        });
    }
}
