using System.Net;
using Cat.Api.Gateway.Tests.Helpers;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class AuthenticationTests
{
    private FakeService _catalog = null!;
    private TestGateway _gateway = null!;

    [SetUp]
    public async Task SetUp()
    {
        _catalog = await FakeService.StartAsync();
        _gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = _catalog.Address,
            ["CatGateway:Services:catalog:Anonymous:0"] = "GET /books/**",
            ["CatGateway:Services:catalog:Anonymous:1"] = "GET,HEAD /covers/*/small"
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        await _gateway.DisposeAsync();
        await _catalog.DisposeAsync();
    }

    [Test]
    public async Task A_request_without_a_token_is_rejected_and_never_reaches_the_service()
    {
        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/admin", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(_catalog.Requests, Is.Empty);
    }

    [Test]
    public async Task A_request_with_a_token_from_another_issuer_is_rejected()
    {
        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/admin", token: false, request =>
            request.Headers.Authorization = new("Bearer", "not.a.token"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(_catalog.Requests, Is.Empty);
    }

    [Test]
    public async Task A_valid_token_passes_and_reaches_the_service_unchanged()
    {
        var token = TestGateway.CreateToken("bob");

        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/admin", token: false, request =>
            request.Headers.Authorization = new("Bearer", token));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(_catalog.Last.Headers["Authorization"], Is.EqualTo("Bearer " + token));
    }

    [Test]
    public async Task A_public_endpoint_needs_no_token()
    {
        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/books/42", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task The_public_path_without_extra_segments_is_public_too()
    {
        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/books", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task A_public_endpoint_is_public_for_the_listed_methods_only()
    {
        var response = await _gateway.SendAsync(HttpMethod.Post, "/catalog/books", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(_catalog.Requests, Is.Empty);
    }

    [Test]
    public async Task Everything_else_of_the_service_stays_protected()
    {
        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/bookshelf", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task A_star_stands_for_one_segment()
    {
        var one = await _gateway.SendAsync(HttpMethod.Head, "/catalog/covers/42/small", token: false);
        var two = await _gateway.SendAsync(HttpMethod.Get, "/catalog/covers/42/43/small", token: false);

        Assert.That(one.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(two.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task A_path_that_looks_like_a_public_one_in_another_case_still_follows_the_same_rule()
    {
        // Route matching ignores case, and the service sees the path as sent. A public pattern is public in every case.
        var response = await _gateway.SendAsync(HttpMethod.Get, "/CATALOG/BOOKS/1", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(_catalog.Last.Path, Is.EqualTo("/BOOKS/1"));
    }

    [Test]
    public async Task A_dot_dot_segment_cannot_reach_a_protected_path_through_a_public_one()
    {
        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/books/%2e%2e/admin", token: false);

        // Either the gateway rejects it, or it asks for a token. It never reaches the service.
        Assert.That(response.StatusCode, Is.AnyOf(HttpStatusCode.Unauthorized, HttpStatusCode.BadRequest, HttpStatusCode.NotFound));
        Assert.That(_catalog.Requests.Where(r => r.Path.Contains("admin", StringComparison.OrdinalIgnoreCase)), Is.Empty);
    }

    [Test]
    public async Task A_gateway_without_an_identity_provider_works_when_every_endpoint_is_public()
    {
        await using var open = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Authentication:Authority"] = null,
            ["CatGateway:Authentication:Audience"] = null,
            ["CatGateway:Services:catalog:Address"] = _catalog.Address,
            ["CatGateway:Services:catalog:Anonymous:0"] = "* /**"
        });

        var response = await open.SendAsync(HttpMethod.Delete, "/catalog/anything", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task An_endpoint_of_the_host_that_is_not_marked_public_is_closed()
    {
        await using var gateway = await TestGateway.StartAsync(
            new() { ["CatGateway:Services:catalog:Address"] = _catalog.Address },
            configureServices: _ => { });

        var response = await gateway.SendAsync(HttpMethod.Get, "/catalog/x", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }
}
