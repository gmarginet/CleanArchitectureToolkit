using System.Net;
using Cat.Api.Gateway.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Yarp.ReverseProxy.Configuration;

namespace Cat.Api.Gateway.Tests;

/// <summary>
/// A route from plain YARP configuration, next to the services of the gateway, gets the same security defaults.
/// </summary>
[TestFixture]
public class PlainYarpRouteTests
{
    private static void AddPlainRoute(IReverseProxyBuilder proxy, string address, string? authorizationPolicy = null) =>
        proxy.LoadFromMemory(
            [
                new RouteConfig
                {
                    RouteId = "plain",
                    ClusterId = "plain",
                    AuthorizationPolicy = authorizationPolicy,
                    Match = new RouteMatch { Path = "/plain/{**rest}" }
                }
            ],
            [
                new ClusterConfig
                {
                    ClusterId = "plain",
                    Destinations = new Dictionary<string, DestinationConfig> { ["d"] = new() { Address = address } }
                }
            ]);

    [Test]
    public async Task A_plain_route_needs_a_token_unless_it_says_otherwise()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new(), configureProxy: p => AddPlainRoute(p, service.Address));

        var without = await gateway.SendAsync(HttpMethod.Get, "/plain/x", token: false);
        var with = await gateway.SendAsync(HttpMethod.Get, "/plain/x");

        Assert.That(without.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(with.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task A_plain_route_can_be_made_anonymous()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(
            new(),
            configureProxy: p => AddPlainRoute(p, service.Address, "anonymous"));

        var response = await gateway.SendAsync(HttpMethod.Get, "/plain/x", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task Identity_headers_are_removed_on_a_plain_route_too()
    {
        await using var service = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new(), configureProxy: p => AddPlainRoute(p, service.Address));

        await gateway.SendAsync(HttpMethod.Get, "/plain/x", configure: request => request.Headers.Add("X-User-Id", "admin"));

        Assert.That(service.Last.Headers.ContainsKey("X-User-Id"), Is.False);
    }

    [Test]
    public async Task Plain_routes_and_services_work_side_by_side()
    {
        await using var plain = await FakeService.StartAsync();
        await using var catalog = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(
            new() { ["CatGateway:Services:catalog:Address"] = catalog.Address },
            configureProxy: p => AddPlainRoute(p, plain.Address));

        await gateway.SendAsync(HttpMethod.Get, "/plain/x");
        await gateway.SendAsync(HttpMethod.Get, "/catalog/x");

        Assert.That(plain.Requests, Has.Count.EqualTo(1));
        Assert.That(catalog.Requests, Has.Count.EqualTo(1));
    }
}
