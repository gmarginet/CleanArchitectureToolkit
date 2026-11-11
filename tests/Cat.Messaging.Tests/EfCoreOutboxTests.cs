using Cat.Messaging.Outbox.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Cat.Messaging.Tests;

[TestFixture]
public class EfCoreOutboxTests
{
    [Test]
    public void AddCatOutbox_MapsTheOutboxTable()
    {
        using var context = new OutboxTestContext();

        var entity = context.Model.FindEntityType(typeof(CatOutboxMessage));

        Assert.That(entity, Is.Not.Null);
        Assert.That(entity!.GetTableName(), Is.EqualTo("CatOutbox"));
        Assert.That(entity.FindPrimaryKey()!.Properties.Single().Name, Is.EqualTo(nameof(CatOutboxMessage.Id)));
    }

    private sealed class OutboxTestContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost;Database=Unused;");

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.AddCatOutbox();
    }
}
