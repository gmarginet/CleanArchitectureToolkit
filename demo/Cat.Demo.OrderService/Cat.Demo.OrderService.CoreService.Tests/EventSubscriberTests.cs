using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.EventSubscribers;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.EventAggregators.Abstractions;
using Cat.EventAggregators.Extensions;
using Cat.Responses;
using Cat.UnitTesting.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class EventSubscriberTests
{
    private FakeCommandProcessor _commandProcessor = null!;
    private FakeStockReservation _stockReservation = null!;
    private ServiceProvider _provider = null!;
    private ICatEventAggregator _eventAggregator = null!;

    [SetUp]
    public void SetUp()
    {
        _commandProcessor = new FakeCommandProcessor().Apply();
        _stockReservation = new FakeStockReservation();

        var services = new ServiceCollection();
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatEventAggregatorsModule();
        services.AddCatDemoOrderEventSubscribers();
        services.AddSingleton<ICatCommandProcessor>(_commandProcessor);
        services.AddSingleton<IStockReservation>(_stockReservation);
        _provider = services.BuildServiceProvider();
        _provider.ActivateCatDemoOrderEventSubscribers();
        _eventAggregator = _provider.GetRequiredService<ICatEventAggregator>();
    }

    [TearDown]
    public void TearDown() => _provider.Dispose();

    [Test]
    public async Task OrderConfirmed_ShouldSetTheStatusToConfirmed()
    {
        var orderId = Guid.NewGuid();

        await _eventAggregator.PublishAsync(new OrderConfirmedEvent(orderId, "20261105-0001", 10m));

        Assert.That(_commandProcessor.Of<OrderSetStatusCommand>().Single(), Is.EqualTo(new OrderSetStatusCommand(orderId, OrderStatuses.ConfirmedCode)));
        Assert.That(_stockReservation.Released, Is.Empty);
    }

    [Test]
    public async Task OrderCancelledBecauseInventoryIsUnavailable_ShouldSetTheStatusAndSkipTheRelease()
    {
        var orderId = Guid.NewGuid();

        await _eventAggregator.PublishAsync(new OrderCancelledEvent(orderId, "20261105-0003", OrderCancelReasons.StockUnavailable));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_commandProcessor.Of<OrderSetStatusCommand>().Single(), Is.EqualTo(new OrderSetStatusCommand(orderId, OrderStatuses.CancelledCode)));
            Assert.That(_stockReservation.Released, Is.Empty);
        }
    }

    [Test]
    public async Task OrderCancelled_ShouldSetTheStatusToCancelledAndReleaseTheStock()
    {
        var orderId = Guid.NewGuid();

        await _eventAggregator.PublishAsync(new OrderCancelledEvent(orderId, "20261105-0002", OrderCancelReasons.CancelledByUser));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_commandProcessor.Of<OrderSetStatusCommand>().Single(), Is.EqualTo(new OrderSetStatusCommand(orderId, OrderStatuses.CancelledCode)));
            Assert.That(_stockReservation.Released, Is.EqualTo(new[] { "20261105-0002" }));
        }
    }

    [Test]
    public async Task WhenTheStatusCannotBeSet_ShouldThrowToThePublisher()
    {
        _commandProcessor.Respond<OrderSetStatusCommand>(CatResponse.InternalServerError());

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _eventAggregator.PublishAsync(new OrderConfirmedEvent(Guid.NewGuid(), "20261105-0003", 10m)));
    }
}
