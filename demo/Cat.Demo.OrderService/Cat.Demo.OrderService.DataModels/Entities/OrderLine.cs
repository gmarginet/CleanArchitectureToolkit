using System;
using Cat.EFCore.Entities;

namespace Cat.Demo.OrderService.DataModels.Entities;

public class OrderLine : CatEntityBase
{
    public Guid OrderId { get; set; }

    /// <summary>The book in the Catalog service. There is no foreign key, because Catalog owns that database.</summary>
    public Guid BookId { get; set; }

    public int Quantity { get; set; }

    /// <summary>The price in euro at the moment the order was placed.</summary>
    public decimal UnitPrice { get; set; }
}
