using System;
using System.Collections.Generic;

namespace Cat.Demo.InventoryService.Infrastructure.Entities;

public partial class StockItem
{
    public int Id { get; set; }

    public int WarehouseId { get; set; }

    public string Isbn { get; set; } = null!;

    public int QuantityOnHand { get; set; }

    public virtual ICollection<StockReservation> StockReservations { get; set; } = new List<StockReservation>();

    public virtual Warehouse Warehouse { get; set; } = null!;
}
