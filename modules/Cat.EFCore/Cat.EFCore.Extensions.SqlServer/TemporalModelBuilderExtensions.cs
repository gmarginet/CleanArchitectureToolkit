using Cat.EFCore.Entities.SqlServer;
using Cat.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.EFCore.Extensions.SqlServer;

/// <summary>
/// Extension methods on <see cref="ModelBuilder"/> that set up SQL Server temporal tables.
/// </summary>
public static class TemporalModelBuilderExtensions
{
    /// <summary>
    /// Configures a temporal entity with the table name and schema already known to the model.
    /// The history table gets the same name in the <c>History</c> schema.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="entityTypeBuildAction">Optional extra configuration for the entity.</param>
    /// <exception cref="Exception">The entity type has no table name in the model.</exception>
    public static void ConfigureCatTemporalEntity<TEntity>(
        this ModelBuilder modelBuilder,
        Action<EntityTypeBuilder<TEntity>>? entityTypeBuildAction = null)
        where TEntity : CatTemporalEntityBase
    {
        var entityType = modelBuilder.Model.FindEntityType(typeof(TEntity));
        var tableName = entityType?.GetTableName();
        var schemaName = entityType?.GetSchema() ?? "dbo";

        if (tableName is null) throw new Exception("EntityType unknown");

        modelBuilder.ConfigureCatTemporalEntity(tableName, schemaName, entityTypeBuildAction);
    }

    /// <summary>
    /// Configures a temporal entity with an explicit table name.
    /// The schema comes from the model and falls back to <c>dbo</c>.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="entityTypeBuildAction">Optional extra configuration for the entity.</param>
    public static void ConfigureCatTemporalEntity<TEntity>(
        this ModelBuilder modelBuilder,
        string tableName,
        Action<EntityTypeBuilder<TEntity>>? entityTypeBuildAction = null)
        where TEntity : CatTemporalEntityBase
    {
        var entityType = modelBuilder.Model.FindEntityType(typeof(TEntity));
        var schemaName = entityType?.GetSchema() ?? "dbo";

        modelBuilder.ConfigureCatTemporalEntity(tableName, schemaName, entityTypeBuildAction);
    }

    /// <summary>
    /// Configures a temporal entity with an explicit table name and schema.
    /// The history table gets the same name in the <c>History</c> schema.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="schemaName">The name of the schema.</param>
    /// <param name="entityTypeBuildAction">Optional extra configuration for the entity.</param>
    public static void ConfigureCatTemporalEntity<TEntity>(
        this ModelBuilder modelBuilder,
        string tableName,
        string schemaName,
        Action<EntityTypeBuilder<TEntity>>? entityTypeBuildAction = null)
        where TEntity : CatTemporalEntityBase
    {
        modelBuilder.ConfigureCatEntity(tableName, schemaName, entityTypeBuildAction, t =>
        {
            t.IsTemporal(tt =>
            {
                tt.UseHistoryTable(tableName, "History");
                tt.HasPeriodStart(x => x.ValidFrom);
                tt.HasPeriodEnd(x => x.ValidUntil);
            });
        });
    }
}
