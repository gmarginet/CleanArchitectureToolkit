using Microsoft.Extensions.Options;
using Microsoft.Extensions.Time.Testing;

namespace Cat.Demo.PaymentService.CoreService.Tests;

[TestFixture]
public class PaymentProcessorTests
{
    private sealed class FixedOptions(PaymentFailureOptions value) : IOptionsMonitor<PaymentFailureOptions>
    {
        public PaymentFailureOptions CurrentValue { get; } = value;

        public PaymentFailureOptions Get(string? name) => CurrentValue;

        public IDisposable? OnChange(Action<PaymentFailureOptions, string?> listener) => null;
    }

    private static PaymentProcessor Processor(PaymentFailureOptions? options = null, int percentage = 0) =>
        new(new FixedOptions(options ?? new PaymentFailureOptions()), new FakeTimeProvider(), () => percentage);

    [Test]
    public async Task AnAmountUpToTheMaximum_ShouldBeApprovedWithAReference()
    {
        var outcome = await Processor().ChargeAsync("key-1", new ChargeRequest("20261106-0001", 500m));

        Assert.That(outcome.Failed, Is.False);
        Assert.That(outcome.Response!.Status, Is.EqualTo(ChargeStatuses.Approved));
        Assert.That(outcome.Response.Reference, Does.StartWith("PAY-20261106-0001-"));
    }

    [Test]
    public async Task AnAmountAboveTheMaximum_ShouldBeDeclinedWithoutAReference()
    {
        var outcome = await Processor().ChargeAsync("key-1", new ChargeRequest("20261106-0001", 500.01m));

        Assert.That(outcome.Failed, Is.False);
        Assert.That(outcome.Response, Is.EqualTo(new ChargeResponse(ChargeStatuses.Declined, null)));
    }

    [Test]
    public async Task TheSameIdempotencyKey_ShouldGetTheSameAnswerAndBeChargedOnce()
    {
        var processor = Processor();

        var first = await processor.ChargeAsync("key-1", new ChargeRequest("20261106-0001", 10m));
        var second = await processor.ChargeAsync("key-1", new ChargeRequest("20261106-0001", 10m));

        Assert.That(second.Response, Is.EqualTo(first.Response));
        Assert.That(processor.Charges, Is.EqualTo(1));
    }

    [Test]
    public async Task AnOutage_ShouldFailAndTakeNothing()
    {
        var processor = Processor(new PaymentFailureOptions { Outage = true });

        var outcome = await processor.ChargeAsync("key-1", new ChargeRequest("20261106-0001", 10m));

        Assert.That(outcome.Failed, Is.True);
        Assert.That(processor.Charges, Is.Zero);
    }

    [Test]
    public async Task ARandomFailure_ShouldFailAfterTheChargeAndTheRetryShouldNotChargeAgain()
    {
        var next = 10;
        var processor = new PaymentProcessor(new FixedOptions(new PaymentFailureOptions { ErrorPercentage = 50 }), new FakeTimeProvider(), () => next);

        var failed = await processor.ChargeAsync("key-1", new ChargeRequest("20261106-0001", 10m));

        Assert.That(failed.Failed, Is.True);
        Assert.That(processor.Charges, Is.EqualTo(1), "The money was taken before the failure.");

        // The number is now above the limit, so the retry gets through and finds the stored answer.
        next = 90;
        var retry = await processor.ChargeAsync("key-1", new ChargeRequest("20261106-0001", 10m));

        Assert.That(retry.Failed, Is.False);
        Assert.That(retry.Response!.Status, Is.EqualTo(ChargeStatuses.Approved));
        Assert.That(processor.Charges, Is.EqualTo(1));
    }

    [Test]
    public async Task ALatency_ShouldDelayTheAnswerOnTheClockOfTheProcessor()
    {
        var time = new FakeTimeProvider();
        var processor = new PaymentProcessor(new FixedOptions(new PaymentFailureOptions { Latency = TimeSpan.FromSeconds(30) }), time, () => 0);

        var answer = processor.ChargeAsync("key-1", new ChargeRequest("20261106-0001", 10m));

        Assert.That(answer.IsCompleted, Is.False, "The answer waits for the latency.");

        time.Advance(TimeSpan.FromSeconds(30));
        var outcome = await answer;

        Assert.That(outcome.Failed, Is.False);
    }

    [Test]
    public async Task ARefundOfAnApprovedCharge_ShouldGiveTheMoneyBack()
    {
        var processor = Processor();
        await processor.ChargeAsync("charge-1", new ChargeRequest("20261106-0001", 10m));

        var outcome = await processor.RefundAsync("refund-1", new RefundRequest("20261106-0001"));

        Assert.That(outcome.Response, Is.EqualTo(new RefundResponse(RefundStatuses.Refunded)));
    }

    [Test]
    public async Task ARefundOfADeclinedOrAnUnknownOrder_ShouldSayThereIsNothingToRefund()
    {
        var processor = Processor();
        await processor.ChargeAsync("charge-1", new ChargeRequest("20261106-0001", 500.01m));

        var declined = await processor.RefundAsync("refund-1", new RefundRequest("20261106-0001"));
        var unknown = await processor.RefundAsync("refund-2", new RefundRequest("20261106-0002"));

        Assert.That(declined.Response!.Status, Is.EqualTo(RefundStatuses.NothingToRefund));
        Assert.That(unknown.Response!.Status, Is.EqualTo(RefundStatuses.NothingToRefund));
    }

    [Test]
    public async Task TheSameRefundKey_ShouldGetTheSameAnswerAndBeRefundedOnce()
    {
        var processor = Processor();
        await processor.ChargeAsync("charge-1", new ChargeRequest("20261106-0001", 10m));

        var first = await processor.RefundAsync("refund-1", new RefundRequest("20261106-0001"));
        var second = await processor.RefundAsync("refund-1", new RefundRequest("20261106-0001"));

        Assert.That(second.Response, Is.EqualTo(first.Response));
        Assert.That(processor.Refunds, Is.EqualTo(1));
    }

    [Test]
    public async Task AnOutage_ShouldFailARefundToo()
    {
        var outcome = await Processor(new PaymentFailureOptions { Outage = true })
            .RefundAsync("refund-1", new RefundRequest("20261106-0001"));

        Assert.That(outcome.Failed, Is.True);
    }
}
