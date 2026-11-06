using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Api.Client;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Microsoft.Extensions.Logging;

// The generated models of the client have an ICatError of their own, so only the types we need are imported.
using IPaymentClient = Cat.Demo.PaymentService.Api.Client.IPaymentClient;
using PaymentRequest = Cat.Demo.PaymentService.Api.Client.PaymentRequest;

namespace Cat.Demo.OrderService.Infrastructure.PaymentServices;

/// <summary>
/// Takes the payment at the payment service, through the generated client and the API gateway.
/// The order number is the idempotency key, so the retries of the resilience handler never charge twice.
/// When the service cannot answer, for example after the retries, on a timeout, with an open circuit or with a
/// rejected token, the result says <see cref="PaymentResult.Unavailable"/>. A declined payment is an answer and not a failure.
/// </summary>
public class PaymentServiceProvider : IPaymentProvider
{
    private const string ServiceName = "Payment";

    private readonly IPaymentClient _paymentClient;
    private readonly ILogger<PaymentServiceProvider> _logger;

    public PaymentServiceProvider(IPaymentClient paymentClient, ILogger<PaymentServiceProvider> logger)
    {
        _paymentClient = paymentClient;
        _logger = logger;
    }

    public async Task<PaymentResult> TakePaymentAsync(string orderNumber, decimal amount, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await CatApiCall.ExecuteAsync(
                () => _paymentClient.PaymentsAsync(new PaymentRequest { OrderNumber = orderNumber, Amount = (double)amount }, cancellationToken),
                ServiceName,
                cancellationToken);

            if (response.IsFailed)
            {
                _logger.LogWarning(
                    "The payment service failed the request for order {OrderNumber} with {ErrorCodes}.",
                    orderNumber,
                    string.Join(", ", response.ErrorList.Select(error => error.Code)));
                return Unavailable();
            }

            var answer = response.Value;
            return answer is null
                ? Unavailable()
                : new PaymentResult(answer.Approved, answer.Reference);
        }
        catch (Exception ex) when (!cancellationToken.IsCancellationRequested && ex is not OutOfMemoryException)
        {
            // The resilience handler throws its own exceptions for a timeout or an open circuit.
            // Whatever the cause is, we could not get an answer, and the order must not wait for it.
            _logger.LogWarning(ex, "The payment request for order {OrderNumber} failed.", orderNumber);
            return Unavailable();
        }
    }

    private static PaymentResult Unavailable() => new(false, null, Unavailable: true);
}
