using System.Collections.Generic;

namespace Cat.Demo.InventoryService.Contracts.Models;

/// <summary>The stock of one order. The order number is the idempotency key.</summary>
public class StockReservationModel
{
    public string OrderNumber { get; set; } = string.Empty;

    public List<StockLineModel> Lines { get; set; } = [];
}
