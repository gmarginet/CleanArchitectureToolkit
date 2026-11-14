using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.Responses.Abstractions;
using Cat.UnitTesting.Messaging;
using Cat.UnitTesting.Responses.NUnit;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Time.Testing;

namespace Cat.Demo.PaymentService.CoreService.Tests;

[TestFixture]
public class TakePaymentHandlerTests
{
    private sealed class FixedOptions(PaymentFailureOptions value) : IOptionsMonitor<PaymentFailureOptions>
    {
        public PaymentFailureOptions CurrentValue { get; } = value;

        public PaymentFailureOptions Get(string? name) => CurrentValue;

        public IDisposable? OnChange(Action<PaymentFailureOptions, string?> listener) => null;
    }

    private FakeMessageSender _sender = null!;

    private TakePaymentHandler Handler(PaymentFailureOptions? options = null, int percentage = 0)
    {
        _sender = new FakeMessageSender();
        var processor = new PaymentProcessor(new FixedOptions(options ?? new PaymentFailureOptions()), new FakeTimeProvider(), () => percentage);
        return new TakePaymentHandler(processor, _sender);
    }

    private static TakePayment Request(string orderNumber = "20261114-0001", decimal amount = 10m, Guid? correlationId = null) =>
        new() { OrderNumber = orderNumber, Amount = amount, CorrelationId = correlationId ?? Guid.NewGuid() };

    [Test]
    public async Task AnApprovedPayment_PublishesPaymentProcessedWithTheCorrelationIdOfTheRequest()
    {
        var handler = Handler();
        var request = Request();

        var response = await handler.HandleAsync(request);

        Assert.That(response, CatIs.Succeeded);
        var answer = _sender.Of<PaymentProcessed>().Single();
        Assert.That(answer.CorrelationId, Is.EqualTo(request.CorrelationId));
        Assert.That(answer.OrderNumber, Is.EqualTo(request.OrderNumber));
        Assert.That(answer.Approved, Is.True);
        Assert.That(answer.Reference, Does.StartWith("PAY-20261114-0001-"));
    }

    [Test]
    public async Task ADeclinedPayment_IsAnAnswerWithApprovedFalse()
    {
        var handler = Handler();

        var response = await handler.HandleAsync(Request(amount: PaymentProcessor.MaximumAmount + 0.01m));

        Assert.That(response, CatIs.Succeeded);
        var answer = _sender.Of<PaymentProcessed>().Single();
        Assert.That(answer.Approved, Is.False);
        Assert.That(answer.Reference, Is.Null);
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
    public async Task ARandomError_FailsTheHandlerAndPublishesNothing()
    {
        var handler = Handler(new PaymentFailureOptions { ErrorPercentage = 50 }, percentage: 0);

        var response = await handler.HandleAsync(Request());

        Assert.That(response, CatIs.FailedWith(CatResponseType.InternalServerError, "DEM-PAY-1001"));
        Assert.That(_sender.Sent, Is.Empty);
    }

    [Test]
    public async Task ARequestWithoutAnOrderNumber_IsABadRequestAndPublishesNothing()
    {
        var handler = Handler();

        var response = await handler.HandleAsync(Request(orderNumber: " "));

        Assert.That(response, CatIs.FailedWith(CatResponseType.BadRequest, "DEM-PAY-1000"));
        Assert.That(_sender.Sent, Is.Empty);
    }

    [Test]
    public async Task AnAmountOfZero_IsABadRequest()
    {
        var handler = Handler();

        var response = await handler.HandleAsync(Request(amount: 0m));

        Assert.That(response, CatIs.FailedWith(CatResponseType.BadRequest, "DEM-PAY-1000"));
    }
}
