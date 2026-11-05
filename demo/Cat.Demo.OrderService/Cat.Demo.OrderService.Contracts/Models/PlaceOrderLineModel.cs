using System;

namespace Cat.Demo.OrderService.Contracts.Models;

public class PlaceOrderLineModel
{
    /// <summary>The book in the Catalog service.</summary>
    public Guid BookId { get; set; }

    public int Quantity { get; set; }
}
