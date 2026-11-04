using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Extensions;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;

public class BookSaveRequestHandler : ICatServiceRequestHandler<BookSaveRequest>
{
    private readonly ICatCommandProcessor _commandProcessor;

    public BookSaveRequestHandler(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public Task<ICatResponse> HandleAsync(BookSaveRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return _commandProcessor.ProcessAsync(serviceRequest.ToCommand(), cancellationToken);
    }
}
