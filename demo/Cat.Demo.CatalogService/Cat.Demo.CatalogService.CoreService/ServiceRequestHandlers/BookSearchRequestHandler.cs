using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Extensions;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;

public class BookSearchRequestHandler : ICatServiceRequestHandler<BookSearchRequest, IList<BookModel>>
{
    private readonly ICatQueryProcessor _queryProcessor;

    public BookSearchRequestHandler(ICatQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
    }

    public async Task<ICatResponse<IList<BookModel>>> HandleAsync(BookSearchRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var response = await _queryProcessor.ProcessAsync(serviceRequest.ToQuery(), cancellationToken);
        return response.Cast<IList<BookModel>>(x => [.. x.Select(y => y.ToModel())]);
    }
}
