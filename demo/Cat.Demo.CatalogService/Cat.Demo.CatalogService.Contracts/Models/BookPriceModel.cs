using System;

namespace Cat.Demo.CatalogService.Contracts.Models;

/// <summary>The current price of one book.</summary>
public class BookPriceModel
{
    public Guid BookId { get; set; }

    /// <summary>The current price in euro.</summary>
    public decimal Price { get; set; }
}
