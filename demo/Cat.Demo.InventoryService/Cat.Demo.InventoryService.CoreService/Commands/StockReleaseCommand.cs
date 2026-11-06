using Cat.Commands.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.Commands;

/// <summary>Gives the stock of an order back. An order without a reservation changes nothing.</summary>
public record StockReleaseCommand(string OrderNumber) : ICatCommand;
