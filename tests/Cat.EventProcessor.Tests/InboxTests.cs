using Cat.EventProcessor.Inbox.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class InboxTests
{
    [Test]
    public void AddCatInbox_MapsTheInboxTableWithTheMessageIdAsKey()
    {
        using var context = new InboxTestContext();

        var entity = context.Model.FindEntityType(typeof(CatInboxMessage));

        Assert.That(entity!.GetTableName(), Is.EqualTo("CatInbox"));
        Assert.That(entity!.FindPrimaryKey()!.Properties.Single().Name, Is.EqualTo(nameof(CatInboxMessage.MessageId)));
    }

    private sealed class InboxTestContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost;Database=Unused;");

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.AddCatInbox();
    }
}
