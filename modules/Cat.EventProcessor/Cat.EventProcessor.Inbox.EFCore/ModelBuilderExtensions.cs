using Microsoft.EntityFrameworkCore;

namespace Cat.EventProcessor.Inbox.EFCore;

/// <summary>
/// Adds the inbox table to the model of a <c>DbContext</c>.
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Maps <see cref="CatInboxMessage"/> to the table <c>CatInbox</c>. Call it from <c>OnModelCreating</c>.
    /// Add a migration afterwards, so the table exists.
    /// </summary>
    /// <param name="modelBuilder">The model builder of the context.</param>
    /// <returns>The same model builder, so calls can be chained.</returns>
    public static ModelBuilder AddCatInbox(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatInboxMessage>(entity =>
        {
            entity.ToTable("CatInbox");
            entity.HasKey(row => row.MessageId);
            entity.Property(row => row.MessageId).HasMaxLength(128);
            entity.Property(row => row.MessageType).HasMaxLength(260).IsRequired();
        });

        return modelBuilder;
    }
}
