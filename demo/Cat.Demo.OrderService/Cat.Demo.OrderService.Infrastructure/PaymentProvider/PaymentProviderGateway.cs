using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.Infrastructure.PaymentProvider;

/// <summary>
/// Calls the outside payment provider with the generated client.
/// A decline is an answer, because the provider says it with status 200.
/// When the provider cannot answer, for example after the retries, on a timeout, with an open circuit or with a rejected API key,
/// the result says <c>Unavailable</c> and the message is delivered again.
/// The idempotency key goes in the header, so the retries of the resilience handler never charge or refund twice.
/// </summary>
public class PaymentProviderGateway : IPaymentProvider
{
    private const string Approved = "approved";
    private const string Refunded = "refunded";

    private readonly IPaymentProviderClient _client;
    private readonly ILogger<PaymentProviderGateway> _logger;

    public PaymentProviderGateway(IPaymentProviderClient client, ILogger<PaymentProviderGateway> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<PaymentChargeResult> ChargeAsync(string idempotencyKey, string orderNumber, decimal amount, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _client.CreateChargeAsync(
                idempotencyKey,
                new ChargeRequest { OrderNumber = orderNumber, Amount = amount },
                cancellationToken);

            return new PaymentChargeResult(response.Status == Approved, response.Reference);
        }
        catch (Exception ex) when (!cancellationToken.IsCancellationRequested && ex is not OutOfMemoryException)
        {
            // The resilience handler throws its own exceptions for a timeout or an open circuit.
            // Whatever the cause is, we could not get an answer.
            _logger.LogWarning(ex, "The payment provider did not answer the charge of order {OrderNumber}.", orderNumber);
            return new PaymentChargeResult(false, null, Unavailable: true);
        }
    }

    public async Task<PaymentRefundResult> RefundAsync(string idempotencyKey, string orderNumber, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _client.CreateRefundAsync(
                idempotencyKey,
                new RefundRequest { OrderNumber = orderNumber },
                cancellationToken);

            return new PaymentRefundResult(response.Status == Refunded);
        }
        catch (Exception ex) when (!cancellationToken.IsCancellationRequested && ex is not OutOfMemoryException)
        {
            _logger.LogWarning(ex, "The payment provider did not answer the refund of order {OrderNumber}.", orderNumber);
            return new PaymentRefundResult(false, Unavailable: true);
        }
    }
}
