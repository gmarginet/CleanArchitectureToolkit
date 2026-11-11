using System;
using System.Collections.Generic;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>
/// Creates an order with status Pending. In one transaction the handler takes the next order number of the day
/// and saves the order and its lines. The caller supplies the <see cref="OrderId"/> and <see cref="PlacedAt"/>.
/// The handler returns the order number, which only the database can hand out, see <see cref="OrderCreated"/>.
/// It is a class with a parameterless constructor, because a workflow step creates it and fills it.
/// </summary>
public class OrderCreateCommand : ICatCommand<OrderCreated>
{
    /// <summary>The id of the new order. The caller creates it, so it is known before the command runs.</summary>
    public Guid OrderId { get; set; }

    /// <summary>The moment the order was placed. The caller sets it. The day of the order number comes from it.</summary>
    public DateTime PlacedAt { get; set; }

    public Guid CustomerId { get; set; }
    public decimal Total { get; set; }
    public List<OrderCreateLine> Lines { get; set; } = [];
}

/// <summary>What <see cref="OrderCreateCommand"/> made: the id it was given, and the order number from the database.</summary>
public record OrderCreated(Guid OrderId, string OrderNumber);

/// <summary>One line of a new order.</summary>
public record OrderCreateLine(Guid BookId, int Quantity, decimal UnitPrice);
