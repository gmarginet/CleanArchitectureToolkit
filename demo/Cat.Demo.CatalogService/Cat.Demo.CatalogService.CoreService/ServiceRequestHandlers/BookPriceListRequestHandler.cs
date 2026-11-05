using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Extensions;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;

public class BookPriceListRequestHandler : ICatServiceRequestHandler<BookPriceListRequest, IList<BookPriceModel>>
{
    private readonly ICatQueryProcessor _queryProcessor;

    public BookPriceListRequestHandler(ICatQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
    }

    public async Task<ICatResponse<IList<BookPriceModel>>> HandleAsync(BookPriceListRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var bookIds = serviceRequest.BookIds.Distinct().ToList();

        var response = await _queryProcessor.ProcessAsync(new Queries.BookPriceListQuery(bookIds), cancellationToken);
        if (response.IsFailed)
        {
            return response.Cast<IList<BookPriceModel>>(_ => []);
        }

        var prices = response.Value!;
        var missing = bookIds.Except(prices.Select(x => x.BookId)).ToList();
        if (missing.Count > 0)
        {
            return CatResponse.NotFound<IList<BookPriceModel>>(
                [.. missing.Select(id => CatError.Create(
                    CatalogErrorDefinitions.BookPriceNotFound.Code,
                    CatalogErrorDefinitions.BookPriceNotFound.Message,
                    id))]);
        }

        // Keep the order of the request.
        var byId = prices.ToDictionary(x => x.BookId);
        return CatResponse.Ok<IList<BookPriceModel>>([.. bookIds.Select(id => byId[id].ToPriceModel())]);
    }
}
