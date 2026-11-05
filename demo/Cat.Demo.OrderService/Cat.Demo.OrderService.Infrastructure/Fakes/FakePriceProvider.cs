using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.Fakes;

/// <summary>
/// A stand-in for the Catalog service. Every book gets a price made from its id, so the same book always costs the same.
/// The empty id has no price. It answers when Orders runs without the AppHost. Under the AppHost, CatalogPriceProvider asks Catalog.
/// </summary>
public class FakePriceProvider : IPriceProvider
{
    public Task<ICatResponse<IReadOnlyDictionary<Guid, decimal>>> GetPricesAsync(IReadOnlyCollection<Guid> bookIds, CancellationToken cancellationToken = default)
    {
        var prices = new Dictionary<Guid, decimal>();

        foreach (var bookId in bookIds)
        {
            if (bookId == Guid.Empty)
            {
                return Task.FromResult(
                    CatResponse.NotFound<IReadOnlyDictionary<Guid, decimal>>(OrderErrorDefinitions.PriceUnavailable.CreateCatError(bookId)));
            }

            prices[bookId] = PriceOf(bookId);
        }

        return Task.FromResult(CatResponse.Ok<IReadOnlyDictionary<Guid, decimal>>(prices));
    }

    /// <summary>A price between 5.95 and 44.95 euro.</summary>
    public static decimal PriceOf(Guid bookId) => 5.95m + bookId.ToByteArray()[0] % 40;
}
