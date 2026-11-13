using Cat.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.EFCore.Extensions;

/// <summary>
/// Extension methods on <see cref="ModelBuilder"/> that apply the standard Cat table setup.
/// </summary>
public static class ModelBuilderExtensions
{
    internal static void ConfigureCatEntity<TEntity>(
        this ModelBuilder modelBuilder,
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

            e.HasKey(x => x.Id)
                .IsClustered(false);

            e.Property(x => x.SequenceId)
                .UseIdentityColumn()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            e.HasIndex(x => x.SequenceId)
                .IsUnique()
                .IsClustered();
            
            entityTypeBuildAction?.Invoke(e);
        });
    }

    /// <summary>
    /// Configures an entity with the table name and schema already known to the model.
    /// The schema falls back to <c>dbo</c>. Sets the non-clustered primary key on <see cref="CatEntityBase.Id"/>
    /// and a unique clustered index on the identity column <see cref="CatEntityBase.SequenceId"/>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="entityTypeBuildAction">Optional extra configuration for the entity.</param>
    /// <exception cref="Exception">The entity type has no table name in the model.</exception>
    public static void ConfigureCatEntity<TEntity>(
        this ModelBuilder modelBuilder,
        Action<EntityTypeBuilder<TEntity>>? entityTypeBuildAction = null)
        where TEntity : CatEntityBase
    {
        var entityType = modelBuilder.Model.FindEntityType(typeof(TEntity));
        var tableName = entityType?.GetTableName();
        var schemaName = entityType?.GetSchema() ?? "dbo";
		
        if (tableName is null) throw new Exception("EntityType unknown");

        modelBuilder.ConfigureCatEntity(tableName, schemaName, entityTypeBuildAction);
    }

    /// <summary>
    /// Configures an entity with an explicit table name.
    /// The schema comes from the model and falls back to <c>dbo</c>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="entityTypeBuildAction">Optional extra configuration for the entity.</param>
    public static void ConfigureCatEntity<TEntity>(
        this ModelBuilder modelBuilder,
        string tableName,
        Action<EntityTypeBuilder<TEntity>>? entityTypeBuildAction = null)
        where TEntity : CatEntityBase
    {
        var entityType = modelBuilder.Model.FindEntityType(typeof(TEntity));
        var schemaName = entityType?.GetSchema() ?? "dbo";

        modelBuilder.ConfigureCatEntity(tableName, schemaName, entityTypeBuildAction);
    }

    /// <summary>
    /// Configures an entity with an explicit table name and schema.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="schemaName">The name of the schema.</param>
    /// <param name="entityTypeBuildAction">Optional extra configuration for the entity.</param>
    public static void ConfigureCatEntity<TEntity>(
        this ModelBuilder modelBuilder,
        string tableName,
        string schemaName,
        Action<EntityTypeBuilder<TEntity>>? entityTypeBuildAction = null)
        where TEntity : CatEntityBase
    {
        modelBuilder.ConfigureCatEntity(tableName, schemaName, entityTypeBuildAction, null);
    }

    /// <summary>
    /// Configures an entity that maps a table owned by someone else.
    /// Sets a non-clustered primary key and excludes the table from migrations.
    /// Use it to define foreign keys to a table of another service in a shared database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="schemaName">The name of the schema. Defaults to <c>dbo</c>.</param>
    public static void ConfigureCatReferenceEntity<TEntity>(
        this ModelBuilder modelBuilder,
        string tableName,
        string schemaName = "dbo")
        where TEntity : CatReferenceEntityBase
    {
        modelBuilder.Entity<TEntity>(e =>
        {
            e.ToTable(tableName, schemaName, t =>
            {
                t.ExcludeFromMigrations();
            });

            e.HasKey(x => x.Id)
                .IsClustered(false);
        });
    }
}
