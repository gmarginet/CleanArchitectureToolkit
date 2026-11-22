#if (SqlServer)
using Cat.EFCore.Extensions.SqlServer;
#else
using Cat.EFCore.Extensions.PostgreSQL;
#endif
using Microsoft.EntityFrameworkCore;
using ServiceName.DataModels.Entities;

namespace ServiceName.Infrastructure.DataAccess;

public class ServiceShortDbContext(DbContextOptions<ServiceShortDbContext> options) : DbContext(options)
{
    public DbSet<ExampleItem> ExampleItems => Set<ExampleItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCatEntity<ExampleItem>("ExampleItem", e =>
        {
            e.Property(x => x.Name).HasMaxLength(100);
        });
    }
}
