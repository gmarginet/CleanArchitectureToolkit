using Cat.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.EFCore.Extensions.PostgreSQL;

/// <summary>
/// Extension methods on <see cref="ModelBuilder"/> that apply the standard Cat table setup on PostgreSQL.
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
        Action<EntityTypeBuilder<TEntity>> internalEntityTypeBuildAction = (e) =>
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.SequenceId)
                .UseIdentityAlwaysColumn();

            e.HasIndex(x => x.SequenceId)
                .IsUnique();

            entityTypeBuildAction?.Invoke(e);
        };

        CatEntityConfigurator.ConfigureCatEntityBase(
            modelBuilder,
            tableName,
            schemaName,
            internalEntityTypeBuildAction,
            tableBuildAction);
    }

    /// <summary>
    /// Configures an entity with the table name and schema already known to the model.
    /// The schema falls back to <c>public</c>. Sets the primary key on <see cref="CatEntityBase.Id"/>
    /// and a unique index on the identity column <see cref="CatEntityBase.SequenceId"/>. PostgreSQL has no clustered index.
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
        var schemaName = entityType?.GetSchema() ?? "public";

        if (tableName is null) throw new Exception("EntityType unknown");

        modelBuilder.ConfigureCatEntity(tableName, schemaName, entityTypeBuildAction, null);
    }

    /// <summary>
    /// Configures an entity with an explicit table name.
    /// The schema comes from the model and falls back to <c>public</c>.
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
        var schemaName = entityType?.GetSchema() ?? "public";

        modelBuilder.ConfigureCatEntity(tableName, schemaName, entityTypeBuildAction, null);
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
    /// Sets the primary key and excludes the table from migrations.
    /// Use it to define foreign keys to a table of another service in a shared database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="schemaName">The name of the schema. Defaults to <c>public</c>.</param>
    public static void ConfigureCatReferenceEntity<TEntity>(
        this ModelBuilder modelBuilder,
        string tableName,
        string schemaName = "public")
        where TEntity : CatReferenceEntityBase
    {
        Action<EntityTypeBuilder<TEntity>> internalEntityTypeBuildAction = (e) =>
        {
            e.HasKey(x => x.Id);
        };

        CatEntityConfigurator.ConfigureCatReferenceEntityBase<TEntity>(
            modelBuilder,
            tableName,
            schemaName,
            internalEntityTypeBuildAction);
    }
}
