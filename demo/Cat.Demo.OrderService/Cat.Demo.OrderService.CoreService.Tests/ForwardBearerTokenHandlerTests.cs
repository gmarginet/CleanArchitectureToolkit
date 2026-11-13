using System.Net;
using Cat.Demo.OrderService.Infrastructure.ApiClients;
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

    private sealed class FakeClientTokens(string? token) : IClientTokenProvider
    {
        public Task<string?> GetTokenAsync(CancellationToken cancellationToken = default) => Task.FromResult(token);
    }

    private static async Task<string?> SendAsync(HttpContext? httpContext, IClientTokenProvider? clientTokens = null)
    {
        var recorder = new RecordingHandler();
        var handler = new ForwardBearerTokenHandler(new HttpContextAccessor { HttpContext = httpContext }, clientTokens) { InnerHandler = recorder };
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

    [Test]
    public async Task NoRequestAtAll_WithAClientTokenProvider_ShouldSendTheClientToken()
    {
        Assert.That(await SendAsync(null, new FakeClientTokens("client-token")), Is.EqualTo("Bearer client-token"));
    }

    [Test]
    public async Task ARequestWithAToken_WithAClientTokenProvider_ShouldStillPassTheUserTokenOn()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers.Authorization = "Bearer abc";

        Assert.That(await SendAsync(context, new FakeClientTokens("client-token")), Is.EqualTo("Bearer abc"));
    }

    [Test]
    public async Task NoRequestAtAll_WhenTheClientTokenProviderGivesNothing_ShouldSendNoToken()
    {
        Assert.That(await SendAsync(null, new FakeClientTokens(null)), Is.Null);
    }
}
