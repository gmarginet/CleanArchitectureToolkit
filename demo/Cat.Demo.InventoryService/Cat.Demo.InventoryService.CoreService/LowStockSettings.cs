namespace Cat.Demo.InventoryService.CoreService;

/// <summary>
/// The limit for the low stock report. One number for all books. A stock item is low when its quantity on hand is below it.
/// </summary>
/// <param name="Limit">The limit. The configuration key is <see cref="ConfigurationKey"/>.</param>
public record LowStockSettings(int Limit)
{
    /// <summary>The configuration key of the limit.</summary>
    public const string ConfigurationKey = "Inventory:LowStockLimit";

    /// <summary>The limit when the configuration gives none.</summary>
    public const int DefaultLimit = 10;
}
