using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.NotificationService.CoreService.Commands;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.NotificationService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles the <see cref="OrderConfirmed"/> message of Orders, as it handles any service request.
/// A customer without an email address gets no mail, and the message counts as handled.
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
        if (string.IsNullOrWhiteSpace(serviceRequest.CustomerEmail))
        {
            return Task.FromResult<ICatResponse>(CatResponse.Ok());
        }

        return _commandProcessor.ProcessAsync(
            new SendOrderConfirmedMailCommand(
                serviceRequest.OrderId,
                serviceRequest.OrderNumber,
                serviceRequest.Total,
                serviceRequest.CustomerName,
                serviceRequest.CustomerEmail),
            cancellationToken);
    }
}
