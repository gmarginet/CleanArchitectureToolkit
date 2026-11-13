using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.EventAggregators.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Users.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

/// <summary>The current user for tests. It is a user of the package, with the email address that Orders asks for.</summary>
public class FakeUser : Cat.UnitTesting.Users.FakeUser, IUserEmail
{
    public FakeUser()
    {
        UserId = "alice";
        Name = "Alice Jansen";
    }

    public string Email { get; set; } = "alice@example.com";

    /// <summary>Gives or takes the admin role.</summary>
    public bool IsAdmin
    {
        get => IsInRole(CatUserExtensions.AdminRole);
        set
        {
            if (value)
            {
                Roles.Add(CatUserExtensions.AdminRole);
            }
            else
            {
                Roles.Remove(CatUserExtensions.AdminRole);
            }
        }
    }
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

    /// <summary>When set, the reservation cancels this source and throws, like a caller that gives up during the call.</summary>
    public CancellationTokenSource? CancelCallerOnReserve { get; set; }

    public Task<StockReservationResult> ReserveAsync(string orderNumber, IReadOnlyCollection<StockReservationLine> lines, CancellationToken cancellationToken = default)
    {
        if (CancelCallerOnReserve is not null)
        {
            CancelCallerOnReserve.Cancel();
            throw new OperationCanceledException(cancellationToken);
        }

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

