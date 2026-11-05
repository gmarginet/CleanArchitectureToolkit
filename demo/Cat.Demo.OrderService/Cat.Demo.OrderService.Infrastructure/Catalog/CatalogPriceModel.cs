using System;

namespace Cat.Demo.OrderService.Infrastructure.Catalog;

/// <summary>
/// The price of one book, as the Catalog service answers it.
/// Orders keeps its own small model and does not reference the Catalog contracts.
/// </summary>
public class CatalogPriceModel
{
    public Guid BookId { get; set; }

    /// <summary>The current price in euro.</summary>
    public decimal Price { get; set; }
}
