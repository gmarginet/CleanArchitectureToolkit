using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles the <see cref="OrderConfirmed"/> message of Orders, as it handles any service request.
/// A failed response is what the event processor turns into a dead letter or a new delivery.
/// </summary>
public class OrderConfirmedHandler : ICatServiceRequestHandler<OrderConfirmed>
{
    private readonly ICatCommandProcessor _commandProcessor;

    public OrderConfirmedHandler(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public Task<ICatResponse> HandleAsync(OrderConfirmed serviceRequest, CancellationToken cancellationToken = default)
    {
        return _commandProcessor.ProcessAsync(new StockReservationConfirmCommand(serviceRequest.OrderNumber), cancellationToken);
    }
}
