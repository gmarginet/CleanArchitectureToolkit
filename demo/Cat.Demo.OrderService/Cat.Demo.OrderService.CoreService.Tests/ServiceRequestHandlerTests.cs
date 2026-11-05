using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;
using Cat.Demo.OrderService.CoreService.Workflows;
using Cat.Demo.OrderService.CoreService.Workflows.Steps;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.EventAggregators.Abstractions;
using Cat.EventAggregators.Extensions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands.Extensions;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class ServiceRequestHandlerTests
{
    private FakeQueryProcessor _queryProcessor = null!;
    private FakeCommandProcessor _commandProcessor = null!;
    private FakeCurrentUser _currentUser = null!;
    private ICatEventAggregator _eventAggregator = null!;
    private RecordingSubscriber _events = null!;

    [SetUp]
    public void SetUp()
    {
        _queryProcessor = new FakeQueryProcessor();
        _commandProcessor = new FakeCommandProcessor();
        _currentUser = new FakeCurrentUser();

        var services = new ServiceCollection();
        services.AddCatEventAggregatorsModule();
        _eventAggregator = services.BuildServiceProvider().GetRequiredService<ICatEventAggregator>();
        _events = new RecordingSubscriber();
        _eventAggregator.Subscribe(_events);
    }

    private static Order NewOrder(string statusCode = OrderStatuses.PendingCode) => new()
    {
        Id = Guid.NewGuid(),
        OrderNumber = "20261105-0007",
        PlacedAt = new DateTime(2026, 11, 5, 10, 0, 0, DateTimeKind.Utc),
        Total = 25m,
        OrderStatus = new OrderStatus { Code = statusCode },
        Lines = [new OrderLine { BookId = Guid.NewGuid(), Quantity = 2, UnitPrice = 12.5m }]
    };

    #region OrderGet

    [Test]
    public async Task OrderGet_ShouldMapTheOrderAndFilterOnTheCurrentUser()
    {
        var order = NewOrder();
        _queryProcessor.Setup<OrderGetQuery, Order>(CatResponse.Ok(order));
        var handler = new OrderGetRequestHandler(_queryProcessor, _currentUser);

        var response = await handler.HandleAsync(new OrderGetRequest(order.Id));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(response.Value!.OrderNumber, Is.EqualTo("20261105-0007"));
            Assert.That(response.Value!.Status, Is.EqualTo(OrderStatuses.PendingCode));
            Assert.That(response.Value!.Total, Is.EqualTo(25m));
            Assert.That(response.Value!.Lines.Single().UnitPrice, Is.EqualTo(12.5m));
            Assert.That(_queryProcessor.Queries.Single(), Is.EqualTo(new OrderGetQuery(order.Id, "alice")));
        }
    }

    [Test]
    public async Task OrderGet_AsAdmin_ShouldNotFilterOnTheUser()
    {
        _currentUser.IsAdmin = true;
        var order = NewOrder();
        _queryProcessor.Setup<OrderGetQuery, Order>(CatResponse.Ok(order));
        var handler = new OrderGetRequestHandler(_queryProcessor, _currentUser);

        await handler.HandleAsync(new OrderGetRequest(order.Id));

        Assert.That(_queryProcessor.Queries.Single(), Is.EqualTo(new OrderGetQuery(order.Id, null)));
    }

    [Test]
    public async Task OrderGet_WhenTheOrderBelongsToSomeoneElse_ShouldPassNotFoundOn()
    {
        _queryProcessor.Setup<OrderGetQuery, Order>(CatResponse.NotFound<Order>());
        var handler = new OrderGetRequestHandler(_queryProcessor, _currentUser);

        var response = await handler.HandleAsync(new OrderGetRequest(Guid.NewGuid()));

        Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.NotFound>());
    }

    [Test]
    public async Task OrderGet_WhenNotAuthenticated_ShouldReturnUnauthorized()
    {
        _currentUser.IsAuthenticated = false;
        var handler = new OrderGetRequestHandler(_queryProcessor, _currentUser);

        var response = await handler.HandleAsync(new OrderGetRequest(Guid.NewGuid()));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.Unauthorized>());
            Assert.That(_queryProcessor.Queries, Is.Empty);
        }
    }

    #endregion OrderGet

    #region OrderGetList

    [Test]
    public async Task OrderGetList_ShouldMapTheSummariesAndFilterOnTheCurrentUser()
    {
        _queryProcessor.Setup<OrderGetListQuery, IList<Order>>(CatResponse.Ok<IList<Order>>([NewOrder(), NewOrder(OrderStatuses.ConfirmedCode)]));
        var handler = new OrderGetListRequestHandler(_queryProcessor, _currentUser);

        var response = await handler.HandleAsync(new OrderGetListRequest());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Value!.Select(x => x.Status), Is.EqualTo(new[] { OrderStatuses.PendingCode, OrderStatuses.ConfirmedCode }));
            Assert.That(_queryProcessor.Queries.Single(), Is.EqualTo(new OrderGetListQuery("alice")));
        }
    }

    [Test]
    public async Task OrderGetList_AsAdmin_ShouldAskForAllOrders()
    {
        _currentUser.IsAdmin = true;
        _queryProcessor.Setup<OrderGetListQuery, IList<Order>>(CatResponse.Ok<IList<Order>>([]));
        var handler = new OrderGetListRequestHandler(_queryProcessor, _currentUser);

        await handler.HandleAsync(new OrderGetListRequest());

        Assert.That(_queryProcessor.Queries.Single(), Is.EqualTo(new OrderGetListQuery(null)));
    }

    #endregion OrderGetList

    #region CancelOrder

    [Test]
    public async Task CancelOrder_ShouldPublishTheCancelledEvent()
    {
        var order = NewOrder(OrderStatuses.ConfirmedCode);
        _queryProcessor.Setup<OrderGetQuery, Order>(CatResponse.Ok(order));
        var handler = new CancelOrderRequestHandler(_queryProcessor, _eventAggregator, _currentUser);

        var response = await handler.HandleAsync(new CancelOrderRequest(order.Id));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(_queryProcessor.Queries.Single(), Is.EqualTo(new OrderGetQuery(order.Id, "alice")));
            Assert.That(_events.Events.Single(), Is.EqualTo(new OrderCancelledEvent(order.Id, order.OrderNumber, OrderCancelReasons.CancelledByUser)));
        }
    }

    [Test]
    public async Task CancelOrder_WhenAlreadyCancelled_ShouldReturnConflict()
    {
        var order = NewOrder(OrderStatuses.CancelledCode);
        _queryProcessor.Setup<OrderGetQuery, Order>(CatResponse.Ok(order));
        var handler = new CancelOrderRequestHandler(_queryProcessor, _eventAggregator, _currentUser);

        var response = await handler.HandleAsync(new CancelOrderRequest(order.Id));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.Conflict>());
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.CannotCancel.Code));
            Assert.That(_events.Events, Is.Empty);
        }
    }

    [Test]
    public async Task CancelOrder_WhenTheOrderBelongsToSomeoneElse_ShouldReturnNotFoundAndPublishNothing()
    {
        _queryProcessor.Setup<OrderGetQuery, Order>(CatResponse.NotFound<Order>());
        var handler = new CancelOrderRequestHandler(_queryProcessor, _eventAggregator, _currentUser);

        var response = await handler.HandleAsync(new CancelOrderRequest(Guid.NewGuid()));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.NotFound>());
            Assert.That(_events.Events, Is.Empty);
        }
    }

    #endregion CancelOrder

    #region CleanUpOrderCounters

    [Test]
    public async Task CleanUpOrderCounters_ShouldSendTheCommand()
    {
        var handler = new CleanUpOrderCountersRequestHandler(_commandProcessor);

        var response = await handler.HandleAsync(new CleanUpOrderCountersRequest());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Succeeded.NoContent>());
            Assert.That(_commandProcessor.Of<OrderCountersCleanUpCommand>().Count(), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task CleanUpOrderCounters_WhenTheCommandFails_ShouldPassTheFailureOn()
    {
        _commandProcessor.Responses[typeof(OrderCountersCleanUpCommand)] = CatResponse.InternalServerError();
        var handler = new CleanUpOrderCountersRequestHandler(_commandProcessor);

        var response = await handler.HandleAsync(new CleanUpOrderCountersRequest());

        Assert.That(response.IsFailed, Is.True);
    }

    #endregion CleanUpOrderCounters

    #region PlaceOrder

    private PlaceOrderRequestHandler NewPlaceOrderHandler(ServiceProvider provider) => new(
        provider.GetRequiredService<ICatWorkflowProcessor>(),
        _queryProcessor,
        _currentUser);

    private ServiceProvider NewWorkflowProvider(FakeStockReservation? stock = null, FakePaymentProvider? payment = null)
    {
        var services = new ServiceCollection();
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatBuildInCommandWorkflowStep();
        services.AddCatFluentWorkflowsFlows(typeof(PlaceOrderWorkflow));
        services.AddCatFluentWorkflowsSteps(typeof(PriceLinesStep));
        services.AddSingleton(_eventAggregator);
        services.AddSingleton<Cat.Commands.Abstractions.ICatCommandProcessor>(_commandProcessor);
        services.AddSingleton<Abstractions.IPriceProvider>(new FakePriceProvider());
        services.AddSingleton<Abstractions.IStockReservation>(stock ?? new FakeStockReservation());
        services.AddSingleton<Abstractions.IPaymentProvider>(payment ?? new FakePaymentProvider());
        return services.BuildServiceProvider();
    }

    private static PlaceOrderRequest NewPlaceOrderRequest() => new(new PlaceOrderModel
    {
        Lines = [new PlaceOrderLineModel { BookId = Guid.NewGuid(), Quantity = 2 }]
    });

    [Test]
    public async Task PlaceOrder_ShouldRunTheWorkflowAndReturnTheCreatedOrder()
    {
        var order = NewOrder(OrderStatuses.ConfirmedCode);
        _queryProcessor.Setup<OrderGetQuery, Order>(CatResponse.Ok(order));
        using var provider = NewWorkflowProvider();
        var handler = NewPlaceOrderHandler(provider);

        var response = await handler.HandleAsync(NewPlaceOrderRequest());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Succeeded.Created>());
            Assert.That(response.Value!.Status, Is.EqualTo(OrderStatuses.ConfirmedCode));
            Assert.That(_queryProcessor.Queries.Single(), Is.EqualTo(new OrderGetQuery(FakeCommandProcessor.NewOrderId, "alice")));
            Assert.That(_events.Events.Single(), Is.TypeOf<OrderConfirmedEvent>());
        }
    }

    [Test]
    public async Task PlaceOrder_WhenTheWorkflowFails_ShouldReturnBadRequestWithItsErrors()
    {
        using var provider = NewWorkflowProvider(stock: new FakeStockReservation { OutOfStock = true });
        var handler = NewPlaceOrderHandler(provider);

        var response = await handler.HandleAsync(NewPlaceOrderRequest());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.BadRequest>());
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(OrderErrorDefinitions.OutOfStock.Code));
            Assert.That(_queryProcessor.Queries, Is.Empty);
        }
    }

    [Test]
    public async Task PlaceOrder_WhenNotAuthenticated_ShouldReturnUnauthorizedWithoutRunningTheWorkflow()
    {
        _currentUser.IsAuthenticated = false;
        using var provider = NewWorkflowProvider();
        var handler = NewPlaceOrderHandler(provider);

        var response = await handler.HandleAsync(NewPlaceOrderRequest());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.Unauthorized>());
            Assert.That(_commandProcessor.Commands, Is.Empty);
        }
    }

    #endregion PlaceOrder
}
