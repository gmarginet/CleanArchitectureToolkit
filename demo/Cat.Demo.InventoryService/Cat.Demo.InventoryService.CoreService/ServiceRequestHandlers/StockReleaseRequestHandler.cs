using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.ServiceRequestHandlers;

public class StockReleaseRequestHandler : ICatServiceRequestHandler<StockReleaseRequest>
{
    private readonly ICatCommandProcessor _commandProcessor;

    public StockReleaseRequestHandler(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public Task<ICatResponse> HandleAsync(StockReleaseRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return _commandProcessor.ProcessAsync(new StockReleaseCommand(serviceRequest.OrderNumber), cancellationToken);
    }
}
