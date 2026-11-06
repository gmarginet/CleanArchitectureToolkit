namespace Cat.Demo.InventoryService.Contracts.Models;

/// <summary>One book and the number of copies to reserve.</summary>
public class StockLineModel
{
    /// <summary>The ISBN of the book. Inventory knows a book by its ISBN.</summary>
    public string Isbn { get; set; } = string.Empty;

    public int Quantity { get; set; }
}
