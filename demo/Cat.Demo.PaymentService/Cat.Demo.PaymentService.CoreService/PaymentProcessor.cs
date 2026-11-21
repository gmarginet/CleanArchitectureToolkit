using System.Collections.Concurrent;
using Microsoft.Extensions.Options;

namespace Cat.Demo.PaymentService.CoreService;

/// <summary>
/// The rules of the stand-in for an outside payment provider: an amount above <see cref="MaximumAmount"/> euro is declined, the rest is approved.
/// It remembers the answer for every idempotency key, so a repeated call gets the first answer and charges nothing twice.
/// The failures from <see cref="PaymentFailureOptions"/> are applied around that.
/// </summary>
public class PaymentProcessor
{
    public const decimal MaximumAmount = 500m;

    private readonly ConcurrentDictionary<string, ChargeResponse> _charges = new();
    private readonly ConcurrentDictionary<string, string> _approvedOrders = new();
    private readonly ConcurrentDictionary<string, RefundResponse> _refunds = new();
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

    /// <summary>How many different charges were taken, one for every idempotency key.</summary>
    public int Charges => _charges.Count;

    /// <summary>How many different refunds were done, one for every idempotency key.</summary>
    public int Refunds => _refunds.Count;

    /// <summary>Takes a payment. The idempotency key makes a repeated call return the first answer.</summary>
    public async Task<ChargeOutcome> ChargeAsync(string idempotencyKey, ChargeRequest request, CancellationToken cancellationToken = default)
    {
        var options = _options.CurrentValue;

        // An outage fails at once and takes nothing.
        if (options.Outage)
        {
            return ChargeOutcome.Failure();
        }

        await WaitAsync(options, cancellationToken);

        // The payment is taken and remembered first. A random failure comes after it, which is the worst case:
        // the money is gone and the caller does not know. The retry finds the answer and charges nothing again.
        var response = _charges.GetOrAdd(idempotencyKey, _ => Charge(request));
        if (response.Status == ChargeStatuses.Approved)
        {
            _approvedOrders.TryAdd(request.OrderNumber, idempotencyKey);
        }

        return FailsRandomly(options) ? ChargeOutcome.Failure() : ChargeOutcome.Answer(response);
    }

    /// <summary>
    /// Gives the money of an approved payment back. The idempotency key makes a repeated call return the first answer.
    /// An order that was declined or never charged has nothing to give back, and the answer says so.
    /// The outage, latency and error settings apply as for a charge. A random failure comes after the refund is remembered, so the retry gets the same answer.
    /// </summary>
    public async Task<RefundOutcome> RefundAsync(string idempotencyKey, RefundRequest request, CancellationToken cancellationToken = default)
    {
        var options = _options.CurrentValue;

        if (options.Outage)
        {
            return RefundOutcome.Failure();
        }

        await WaitAsync(options, cancellationToken);

        var response = _refunds.GetOrAdd(idempotencyKey, _ => new RefundResponse(
            _approvedOrders.ContainsKey(request.OrderNumber) ? RefundStatuses.Refunded : RefundStatuses.NothingToRefund));

        return FailsRandomly(options) ? RefundOutcome.Failure() : RefundOutcome.Answer(response);
    }

    private Task WaitAsync(PaymentFailureOptions options, CancellationToken cancellationToken) =>
        options.Latency > TimeSpan.Zero ? Task.Delay(options.Latency, _timeProvider, cancellationToken) : Task.CompletedTask;

    private bool FailsRandomly(PaymentFailureOptions options) =>
        options.ErrorPercentage > 0 && _nextPercentage() < options.ErrorPercentage;

    private static ChargeResponse Charge(ChargeRequest request) =>
        request.Amount > MaximumAmount
            ? new ChargeResponse(ChargeStatuses.Declined, null)
            : new ChargeResponse(ChargeStatuses.Approved, $"PAY-{request.OrderNumber}-{Guid.NewGuid():N}");
}
