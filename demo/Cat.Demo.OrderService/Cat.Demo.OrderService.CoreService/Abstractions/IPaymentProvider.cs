using System.Threading;
using System.Threading.Tasks;

namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// Talks to the outside payment provider. The tests use a fake.
/// The provider is not one of our services, so the call does not go through the gateway.
/// The idempotency key makes a repeated call return the first answer, so a retry never charges or refunds twice.
/// </summary>
public interface IPaymentProvider
{
    /// <summary>Takes a payment. A decline is an answer, not a failure.</summary>
    Task<PaymentChargeResult> ChargeAsync(string idempotencyKey, string orderNumber, decimal amount, CancellationToken cancellationToken = default);

    /// <summary>Gives the money of an approved payment back.</summary>
    Task<PaymentRefundResult> RefundAsync(string idempotencyKey, string orderNumber, CancellationToken cancellationToken = default);
}

/// <summary>
/// The outcome of a charge. <paramref name="Approved"/> is false for a decline, and <paramref name="Reference"/> is then null.
/// <paramref name="Unavailable"/> is true when the provider could not answer, for example when it is down or its circuit is open.
/// </summary>
public record PaymentChargeResult(bool Approved, string? Reference, bool Unavailable = false);

/// <summary>
/// The outcome of a refund. <paramref name="Refunded"/> is false when there was no approved payment to give back.
/// <paramref name="Unavailable"/> is true when the provider could not answer.
/// </summary>
public record PaymentRefundResult(bool Refunded, bool Unavailable = false);
