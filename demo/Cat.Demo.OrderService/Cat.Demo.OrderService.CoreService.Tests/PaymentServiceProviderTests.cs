using System.Net;
using System.Text;
using System.Text.Json;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.Infrastructure.PaymentServices;
using Cat.Demo.PaymentService.Api.Client;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class PaymentServiceProviderTests
{
    private sealed class StubHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> respond) : HttpMessageHandler
    {
        public List<(HttpMethod Method, string? Path, string Body)> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add((request.Method, request.RequestUri?.AbsolutePath, request.Content is null ? "" : await request.Content.ReadAsStringAsync(cancellationToken)));
            return await respond(request);
        }
    }

    private static HttpResponseMessage Json(HttpStatusCode status, string json) =>
        new(status) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

    private static PaymentServiceProvider Provider(StubHandler handler) =>
        new(new PaymentClient(new HttpClient(handler) { BaseAddress = new Uri("http://gateway") }), NullLogger<PaymentServiceProvider>.Instance);

    [Test]
    public async Task AnApprovedAnswer_ShouldBeApprovedWithTheReference()
    {
        var handler = new StubHandler(_ => Task.FromResult(Json(HttpStatusCode.OK, "{\"approved\":true,\"reference\":\"PAY-1\"}")));

        var result = await Provider(handler).TakePaymentAsync("20261106-0001", 12.5m);

        Assert.That(result, Is.EqualTo(new PaymentResult(true, "PAY-1")));
        var request = handler.Requests.Single();
        Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
        Assert.That(request.Path, Is.EqualTo("/payment/payments"));
        using var body = JsonDocument.Parse(request.Body);
        Assert.That(body.RootElement.GetProperty("orderNumber").GetString(), Is.EqualTo("20261106-0001"));
        Assert.That(body.RootElement.GetProperty("amount").GetDecimal(), Is.EqualTo(12.5m));
    }

    [Test]
    public async Task ADeclinedAnswer_ShouldBeDeclinedAndNotUnavailable()
    {
        var handler = new StubHandler(_ => Task.FromResult(Json(HttpStatusCode.OK, "{\"approved\":false,\"reference\":null}")));

        var result = await Provider(handler).TakePaymentAsync("20261106-0001", 900m);

        Assert.That(result, Is.EqualTo(new PaymentResult(false, null)));
    }

    [TestCase(HttpStatusCode.ServiceUnavailable)]
    [TestCase(HttpStatusCode.InternalServerError)]
    [TestCase(HttpStatusCode.BadRequest)]
    public async Task AnErrorStatus_ShouldBeUnavailable(HttpStatusCode status)
    {
        var handler = new StubHandler(_ => Task.FromResult(new HttpResponseMessage(status)));

        var result = await Provider(handler).TakePaymentAsync("20261106-0001", 10m);

        Assert.That(result, Is.EqualTo(new PaymentResult(false, null, Unavailable: true)));
    }

    [Test]
    public async Task AnAnswerWithoutABody_ShouldBeUnavailable()
    {
        var handler = new StubHandler(_ => Task.FromResult(Json(HttpStatusCode.OK, "null")));

        var result = await Provider(handler).TakePaymentAsync("20261106-0001", 10m);

        Assert.That(result.Unavailable, Is.True);
    }

    [Test]
    public async Task AFailedCall_ShouldBeUnavailable()
    {
        // The resilience handler throws its own exceptions for a timeout or an open circuit. Any exception counts.
        var handler = new StubHandler(_ => throw new HttpRequestException("connection refused"));

        var result = await Provider(handler).TakePaymentAsync("20261106-0001", 10m);

        Assert.That(result, Is.EqualTo(new PaymentResult(false, null, Unavailable: true)));
    }

    [Test]
    public void ACancelledCall_ShouldStayCancelled()
    {
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        var handler = new StubHandler(_ => throw new OperationCanceledException(cancellation.Token));

        Assert.That(async () => await Provider(handler).TakePaymentAsync("20261106-0001", 10m, cancellation.Token),
            Throws.InstanceOf<OperationCanceledException>());
    }
}
