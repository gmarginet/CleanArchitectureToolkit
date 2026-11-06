using Microsoft.Extensions.Options;

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

    private sealed class FakeTime : TimeProvider
    {
        public override ITimer CreateTimer(TimerCallback callback, object? state, TimeSpan dueTime, TimeSpan period)
        {
            // The delay is over as soon as it starts.
            callback(state);
            return new NoTimer();
        }

        private sealed class NoTimer : ITimer
        {
            public bool Change(TimeSpan dueTime, TimeSpan period) => true;
            public void Dispose() { }
            public ValueTask DisposeAsync() => ValueTask.CompletedTask;
        }
    }

    private static PaymentProcessor Processor(PaymentFailureOptions? options = null, int percentage = 0) =>
        new(new FixedOptions(options ?? new PaymentFailureOptions()), new FakeTime(), () => percentage);

    [Test]
    public async Task AnAmountUpToTheMaximum_ShouldBeApprovedWithAReference()
    {
        var outcome = await Processor().ProcessAsync(new PaymentRequest("20261106-0001", 500m));

        Assert.That(outcome.Failed, Is.False);
        Assert.That(outcome.Response!.Approved, Is.True);
        Assert.That(outcome.Response.Reference, Does.StartWith("PAY-20261106-0001-"));
    }

    [Test]
    public async Task AnAmountAboveTheMaximum_ShouldBeDeclinedWithoutAReference()
    {
        var outcome = await Processor().ProcessAsync(new PaymentRequest("20261106-0001", 500.01m));

        Assert.That(outcome.Failed, Is.False);
        Assert.That(outcome.Response, Is.EqualTo(new PaymentResponse(false, null)));
    }

    [Test]
    public async Task TheSameOrderNumber_ShouldGetTheSameAnswerAndBeChargedOnce()
    {
        var processor = Processor();

        var first = await processor.ProcessAsync(new PaymentRequest("20261106-0001", 10m));
        var second = await processor.ProcessAsync(new PaymentRequest("20261106-0001", 10m));

        Assert.That(second.Response, Is.EqualTo(first.Response));
        Assert.That(processor.ChargedOrders, Is.EqualTo(1));
    }

    [Test]
    public async Task AnOutage_ShouldFailAndTakeNothing()
    {
        var processor = Processor(new PaymentFailureOptions { Outage = true });

        var outcome = await processor.ProcessAsync(new PaymentRequest("20261106-0001", 10m));

        Assert.That(outcome.Failed, Is.True);
        Assert.That(processor.ChargedOrders, Is.Zero);
    }

    [Test]
    public async Task ARandomFailure_ShouldFailAfterTheChargeAndTheRetryShouldNotChargeAgain()
    {
        var next = 10;
        var processor = new PaymentProcessor(new FixedOptions(new PaymentFailureOptions { ErrorPercentage = 50 }), new FakeTime(), () => next);

        var failed = await processor.ProcessAsync(new PaymentRequest("20261106-0001", 10m));

        Assert.That(failed.Failed, Is.True);
        Assert.That(processor.ChargedOrders, Is.EqualTo(1), "The money was taken before the failure.");

        // The number is now above the limit, so the retry gets through and finds the stored answer.
        next = 90;
        var retry = await processor.ProcessAsync(new PaymentRequest("20261106-0001", 10m));

        Assert.That(retry.Failed, Is.False);
        Assert.That(retry.Response!.Approved, Is.True);
        Assert.That(processor.ChargedOrders, Is.EqualTo(1));
    }

    [Test]
    public async Task ALatency_ShouldDelayTheAnswerOnTheClockOfTheProcessor()
    {
        var outcome = await Processor(new PaymentFailureOptions { Latency = TimeSpan.FromSeconds(30) })
            .ProcessAsync(new PaymentRequest("20261106-0001", 10m));

        Assert.That(outcome.Failed, Is.False);
    }
}
