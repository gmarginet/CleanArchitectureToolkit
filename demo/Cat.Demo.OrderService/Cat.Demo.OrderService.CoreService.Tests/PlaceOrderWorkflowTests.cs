using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Workflows;
using Cat.Demo.OrderService.CoreService.Workflows.Steps;
using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.EventAggregators.Abstractions;
using Cat.EventAggregators.Extensions;
using Cat.FluentWorkflows.Commands.Extensions;
using Cat.FluentWorkflows.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Responses.Abstractions;
using Cat.Sagas;
using Cat.Sagas.Abstractions;
using Cat.Sagas.Extensions;
using Cat.ServiceRequests.Abstractions;
using Cat.UnitTesting.Commands;
using Cat.UnitTesting.EventAggregators;
using Cat.UnitTesting.Messaging;
using Cat.UnitTesting.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

/// <summary>
/// The place order saga from the start to the answer of Payment. The saga runs in memory with a fake sender,
/// and a test plays the part of Payment by giving the dispatcher the answer.
/// </summary>
[TestFixture]
public class PlaceOrderWorkflowTests : UnitTestBase
{
    private static readonly TimeSpan PaymentTimeout = TimeSpan.FromMinutes(2);

    private readonly FakeCommandProcessor _commandProcessor = new FakeCommandProcessor().Apply();
    private readonly FakePriceProvider _priceProvider = new();
    private readonly FakeStockReservation _stockReservation = new();
    private readonly FakeMessageSender _sender = new();

    private IServiceScope _scope = null!;
    private RecordingSubscriber<IOrderEvent> _events = null!;

    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatBuildInCommandWorkflowStep();
        services.AddCatFluentWorkflowsFlows(typeof(PlaceOrderWorkflow));
        services.AddCatFluentWorkflowsSteps(typeof(PriceLinesStep));
        services.AddCatEventAggregatorsModule();

        services.AddCatSagasModule();
        services.AddCatSagasInMemoryStore();
        services.AddCatSaga<PlaceOrderWorkflow, PlaceOrderState>();
        services.AddSingleton(new PlaceOrderOptions { PaymentTimeout = PaymentTimeout });
        services.AddSingleton<ICatMessageSender>(_sender);

        services.AddSingleton<Cat.Commands.Abstractions.ICatCommandProcessor>(_commandProcessor);
        services.AddSingleton<IPriceProvider>(_priceProvider);
        services.AddSingleton<IStockReservation>(_stockReservation);
    }

    [SetUp]
    public void SetUp()
    {
        _commandProcessor.Reset();
        _commandProcessor.Apply();
        _sender.Reset();
        _priceProvider.Price = 10m;
        _priceProvider.Fail = false;
        _priceProvider.UnknownBooks.Clear();
        _stockReservation.OutOfStock = false;
        _stockReservation.Unavailable = false;
        _stockReservation.Reserved.Clear();
        _stockReservation.Released.Clear();

        _scope = ServiceProvider.CreateScope();
        _events = new RecordingSubscriber<IOrderEvent>();
        ServiceProvider.GetRequiredService<ICatEventAggregator>().Subscribe(_events);
    }

    [TearDown]
    public void TearDown()
    {
        ServiceProvider.GetRequiredService<ICatEventAggregator>().Unsubscribe(_events);
        _scope.Dispose();
    }

    private static PlaceOrderState NewState(params (Guid BookId, int Quantity)[] lines) => new()
    {
        OrderId = OrderCommandDefaults.NewOrderId,
        PlacedAt = new DateTime(2026, 11, 5, 10, 0, 0, DateTimeKind.Utc),
        CustomerExternalId = "alice",
        CustomerName = "Alice Jansen",
        CustomerEmail = "alice@example.com",
        Lines = [.. lines.Select(x => new PlaceOrderLineState { BookId = x.BookId, Quantity = x.Quantity })]
    };

    private Task<CatSagaResult> StartAsync(PlaceOrderState state)
        => _scope.ServiceProvider.GetRequiredService<ICatSagaRunner>().StartAsync<PlaceOrderWorkflow, PlaceOrderState>(state);

    /// <summary>Plays Payment: gives the saga the answer for the instance, with the correlation id of the request.</summary>
    private Task<ICatResponse> AnswerAsync(CatSagaResult started, bool approved, string? reference = "REF")
        => _scope.ServiceProvider.GetRequiredService<ICatSagaDispatcher>().ResumeAsync(started.InstanceId, new PaymentProcessed
        {
            CorrelationId = started.InstanceId,
            OrderNumber = OrderCommandDefaults.NewOrderNumber,
            Approved = approved,
            Reference = reference
        });

    private Task<CatSagaInstance?> InstanceAsync(CatSagaResult started)
        => _scope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(started.InstanceId);

    [Test]
    public async Task WhenEverythingWorks_ShouldCreateTheOrderAskForThePaymentAndWait()
    {
        var bookA = Guid.NewGuid();
        var bookB = Guid.NewGuid();
        _priceProvider.Price = 12.50m;

        var result = await StartAsync(NewState((bookA, 2), (bookB, 1)));

        var create = _commandProcessor.Of<OrderCreateCommand>().Single();
        var request = _sender.Of<TakePayment>().Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Waiting));
            Assert.That(result.Errors, Is.Empty);
            Assert.That(create.OrderId, Is.EqualTo(OrderCommandDefaults.NewOrderId));
            Assert.That(create.Total, Is.EqualTo(37.50m));
            Assert.That(create.Lines, Is.EqualTo(new[] { new OrderCreateLine(bookA, 2, 12.50m), new OrderCreateLine(bookB, 1, 12.50m) }));
            Assert.That(_stockReservation.Reserved, Is.EqualTo(new[] { OrderCommandDefaults.NewOrderNumber }));
            Assert.That(request.OrderNumber, Is.EqualTo(OrderCommandDefaults.NewOrderNumber));
            Assert.That(request.Amount, Is.EqualTo(37.50m));
            Assert.That(request.CorrelationId, Is.EqualTo(result.InstanceId));
            Assert.That(_commandProcessor.Of<PaymentSaveCommand>(), Is.Empty);
            Assert.That(_events.Events, Is.Empty);
        }
    }

    [Test]
    public async Task WhenWaitingForThePayment_ShouldScheduleATimeoutFromTheOptions()
    {
        var before = DateTimeOffset.UtcNow;

        await StartAsync(NewState((Guid.NewGuid(), 1)));

        var timeout = _sender.Sent.Single(x => x.Message is CatSagaTimeout);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(timeout.ScheduledAt, Is.Not.Null);
            Assert.That(timeout.ScheduledAt!.Value, Is.GreaterThanOrEqualTo(before + PaymentTimeout));
            Assert.That(timeout.ScheduledAt!.Value, Is.LessThan(before + PaymentTimeout + TimeSpan.FromMinutes(1)));
        }
    }

    [Test]
    public async Task WhenThePaymentIsApproved_ShouldSaveItAndConfirmTheOrder()
    {
        var started = await StartAsync(NewState((Guid.NewGuid(), 2)));

        var response = await AnswerAsync(started, approved: true);

        var payment = _commandProcessor.Of<PaymentSaveCommand>().Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(payment.OrderId, Is.EqualTo(OrderCommandDefaults.NewOrderId));
            Assert.That(payment.Approved, Is.True);
            Assert.That(payment.Amount, Is.EqualTo(20m));
            Assert.That((await InstanceAsync(started))!.Status, Is.EqualTo(CatSagaStatus.Completed));
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderConfirmedEvent(OrderCommandDefaults.NewOrderId, OrderCommandDefaults.NewOrderNumber, 20m)));
        }
    }

    [Test]
    public async Task ShouldCreateTheCustomerFromTheState()
    {
        await StartAsync(NewState((Guid.NewGuid(), 1)));

        var customer = _commandProcessor.Of<CustomerCreateOrUpdateCommand>().Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(customer.ExternalId, Is.EqualTo("alice"));
            Assert.That(customer.Name, Is.EqualTo("Alice Jansen"));
            Assert.That(customer.Email, Is.EqualTo("alice@example.com"));
        }
    }

    [Test]
    public async Task WhenAPriceIsMissing_ShouldFailBeforeTheOrderIsCreated()
    {
        var unknown = Guid.NewGuid();
        _priceProvider.UnknownBooks.Add(unknown);

        var result = await StartAsync(NewState((Guid.NewGuid(), 1), (unknown, 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Failed));
            Assert.That(result.Errors.Single().Code, Is.EqualTo(OrderErrorDefinitions.PriceUnavailable.Code));
            Assert.That(result.Errors.Single().Arguments, Is.EqualTo(new object?[] { unknown }));
            Assert.That(_commandProcessor.Of<OrderCreateCommand>(), Is.Empty);
            Assert.That(_sender.Sent, Is.Empty);
            Assert.That(_events.Events, Is.Empty);
        }
    }

    [Test]
    public async Task WhenThePriceProviderFails_ShouldPassItsErrorsOn()
    {
        _priceProvider.Fail = true;

        var result = await StartAsync(NewState((Guid.NewGuid(), 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Failed));
            Assert.That(result.Errors.Single().Code, Is.EqualTo(OrderErrorDefinitions.PriceUnavailable.Code));
            Assert.That(_commandProcessor.Of<OrderCreateCommand>(), Is.Empty);
        }
    }

    [Test]
    public async Task WhenTheOrderCannotBeCreated_ShouldStopBeforeStockAndPayment()
    {
        _commandProcessor.Respond<OrderCreateCommand, OrderCreated>(
            Cat.Responses.CatResponse.BadRequest<OrderCreated>(OrderErrorDefinitions.DailyLimitReached.CreateCatError(9999)));

        var result = await StartAsync(NewState((Guid.NewGuid(), 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Failed));
            Assert.That(result.Errors.Single().Code, Is.EqualTo(OrderErrorDefinitions.DailyLimitReached.Code));
            Assert.That(_stockReservation.Reserved, Is.Empty);
            Assert.That(_sender.Of<TakePayment>(), Is.Empty);
            Assert.That(_events.Events, Is.Empty);
        }
    }

    [Test]
    public async Task WhenOutOfStock_ShouldCancelTheOrderAndSkipThePayment()
    {
        var book = Guid.NewGuid();
        _stockReservation.OutOfStock = true;
        _stockReservation.OutOfStockBookId = book;

        var result = await StartAsync(NewState((book, 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Failed));
            Assert.That(result.Errors.Single().Code, Is.EqualTo(OrderErrorDefinitions.OutOfStock.Code));
            Assert.That(result.Errors.Single().Arguments, Is.EqualTo(new object?[] { book, OrderCommandDefaults.NewOrderNumber }));
            Assert.That(_sender.Of<TakePayment>(), Is.Empty);
            Assert.That(_commandProcessor.Of<PaymentSaveCommand>(), Is.Empty);
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderCancelledEvent(OrderCommandDefaults.NewOrderId, OrderCommandDefaults.NewOrderNumber, OrderCancelReasons.OutOfStock)));
        }
    }

    [Test]
    public async Task WhenTheInventoryServiceIsUnavailable_ShouldCancelTheOrderAndSkipThePayment()
    {
        _stockReservation.Unavailable = true;

        var result = await StartAsync(NewState((Guid.NewGuid(), 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Failed));
            Assert.That(result.Errors.Single().Code, Is.EqualTo(OrderErrorDefinitions.StockUnavailable.Code));
            Assert.That(_sender.Of<TakePayment>(), Is.Empty);
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderCancelledEvent(OrderCommandDefaults.NewOrderId, OrderCommandDefaults.NewOrderNumber, OrderCancelReasons.StockUnavailable)));
        }
    }

    [Test]
    public async Task WhenThePaymentIsDeclined_ShouldSaveItAndCancelTheOrder()
    {
        var started = await StartAsync(NewState((Guid.NewGuid(), 1)));

        await AnswerAsync(started, approved: false, reference: null);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_commandProcessor.Of<PaymentSaveCommand>().Single().Approved, Is.False);
            Assert.That((await InstanceAsync(started))!.Status, Is.EqualTo(CatSagaStatus.Failed));
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderCancelledEvent(OrderCommandDefaults.NewOrderId, OrderCommandDefaults.NewOrderNumber, OrderCancelReasons.PaymentDeclined)));
        }
    }

    [Test]
    public async Task WhenPaymentDoesNotAnswerInTime_ShouldCancelTheOrderAndSaveNoPayment()
    {
        var started = await StartAsync(NewState((Guid.NewGuid(), 1)));
        var timeout = _sender.Of<CatSagaTimeout>().Single();

        await _scope.ServiceProvider.GetRequiredService<ICatSagaDispatcher>().TimeoutAsync(timeout.CorrelationId, timeout.WaitId);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_commandProcessor.Of<PaymentSaveCommand>(), Is.Empty);
            Assert.That((await InstanceAsync(started))!.Status, Is.EqualTo(CatSagaStatus.Failed));
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderCancelledEvent(OrderCommandDefaults.NewOrderId, OrderCommandDefaults.NewOrderNumber, OrderCancelReasons.PaymentUnavailable)));
        }
    }

    [Test]
    public async Task WhenTheAnswerComesAfterTheTimeout_ShouldChangeNothing()
    {
        var started = await StartAsync(NewState((Guid.NewGuid(), 1)));
        var timeout = _sender.Of<CatSagaTimeout>().Single();
        var dispatcher = _scope.ServiceProvider.GetRequiredService<ICatSagaDispatcher>();
        await dispatcher.TimeoutAsync(timeout.CorrelationId, timeout.WaitId);
        _commandProcessor.Reset();
        _commandProcessor.Apply();

        await AnswerAsync(started, approved: true);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_commandProcessor.Of<PaymentSaveCommand>(), Is.Empty);
            Assert.That(_events.Events, Has.Count.EqualTo(1));
            Assert.That(_events.Events.Single(), Is.TypeOf<OrderCancelledEvent>());
        }
    }
}
