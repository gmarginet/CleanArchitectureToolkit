using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Messages;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles <see cref="TakePayment"/> from the queue of Orders. It calls the outside payment provider, and then publishes
/// <see cref="PaymentProcessed"/> with the correlation id of the request, so the saga resumes.
/// The id of the saga is the idempotency key, so a message that is delivered again never charges twice.
/// A provider that cannot answer gives a failed response, which the event processor turns into a new delivery.
/// The publish runs in the scope of the handler, through <see cref="ICatCurrentScopeCommandProcessor"/>, so the inbox row of the receiver is saved with it.
/// </summary>
public class TakePaymentHandler : ICatServiceRequestHandler<TakePayment>
{
    private readonly IPaymentProvider _provider;
    private readonly ICatCurrentScopeCommandProcessor _commandProcessor;

    public TakePaymentHandler(IPaymentProvider provider, ICatCurrentScopeCommandProcessor commandProcessor)
    {
        _provider = provider;
        _commandProcessor = commandProcessor;
    }

    public async Task<ICatResponse> HandleAsync(TakePayment serviceRequest, CancellationToken cancellationToken = default)
    {
        var result = await _provider.ChargeAsync(serviceRequest.CorrelationId.ToString(), serviceRequest.OrderNumber, serviceRequest.Amount, cancellationToken);
        if (result.Unavailable)
        {
            return CatResponse.InternalServerError(OrderErrorDefinitions.PaymentProviderUnavailable.CreateCatError(serviceRequest.OrderNumber));
        }

        return await _commandProcessor.ProcessInCurrentScopeAsync(
            new PaymentProcessedPublishCommand(serviceRequest.CorrelationId, serviceRequest.OrderNumber, result.Approved, result.Reference),
            cancellationToken);
    }
}
