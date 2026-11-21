using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Messages;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Sagas.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles <see cref="TakePayment"/> from the queue of Orders. It calls the outside payment provider, and then publishes
/// <see cref="PaymentProcessed"/> with the correlation id of the request, so the saga resumes.
/// The id of the saga is the idempotency key, so a message that is delivered again never charges twice.
/// A provider that cannot answer gives a failed response, which the event processor turns into a new delivery.
/// A payment can arrive after the order was cancelled, because the saga stopped waiting for it. The handler reads the saga
/// and never charges for a saga that no longer waits. When the saga stops waiting while the provider is called, the handler
/// refunds the charge at once. The refund uses the id of the saga as its idempotency key, so a message that is delivered again
/// refunds once. A message for a saga that no longer waits only refunds, which is safe: a provider that has no charge for the order answers that nothing was refunded.
/// The publish runs in the scope of the handler, through <see cref="ICatCurrentScopeCommandProcessor"/>, so the inbox row of the receiver is saved with it.
/// </summary>
public class TakePaymentHandler : ICatServiceRequestHandler<TakePayment>
{
    private readonly IPaymentProvider _provider;
    private readonly ICatCurrentScopeCommandProcessor _commandProcessor;
    private readonly ICatSagaStore _sagaStore;

    public TakePaymentHandler(IPaymentProvider provider, ICatCurrentScopeCommandProcessor commandProcessor, ICatSagaStore sagaStore)
    {
        _provider = provider;
        _commandProcessor = commandProcessor;
        _sagaStore = sagaStore;
    }

    public async Task<ICatResponse> HandleAsync(TakePayment serviceRequest, CancellationToken cancellationToken = default)
    {
        if (await SagaStoppedWaitingAsync(serviceRequest, cancellationToken))
        {
            return await RefundLateAsync(serviceRequest, cancellationToken);
        }

        var result = await _provider.ChargeAsync(serviceRequest.CorrelationId.ToString(), serviceRequest.OrderNumber, serviceRequest.Amount, cancellationToken);
        if (result.Unavailable)
        {
            return CatResponse.InternalServerError(OrderErrorDefinitions.PaymentProviderUnavailable.CreateCatError(serviceRequest.OrderNumber));
        }

        // The saga can time out while the provider works. The charge is then late and goes back at once.
        if (result.Approved && await SagaStoppedWaitingAsync(serviceRequest, cancellationToken))
        {
            return await RefundLateAsync(serviceRequest, cancellationToken);
        }

        return await _commandProcessor.ProcessInCurrentScopeAsync(
            new PaymentProcessedPublishCommand(serviceRequest.CorrelationId, serviceRequest.OrderNumber, result.Approved, result.Reference),
            cancellationToken);
    }

    private async Task<bool> SagaStoppedWaitingAsync(TakePayment serviceRequest, CancellationToken cancellationToken)
    {
        var instance = await _sagaStore.FindAsync(serviceRequest.CorrelationId, cancellationToken);
        return instance is not null && instance.Status != CatSagaStatus.Waiting;
    }

    private async Task<ICatResponse> RefundLateAsync(TakePayment serviceRequest, CancellationToken cancellationToken)
    {
        var refund = await _provider.RefundAsync(serviceRequest.CorrelationId.ToString(), serviceRequest.OrderNumber, cancellationToken);
        return refund.Unavailable
            ? CatResponse.InternalServerError(OrderErrorDefinitions.PaymentProviderUnavailable.CreateCatError(serviceRequest.OrderNumber))
            : CatResponse.Ok();
    }
}
