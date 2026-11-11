using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.EventAggregators.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

/// <summary>
/// A command processor for tests. It records the commands and answers them without a database.
/// By default it fills the result properties the way the real handlers do.
/// </summary>
public class FakeCommandProcessor : ICatCommandProcessor
{
    /// <summary>The order id that <c>NewState</c> in the workflow tests puts in the state.</summary>
    public static readonly Guid NewOrderId = Guid.Parse("11111111-1111-1111-1111-111111111111");

    public const string NewOrderNumber = "20261105-0001";

    /// <summary>The customer id the fake hands out.</summary>
    public static readonly Guid CustomerId = Guid.Parse("22222222-2222-2222-2222-222222222222");

    /// <summary>Gives a response for a command type instead of the default. Return null to use the default.</summary>
    public Dictionary<Type, ICatResponse> Responses { get; } = [];

    /// <summary>Every command that was processed, in order.</summary>
    public List<object> Commands { get; } = [];

    public Task<ICatResponse> ProcessAsync(ICatCommand catCommand, CancellationToken cancellationToken = default)
        => Task.FromResult(Process(catCommand));

    public ICatResponse Process(ICatCommand catCommand)
    {
        Commands.Add(catCommand);

        if (Responses.TryGetValue(catCommand.GetType(), out var response))
        {
            return response;
        }

        switch (catCommand)
        {
            case CustomerCreateOrUpdateCommand customer:
                customer.CustomerId = CustomerId;
                break;
        }

        return CatResponse.Ok();
    }

    public Task<ICatResponse<TResult>> ProcessAsync<TResult>(ICatCommand<TResult> catCommand, CancellationToken cancellationToken = default)
        => Task.FromResult(Process(catCommand));

    public ICatResponse<TResult> Process<TResult>(ICatCommand<TResult> catCommand)
    {
        Commands.Add(catCommand);

        if (Responses.TryGetValue(catCommand.GetType(), out var response))
        {
            return (ICatResponse<TResult>)response;
        }

        if (catCommand is OrderCreateCommand order)
        {
            return (ICatResponse<TResult>)CatResponse.Ok(new OrderCreated(order.OrderId, NewOrderNumber));
        }

        throw new NotSupportedException($"No answer is set up for {catCommand.GetType().Name}.");
    }

    public IEnumerable<T> Of<T>() => Commands.OfType<T>();
}

/// <summary>A query processor for tests. Set up the response per query type.</summary>
public class FakeQueryProcessor : ICatQueryProcessor
{
    private readonly Dictionary<Type, object> _responses = [];

    /// <summary>Every query that was processed, in order.</summary>
    public List<object> Queries { get; } = [];

    public void Setup<TQuery, TQueryResult>(ICatResponse<TQueryResult> response)
        where TQuery : ICatQuery<TQueryResult>
    {
        _responses[typeof(TQuery)] = response;
    }

    public Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(ICatQuery<TQueryResult> catQuery, CancellationToken cancellationToken = default)
        => Task.FromResult(Process(catQuery));

    public ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery)
    {
        Queries.Add(catQuery);

        return _responses.TryGetValue(catQuery.GetType(), out var configured)
            ? (ICatResponse<TQueryResult>)configured
            : throw new NotSupportedException($"The fake has no response for {catQuery.GetType().Name}.");
    }
}

/// <summary>The current user for tests.</summary>
public class FakeCurrentUser : ICurrentUser
{
    public bool IsAuthenticated { get; set; } = true;
    public string UserId { get; set; } = "alice";
    public string Name { get; set; } = "Alice Jansen";
    public string Email { get; set; } = "alice@example.com";
    public bool IsAdmin { get; set; }
}

/// <summary>A price provider for tests. Every book costs 10 euro, unless the test changes it.</summary>
public class FakePriceProvider : IPriceProvider
{
    public decimal Price { get; set; } = 10m;
    public bool Fail { get; set; }
    public HashSet<Guid> UnknownBooks { get; } = [];

    public Task<ICatResponse<IReadOnlyDictionary<Guid, BookPrice>>> GetPricesAsync(IReadOnlyCollection<Guid> bookIds, CancellationToken cancellationToken = default)
    {
        if (Fail)
        {
            return Task.FromResult(CatResponse.NotFound<IReadOnlyDictionary<Guid, BookPrice>>(OrderErrorDefinitions.PriceUnavailable.CreateCatError(bookIds.First())));
        }

        IReadOnlyDictionary<Guid, BookPrice> prices = bookIds
            .Where(x => !UnknownBooks.Contains(x))
            .ToDictionary(x => x, _ => new BookPrice(Price, "9780000000002"));

        return Task.FromResult(CatResponse.Ok(prices));
    }
}

/// <summary>A stock reservation for tests. It records what it was asked.</summary>
public class FakeStockReservation : IStockReservation
{
    public bool OutOfStock { get; set; }
    public bool Unavailable { get; set; }
    public Guid? OutOfStockBookId { get; set; }
    public List<string> Reserved { get; } = [];
    public List<string> Released { get; } = [];

    public Task<StockReservationResult> ReserveAsync(string orderNumber, IReadOnlyCollection<StockReservationLine> lines, CancellationToken cancellationToken = default)
    {
        if (Unavailable)
        {
            return Task.FromResult(new StockReservationResult(false, null, Unavailable: true));
        }

        if (OutOfStock)
        {
            return Task.FromResult(new StockReservationResult(false, OutOfStockBookId ?? lines.First().BookId));
        }

        Reserved.Add(orderNumber);
        return Task.FromResult(new StockReservationResult(true, null));
    }

    public Task ReleaseAsync(string orderNumber, CancellationToken cancellationToken = default)
    {
        Released.Add(orderNumber);
        return Task.CompletedTask;
    }
}

/// <summary>A payment provider for tests.</summary>
public class FakePaymentProvider : IPaymentProvider
{
    public bool Approve { get; set; } = true;
    public bool Unavailable { get; set; }
    public List<(string OrderNumber, decimal Amount)> Payments { get; } = [];

    public Task<PaymentResult> TakePaymentAsync(string orderNumber, decimal amount, CancellationToken cancellationToken = default)
    {
        Payments.Add((orderNumber, amount));
        return Task.FromResult(Unavailable
            ? new PaymentResult(false, null, Unavailable: true)
            : new PaymentResult(Approve, Approve ? "REF" : null));
    }
}

/// <summary>Collects every order event. Keep a reference to it while it must receive events, because the aggregator holds it weakly.</summary>
public class RecordingSubscriber : ICatHandleEvent<IOrderEvent>
{
    public List<IOrderEvent> Events { get; } = [];

    public Task HandleEventAsync(IOrderEvent @event, CancellationToken cancellationToken = default)
    {
        Events.Add(@event);
        return Task.CompletedTask;
    }
}
