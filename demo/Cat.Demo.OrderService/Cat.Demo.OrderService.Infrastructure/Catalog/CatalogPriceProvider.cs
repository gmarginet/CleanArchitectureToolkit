using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Api.Client;
using Cat.Demo.OrderService.CoreService;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

// The generated models of the client have an ICatError of their own, so only the client itself is imported.
using ICatalogClient = Cat.Demo.CatalogService.Api.Client.ICatalogClient;

namespace Cat.Demo.OrderService.Infrastructure.Catalog;

/// <summary>
/// Asks the Catalog service for the current price of books, through the generated client and the API gateway.
/// A 404 becomes a failed response, so the order step answers with <c>PriceUnavailable</c>.
/// Every other problem becomes an error response. Orders never trusts a half answer.
/// </summary>
public class CatalogPriceProvider : IPriceProvider
{
    private const string ServiceName = "Catalog";

    private readonly ICatalogClient _catalogClient;
    private readonly ILogger<CatalogPriceProvider> _logger;

    public CatalogPriceProvider(ICatalogClient catalogClient, ILogger<CatalogPriceProvider> logger)
    {
        _catalogClient = catalogClient;
        _logger = logger;
    }

    public async Task<ICatResponse<IReadOnlyDictionary<Guid, BookPrice>>> GetPricesAsync(IReadOnlyCollection<Guid> bookIds, CancellationToken cancellationToken = default)
    {
        var response = await CatApiCall.ExecuteAsync(
            () => _catalogClient.PricesAsync(bookIds, cancellationToken),
            ServiceName,
            cancellationToken);

        if (response.IsFailed)
        {
            if (response.Type is CatResponseType.Failed.NotFound)
            {
                return CatResponse.NotFound<IReadOnlyDictionary<Guid, BookPrice>>(
                    OrderErrorDefinitions.PriceUnavailable.CreateCatError(FindMissingBookId(response.ErrorList, bookIds)));
            }

            _logger.LogWarning("Catalog failed the price request with {ErrorCodes}.", string.Join(", ", response.ErrorList.Select(error => error.Code)));
            return Unexpected();
        }

        var prices = response.Value!;
        if (bookIds.Any(id => prices.All(price => price.BookId != id)))
        {
            _logger.LogWarning("Catalog answered 200 but not with a price for every book.");
            return Unexpected();
        }

        return CatResponse.Ok<IReadOnlyDictionary<Guid, BookPrice>>(prices.ToDictionary(price => price.BookId, price => new BookPrice((decimal)price.Price, price.Isbn)));
    }

    private static ICatResponse<IReadOnlyDictionary<Guid, BookPrice>> Unexpected()
        => CatResponse.InternalServerError<IReadOnlyDictionary<Guid, BookPrice>>(
            CatGeneralErrorDefinitions.UnexpectedResponse.CreateCatError(ServiceName));

    /// <summary>Reads the first book id from the Catalog errors. Falls back to the first requested book.</summary>
    private static Guid FindMissingBookId(IReadOnlyList<ICatError> errors, IReadOnlyCollection<Guid> bookIds)
    {
        foreach (var error in errors)
        {
            foreach (var argument in error.Arguments)
            {
                if (argument is string text && Guid.TryParse(text, out var id))
                {
                    return id;
                }
            }
        }

        return bookIds.FirstOrDefault();
    }
}
