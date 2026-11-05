using System.Threading;
using System.Threading.Tasks;

namespace Cat.Demo.OrderService.CoreService.Abstractions;

/// <summary>
/// Takes the payment of an order. A fake implements it for now.
/// Later the call may go over the Service Bus, see plans/Cat.Sagas.md.
/// </summary>
public interface IPaymentProvider
{
    /// <summary>Takes the amount in euro.</summary>
    Task<PaymentResult> TakePaymentAsync(string orderNumber, decimal amount, CancellationToken cancellationToken = default);
}

/// <summary>The outcome of a payment.</summary>
public record PaymentResult(bool Approved, string? Reference);
