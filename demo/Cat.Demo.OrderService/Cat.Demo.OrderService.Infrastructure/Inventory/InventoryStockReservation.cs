using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Api.Client;
using Cat.Demo.InventoryService.Contracts.Models;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

// The generated client has an ICatError of its own, so only the client itself is imported.
using IInventoryClient = Cat.Demo.InventoryService.Api.Client.IInventoryClient;

namespace Cat.Demo.OrderService.Infrastructure.Inventory;

/// <summary>
/// Reserves stock at the Inventory service, through the generated client and the API gateway.
/// The client shares the Contracts project of Inventory, so the request models are the ones Inventory uses.
/// An out of stock book (409) or a book that Inventory does not know (404) is an answer, and the order is refused.
/// When Inventory cannot answer, for example after the retries, on a timeout, with an open circuit or with a rejected token,
/// the result says <see cref="StockReservationResult.Unavailable"/>.
/// The order number is the idempotency key, so the retries of the resilience handler never reserve twice.
/// </summary>
public class InventoryStockReservation : IStockReservation
{
    private const string ServiceName = "Inventory";

    private readonly IInventoryClient _inventoryClient;
    private readonly ILogger<InventoryStockReservation> _logger;

    public InventoryStockReservation(IInventoryClient inventoryClient, ILogger<InventoryStockReservation> logger)
    {
        _inventoryClient = inventoryClient;
        _logger = logger;
    }

    public async Task<StockReservationResult> ReserveAsync(string orderNumber, IReadOnlyCollection<StockReservationLine> lines, CancellationToken cancellationToken = default)
    {
        var reservation = new StockReservationModel
        {
            OrderNumber = orderNumber,
            Lines = [.. lines.Select(line => new StockLineModel { Isbn = line.Isbn, Quantity = line.Quantity })]
        };

        try
        {
            var response = await CatApiCall.ExecuteAsync(
                () => _inventoryClient.ReserveStockAsync(reservation, cancellationToken),
                ServiceName,
                cancellationToken);

            if (response.IsSucceeded)
            {
                return new StockReservationResult(true, null);
            }

            if (response.Type is CatResponseType.Failed.Conflict or CatResponseType.Failed.NotFound)
            {
                return new StockReservationResult(false, FindBookId(response.ErrorList, lines));
            }

            _logger.LogWarning(
                "The inventory service failed the reservation of order {OrderNumber} with {ErrorCodes}.",
                orderNumber,
                string.Join(", ", response.ErrorList.Select(error => error.Code)));
            return Unavailable();
        }
        catch (Exception ex) when (!cancellationToken.IsCancellationRequested && ex is not OutOfMemoryException)
        {
            // The resilience handler throws its own exceptions for a timeout or an open circuit.
            // Whatever the cause is, we could not get an answer, and the order must not wait for it.
            _logger.LogWarning(ex, "The stock reservation of order {OrderNumber} failed.", orderNumber);
            return Unavailable();
        }
    }

    /// <summary>
    /// Gives the stock back. A failure is logged and not thrown: the order is cancelled already,
    /// and a cleanup that cannot run must not hide the reason for the cancel.
    /// </summary>
    public async Task ReleaseAsync(string orderNumber, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await CatApiCall.ExecuteAsync(
                () => _inventoryClient.ReleaseStockAsync(orderNumber, cancellationToken),
                ServiceName,
                cancellationToken);

            if (response.IsFailed)
            {
                _logger.LogWarning(
                    "The inventory service failed to release the stock of order {OrderNumber} with {ErrorCodes}.",
                    orderNumber,
                    string.Join(", ", response.ErrorList.Select(error => error.Code)));
            }
        }
        catch (Exception ex) when (!cancellationToken.IsCancellationRequested && ex is not OutOfMemoryException)
        {
            _logger.LogWarning(ex, "The stock of order {OrderNumber} could not be released.", orderNumber);
        }
    }

    private static StockReservationResult Unavailable() => new(false, null, Unavailable: true);

    /// <summary>Finds the book that Inventory named by its ISBN in the first argument of its error. Falls back to the first line.</summary>
    private static Guid? FindBookId(IReadOnlyList<ICatError> errors, IReadOnlyCollection<StockReservationLine> lines)
    {
        foreach (var error in errors)
        {
            foreach (var argument in error.Arguments)
            {
                var line = lines.FirstOrDefault(x => x.Isbn == argument as string);
                if (line is not null)
                {
                    return line.BookId;
                }
            }
        }

        return lines.FirstOrDefault()?.BookId;
    }
}
