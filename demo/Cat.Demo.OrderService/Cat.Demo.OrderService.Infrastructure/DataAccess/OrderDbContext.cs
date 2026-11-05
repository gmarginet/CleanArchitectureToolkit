using Cat.Demo.OrderService.DataModels.Entities;
using Cat.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.OrderService.Infrastructure.DataAccess;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<DailyOrderCounter> DailyOrderCounters => Set<DailyOrderCounter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCatEntity<Customer>("Customer", e =>
        {
            e.Property(x => x.ExternalId).HasMaxLength(100);
            e.Property(x => x.Name).HasMaxLength(200);
            e.Property(x => x.Email).HasMaxLength(320);
            e.HasIndex(x => x.ExternalId).IsUnique();
        });

        modelBuilder.ConfigureCatEntity<OrderStatus>("OrderStatus", e =>
        {
            e.Property(x => x.Code).HasMaxLength(50);
            e.HasIndex(x => x.Code).IsUnique();
        });

        modelBuilder.ConfigureCatEntity<Order>("Order", e =>
        {
            e.Property(x => x.OrderNumber).HasMaxLength(13);
            e.Property(x => x.Total).HasPrecision(10, 2);
            e.HasIndex(x => x.OrderNumber).IsUnique();
            e.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId);
            e.HasOne(x => x.OrderStatus)
                .WithMany()
                .HasForeignKey(x => x.OrderStatusId);
            e.HasMany(x => x.Lines)
                .WithOne()
                .HasForeignKey(x => x.OrderId);
            e.HasOne(x => x.Payment)
                .WithOne()
                .HasForeignKey<Payment>(x => x.OrderId);
        });

        // BookId has no foreign key, because the book lives in the Catalog database.
        modelBuilder.ConfigureCatEntity<OrderLine>("OrderLine", e =>
        {
            e.Property(x => x.UnitPrice).HasPrecision(10, 2);
        });

        modelBuilder.ConfigureCatEntity<Payment>("Payment", e =>
        {
            e.Property(x => x.Amount).HasPrecision(10, 2);
            e.Property(x => x.Status).HasMaxLength(20);
        });

        modelBuilder.ConfigureCatEntity<DailyOrderCounter>("DailyOrderCounter", e =>
        {
            e.Property(x => x.Date).HasColumnType("date");
            e.HasIndex(x => x.Date).IsUnique();
        });
    }
}
