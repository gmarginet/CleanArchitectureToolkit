using System.Net;
using Cat.Demo.OrderService.Infrastructure.PaymentServices;
using Microsoft.AspNetCore.Http;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class ForwardBearerTokenHandlerTests
{
    private sealed class RecordingHandler : HttpMessageHandler
    {
        public string? Authorization { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Authorization = request.Headers.TryGetValues("Authorization", out var values) ? values.Single() : null;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }

    private static async Task<string?> SendAsync(HttpContext? httpContext)
    {
        var recorder = new RecordingHandler();
        var handler = new ForwardBearerTokenHandler(new HttpContextAccessor { HttpContext = httpContext }) { InnerHandler = recorder };
        using var client = new HttpClient(handler) { BaseAddress = new Uri("http://gateway") };

        await client.GetAsync("/payment/payments");

        return recorder.Authorization;
    }

    [Test]
    public async Task ARequestWithAToken_ShouldPassTheTokenOn()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers.Authorization = "Bearer abc";

        Assert.That(await SendAsync(context), Is.EqualTo("Bearer abc"));
    }

    [Test]
    public async Task ARequestWithoutAToken_ShouldSendNoToken()
    {
        Assert.That(await SendAsync(new DefaultHttpContext()), Is.Null);
    }

    [Test]
    public async Task NoRequestAtAll_ShouldSendNoToken()
    {
        Assert.That(await SendAsync(null), Is.Null);
    }
}
