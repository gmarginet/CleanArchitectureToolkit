using Cat.Demo.InventoryService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.Contracts.ServiceRequests;

/// <summary>
/// Reserves every line of an order, or none of them. Asking again for the same order number changes nothing.
/// </summary>
public record StockReserveRequest(StockReservationModel Reservation) : ICatServiceRequest;
