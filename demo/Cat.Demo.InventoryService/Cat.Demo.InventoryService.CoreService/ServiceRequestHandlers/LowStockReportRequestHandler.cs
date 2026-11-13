using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.ServiceRequestHandlers;

public class LowStockReportRequestHandler : ICatServiceRequestHandler<LowStockReportRequest>
{
    private readonly ICatCommandProcessor _commandProcessor;
    private readonly LowStockSettings _settings;

    public LowStockReportRequestHandler(ICatCommandProcessor commandProcessor, LowStockSettings settings)
    {
        _commandProcessor = commandProcessor;
        _settings = settings;
    }

    public async Task<ICatResponse> HandleAsync(LowStockReportRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var response = await _commandProcessor.ProcessAsync(new LowStockReportPublishCommand(_settings.Limit), cancellationToken);
        return response.IsSucceeded ? CatResponse.NoContent() : response;
    }
}
