using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// Gives the current price of books, with the ISBN that Inventory knows them by. Under the AppHost a call to the Catalog service
/// through the gateway implements it. Without the AppHost a fake does.
/// </summary>
public interface IPriceProvider
{
    /// <summary>
    /// Gets the current price in euro and the ISBN of each book.
    /// A failed response means at least one book is unknown or has no price.
    /// </summary>
    Task<ICatResponse<IReadOnlyDictionary<Guid, BookPrice>>> GetPricesAsync(IReadOnlyCollection<Guid> bookIds, CancellationToken cancellationToken = default);
}

/// <summary>The price of one book in euro and its ISBN.</summary>
public record BookPrice(decimal Price, string Isbn);
