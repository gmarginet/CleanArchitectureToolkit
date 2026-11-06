using System;
using System.Collections.Generic;

namespace Cat.Demo.InventoryService.Infrastructure.Entities;

public partial class Warehouse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();
}
