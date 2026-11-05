using System;
using System.Collections.Generic;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>
/// Creates an order with status Pending. In one transaction the handler takes the next order number of the day
/// and saves the order and its lines. It fills <see cref="OrderId"/>, <see cref="OrderNumber"/> and <see cref="PlacedAt"/>.
/// It is a class with a parameterless constructor, because a workflow step creates it and fills it.
/// </summary>
public class OrderCreateCommand : ICatCommand
{
    public Guid CustomerId { get; set; }
    public decimal Total { get; set; }
    public List<OrderCreateLine> Lines { get; set; } = [];

    /// <summary>The result. Set by the handler.</summary>
    public Guid OrderId { get; set; }

    /// <summary>The result. Set by the handler.</summary>
    public string OrderNumber { get; set; } = "";

    /// <summary>The result. Set by the handler.</summary>
    public DateTime PlacedAt { get; set; }
}

/// <summary>One line of a new order.</summary>
public record OrderCreateLine(Guid BookId, int Quantity, decimal UnitPrice);
