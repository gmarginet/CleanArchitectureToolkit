using Cat.Inbox.Abstractions;
using Cat.Inbox.EFCore;
using Cat.Inbox.EFCore.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Inbox.Tests;

/// <summary>
/// The test of the chapter "Tests" in the module readme. It runs a handler twice with the same id against a real store on SQLite.
/// </summary>
[TestFixture]
public class InboxHandlingTests
{
    private SqliteConnection _connection = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public async Task SetUp()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        await _connection.OpenAsync();
        var services = new ServiceCollection();
        services.AddDbContext<HandlingContext>(options => options.UseSqlite(_connection));
        services.AddCatInboxEfCore<HandlingContext>();
        _provider = services.BuildServiceProvider();
        using var scope = _provider.CreateScope();
        await scope.ServiceProvider.GetRequiredService<HandlingContext>().Database.EnsureCreatedAsync();
    }

    [TearDown]
    public void TearDown()
    {
        _provider.Dispose();
        _connection.Dispose();
    }

    [Test]
    public async Task Handle_WithTheSameIdTwice_ShouldDoTheWorkOnce()
    {
        var runs = 0;

        for (var delivery = 0; delivery < 2; delivery++)
        {
            using var scope = _provider.CreateScope();
            var handler = new RefundHandler(
                scope.ServiceProvider.GetRequiredService<HandlingContext>(),
                scope.ServiceProvider.GetRequiredService<ICatInboxStore>(),
                () => runs++);

            await handler.HandleAsync("evt-1");
        }

        using var check = _provider.CreateScope();
        var rows = await check.ServiceProvider.GetRequiredService<HandlingContext>().Set<CatInboxMessage>().CountAsync();
        Assert.That(runs, Is.EqualTo(1));
        Assert.That(rows, Is.EqualTo(1));
    }

    [Test]
    public async Task Handle_WithAnotherId_ShouldDoTheWorkAgain()
    {
        var runs = 0;

        foreach (var eventId in new[] { "evt-1", "evt-2" })
        {
            using var scope = _provider.CreateScope();
            var handler = new RefundHandler(
                scope.ServiceProvider.GetRequiredService<HandlingContext>(),
                scope.ServiceProvider.GetRequiredService<ICatInboxStore>(),
                () => runs++);

            await handler.HandleAsync(eventId);
        }

        Assert.That(runs, Is.EqualTo(2));
    }

    private sealed class HandlingContext(DbContextOptions<HandlingContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.AddCatInbox();
    }

    private sealed class RefundHandler(HandlingContext dbContext, ICatInboxStore inbox, Action work)
    {
        public async Task HandleAsync(string eventId)
        {
            if (await inbox.ExistsAsync(eventId))
            {
                return;
            }

            work();
            inbox.Add(eventId, "Refund");
            await dbContext.SaveChangesAsync();
        }
    }
}
