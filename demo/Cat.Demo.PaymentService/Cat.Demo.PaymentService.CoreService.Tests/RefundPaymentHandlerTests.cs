using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.Responses.Abstractions;
using Cat.UnitTesting.Messaging;
using Cat.UnitTesting.Responses.NUnit;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Time.Testing;

namespace Cat.Demo.PaymentService.CoreService.Tests;

[TestFixture]
public class RefundPaymentHandlerTests
{
    private sealed class FixedOptions(PaymentFailureOptions value) : IOptionsMonitor<PaymentFailureOptions>
    {
        public PaymentFailureOptions CurrentValue { get; } = value;

        public PaymentFailureOptions Get(string? name) => CurrentValue;

        public IDisposable? OnChange(Action<PaymentFailureOptions, string?> listener) => null;
    }

    private FakeMessageSender _sender = null!;
    private PaymentProcessor _processor = null!;

    private RefundPaymentHandler Handler(PaymentFailureOptions? options = null, int percentage = 0)
    {
        _sender = new FakeMessageSender();
        _processor = new PaymentProcessor(new FixedOptions(options ?? new PaymentFailureOptions()), new FakeTimeProvider(), () => percentage);
        return new RefundPaymentHandler(_processor, _sender);
    }

    private static RefundPayment Request(string orderNumber = "20261118-0001", Guid? correlationId = null) =>
        new() { OrderNumber = orderNumber, CorrelationId = correlationId ?? Guid.NewGuid() };

    [Test]
    public async Task AnApprovedPayment_IsRefundedAndPaymentRefundedCarriesTheCorrelationId()
    {
        var handler = Handler();
        await _processor.ProcessAsync(new PaymentRequest("20261118-0001", 10m));
        var request = Request();

        var response = await handler.HandleAsync(request);

        Assert.That(response, CatIs.Succeeded);
        var answer = _sender.Of<PaymentRefunded>().Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(answer.CorrelationId, Is.EqualTo(request.CorrelationId));
            Assert.That(answer.OrderNumber, Is.EqualTo(request.OrderNumber));
            Assert.That(answer.Refunded, Is.True);
            Assert.That(_processor.RefundedOrders, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task ARefundThatIsRepeated_GivesTheSameAnswerAndRefundsOnce()
    {
        var handler = Handler();
        await _processor.ProcessAsync(new PaymentRequest("20261118-0001", 10m));

        await handler.HandleAsync(Request());
        await handler.HandleAsync(Request());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_sender.Of<PaymentRefunded>().Count(), Is.EqualTo(2));
            Assert.That(_sender.Of<PaymentRefunded>().All(x => x.Refunded), Is.True);
            Assert.That(_processor.RefundedOrders, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task ADeclinedPayment_HasNothingToRefund()
    {
        var handler = Handler();
        await _processor.ProcessAsync(new PaymentRequest("20261118-0001", PaymentProcessor.MaximumAmount + 1m));

        var response = await handler.HandleAsync(Request());

        Assert.That(response, CatIs.Succeeded);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_sender.Of<PaymentRefunded>().Single().Refunded, Is.False);
            Assert.That(_processor.RefundedOrders, Is.Zero);
        }
    }

    [Test]
    public async Task AnUnknownOrder_HasNothingToRefund()
    {
        var handler = Handler();

        await handler.HandleAsync(Request("20261118-9999"));

        Assert.That(_sender.Of<PaymentRefunded>().Single().Refunded, Is.False);
    }

    [Test]
    public async Task AnOutage_FailsTheHandlerAndPublishesNothing()
    {
        var handler = Handler(new PaymentFailureOptions { Outage = true });

        var response = await handler.HandleAsync(Request());

        Assert.That(response, CatIs.FailedWith(CatResponseType.InternalServerError, "DEM-PAY-1001"));
        Assert.That(_sender.Sent, Is.Empty);
    }

    [Test]
    public async Task ARandomError_FailsTheHandlerButTheRefundIsRemembered()
    {
        var handler = Handler(new PaymentFailureOptions { ErrorPercentage = 50 }, percentage: 0);
        await _processor.ProcessAsync(new PaymentRequest("20261118-0001", 10m));

        var response = await handler.HandleAsync(Request());

        Assert.That(response, CatIs.FailedWith(CatResponseType.InternalServerError, "DEM-PAY-1001"));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_sender.Sent, Is.Empty);
            Assert.That(_processor.RefundedOrders, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task ARequestWithoutAnOrderNumber_IsABadRequestAndPublishesNothing()
    {
        var handler = Handler();

        var response = await handler.HandleAsync(Request(orderNumber: " "));

        Assert.That(response, CatIs.FailedWith(CatResponseType.BadRequest, "DEM-PAY-1002"));
        Assert.That(_sender.Sent, Is.Empty);
    }
}
