#if (DatabaseFirst)
using Microsoft.EntityFrameworkCore;
#else
#if (SqlServer)
using Cat.EFCore.Extensions.SqlServer;
#else
using Cat.EFCore.Extensions.PostgreSQL;
#endif
using Microsoft.EntityFrameworkCore;
#endif
#if (Messages)
using Cat.Inbox.EFCore;
#endif
#if (Jobs)
using Cat.Scheduling.EFCore;
#endif
using ServiceName.DataModels.Entities;

namespace ServiceName.Infrastructure.DataAccess;

public class ServiceShortDbContext(DbContextOptions<ServiceShortDbContext> options) : DbContext(options)
{
    public DbSet<ExampleItem> ExampleItems => Set<ExampleItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
#if (DatabaseFirst)
        // The mapping follows the tables in ServiceName.Database. Scaffold it again when the schema changes, see the readme.
        modelBuilder.Entity<ExampleItem>(entity =>
        {
            entity.ToTable("ExampleItem");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SequenceId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });
#else
        modelBuilder.ConfigureCatEntity<ExampleItem>("ExampleItem", e =>
        {
            e.Property(x => x.Name).HasMaxLength(100);
        });
#endif
#if (Jobs)
        modelBuilder.AddCatScheduling();
#endif
#if (Messages)
        // The inbox table remembers the messages that are handled, so a message that arrives twice runs once.
        modelBuilder.AddCatInbox();
#endif
    }
}
