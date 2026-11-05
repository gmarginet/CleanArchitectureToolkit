using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// Gives the current price of books. Under the AppHost a plain HttpClient call to the Catalog service implements it.
/// Without the AppHost a fake does. Later an Api.Client call replaces the HttpClient call.
/// </summary>
public interface IPriceProvider
{
    /// <summary>
    /// Gets the current price in euro of each book.
    /// A failed response means at least one book is unknown or has no price.
    /// </summary>
    Task<ICatResponse<IReadOnlyDictionary<Guid, decimal>>> GetPricesAsync(IReadOnlyCollection<Guid> bookIds, CancellationToken cancellationToken = default);
}
