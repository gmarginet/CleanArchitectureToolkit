using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.PaymentService.CoreService;

/// <summary>
/// Handles <see cref="RefundPayment"/> from the queue. It refunds with the same <see cref="PaymentProcessor"/> as the payment itself,
/// so the same failure settings and the same ledger apply, and then publishes <see cref="PaymentRefunded"/> with the correlation id of the request.
/// A failure that was switched on gives a failed response, which the event processor turns into a new delivery.
/// </summary>
public class RefundPaymentHandler : ICatServiceRequestHandler<RefundPayment>
{
    private readonly PaymentProcessor _processor;
    private readonly ICatMessageSender _sender;

    public RefundPaymentHandler(PaymentProcessor processor, ICatMessageSender sender)
    {
        _processor = processor;
        _sender = sender;
    }

    public async Task<ICatResponse> HandleAsync(RefundPayment serviceRequest, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(serviceRequest.OrderNumber))
        {
            return CatResponse.BadRequest(PaymentErrorDefinitions.InvalidRefundRequest.CreateCatError());
        }

        var outcome = await _processor.RefundAsync(serviceRequest.OrderNumber, cancellationToken);
        if (outcome.Failed)
        {
            return CatResponse.InternalServerError(PaymentErrorDefinitions.Failing.CreateCatError(serviceRequest.OrderNumber));
        }

        await _sender.PublishAsync(new PaymentRefunded
        {
            CorrelationId = serviceRequest.CorrelationId,
            OrderNumber = serviceRequest.OrderNumber,
            Refunded = outcome.Refunded
        }, cancellationToken: cancellationToken);

        return CatResponse.Ok();
    }
}
