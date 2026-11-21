using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Demo.OrderService.CoreService.Messages;
using Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;
using Cat.Sagas.Abstractions;
using Cat.UnitTesting.Commands;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class PaymentProviderHandlerTests
{
    private sealed class FakePaymentProvider : IPaymentProvider
    {
        public PaymentChargeResult Charge { get; set; } = new(true, "PAY-1");

        public PaymentRefundResult Refund { get; set; } = new(true);

        public List<(string Key, string OrderNumber, decimal Amount)> Charges { get; } = [];

        public List<(string Key, string OrderNumber)> Refunds { get; } = [];

        public Task<PaymentChargeResult> ChargeAsync(string idempotencyKey, string orderNumber, decimal amount, CancellationToken cancellationToken = default)
        {
            Charges.Add((idempotencyKey, orderNumber, amount));
            return Task.FromResult(Charge);
        }

        public Task<PaymentRefundResult> RefundAsync(string idempotencyKey, string orderNumber, CancellationToken cancellationToken = default)
        {
            Refunds.Add((idempotencyKey, orderNumber));
            return Task.FromResult(Refund);
        }
    }

    private sealed class FakeSagaStore : ICatSagaStore
    {
        public Queue<CatSagaStatus?> Statuses { get; } = new();

        public CatSagaStatus? Default { get; set; } = CatSagaStatus.Waiting;

        public Task<CatSagaInstance?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var status = Statuses.Count > 0 ? Statuses.Dequeue() : Default;
            return Task.FromResult(status is null ? null : new CatSagaInstance { Id = id, Status = status.Value });
        }

        public Task AddAsync(CatSagaInstance instance, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public Task UpdateAsync(CatSagaInstance instance, CancellationToken cancellationToken = default) => throw new NotSupportedException();
    }

    private FakePaymentProvider _provider = null!;
    private FakeSagaStore _sagas = null!;
    private FakeCommandProcessor _commands = null!;

    [SetUp]
    public void SetUp()
    {
        _provider = new FakePaymentProvider();
        _sagas = new FakeSagaStore();
        _commands = new FakeCommandProcessor().Apply();
    }

    [Test]
    public async Task TakePayment_CallsTheProviderWithTheSagaIdAsTheKeyAndPublishesTheAnswer()
    {
        var request = new TakePayment { OrderNumber = "20261121-0001", Amount = 42.5m };

        var response = await new TakePaymentHandler(_provider, _commands, _sagas).HandleAsync(request);

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_provider.Charges.Single(), Is.EqualTo((request.CorrelationId.ToString(), "20261121-0001", 42.5m)));
        Assert.That(_commands.Of<PaymentProcessedPublishCommand>().Single(),
            Is.EqualTo(new PaymentProcessedPublishCommand(request.CorrelationId, "20261121-0001", true, "PAY-1")));
    }

    [Test]
    public async Task TakePayment_ADecline_IsPublishedAsAnAnswerAndNotAFailure()
    {
        _provider.Charge = new PaymentChargeResult(false, null);
        var request = new TakePayment { OrderNumber = "20261121-0001", Amount = 900m };

        var response = await new TakePaymentHandler(_provider, _commands, _sagas).HandleAsync(request);

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_commands.Of<PaymentProcessedPublishCommand>().Single().Approved, Is.False);
    }

    [Test]
    public async Task TakePayment_AProviderThatCannotAnswer_FailsSoTheMessageComesAgain()
    {
        _provider.Charge = new PaymentChargeResult(false, null, Unavailable: true);

        var response = await new TakePaymentHandler(_provider, _commands, _sagas)
            .HandleAsync(new TakePayment { OrderNumber = "20261121-0001", Amount = 10m });

        Assert.That(response.IsFailed, Is.True);
        Assert.That(_commands.Of<PaymentProcessedPublishCommand>(), Is.Empty);
    }

    [Test]
    public async Task TakePayment_ASagaThatNoLongerWaits_DoesNotChargeAndRefundsWithTheSagaIdAsTheKey()
    {
        _sagas.Default = CatSagaStatus.Completed;
        var request = new TakePayment { OrderNumber = "20261121-0001", Amount = 42.5m };

        var response = await new TakePaymentHandler(_provider, _commands, _sagas).HandleAsync(request);

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_provider.Charges, Is.Empty);
        Assert.That(_provider.Refunds.Single(), Is.EqualTo((request.CorrelationId.ToString(), "20261121-0001")));
        Assert.That(_commands.Of<PaymentProcessedPublishCommand>(), Is.Empty);
    }

    [Test]
    public async Task TakePayment_ASagaThatTimesOutWhileTheProviderWorks_RefundsTheChargeAtOnce()
    {
        _sagas.Statuses.Enqueue(CatSagaStatus.Waiting);
        _sagas.Statuses.Enqueue(CatSagaStatus.Completed);
        var request = new TakePayment { OrderNumber = "20261121-0001", Amount = 42.5m };

        var response = await new TakePaymentHandler(_provider, _commands, _sagas).HandleAsync(request);

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_provider.Charges, Has.Count.EqualTo(1));
        Assert.That(_provider.Refunds.Single(), Is.EqualTo((request.CorrelationId.ToString(), "20261121-0001")));
        Assert.That(_commands.Of<PaymentProcessedPublishCommand>(), Is.Empty);
    }

    [Test]
    public async Task TakePayment_ALateRefundThatCannotBeAnswered_FailsSoTheMessageComesAgain()
    {
        _sagas.Default = CatSagaStatus.Completed;
        _provider.Refund = new PaymentRefundResult(false, Unavailable: true);

        var response = await new TakePaymentHandler(_provider, _commands, _sagas)
            .HandleAsync(new TakePayment { OrderNumber = "20261121-0001", Amount = 10m });

        Assert.That(response.IsFailed, Is.True);
    }

    [Test]
    public async Task TakePayment_ADeclineAfterTheSagaTimedOut_IsNotRefunded()
    {
        _sagas.Statuses.Enqueue(CatSagaStatus.Waiting);
        _sagas.Statuses.Enqueue(CatSagaStatus.Completed);
        _provider.Charge = new PaymentChargeResult(false, null);

        await new TakePaymentHandler(_provider, _commands, _sagas).HandleAsync(new TakePayment { OrderNumber = "20261121-0001", Amount = 10m });

        Assert.That(_provider.Refunds, Is.Empty);
    }

    [Test]
    public async Task RefundPayment_CallsTheProviderWithTheOrderNumberAsTheKeyAndPublishesTheAnswer()
    {
        var request = new RefundPayment { OrderNumber = "20261121-0001" };

        var response = await new RefundPaymentHandler(_provider, _commands).HandleAsync(request);

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_provider.Refunds.Single(), Is.EqualTo(("refund-20261121-0001", "20261121-0001")));
        Assert.That(_commands.Of<PaymentRefundedPublishCommand>().Single(),
            Is.EqualTo(new PaymentRefundedPublishCommand(request.CorrelationId, "20261121-0001", true)));
    }

    [Test]
    public async Task RefundPayment_AProviderThatCannotAnswer_FailsSoTheMessageComesAgain()
    {
        _provider.Refund = new PaymentRefundResult(false, Unavailable: true);

        var response = await new RefundPaymentHandler(_provider, _commands)
            .HandleAsync(new RefundPayment { OrderNumber = "20261121-0001" });

        Assert.That(response.IsFailed, Is.True);
        Assert.That(_commands.Of<PaymentRefundedPublishCommand>(), Is.Empty);
    }
}
