using Microsoft.AspNetCore.Builder;
using System.Net;
using Cat.Api.Gateway.Tests.Helpers;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class RoutingTests
{
    [Test]
    public async Task A_service_gets_the_requests_that_start_with_its_name_and_the_prefix_is_removed()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address
        });

        var response = await gateway.SendAsync(HttpMethod.Get, "/catalog/books/42?lang=nl");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(catalog.Last.Path, Is.EqualTo("/books/42"));
        Assert.That(catalog.Last.Query, Is.EqualTo("?lang=nl"));
    }

    [Test]
    public async Task The_path_of_the_address_stays_in_front_of_the_request_path()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address + "/catalog"
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/books");

        Assert.That(catalog.Last.Path, Is.EqualTo("/catalog/books"));
    }

    [Test]
    public async Task The_prefix_stays_when_StripPrefix_is_off()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address,
            ["CatGateway:Services:catalog:StripPrefix"] = "false"
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/books");

        Assert.That(catalog.Last.Path, Is.EqualTo("/catalog/books"));
    }

    [Test]
    public async Task A_service_can_listen_on_another_path()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address,
            ["CatGateway:Services:catalog:Path"] = "/shop/api"
        });

        var moved = await gateway.SendAsync(HttpMethod.Get, "/shop/api/books");
        var old = await gateway.SendAsync(HttpMethod.Get, "/catalog/books");

        Assert.That(moved.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(catalog.Last.Path, Is.EqualTo("/books"));
        Assert.That(old.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task Every_service_gets_its_own_requests()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var orders = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address,
            ["CatGateway:Services:orders:Address"] = orders.Address
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/books");
        await gateway.SendAsync(HttpMethod.Post, "/orders/new");

        Assert.That(catalog.Requests, Has.Count.EqualTo(1));
        Assert.That(orders.Requests, Has.Count.EqualTo(1));
        Assert.That(orders.Last.Method, Is.EqualTo("POST"));
    }

    [Test]
    public async Task A_path_that_belongs_to_no_service_is_not_found()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address
        });

        var response = await gateway.SendAsync(HttpMethod.Get, "/unknown/thing");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(catalog.Requests, Is.Empty);
    }

    [Test]
    public async Task A_service_with_more_than_one_address_gets_calls_on_all_of_them()
    {
        await using var first = await FakeService.StartAsync();
        await using var second = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Addresses:0"] = first.Address,
            ["CatGateway:Services:catalog:Addresses:1"] = second.Address
        });

        for (var i = 0; i < 30; i++) await gateway.SendAsync(HttpMethod.Get, "/catalog/books");

        Assert.That(first.Requests, Is.Not.Empty);
        Assert.That(second.Requests, Is.Not.Empty);
    }

    [Test]
    public async Task A_service_that_answers_too_slowly_gives_a_gateway_timeout()
    {
        await using var slow = await FakeService.StartAsync(configureApp: app =>
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/slow")) await Task.Delay(3000);
                await next(context);
            }));
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = slow.Address,
            ["CatGateway:Services:catalog:Timeout"] = "00:00:00.5"
        });

        var response = await gateway.SendAsync(HttpMethod.Get, "/catalog/slow");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.GatewayTimeout));
    }
}
