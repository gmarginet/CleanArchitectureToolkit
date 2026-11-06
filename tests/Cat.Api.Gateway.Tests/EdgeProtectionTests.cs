using System.Net;
using Cat.Api.Gateway.Abstractions;
using Cat.Api.Gateway.Middleware;
using Cat.Api.Gateway.Tests.Helpers;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class EdgeProtectionTests
{
    [Test]
    public async Task A_request_gets_a_correlation_id_that_the_service_and_the_caller_both_see()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address
        });

        var response = await gateway.SendAsync(HttpMethod.Get, "/catalog/x");

        var id = response.Headers.GetValues(CatGatewayDefaults.CorrelationIdHeaderName).Single();
        Assert.That(id, Is.Not.Empty);
        Assert.That(service.Last.Headers[CatGatewayDefaults.CorrelationIdHeaderName], Is.EqualTo(id));
    }

    [Test]
    public async Task A_correlation_id_of_the_caller_is_kept()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address
        });

        var response = await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
            request.Headers.Add(CatGatewayDefaults.CorrelationIdHeaderName, "order-42"));

        Assert.That(response.Headers.GetValues(CatGatewayDefaults.CorrelationIdHeaderName).Single(), Is.EqualTo("order-42"));
        Assert.That(service.Last.Headers[CatGatewayDefaults.CorrelationIdHeaderName], Is.EqualTo("order-42"));
    }

    [TestCase("")]
    [TestCase("has space")]
    [TestCase("semi;colon")]
    [TestCase("quote\"")]
    [TestCase("new\nline")]
    public void A_correlation_id_with_odd_characters_is_not_accepted(string value) =>
        Assert.That(CorrelationIdMiddleware.IsValid(value), Is.False);

    [Test]
    public void A_correlation_id_that_is_too_long_is_not_accepted() =>
        Assert.That(CorrelationIdMiddleware.IsValid(new string('a', 129)), Is.False);

    [Test]
    public async Task A_body_that_is_too_large_is_refused_before_it_reaches_the_service()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address,
            ["CatGateway:Limits:MaxRequestBodySize"] = "100"
        });

        var response = await gateway.SendAsync(HttpMethod.Post, "/catalog/x", configure: request =>
            request.Content = new StringContent(new string('x', 500)));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.RequestEntityTooLarge));
        Assert.That(service.Requests, Is.Empty);
    }

    [Test]
    public async Task A_body_within_the_limit_passes()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address,
            ["CatGateway:Limits:MaxRequestBodySize"] = "1000"
        });

        var response = await gateway.SendAsync(HttpMethod.Post, "/catalog/x", configure: request =>
            request.Content = new StringContent(new string('x', 500)));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task A_caller_that_sends_too_many_requests_is_limited()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address,
            ["CatGateway:RateLimit:Enabled"] = "true",
            ["CatGateway:RateLimit:PermitLimit"] = "3",
            ["CatGateway:RateLimit:Window"] = "00:10:00"
        });

        var codes = new List<HttpStatusCode>();
        for (var i = 0; i < 5; i++) codes.Add((await gateway.SendAsync(HttpMethod.Get, "/catalog/x")).StatusCode);

        Assert.That(codes.Take(3), Has.All.EqualTo(HttpStatusCode.OK));
        Assert.That(codes.Skip(3), Has.All.EqualTo(HttpStatusCode.TooManyRequests));
    }

    [Test]
    public void Rate_limiting_is_on_by_default()
    {
        var options = new Cat.Api.Gateway.Configuration.CatGatewayRateLimitOptions();

        Assert.That(options.Enabled, Is.True);
        Assert.That(options.PermitLimit, Is.EqualTo(300));
    }

    [Test]
    public async Task Cross_origin_calls_are_off_until_an_origin_is_listed()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address
        });

        var response = await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
            request.Headers.Add("Origin", "https://shop.example.com"));

        Assert.That(response.Headers.Contains("Access-Control-Allow-Origin"), Is.False);
    }

    [Test]
    public async Task A_listed_origin_may_call_and_another_origin_may_not()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address,
            ["CatGateway:Cors:AllowedOrigins:0"] = "https://shop.example.com"
        });

        var allowed = await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
            request.Headers.Add("Origin", "https://shop.example.com"));
        var other = await gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
            request.Headers.Add("Origin", "https://evil.example.com"));

        Assert.That(allowed.Headers.GetValues("Access-Control-Allow-Origin").Single(), Is.EqualTo("https://shop.example.com"));
        Assert.That(other.Headers.Contains("Access-Control-Allow-Origin"), Is.False);
    }

    [Test]
    public async Task A_browser_preflight_is_answered_without_a_token()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address,
            ["CatGateway:Cors:AllowedOrigins:0"] = "https://shop.example.com"
        });

        var response = await gateway.SendAsync(HttpMethod.Options, "/catalog/x", token: false, request =>
        {
            request.Headers.Add("Origin", "https://shop.example.com");
            request.Headers.Add("Access-Control-Request-Method", "POST");
            request.Headers.Add("Access-Control-Request-Headers", "authorization");
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(service.Requests, Is.Empty);
    }
}
