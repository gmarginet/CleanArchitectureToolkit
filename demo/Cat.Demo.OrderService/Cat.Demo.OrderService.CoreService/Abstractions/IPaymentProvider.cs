using System.Threading;
using System.Threading.Tasks;

namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// Takes the payment of an order. A fake or the payment service implements it.
/// Later the call may go over the Service Bus, see plans/Cat.Sagas.md.
/// </summary>
public interface IPaymentProvider
{
    /// <summary>Takes the amount in euro.</summary>
    Task<PaymentResult> TakePaymentAsync(string orderNumber, decimal amount, CancellationToken cancellationToken = default);
}

/// <summary>
/// The outcome of a payment. <paramref name="Unavailable"/> is true when the provider could not answer,
/// for example when it is down or its circuit is open. The payment is then neither approved nor declined.
/// </summary>
public record PaymentResult(bool Approved, string? Reference, bool Unavailable = false);
