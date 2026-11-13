using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.EFCore.Extensions;
using Cat.EFCore.Extensions.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.DataAccess;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BookPrice> BookPrices => Set<BookPrice>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCatEntity<Category>("Category", e =>
        {
            e.Property(x => x.Name).HasMaxLength(100);
        });

        modelBuilder.ConfigureCatEntity<Book>("Book", e =>
        {
            e.Property(x => x.Isbn).HasMaxLength(13);
            e.Property(x => x.Title).HasMaxLength(200);
            e.Property(x => x.Author).HasMaxLength(200);
            e.HasIndex(x => x.Isbn).IsUnique();
            e.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);
        });

        // SQL Server keeps every old price in the History.BookPrice table.
        modelBuilder.ConfigureCatTemporalEntity<BookPrice>("BookPrice", e =>
        {
            e.Property(x => x.Amount).HasPrecision(10, 2);
            e.Property(x => x.LastUpdatedBy).HasMaxLength(100);
            e.HasOne<Book>()
                .WithOne(x => x.BookPrice)
                .HasForeignKey<BookPrice>(x => x.BookId);
        });
    }
}
