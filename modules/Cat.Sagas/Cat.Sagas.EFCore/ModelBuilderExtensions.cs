using Cat.Sagas.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Sagas.EFCore;

/// <summary>
/// Adds the saga table to the model of a <c>DbContext</c>.
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Maps <see cref="CatSagaInstance"/> to the table <c>CatSagas</c>. The version is the concurrency token.
    /// Call it from <c>OnModelCreating</c>. Add a migration afterwards, so the table exists.
    /// </summary>
    /// <param name="modelBuilder">The model builder of the context.</param>
    /// <returns>The same model builder, so calls can be chained.</returns>
    public static ModelBuilder AddCatSagas(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatSagaInstance>(entity =>
        {
            entity.ToTable("CatSagas");
            entity.HasKey(row => row.Id);
            entity.Property(row => row.Id).ValueGeneratedNever();
            entity.Property(row => row.WorkflowType).HasMaxLength(260).IsRequired();
            entity.Property(row => row.State).IsRequired();
            entity.Property(row => row.WaitingFor).HasMaxLength(260);
            entity.Property(row => row.Version).IsConcurrencyToken();
            entity.HasIndex(row => row.Status);
        });

        return modelBuilder;
    }
}
