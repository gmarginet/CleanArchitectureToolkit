using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles the <see cref="PaymentRefunded"/> answer of Payment, as it handles any service request. It is a plain receiver, not a saga.
/// An answer with <c>Refunded</c> false means Payment had nothing to give back. The payment keeps its status and the message counts as handled.
/// A failed response is what the event processor turns into a dead letter or a new delivery.
/// </summary>
public class PaymentRefundedHandler : ICatServiceRequestHandler<PaymentRefunded>
{
    private readonly ICatCommandProcessor _commandProcessor;

    public PaymentRefundedHandler(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public Task<ICatResponse> HandleAsync(PaymentRefunded serviceRequest, CancellationToken cancellationToken = default)
    {
        if (!serviceRequest.Refunded)
        {
            return Task.FromResult<ICatResponse>(CatResponse.Ok());
        }

        return _commandProcessor.ProcessAsync(new PaymentRefundedSaveCommand(serviceRequest.OrderNumber), cancellationToken);
    }
}
