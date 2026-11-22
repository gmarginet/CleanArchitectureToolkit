#if (SqlServer)
using Cat.EFCore.Extensions.SqlServer;
#else
using Cat.EFCore.Extensions.PostgreSQL;
#endif
using Microsoft.EntityFrameworkCore;
using ServiceName.DataModels.Entities;

namespace ServiceName.Infrastructure.DataAccess;

public static class ItemNameModelBuilderExtensions
{
    /// <summary>Maps <see cref="ItemName"/> to the table ItemName. Call it from <c>OnModelCreating</c> of the context.</summary>
    public static ModelBuilder ConfigureItemName(this ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCatEntity<ItemName>("ItemName", e =>
        {
            e.Property(x => x.Name).HasMaxLength(100);
        });

        return modelBuilder;
    }
}
