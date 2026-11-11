using Microsoft.EntityFrameworkCore;

namespace Cat.Messaging.Outbox.EFCore;

/// <summary>
/// Adds the outbox table to the model of a <c>DbContext</c>.
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Maps <see cref="CatOutboxMessage"/> to the table <c>CatOutbox</c>. Call it from <c>OnModelCreating</c>.
    /// Add a migration afterwards, so the table exists.
    /// </summary>
    /// <param name="modelBuilder">The model builder of the context.</param>
    /// <returns>The same model builder, so calls can be chained.</returns>
    public static ModelBuilder AddCatOutbox(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatOutboxMessage>(entity =>
        {
            entity.ToTable("CatOutbox");
            entity.HasKey(row => row.Id);
            entity.Property(row => row.EntityName).HasMaxLength(260).IsRequired();
            entity.Property(row => row.ContentType).HasMaxLength(100).IsRequired();
            entity.Property(row => row.Subject).HasMaxLength(260).IsRequired();
            entity.Property(row => row.SessionId).HasMaxLength(128);
            entity.HasIndex(row => new { row.SentAt, row.CreatedAt });
        });

        return modelBuilder;
    }
}
