using System.Collections.Generic;
using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.Contracts.Messages;

/// <summary>
/// Tells the other services which stock items are low. The nightly report job of Inventory publishes it, and only when something is low.
/// Notifications mails it to the admin. A service that receives it writes a handler for it, as for any service request.
/// </summary>
public class LowStockReport : CatEventMessage, ICatServiceRequest
{
    /// <summary>The limit that was used. A stock item is low when its quantity on hand is below this number.</summary>
    public int Limit { get; set; }

    /// <summary>The low stock items, the lowest quantity first.</summary>
    public List<LowStockLine> Lines { get; set; } = [];
}

/// <summary>One low stock item in a <see cref="LowStockReport"/>.</summary>
public class LowStockLine
{
    public string Isbn { get; set; } = string.Empty;
    public string Warehouse { get; set; } = string.Empty;
    public int QuantityOnHand { get; set; }
}
