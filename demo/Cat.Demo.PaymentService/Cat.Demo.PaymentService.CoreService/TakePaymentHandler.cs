using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.PaymentService.CoreService;

/// <summary>
/// Handles <see cref="TakePayment"/> from the queue. It takes the payment with the same <see cref="PaymentProcessor"/> as the HTTP endpoint,
/// so the same failure settings and the same ledger apply, and then publishes <see cref="PaymentProcessed"/> with the correlation id of the request.
/// A failure that was switched on gives a failed response, which the event processor turns into a new delivery.
/// </summary>
public class TakePaymentHandler : ICatServiceRequestHandler<TakePayment>
{
    private readonly PaymentProcessor _processor;
    private readonly ICatMessageSender _sender;

    public TakePaymentHandler(PaymentProcessor processor, ICatMessageSender sender)
    {
        _processor = processor;
        _sender = sender;
    }

    public async Task<ICatResponse> HandleAsync(TakePayment serviceRequest, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(serviceRequest.OrderNumber) || serviceRequest.Amount <= 0)
        {
            return CatResponse.BadRequest(PaymentErrorDefinitions.InvalidRequest.CreateCatError());
        }

        var outcome = await _processor.ProcessAsync(new PaymentRequest(serviceRequest.OrderNumber, serviceRequest.Amount), cancellationToken);
        if (outcome.Failed)
        {
            return CatResponse.InternalServerError(PaymentErrorDefinitions.Failing.CreateCatError(serviceRequest.OrderNumber));
        }

        await _sender.PublishAsync(new PaymentProcessed
        {
            CorrelationId = serviceRequest.CorrelationId,
            OrderNumber = serviceRequest.OrderNumber,
            Approved = outcome.Response!.Approved,
            Reference = outcome.Response.Reference
        }, cancellationToken: cancellationToken);

        return CatResponse.Ok();
    }
}
