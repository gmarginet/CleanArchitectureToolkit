using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// Reserves stock for an order in the Inventory service. Until Inventory exists a fake implements it.
/// Inventory identifies an order by its order number.
/// </summary>
public interface IStockReservation
{
    /// <summary>Reserves every line, or none of them.</summary>
    Task<StockReservationResult> ReserveAsync(string orderNumber, IReadOnlyCollection<StockReservationLine> lines, CancellationToken cancellationToken = default);

    /// <summary>Releases the stock of an order. Releasing an order without a reservation does nothing.</summary>
    Task ReleaseAsync(string orderNumber, CancellationToken cancellationToken = default);
}

/// <summary>One book and the number of copies to reserve.</summary>
public record StockReservationLine(Guid BookId, int Quantity);

/// <summary>The outcome of a reservation. <paramref name="OutOfStockBookId"/> names the first book that is not available.</summary>
public record StockReservationResult(bool Reserved, Guid? OutOfStockBookId);
