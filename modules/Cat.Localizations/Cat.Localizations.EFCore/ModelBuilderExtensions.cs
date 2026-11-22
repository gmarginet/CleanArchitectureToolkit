using Cat.Localizations.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Localizations.EFCore;

/// <summary>
/// Maps the translation table.
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Maps <see cref="CatTranslation"/> to one table, with a unique index on entity type, entity, field and culture.
    /// Call it in <c>OnModelCreating</c> of the <c>DbContext</c>. It is plain EF Core, so it works on every provider.
    /// </summary>
    /// <param name="modelBuilder">The model builder to configure.</param>
    /// <param name="tableName">The name of the table.</param>
    /// <param name="schemaName">The name of the schema. Null uses the default schema of the provider.</param>
    /// <returns>The same model builder, so calls can be chained.</returns>
    public static ModelBuilder AddCatTranslations(this ModelBuilder modelBuilder, string tableName = "Translation", string? schemaName = null)
    {
        modelBuilder.Entity<CatTranslation>(e =>
        {
            e.ToTable(tableName, schemaName);
            e.HasKey(x => x.Id);
            e.Property(x => x.EntityType).HasMaxLength(100).IsRequired();
            e.Property(x => x.Field).HasMaxLength(100).IsRequired();
            e.Property(x => x.Culture).HasMaxLength(20).IsRequired();
            e.Property(x => x.Text).HasMaxLength(1000).IsRequired();
            e.HasIndex(x => new { x.EntityType, x.EntityId, x.Field, x.Culture }).IsUnique();
        });

        return modelBuilder;
    }
}
