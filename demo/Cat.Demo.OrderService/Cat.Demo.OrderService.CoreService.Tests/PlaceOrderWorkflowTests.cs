using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Workflows;
using Cat.Demo.OrderService.CoreService.Workflows.Steps;
using Cat.EventAggregators.Abstractions;
using Cat.EventAggregators.Extensions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands.Extensions;
using Cat.FluentWorkflows.Extensions;
using Cat.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class PlaceOrderWorkflowTests : UnitTestBase
{
    private readonly FakeCommandProcessor _commandProcessor = new();
    private readonly FakePriceProvider _priceProvider = new();
    private readonly FakeStockReservation _stockReservation = new();
    private readonly FakePaymentProvider _paymentProvider = new();

    private IServiceScope _scope = null!;
    private RecordingSubscriber _events = null!;

    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatBuildInCommandWorkflowStep();
        services.AddCatFluentWorkflowsFlows(typeof(PlaceOrderWorkflow));
        services.AddCatFluentWorkflowsSteps(typeof(PriceLinesStep));
        services.AddCatEventAggregatorsModule();

        services.AddSingleton<Cat.Commands.Abstractions.ICatCommandProcessor>(_commandProcessor);
        services.AddSingleton<IPriceProvider>(_priceProvider);
        services.AddSingleton<IStockReservation>(_stockReservation);
        services.AddSingleton<IPaymentProvider>(_paymentProvider);
    }

    [SetUp]
    public void SetUp()
    {
        _commandProcessor.Commands.Clear();
        _commandProcessor.Responses.Clear();
        _priceProvider.Fail = false;
        _priceProvider.UnknownBooks.Clear();
        _stockReservation.OutOfStock = false;
        _stockReservation.Reserved.Clear();
        _stockReservation.Released.Clear();
        _paymentProvider.Approve = true;
        _paymentProvider.Payments.Clear();

        _scope = ServiceProvider.CreateScope();
        _events = new RecordingSubscriber();
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
        CustomerExternalId = "alice",
        CustomerName = "Alice Jansen",
        CustomerEmail = "alice@example.com",
        Lines = [.. lines.Select(x => new PlaceOrderLineState { BookId = x.BookId, Quantity = x.Quantity })]
    };

    private Task<ICatWorkflowResponse> RunAsync(PlaceOrderState state)
        => _scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>().RunAsync<PlaceOrderWorkflow, PlaceOrderState>(state, CancellationToken.None);

    [Test]
    public async Task WhenEverythingWorks_ShouldPriceTheLinesCreateTheOrderAndConfirm()
    {
        var bookA = Guid.NewGuid();
        var bookB = Guid.NewGuid();
        _priceProvider.Price = 12.50m;
        var state = NewState((bookA, 2), (bookB, 1));

        var response = await RunAsync(state);

        var create = _commandProcessor.Of<OrderCreateCommand>().Single();
        var payment = _commandProcessor.Of<PaymentSaveCommand>().Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.ErrorList, Is.Empty);
            Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
            Assert.That(state.Total, Is.EqualTo(37.50m));
            Assert.That(state.OrderNumber, Is.EqualTo(FakeCommandProcessor.NewOrderNumber));
            Assert.That(create.CustomerId, Is.EqualTo(FakeCommandProcessor.CustomerId));
            Assert.That(create.Total, Is.EqualTo(37.50m));
            Assert.That(create.Lines, Is.EqualTo(new[] { new OrderCreateLine(bookA, 2, 12.50m), new OrderCreateLine(bookB, 1, 12.50m) }));
            Assert.That(payment.Approved, Is.True);
            Assert.That(payment.Amount, Is.EqualTo(37.50m));
            Assert.That(_stockReservation.Reserved, Is.EqualTo(new[] { FakeCommandProcessor.NewOrderNumber }));
            Assert.That(_paymentProvider.Payments.Single().Amount, Is.EqualTo(37.50m));
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderConfirmedEvent(FakeCommandProcessor.NewOrderId, FakeCommandProcessor.NewOrderNumber, 37.50m)));
        }
    }

    [Test]
    public async Task ShouldCreateTheCustomerFromTheState()
    {
        await RunAsync(NewState((Guid.NewGuid(), 1)));

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

        var response = await RunAsync(NewState((Guid.NewGuid(), 1), (unknown, 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.PriceUnavailable.Code));
            Assert.That(response.ErrorList.Single().Arguments, Is.EqualTo(new object?[] { unknown }));
            Assert.That(_commandProcessor.Of<OrderCreateCommand>(), Is.Empty);
            Assert.That(_events.Events, Is.Empty);
        }
    }

    [Test]
    public async Task WhenThePriceProviderFails_ShouldPassItsErrorsOn()
    {
        _priceProvider.Fail = true;

        var response = await RunAsync(NewState((Guid.NewGuid(), 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.PriceUnavailable.Code));
            Assert.That(_commandProcessor.Of<OrderCreateCommand>(), Is.Empty);
        }
    }

    [Test]
    public async Task WhenTheOrderCannotBeCreated_ShouldStopBeforeStockAndPayment()
    {
        _commandProcessor.Responses[typeof(OrderCreateCommand)] =
            Cat.Responses.CatResponse.BadRequest(OrderErrorDefinitions.DailyLimitReached.CreateCatError(9999));

        var response = await RunAsync(NewState((Guid.NewGuid(), 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.DailyLimitReached.Code));
            Assert.That(_stockReservation.Reserved, Is.Empty);
            Assert.That(_paymentProvider.Payments, Is.Empty);
            Assert.That(_events.Events, Is.Empty);
        }
    }

    [Test]
    public async Task WhenOutOfStock_ShouldCancelTheOrderAndSkipThePayment()
    {
        var book = Guid.NewGuid();
        _stockReservation.OutOfStock = true;
        _stockReservation.OutOfStockBookId = book;

        var response = await RunAsync(NewState((book, 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.OutOfStock.Code));
            Assert.That(response.ErrorList.Single().Arguments, Is.EqualTo(new object?[] { book, FakeCommandProcessor.NewOrderNumber }));
            Assert.That(_paymentProvider.Payments, Is.Empty);
            Assert.That(_commandProcessor.Of<PaymentSaveCommand>(), Is.Empty);
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderCancelledEvent(FakeCommandProcessor.NewOrderId, FakeCommandProcessor.NewOrderNumber, OrderCancelReasons.OutOfStock)));
        }
    }

    [Test]
    public async Task WhenThePaymentIsDeclined_ShouldSaveItAndCancelTheOrder()
    {
        _paymentProvider.Approve = false;

        var response = await RunAsync(NewState((Guid.NewGuid(), 1)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.PaymentDeclined.Code));
            Assert.That(_commandProcessor.Of<PaymentSaveCommand>().Single().Approved, Is.False);
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderCancelledEvent(FakeCommandProcessor.NewOrderId, FakeCommandProcessor.NewOrderNumber, OrderCancelReasons.PaymentDeclined)));
        }
    }
}
