using System;
using System.Collections.Generic;

namespace Cat.Demo.InventoryService.Infrastructure.Entities;

public partial class StockReservation
{
    public int Id { get; set; }

    public int StockItemId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime ReservedAt { get; set; }

    public virtual StockItem StockItem { get; set; } = null!;
}
