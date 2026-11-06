using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.Infrastructure.PaymentServices;

/// <summary>
/// Takes the payment at the payment service, with a plain <see cref="HttpClient"/>.
/// The order number is the idempotency key, so the retries of the resilience handler never charge twice.
/// When the service cannot answer, for example after the retries, on a timeout or with an open circuit,
/// the result says <see cref="PaymentResult.Unavailable"/>. A declined payment is an answer and not a failure.
/// </summary>
public class PaymentServiceProvider : IPaymentProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<PaymentServiceProvider> _logger;

    public PaymentServiceProvider(HttpClient httpClient, ILogger<PaymentServiceProvider> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<PaymentResult> TakePaymentAsync(string orderNumber, decimal amount, CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await _httpClient.PostAsJsonAsync(
                "/payments", new PaymentRequestModel(orderNumber, amount), cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("The payment service answered {StatusCode} for order {OrderNumber}.", (int)response.StatusCode, orderNumber);
                return Unavailable();
            }

            var answer = await response.Content.ReadFromJsonAsync<PaymentResponseModel>(cancellationToken);
            if (answer is null)
            {
                _logger.LogWarning("The payment service answered without a body for order {OrderNumber}.", orderNumber);
                return Unavailable();
            }

            return new PaymentResult(answer.Approved, answer.Reference);
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

    private sealed record PaymentRequestModel(string OrderNumber, decimal Amount);

    private sealed record PaymentResponseModel(bool Approved, string? Reference);
}
