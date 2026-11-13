using Microsoft.EntityFrameworkCore;

namespace Cat.Scheduling.EFCore;

/// <summary>
/// Adds the job run table to the model of a <c>DbContext</c>.
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Maps <see cref="CatJobRun"/> to the table <c>CatJobRun</c>. Call it from <c>OnModelCreating</c>.
    /// Add a migration afterwards, so the table exists.
    /// </summary>
    /// <param name="modelBuilder">The model builder of the context.</param>
    /// <returns>The same model builder, so calls can be chained.</returns>
    public static ModelBuilder AddCatScheduling(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatJobRun>(entity =>
        {
            entity.ToTable("CatJobRun");
            entity.HasKey(row => new { row.JobName, row.DueTime });
            entity.Property(row => row.JobName).HasMaxLength(200);
            entity.Property(row => row.Status).HasConversion<string>().HasMaxLength(20);
            entity.Property(row => row.ErrorCode).HasMaxLength(200);
            entity.Property(row => row.DueTime).HasConversion(AsUtc);
            entity.Property(row => row.StartedAt).HasConversion(AsUtc);
            entity.Property(row => row.FinishedAt).HasConversion(AsNullableUtc);
            entity.HasIndex(row => new { row.JobName, row.Status, row.StartedAt });
        });
        return modelBuilder;
    }

    // The database returns a date time without a kind. These converters make it UTC, as the code stored it.
    private static readonly Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime> AsUtc =
        new(value => DateTime.SpecifyKind(value, DateTimeKind.Utc), value => DateTime.SpecifyKind(value, DateTimeKind.Utc));

    private static readonly Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime?, DateTime?> AsNullableUtc =
        new(value => value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : value,
            value => value.HasValue ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : value);
}
