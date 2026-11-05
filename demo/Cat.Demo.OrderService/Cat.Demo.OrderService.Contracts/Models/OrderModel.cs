using System;
using System.Collections.Generic;

namespace Cat.Demo.OrderService.Contracts.Models;

public class OrderModel
{
    public Guid Id { get; set; }
    public required string OrderNumber { get; set; }

    /// <summary>The status code: <c>Pending</c>, <c>Confirmed</c> or <c>Cancelled</c>.</summary>
    public required string Status { get; set; }

    public DateTime PlacedAt { get; set; }

    /// <summary>The total in euro.</summary>
    public decimal Total { get; set; }

    public IList<OrderLineModel> Lines { get; set; } = [];
}
