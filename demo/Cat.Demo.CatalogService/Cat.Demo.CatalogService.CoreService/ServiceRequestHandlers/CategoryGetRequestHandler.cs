using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;

public class CategoryGetRequestHandler(ICatQueryProcessor queryProcessor) : ICatServiceRequestHandler<CategoryGetRequest, CategoryEditModel>
{
    public Task<ICatResponse<CategoryEditModel>> HandleAsync(CategoryGetRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return queryProcessor.ProcessAsync(new CategoryGetQuery(serviceRequest.CategoryId), cancellationToken);
    }
}
