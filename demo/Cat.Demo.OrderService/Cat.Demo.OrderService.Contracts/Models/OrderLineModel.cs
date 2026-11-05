using System;

namespace Cat.Demo.OrderService.Contracts.Models;

public class OrderLineModel
{
    public Guid BookId { get; set; }
    public int Quantity { get; set; }

    /// <summary>The price in euro at the moment the order was placed.</summary>
    public decimal UnitPrice { get; set; }
}
