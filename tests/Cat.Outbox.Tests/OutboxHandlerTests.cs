using Cat.Messaging.Abstractions;
using Cat.Messaging.Extensions;
using Cat.Outbox.EFCore;
using Cat.Outbox.EFCore.Extensions;
using Cat.Outbox.Extensions;
using Cat.UnitTesting.Messaging;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Outbox.Tests;

/// <summary>
/// The tests of the chapter "Tests" in the module readme. One checks the logic of a handler with the fake sender,
/// the other checks that the message is stored with the data change, on a real store on SQLite.
/// </summary>
[TestFixture]
public class OutboxHandlerTests
{
    [Test]
    public async Task Handle_ShouldPublishOrderPlaced()
    {
        var sender = new FakeMessageSender();
        var handler = new PlaceOrderHandler(null, sender);

        await handler.HandleAsync("ORD-1");

        Assert.That(sender.Of<OrderPlaced>().Single().OrderNumber, Is.EqualTo("ORD-1"));
    }

    [Test]
    public async Task Handle_WithTheOutbox_ShouldStoreTheMessageWithTheSave()
    {
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();
        var transport = new FakeTransport();
        var services = new ServiceCollection();
        services.AddDbContext<OrdersContext>(options => options.UseSqlite(connection));
        services.AddSingleton<ICatMessageTransport>(transport);
        services.AddCatMessagingModule();
        services.AddCatOutboxEfCore<OrdersContext>();
        services.AddCatOutbox();
        await using var provider = services.BuildServiceProvider();
        using (var setup = provider.CreateScope())
        {
            await setup.ServiceProvider.GetRequiredService<OrdersContext>().Database.EnsureCreatedAsync();
        }

        using (var scope = provider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<OrdersContext>();
            var handler = new PlaceOrderHandler(context, scope.ServiceProvider.GetRequiredService<ICatMessageSender>());

            await handler.HandleAsync("ORD-1");
        }

        using var check = provider.CreateScope();
        var checkContext = check.ServiceProvider.GetRequiredService<OrdersContext>();
        Assert.That(await checkContext.Orders.CountAsync(), Is.EqualTo(1));
        Assert.That(await checkContext.Set<CatOutboxMessage>().CountAsync(), Is.EqualTo(1));
        Assert.That(transport.Sent, Is.Empty);
    }

    private sealed class OrdersContext(DbContextOptions<OrdersContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.AddCatOutbox();
    }

    private sealed class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Number { get; set; } = string.Empty;
    }

    private sealed class PlaceOrderHandler(OrdersContext? context, ICatMessageSender sender)
    {
        public async Task HandleAsync(string number)
        {
            context?.Orders.Add(new Order { Number = number });
            await sender.PublishAsync(new OrderPlaced { OrderNumber = number });

            // Nothing is stored before this save. With the outbox on, it saves the data and the message together.
            if (context is not null)
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
