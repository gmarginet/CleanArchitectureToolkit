using System.Collections.Generic;

namespace Cat.Demo.OrderService.Contracts.Models;

/// <summary>The books a customer wants to order. Orders looks up the prices itself.</summary>
public class PlaceOrderModel
{
    public IList<PlaceOrderLineModel> Lines { get; set; } = [];
}
