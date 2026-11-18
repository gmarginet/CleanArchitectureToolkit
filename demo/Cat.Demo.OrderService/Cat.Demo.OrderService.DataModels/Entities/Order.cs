using System;
using System.Collections.Generic;
using Cat.EFCore.Entities;

namespace Cat.Demo.OrderService.DataModels.Entities;

public class Order : CatEntityBase
{
    /// <summary>The unique number, in the format <c>YYYYMMDD-0000</c>.</summary>
    public required string OrderNumber { get; set; }

    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid OrderStatusId { get; set; }
    public OrderStatus? OrderStatus { get; set; }
    public DateTime PlacedAt { get; set; }

    /// <summary>The moment (UTC) the order became confirmed. It is empty until then.</summary>
    public DateTime? ConfirmedAt { get; set; }

    /// <summary>The total in euro.</summary>
    public decimal Total { get; set; }

    public ICollection<OrderLine> Lines { get; set; } = [];
    public Payment? Payment { get; set; }
}
