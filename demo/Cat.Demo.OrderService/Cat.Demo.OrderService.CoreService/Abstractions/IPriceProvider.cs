using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// Gives the current price of books. Later an Api.Client call to the Catalog service implements it.
/// Until then a fake does.
/// </summary>
public interface IPriceProvider
{
    /// <summary>
    /// Gets the current price in euro of each book.
    /// A failed response means at least one book is unknown or has no price.
    /// </summary>
    Task<ICatResponse<IReadOnlyDictionary<Guid, decimal>>> GetPricesAsync(IReadOnlyCollection<Guid> bookIds, CancellationToken cancellationToken = default);
}
