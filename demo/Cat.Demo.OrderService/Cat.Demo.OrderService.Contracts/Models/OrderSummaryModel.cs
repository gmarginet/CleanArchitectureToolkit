using System;

namespace Cat.Demo.OrderService.Contracts.Models;

/// <summary>One row of the order overview.</summary>
public class OrderSummaryModel
{
    public Guid Id { get; set; }
    public required string OrderNumber { get; set; }
    public required string Status { get; set; }
    public DateTime PlacedAt { get; set; }
    public decimal Total { get; set; }
}
