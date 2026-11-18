using System.Collections.Concurrent;
using Microsoft.Extensions.Options;

namespace Cat.Demo.PaymentService.CoreService;

/// <summary>
/// Takes payments by the rules of the demo: an amount above <see cref="MaximumAmount"/> euro is declined, the rest is approved.
/// It remembers the answer for every order number, so a retried call gets the same answer and charges nothing twice.
/// The failures from <see cref="PaymentFailureOptions"/> are applied around that.
/// </summary>
public class PaymentProcessor
{
    public const decimal MaximumAmount = 500m;

    private readonly ConcurrentDictionary<string, PaymentResponse> _ledger = new();
    private readonly ConcurrentDictionary<string, bool> _refunded = new();
    private readonly IOptionsMonitor<PaymentFailureOptions> _options;
    private readonly TimeProvider _timeProvider;
    private readonly Func<int> _nextPercentage;

    public PaymentProcessor(IOptionsMonitor<PaymentFailureOptions> options, TimeProvider timeProvider)
        : this(options, timeProvider, () => Random.Shared.Next(100))
    {
    }

    /// <param name="options">The failure settings.</param>
    /// <param name="timeProvider">The clock that the latency waits on.</param>
    /// <param name="nextPercentage">Gives a number from 0 to 99. A call fails when the number is below the error percentage.</param>
    public PaymentProcessor(IOptionsMonitor<PaymentFailureOptions> options, TimeProvider timeProvider, Func<int> nextPercentage)
    {
        _options = options;
        _timeProvider = timeProvider;
        _nextPercentage = nextPercentage;
    }

    /// <summary>How many different orders were charged.</summary>
    public int ChargedOrders => _ledger.Count;

    /// <summary>How many different orders were refunded.</summary>
    public int RefundedOrders => _refunded.Count;

    public async Task<PaymentOutcome> ProcessAsync(PaymentRequest request, CancellationToken cancellationToken = default)
    {
        var options = _options.CurrentValue;

        // An outage fails at once and takes nothing.
        if (options.Outage)
        {
            return PaymentOutcome.Failure();
        }

        if (options.Latency > TimeSpan.Zero)
        {
            await Task.Delay(options.Latency, _timeProvider, cancellationToken);
        }

        // The payment is taken and remembered first. A random failure comes after it, which is the worst case:
        // the money is gone and the caller does not know. The retry finds the answer and charges nothing again.
        var response = _ledger.GetOrAdd(request.OrderNumber, _ => Charge(request));

        if (options.ErrorPercentage > 0 && _nextPercentage() < options.ErrorPercentage)
        {
            return PaymentOutcome.Failure();
        }

        return PaymentOutcome.Answer(response);
    }

    /// <summary>
    /// Gives the money of an approved payment back. The order number is the key: a refund that was done is done again with the same answer.
    /// A payment that was declined or never taken has nothing to give back, and the answer says so.
    /// The outage, latency and error settings apply as for a payment. A random failure comes after the refund is remembered, so the retry gets the same answer.
    /// </summary>
    public async Task<RefundOutcome> RefundAsync(string orderNumber, CancellationToken cancellationToken = default)
    {
        var options = _options.CurrentValue;

        if (options.Outage)
        {
            return RefundOutcome.Failure();
        }

        if (options.Latency > TimeSpan.Zero)
        {
            await Task.Delay(options.Latency, _timeProvider, cancellationToken);
        }

        var refunded = _ledger.TryGetValue(orderNumber, out var payment) && payment.Approved;
        if (refunded)
        {
            _refunded.TryAdd(orderNumber, true);
        }

        if (options.ErrorPercentage > 0 && _nextPercentage() < options.ErrorPercentage)
        {
            return RefundOutcome.Failure();
        }

        return RefundOutcome.Done(refunded);
    }

    private static PaymentResponse Charge(PaymentRequest request) =>
        request.Amount > MaximumAmount
            ? new PaymentResponse(false, null)
            : new PaymentResponse(true, $"PAY-{request.OrderNumber}-{Guid.NewGuid():N}");
}
