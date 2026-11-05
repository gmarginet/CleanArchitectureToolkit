using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.Infrastructure.Catalog;

/// <summary>
/// Asks the Catalog service for the current price of books, with a plain <see cref="HttpClient"/>.
/// A 404 becomes a failed response, so the order step answers with <c>PriceUnavailable</c>.
/// Every other problem becomes an error response. Orders never trusts a half answer.
/// </summary>
public class CatalogPriceProvider : IPriceProvider
{
    private const string ServiceName = "Catalog";

    private readonly HttpClient _httpClient;
    private readonly ILogger<CatalogPriceProvider> _logger;

    public CatalogPriceProvider(HttpClient httpClient, ILogger<CatalogPriceProvider> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<ICatResponse<IReadOnlyDictionary<Guid, decimal>>> GetPricesAsync(IReadOnlyCollection<Guid> bookIds, CancellationToken cancellationToken = default)
    {
        var query = string.Join("&", bookIds.Select(id => $"bookIds={id}"));

        try
        {
            using var response = await _httpClient.GetAsync($"/catalog/books/prices?{query}", cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return CatResponse.NotFound<IReadOnlyDictionary<Guid, decimal>>(
                    OrderErrorDefinitions.PriceUnavailable.CreateCatError(await FindMissingBookIdAsync(response, bookIds, cancellationToken)));
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogWarning("Catalog answered {StatusCode} to the price request.", (int)response.StatusCode);
                return Unexpected();
            }

            var prices = await response.Content.ReadFromJsonAsync<List<CatalogPriceModel>>(cancellationToken);
            if (prices is null || bookIds.Any(id => prices.All(x => x.BookId != id)))
            {
                _logger.LogWarning("Catalog answered 200 but not with a price for every book.");
                return Unexpected();
            }

            return CatResponse.Ok<IReadOnlyDictionary<Guid, decimal>>(prices.ToDictionary(x => x.BookId, x => x.Price));
        }
        catch (Exception ex) when (ex is HttpRequestException or JsonException or TaskCanceledException or NotSupportedException)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw;
            }

            _logger.LogWarning(ex, "The price request to Catalog failed.");
            return Unexpected();
        }
    }

    private static ICatResponse<IReadOnlyDictionary<Guid, decimal>> Unexpected()
        => CatResponse.InternalServerError<IReadOnlyDictionary<Guid, decimal>>(
            CatGeneralErrorDefinitions.UnexpectedResponse.CreateCatError(ServiceName));

    /// <summary>Reads the first book id from the Catalog errors. Falls back to the first requested book.</summary>
    private static async Task<Guid> FindMissingBookIdAsync(HttpResponseMessage response, IReadOnlyCollection<Guid> bookIds, CancellationToken cancellationToken)
    {
        try
        {
            var body = await response.Content.ReadFromJsonAsync<JsonElement>(cancellationToken);
            foreach (var error in body.GetProperty("catErrors").EnumerateArray())
            {
                foreach (var argument in error.GetProperty("arguments").EnumerateArray())
                {
                    if (argument.ValueKind == JsonValueKind.String && Guid.TryParse(argument.GetString(), out var id))
                    {
                        return id;
                    }
                }
            }
        }
        catch (Exception ex) when (ex is JsonException or KeyNotFoundException or InvalidOperationException)
        {
            // The body is not what we expect. The first requested book is the best we can name.
        }

        return bookIds.FirstOrDefault();
    }
}
