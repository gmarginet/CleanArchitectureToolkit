using Cat.Demo.NotificationService.DataModels.Entities;
using Cat.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.NotificationService.Infrastructure.DataAccess;

public class NotificationDbContext : DbContext
{
    public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }

    public DbSet<SentMail> SentMails => Set<SentMail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCatEntity<SentMail>("SentMail", e =>
        {
            e.Property(x => x.Kind).HasMaxLength(50);
            e.Property(x => x.Recipient).HasMaxLength(320);
            e.Property(x => x.Subject).HasMaxLength(200);

            // One mail of a kind per order, so a message that arrives twice sends one mail.
            e.HasIndex(x => new { x.OrderId, x.Kind }).IsUnique();
        });
    }
}
