using System.Net;
using Cat.Api.Gateway.Abstractions;
using Cat.Api.Gateway.Tests.Helpers;
using Cat.Api.Gateway.Verification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class HealthAndPolicyTests
{
    [Test]
    public async Task The_gateway_calls_the_health_check_path_of_a_service()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = service.Address,
            ["CatGateway:Services:catalog:HealthCheckPath"] = "/ping",
            ["CatGateway:Services:catalog:HealthCheckInterval"] = "00:00:01"
        });

        await Eventually(() => service.Requests.Any(r => r.Path == "/ping"));
    }

    [Test]
    public async Task An_instance_that_fails_its_health_check_gets_no_calls()
    {
        await using var healthy = await FakeService.StartAsync();
        await using var sick = await FakeService.StartAsync(configureApp: app =>
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ping") context.Response.StatusCode = 500;
                else await next(context);
            }));
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Addresses:0"] = healthy.Address,
            ["CatGateway:Services:catalog:Addresses:1"] = sick.Address,
            ["CatGateway:Services:catalog:HealthCheckPath"] = "/ping",
            ["CatGateway:Services:catalog:HealthCheckInterval"] = "00:00:01"
        });

        await Eventually(() => healthy.Requests.Any(r => r.Path == "/ping"));
        await Task.Delay(4000);
        var before = sick.Requests.Count(r => r.Path != "/ping");
        for (var i = 0; i < 20; i++) await gateway.SendAsync(HttpMethod.Get, "/catalog/x");

        Assert.That(sick.Requests.Count(r => r.Path != "/ping"), Is.EqualTo(before));
        Assert.That(healthy.Requests.Count(r => r.Path == "/x"), Is.EqualTo(20));
    }

    [Test]
    public async Task The_verification_scheme_works_in_an_authorization_policy()
    {
        var (privatePem, publicPem) = TestKeys.CreatePemPair();
        await using var service = await FakeService.StartAsync(
            configureBuilder: builder =>
            {
                builder.Services.AddAuthorization();
                builder.Services.AddCatGatewayVerification(o =>
                {
                    o.Audience = "catalog";
                    o.PublicKeyPems = [publicPem];
                });
            },
            configureApp: app =>
            {
                app.UseAuthentication();
                app.UseAuthorization();
                app.MapGet("/secure", () => "secret").RequireAuthorization(policy => policy
                    .AddAuthenticationSchemes(CatGatewayVerificationDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser());
                app.MapGet("/open", () => "open");
            });
        using var client = new HttpClient { BaseAddress = new Uri(service.Address) };

        var open = await client.GetAsync("/open");
        var without = await client.GetAsync("/secure");
        using var request = new HttpRequestMessage(HttpMethod.Get, "/secure");
        request.Headers.Add(CatGatewayDefaults.AssertionHeaderName, TestKeys.CreateAssertion(privatePem, "catalog"));
        var with = await client.SendAsync(request);

        Assert.That(open.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(without.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(with.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    private static async Task Eventually(Func<bool> condition)
    {
        var deadline = DateTime.UtcNow.AddSeconds(10);
        while (DateTime.UtcNow < deadline)
        {
            if (condition()) return;
            await Task.Delay(100);
        }

        Assert.Fail("The condition did not become true in time.");
    }
}
