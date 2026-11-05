using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

public class CleanUpOrderCountersRequestHandler : ICatServiceRequestHandler<CleanUpOrderCountersRequest>
{
    private readonly ICatCommandProcessor _commandProcessor;

    public CleanUpOrderCountersRequestHandler(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public async Task<ICatResponse> HandleAsync(CleanUpOrderCountersRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var response = await _commandProcessor.ProcessAsync(new OrderCountersCleanUpCommand(), cancellationToken);
        return response.IsSucceeded ? CatResponse.NoContent() : response;
    }
}
