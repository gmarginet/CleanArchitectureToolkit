using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// Reserves stock for an order in the Inventory service. Without the AppHost a fake implements it.
/// Inventory identifies an order by its order number and a book by its ISBN.
/// </summary>
public interface IStockReservation
{
    /// <summary>Reserves every line, or none of them.</summary>
    Task<StockReservationResult> ReserveAsync(string orderNumber, IReadOnlyCollection<StockReservationLine> lines, CancellationToken cancellationToken = default);

    /// <summary>Releases the stock of an order. Releasing an order without a reservation does nothing.</summary>
    Task ReleaseAsync(string orderNumber, CancellationToken cancellationToken = default);
}

/// <summary>One book and the number of copies to reserve. Orders knows the book by its id, Inventory by its ISBN.</summary>
public record StockReservationLine(Guid BookId, string Isbn, int Quantity);

/// <summary>
/// The outcome of a reservation. <paramref name="OutOfStockBookId"/> names the first book that is not available.
/// <paramref name="Unavailable"/> is true when the provider could not answer, for example when it is down or its circuit is open.
/// The stock is then neither reserved nor refused.
/// </summary>
public record StockReservationResult(bool Reserved, Guid? OutOfStockBookId, bool Unavailable = false);
