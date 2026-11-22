using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Commands;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;

public class CategorySaveRequestHandler(ICatCommandProcessor commandProcessor) : ICatServiceRequestHandler<CategorySaveRequest>
{
    public Task<ICatResponse> HandleAsync(CategorySaveRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var category = serviceRequest.Category;
        return commandProcessor.ProcessAsync(new CategorySaveCommand(category.Id, category.Name.Trim(), category.NameNl), cancellationToken);
    }
}
