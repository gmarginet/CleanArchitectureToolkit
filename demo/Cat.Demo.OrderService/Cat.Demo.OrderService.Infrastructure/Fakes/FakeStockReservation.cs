using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.Fakes;

/// <summary>
/// A stand-in for the Inventory service. A line with more than <see cref="MaximumQuantity"/> copies is out of stock.
/// It remembers the reservations in memory. The Inventory service replaces this class.
/// </summary>
public class FakeStockReservation : IStockReservation
{
    public const int MaximumQuantity = 50;

    private readonly ConcurrentDictionary<string, IReadOnlyCollection<StockReservationLine>> _reservations = new();

    public Task<StockReservationResult> ReserveAsync(string orderNumber, IReadOnlyCollection<StockReservationLine> lines, CancellationToken cancellationToken = default)
    {
        var outOfStock = lines.FirstOrDefault(x => x.Quantity > MaximumQuantity);
        if (outOfStock is not null)
        {
            return Task.FromResult(new StockReservationResult(false, outOfStock.BookId));
        }

        _reservations[orderNumber] = lines;
        return Task.FromResult(new StockReservationResult(true, null));
    }

    public Task ReleaseAsync(string orderNumber, CancellationToken cancellationToken = default)
    {
        _reservations.TryRemove(orderNumber, out _);
        return Task.CompletedTask;
    }
}
