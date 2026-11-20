using Cat.Demo.OrderService.CoreService;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Demo.OrderService.Infrastructure.CommandHandlers;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.Infrastructure.Extensions;
using Cat.IntegrationTesting.SqlServer.NUnit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.IntegrationTests;

/// <summary>
/// Shows how a developer tests a command handler against a real SQL Server.
/// The base class gives this class its own empty database in a container. The test applies the migrations of the Orders service,
/// so the database is the one the service runs on, and then calls the handlers in process.
/// </summary>
[TestFixture]
public class OrderDatabaseTests : SqlServerDatabaseTests
{
    private ServiceProvider _provider = null!;

    [OneTimeSetUp]
    public async Task ApplyMigrations()
    {
        var services = new ServiceCollection();
        services.AddCatDemoOrderDatabase(ConnectionString);
        _provider = services.BuildServiceProvider();
        await _provider.InitializeOrderDatabaseAsync();
    }

    [OneTimeTearDown]
    public async Task DisposeProvider()
    {
        if (_provider is not null) await _provider.DisposeAsync();
    }

    [SetUp]
    public async Task ClearOrders()
    {
        using var scope = _provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
        await context.OrderLines.ExecuteDeleteAsync();
        await context.Orders.ExecuteDeleteAsync();
        await context.DailyOrderCounters.ExecuteDeleteAsync();
        await context.Customers.ExecuteDeleteAsync();
    }

    private async Task<Guid> CreateCustomerAsync(string externalId = "user-1")
    {
        using var scope = _provider.CreateScope();
        var command = new CustomerCreateOrUpdateCommand { ExternalId = externalId, Name = "Ada", Email = "ada@example.com" };
        var response = await new CustomerCreateOrUpdateCommandHandler(scope.ServiceProvider.GetRequiredService<OrderDbContext>()).HandleAsync(command);
        Assert.That(response.IsSucceeded, Is.True);
        return command.CustomerId;
    }

    private async Task<OrderCreated> PlaceOrderAsync(Guid customerId, DateTime placedAt)
    {
        using var scope = _provider.CreateScope();
        var command = new OrderCreateCommand
        {
            OrderId = Guid.NewGuid(),
            PlacedAt = placedAt,
            CustomerId = customerId,
            Total = 20m,
            Lines = [new OrderCreateLine(Guid.NewGuid(), 2, 10m)]
        };
        var response = await new OrderCreateCommandHandler(scope.ServiceProvider.GetRequiredService<OrderDbContext>()).HandleAsync(command);
        Assert.That(response.IsSucceeded, Is.True);
        return response.Value;
    }

    private async Task<int> CountAsync<TEntity>() where TEntity : class
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<OrderDbContext>().Set<TEntity>().CountAsync();
    }

    [Test]
    public async Task CustomerCreateOrUpdate_CreatesTheCustomerOnceAndUpdatesTheName()
    {
        var first = await CreateCustomerAsync("user-1");

        using (var scope = _provider.CreateScope())
        {
            var command = new CustomerCreateOrUpdateCommand { ExternalId = "user-1", Name = "Ada Lovelace", Email = "ada@example.com" };
            await new CustomerCreateOrUpdateCommandHandler(scope.ServiceProvider.GetRequiredService<OrderDbContext>()).HandleAsync(command);

            Assert.That(command.CustomerId, Is.EqualTo(first));
        }

        using var readScope = _provider.CreateScope();
        var customers = await readScope.ServiceProvider.GetRequiredService<OrderDbContext>().Customers.ToListAsync();
        Assert.That(customers.Select(c => c.Name), Is.EqualTo(new[] { "Ada Lovelace" }));
    }

    [Test]
    public async Task OrderCreate_NumbersTheOrdersOfADayInOrder()
    {
        var customerId = await CreateCustomerAsync();
        var day = new DateTime(2030, 3, 5, 10, 0, 0, DateTimeKind.Utc);

        var first = await PlaceOrderAsync(customerId, day);
        var second = await PlaceOrderAsync(customerId, day.AddHours(1));
        var nextDay = await PlaceOrderAsync(customerId, day.AddDays(1));

        Assert.That(first.OrderNumber, Is.EqualTo("20300305-0001"));
        Assert.That(second.OrderNumber, Is.EqualTo("20300305-0002"));
        Assert.That(nextDay.OrderNumber, Is.EqualTo("20300306-0001"));
    }

    [Test]
    public async Task OrderCreate_SavesTheOrderWithItsLinesAndTheStatusPending()
    {
        var customerId = await CreateCustomerAsync();

        var created = await PlaceOrderAsync(customerId, new DateTime(2030, 3, 5, 10, 0, 0, DateTimeKind.Utc));

        using var scope = _provider.CreateScope();
        var order = await scope.ServiceProvider.GetRequiredService<OrderDbContext>().Orders
            .Include(o => o.Lines)
            .SingleAsync(o => o.Id == created.OrderId);
        Assert.That(order.OrderStatusId, Is.EqualTo(OrderStatuses.PendingId));
        Assert.That(order.Total, Is.EqualTo(20m));
        Assert.That(order.Lines, Has.Count.EqualTo(1));
        Assert.That(order.Lines.Single().UnitPrice, Is.EqualTo(10m));
    }

    [Test]
    public async Task OrderCreate_WhenManyOrdersArriveAtTheSameMoment_NeverHandsOutANumberTwice()
    {
        var customerId = await CreateCustomerAsync();
        var day = new DateTime(2030, 3, 5, 10, 0, 0, DateTimeKind.Utc);

        var created = await Task.WhenAll(Enumerable.Range(0, 10).Select(_ => Task.Run(() => PlaceOrderAsync(customerId, day))));

        var numbers = created.Select(c => c.OrderNumber).ToList();
        Assert.That(numbers, Is.Unique);
        Assert.That(numbers.OrderBy(n => n), Is.EqualTo(Enumerable.Range(1, 10).Select(i => $"20300305-{i:0000}")));
    }

    [Test]
    public async Task OrderCreate_AfterTheDailyLimit_AnswersBadRequestAndKeepsTheCounter()
    {
        var customerId = await CreateCustomerAsync();
        var day = new DateTime(2030, 3, 5, 10, 0, 0, DateTimeKind.Utc);
        using (var scope = _provider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
            context.DailyOrderCounters.Add(new DailyOrderCounter { Date = DateOnly.FromDateTime(day), LastNumber = OrderCreateCommandHandler.DailyLimit });
            await context.SaveChangesAsync();
        }

        using (var scope = _provider.CreateScope())
        {
            var command = new OrderCreateCommand { OrderId = Guid.NewGuid(), PlacedAt = day, CustomerId = customerId, Total = 5m };
            var response = await new OrderCreateCommandHandler(scope.ServiceProvider.GetRequiredService<OrderDbContext>()).HandleAsync(command);

            Assert.That(response.IsFailed, Is.True);
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.DailyLimitReached.CreateCatError(OrderCreateCommandHandler.DailyLimit).Code));
        }

        using var readScope = _provider.CreateScope();
        var counter = await readScope.ServiceProvider.GetRequiredService<OrderDbContext>().DailyOrderCounters.SingleAsync();
        Assert.That(counter.LastNumber, Is.EqualTo(OrderCreateCommandHandler.DailyLimit));
        Assert.That(await CountAsync<Order>(), Is.Zero);
    }

    [Test]
    public async Task OrderCreate_WhenSavingTheOrderFails_TheCounterGoesBackWithIt()
    {
        var day = new DateTime(2030, 3, 5, 10, 0, 0, DateTimeKind.Utc);

        using (var scope = _provider.CreateScope())
        {
            // The customer does not exist, so the foreign key stops the insert after the counter was taken.
            var command = new OrderCreateCommand { OrderId = Guid.NewGuid(), PlacedAt = day, CustomerId = Guid.NewGuid(), Total = 5m };
            var handler = new OrderCreateCommandHandler(scope.ServiceProvider.GetRequiredService<OrderDbContext>());

            await Assert.ThrowsAsync<DbUpdateException>(() => handler.HandleAsync(command));
        }

        Assert.That(await CountAsync<DailyOrderCounter>(), Is.Zero);
        var customerId = await CreateCustomerAsync();
        Assert.That((await PlaceOrderAsync(customerId, day)).OrderNumber, Is.EqualTo("20300305-0001"));
    }
}
