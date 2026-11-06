using System.Collections.Generic;
using Cat.Commands.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.Commands;

/// <summary>One book and the copies to reserve.</summary>
public record StockLine(string Isbn, int Quantity);

/// <summary>
/// Reserves the lines of an order in one step, or none. A book is never listed twice.
/// The handler answers a failed response when a book is out of stock or unknown.
/// Asking again for an order that already has its stock changes nothing.
/// </summary>
public record StockReserveCommand(string OrderNumber, IReadOnlyList<StockLine> Lines) : ICatCommand;
