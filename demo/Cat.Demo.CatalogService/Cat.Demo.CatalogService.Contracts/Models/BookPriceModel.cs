using System;

namespace Cat.Demo.CatalogService.Contracts.Models;

/// <summary>The current price of one book.</summary>
public class BookPriceModel
{
    public Guid BookId { get; set; }

    /// <summary>The ISBN of the book. Inventory knows a book by its ISBN.</summary>
    public string Isbn { get; set; } = string.Empty;

    /// <summary>The current price in euro.</summary>
    public decimal Price { get; set; }
}
