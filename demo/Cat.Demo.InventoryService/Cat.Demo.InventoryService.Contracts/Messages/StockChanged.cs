using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.Contracts.Messages;

/// <summary>
/// Tells the other services that the quantity of a stock item changed. Nobody in Inventory publishes it.
/// <c>Cat.Sql.Cdc</c> reads the change of the stock table from the log of the database and sends it, so every change counts,
/// also one made by a script. A service that receives it decides what the change means, such as Notifications for a drop below the limit.
/// </summary>
public class StockChanged : CatEventMessage, ICatServiceRequest
{
    /// <summary>The ISBN of the book.</summary>
    public string Isbn { get; set; } = string.Empty;

    /// <summary>The warehouse that holds the stock item.</summary>
    public int WarehouseId { get; set; }

    /// <summary>The quantity on hand before the change. Empty when the stock item is new.</summary>
    public int? OldQuantity { get; set; }

    /// <summary>The quantity on hand after the change. Empty when the stock item was deleted.</summary>
    public int? NewQuantity { get; set; }

    /// <summary>The low stock limit of Inventory when the change was read. A stock item is low when its quantity is below it.</summary>
    public int Limit { get; set; }
}
