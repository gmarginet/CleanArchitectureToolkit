using System;

namespace Cat.Demo.OrderService.CoreService.Queries;

/// <summary>One row of the order overview, as the SQL of <see cref="OrderGetListQuery"/> returns it.</summary>
public class OrderSummaryRow
{
    public Guid Id { get; set; }
    public required string OrderNumber { get; set; }
    public required string Status { get; set; }
    public DateTime PlacedAt { get; set; }
    public decimal Total { get; set; }
}
