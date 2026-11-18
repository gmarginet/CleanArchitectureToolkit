using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.EventSubscribers;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;
using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.EventAggregators.Abstractions;
using Cat.EventAggregators.Extensions;
using Cat.Responses;
using Cat.UnitTesting.Commands;
using Cat.UnitTesting.Responses.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class PaymentRefundTests
{
    private FakeCommandProcessor _commandProcessor = null!;
    private ServiceProvider _provider = null!;
    private ICatEventAggregator _eventAggregator = null!;

    [SetUp]
    public void SetUp()
    {
        _commandProcessor = new FakeCommandProcessor().Apply();

        var services = new ServiceCollection();
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatEventAggregatorsModule();
        services.AddCatDemoOrderEventSubscribers();
        services.AddSingleton<ICatCommandProcessor>(_commandProcessor);
        services.AddSingleton<IStockReservation>(new FakeStockReservation());
        _provider = services.BuildServiceProvider();
        _provider.ActivateCatDemoOrderEventSubscribers();
        _eventAggregator = _provider.GetRequiredService<ICatEventAggregator>();
    }

    [TearDown]
    public void TearDown() => _provider.Dispose();

    [Test]
    public async Task ACancelledOrder_AsksForTheRefund()
    {
        var orderId = Guid.NewGuid();

        await _eventAggregator.PublishAsync(new OrderCancelledEvent(orderId, "20261118-0001", OrderCancelReasons.CancelledByUser));

        Assert.That(_commandProcessor.Of<PaymentRefundRequestCommand>().Single(), Is.EqualTo(new PaymentRefundRequestCommand(orderId, "20261118-0001")));
    }

    [Test]
    public async Task WhenTheRefundCannotBeRequested_ShouldThrowToThePublisher()
    {
        _commandProcessor.Respond<PaymentRefundRequestCommand>(CatResponse.InternalServerError());

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => _eventAggregator.PublishAsync(new OrderCancelledEvent(Guid.NewGuid(), "20261118-0002", OrderCancelReasons.CancelledByUser)));
    }

    [Test]
    public async Task ARefundedAnswer_SavesTheRefund()
    {
        var handler = new PaymentRefundedHandler(_commandProcessor);

        var response = await handler.HandleAsync(new PaymentRefunded { OrderNumber = "20261118-0001", Refunded = true });

        Assert.That(response, CatIs.Succeeded);
        Assert.That(_commandProcessor.Of<PaymentRefundedSaveCommand>().Single(), Is.EqualTo(new PaymentRefundedSaveCommand("20261118-0001")));
    }

    [Test]
    public async Task AnAnswerWithNothingToRefund_SavesNothingAndCountsAsHandled()
    {
        var handler = new PaymentRefundedHandler(_commandProcessor);

        var response = await handler.HandleAsync(new PaymentRefunded { OrderNumber = "20261118-0001", Refunded = false });

        Assert.That(response, CatIs.Succeeded);
        Assert.That(_commandProcessor.Of<PaymentRefundedSaveCommand>(), Is.Empty);
    }
}
