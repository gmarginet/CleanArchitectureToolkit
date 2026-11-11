using Cat.Commands.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.Commands;

/// <summary>Marks the reservations of an order as confirmed. An order without a reservation is an error.</summary>
public record StockReservationConfirmCommand(string OrderNumber) : ICatCommand;
