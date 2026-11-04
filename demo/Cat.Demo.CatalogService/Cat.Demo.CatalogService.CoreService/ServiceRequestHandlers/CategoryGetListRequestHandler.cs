using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Extensions;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;

public class CategoryGetListRequestHandler : ICatServiceRequestHandler<CategoryGetListRequest, IList<CategoryModel>>
{
    private readonly ICatQueryProcessor _queryProcessor;

    public CategoryGetListRequestHandler(ICatQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
    }

    public async Task<ICatResponse<IList<CategoryModel>>> HandleAsync(CategoryGetListRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var response = await _queryProcessor.ProcessAsync(new CategoryGetListQuery(), cancellationToken);
        return response.Cast<IList<CategoryModel>>(x => [.. x.Select(y => y.ToModel())]);
    }
}
