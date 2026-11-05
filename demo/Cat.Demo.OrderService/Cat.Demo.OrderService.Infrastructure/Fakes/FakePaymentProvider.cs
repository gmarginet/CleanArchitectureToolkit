using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.Fakes;

/// <summary>
/// A stand-in for the payment provider. It declines an amount above <see cref="MaximumAmount"/> euro and approves the rest.
/// </summary>
public class FakePaymentProvider : IPaymentProvider
{
    public const decimal MaximumAmount = 500m;

    public Task<PaymentResult> TakePaymentAsync(string orderNumber, decimal amount, CancellationToken cancellationToken = default)
    {
        var result = amount > MaximumAmount
            ? new PaymentResult(false, null)
            : new PaymentResult(true, $"FAKE-{orderNumber}-{Guid.NewGuid():N}");

        return Task.FromResult(result);
    }
}
