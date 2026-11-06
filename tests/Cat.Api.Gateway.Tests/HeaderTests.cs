using Cat.Api.Gateway.Abstractions;
using Cat.Api.Gateway.Tests.Helpers;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class HeaderTests
{
    [Test]
    public async Task Identity_headers_of_a_caller_never_reach_the_service()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
        {
            request.Headers.Add("X-User-Id", "admin");
            request.Headers.Add("X-User", "admin");
            request.Headers.Add("X-Forwarded-User", "admin");
            request.Headers.Add("X-Authenticated-User", "admin");
            request.Headers.Add("X-Remote-User", "admin");
            request.Headers.Add("X-Original-User", "admin");
        });

        var headers = service.Last.Headers;
        Assert.That(headers.Keys.Where(k => k.Contains("User", StringComparison.OrdinalIgnoreCase)), Is.Empty);
    }

    [Test]
    public async Task The_owner_can_name_more_headers_to_remove()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address,
            ["CatGateway:Headers:StripHeaders:0"] = "X-Tenant"
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request => request.Headers.Add("X-Tenant", "other"));

        Assert.That(service.Last.Headers.ContainsKey("X-Tenant"), Is.False);
    }

    [Test]
    public async Task A_caller_cannot_send_a_gateway_assertion_to_a_service_that_is_not_gateway_only()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
            request.Headers.Add(CatGatewayDefaults.AssertionHeaderName, "forged"));

        Assert.That(service.Last.Headers.ContainsKey(CatGatewayDefaults.AssertionHeaderName), Is.False);
    }

    [Test]
    public async Task The_forwarded_headers_of_a_caller_are_replaced_by_default()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
        {
            request.Headers.Add("X-Forwarded-For", "6.6.6.6");
            request.Headers.Add("X-Forwarded-Host", "evil.example");
            request.Headers.Add("X-Forwarded-Proto", "https");
            request.Headers.Add("Forwarded", "for=6.6.6.6");
        });

        var headers = service.Last.Headers;
        Assert.That(headers["X-Forwarded-For"], Does.Not.Contain("6.6.6.6"));
        Assert.That(headers["X-Forwarded-Host"], Does.Not.Contain("evil.example"));
        Assert.That(headers["X-Forwarded-Proto"], Is.EqualTo("http"));
        Assert.That(headers.ContainsKey("Forwarded"), Is.False);
    }

    [Test]
    public async Task The_forwarded_headers_of_an_earlier_proxy_are_extended_when_the_owner_trusts_it()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address,
            ["CatGateway:Headers:TrustForwardedHeaders"] = "true"
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
            request.Headers.Add("X-Forwarded-For", "10.1.2.3"));

        Assert.That(service.Last.Headers["X-Forwarded-For"], Does.StartWith("10.1.2.3,"));
    }

    [Test]
    public async Task The_trace_context_continues_through_the_gateway()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address
        });
        const string traceId = "0af7651916cd43dd8448eb211c80319c";

        await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
            request.Headers.Add("traceparent", $"00-{traceId}-b7ad6b7169203331-01"));

        Assert.That(service.Last.Headers["traceparent"], Does.Contain(traceId));
    }
}
