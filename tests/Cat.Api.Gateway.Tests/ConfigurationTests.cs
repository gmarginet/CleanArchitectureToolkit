using System.Net;
using Cat.Api.Gateway.Configuration;
using Cat.Api.Gateway.Tests.Helpers;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class ConfigurationTests
{
    private static CatGatewayOptions Valid() => new()
    {
        Authentication = { Authority = "https://idp.test", Audience = "gateway" },
        Services = { ["catalog"] = new CatGatewayServiceOptions { Address = "http://catalog" } }
    };

    private static IReadOnlyList<string> Errors(Action<CatGatewayOptions> change, bool signingKey = false)
    {
        var options = Valid();
        change(options);
        return CatGatewayOptionsValidator.Validate(options, signingKey);
    }

    [Test]
    public void A_minimal_configuration_is_valid() =>
        Assert.That(CatGatewayOptionsValidator.Validate(Valid(), signingKeyAvailable: false), Is.Empty);

    [Test]
    public void A_service_needs_an_address() =>
        Assert.That(Errors(o => o.Services["catalog"].Address = null), Has.Some.Contain("Address is required"));

    [Test]
    public void An_address_must_be_absolute_http() =>
        Assert.That(Errors(o => o.Services["catalog"].Address = "ftp://catalog"), Has.Some.Contain("not an absolute http"));

    [Test]
    public void Address_and_Addresses_cannot_be_combined() =>
        Assert.That(
            Errors(o => o.Services["catalog"].Addresses = ["http://a", "http://b"]),
            Has.Some.Contain("not both"));

    [TestCase("catalog/api")]
    [TestCase("/cat{alog}")]
    [TestCase("/a/../b")]
    [TestCase("/a//b")]
    [TestCase("no-slash")]
    public void A_path_with_odd_parts_is_not_valid(string path) =>
        Assert.That(Errors(o => o.Services["catalog"].Path = path), Has.Some.Contain("path"));

    [Test]
    public void A_service_name_cannot_hold_a_slash() =>
        Assert.That(Errors(o => o.Services["ca/talog"] = new CatGatewayServiceOptions { Address = "http://x" }),
            Has.Some.Contain("name can only hold"));

    [Test]
    public void Two_services_cannot_share_a_path() =>
        Assert.That(
            Errors(o => o.Services["orders"] = new CatGatewayServiceOptions { Address = "http://x", Path = "/Catalog" }),
            Has.Some.Contain("already used"));

    [TestCase("GET")]
    [TestCase("FETCH /x")]
    [TestCase("GET books")]
    [TestCase("GET /a/**/b")]
    [TestCase("GET /a/{id}")]
    [TestCase("GET /a/..")]
    public void An_anonymous_pattern_must_be_well_formed(string pattern) =>
        Assert.That(Errors(o => o.Services["catalog"].Anonymous = [pattern]), Is.Not.Empty);

    [Test]
    public void Authority_is_required_when_an_endpoint_needs_a_token() =>
        Assert.That(Errors(o => o.Authentication.Authority = null), Has.Some.Contain("Authority is required"));

    [Test]
    public void Audience_is_required_when_an_endpoint_needs_a_token() =>
        Assert.That(Errors(o => o.Authentication.Audience = null), Has.Some.Contain("Audience is required"));

    [Test]
    public void No_authentication_is_needed_when_every_endpoint_is_public() =>
        Assert.That(
            Errors(o =>
            {
                o.Authentication.Authority = null;
                o.Authentication.Audience = null;
                o.Services["catalog"].Anonymous = ["* /**"];
            }),
            Is.Empty);

    [Test]
    public void A_public_get_alone_does_not_remove_the_need_for_authentication() =>
        Assert.That(
            Errors(o =>
            {
                o.Authentication.Authority = null;
                o.Services["catalog"].Anonymous = ["GET /**"];
            }),
            Has.Some.Contain("Authority is required"));

    [Test]
    public void GatewayOnly_needs_a_signing_key() =>
        Assert.That(Errors(o => o.Services["catalog"].GatewayOnly = true), Has.Some.Contain("signing key"));

    [Test]
    public void GatewayOnly_as_a_default_needs_a_signing_key() =>
        Assert.That(Errors(o => o.Defaults.GatewayOnly = true), Has.Some.Contain("signing key"));

    [Test]
    public void GatewayOnly_is_fine_with_a_signing_key() =>
        Assert.That(Errors(o => o.Services["catalog"].GatewayOnly = true, signingKey: true), Is.Empty);

    [Test]
    public void A_service_can_turn_off_the_gateway_only_default() =>
        Assert.That(
            Errors(o =>
            {
                o.Defaults.GatewayOnly = true;
                o.Services["catalog"].GatewayOnly = false;
            }),
            Is.Empty);

    [TestCase("00:00:01")]
    [TestCase("00:10:00")]
    public void The_assertion_lifetime_must_be_short_but_workable(string lifetime) =>
        Assert.That(Errors(o => o.Assertion.Lifetime = TimeSpan.Parse(lifetime)), Has.Some.Contain("Lifetime"));

    [Test]
    public void A_star_origin_cannot_have_credentials() =>
        Assert.That(
            Errors(o =>
            {
                o.Cors.AllowedOrigins = ["*"];
                o.Cors.AllowCredentials = true;
            }),
            Has.Some.Contain("AllowCredentials"));

    [Test]
    public void An_origin_has_no_path() =>
        Assert.That(Errors(o => o.Cors.AllowedOrigins = ["https://shop.example.com/app"]), Has.Some.Contain("not an origin"));

    [Test]
    public void The_path_defaults_to_the_service_name() =>
        Assert.That(CatGatewayOptionsValidator.EffectivePath("catalog", new CatGatewayServiceOptions()), Is.EqualTo("/catalog"));

    [Test]
    public void A_trailing_slash_of_the_path_is_ignored() =>
        Assert.That(
            CatGatewayOptionsValidator.EffectivePath("catalog", new CatGatewayServiceOptions { Path = "/shop/" }),
            Is.EqualTo("/shop"));

    [TestCase("GET /books/**", "/catalog/books/{**catchAll}")]
    [TestCase("/books", "/catalog/books")]
    [TestCase("* /covers/*/small", "/catalog/covers/{segment0}/small")]
    [TestCase("GET /**", "/catalog/{**catchAll}")]
    [TestCase("GET /", "/catalog")]
    public void An_anonymous_pattern_becomes_a_route_template(string text, string expected)
    {
        Assert.That(AnonymousPattern.TryParse(text, out var pattern, out var error), Is.True, error);
        Assert.That(pattern.ToRouteTemplate("/catalog"), Is.EqualTo(expected));
    }

    [Test]
    public void The_methods_of_a_pattern_are_upper_cased() =>
        Assert.That(
            AnonymousPattern.TryParse("get,head /x", out var pattern, out _) ? pattern.Methods : null,
            Is.EqualTo(new[] { "GET", "HEAD" }));

    [Test]
    public async Task A_gateway_with_an_invalid_configuration_does_not_start()
    {
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await TestGateway.StartAsync(new() { ["CatGateway:Services:catalog:Address"] = "not an address" }));

        Assert.That(exception!.Message, Does.Contain("not valid").And.Contain("catalog"));
    }

    [Test]
    public async Task A_changed_address_goes_live_without_a_restart()
    {
        await using var first = await FakeService.StartAsync();
        await using var second = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = first.Address
        });
        await gateway.SendAsync(HttpMethod.Get, "/catalog/x");

        gateway.Change(d => d["CatGateway:Services:catalog:Address"] = second.Address);
        await Eventually(async () => (await gateway.SendAsync(HttpMethod.Get, "/catalog/x")).StatusCode == HttpStatusCode.OK && second.Requests.Count > 0);

        Assert.That(first.Requests, Has.Count.EqualTo(1));
        Assert.That(second.Requests, Is.Not.Empty);
    }

    [Test]
    public async Task A_new_service_goes_live_without_a_restart()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var orders = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address
        });
        Assert.That((await gateway.SendAsync(HttpMethod.Get, "/orders/x")).StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        gateway.Change(d => d["CatGateway:Services:orders:Address"] = orders.Address);

        await Eventually(async () => (await gateway.SendAsync(HttpMethod.Get, "/orders/x")).StatusCode == HttpStatusCode.OK);
    }

    [Test]
    public async Task A_change_that_is_not_valid_is_ignored_and_the_last_good_configuration_stays()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address
        });

        gateway.Change(d =>
        {
            d["CatGateway:Services:catalog:Address"] = "not an address";
            d["CatGateway:Services:catalog:Anonymous:0"] = "this is wrong";
        });
        await Task.Delay(500);

        var response = await gateway.SendAsync(HttpMethod.Get, "/catalog/x");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var withoutToken = await gateway.SendAsync(HttpMethod.Get, "/catalog/x", token: false);
        Assert.That(withoutToken.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task A_removed_public_pattern_closes_the_endpoint_again()
    {
        await using var catalog = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Services:catalog:Address"] = catalog.Address,
            ["CatGateway:Services:catalog:Anonymous:0"] = "GET /books/**"
        });
        Assert.That((await gateway.SendAsync(HttpMethod.Get, "/catalog/books/1", token: false)).StatusCode, Is.EqualTo(HttpStatusCode.OK));

        gateway.Change(d => d.Remove("CatGateway:Services:catalog:Anonymous:0"));

        await Eventually(async () =>
            (await gateway.SendAsync(HttpMethod.Get, "/catalog/books/1", token: false)).StatusCode == HttpStatusCode.Unauthorized);
    }

    private static async Task Eventually(Func<Task<bool>> condition)
    {
        var deadline = DateTime.UtcNow.AddSeconds(10);
        while (DateTime.UtcNow < deadline)
        {
            if (await condition()) return;
            await Task.Delay(100);
        }

        Assert.Fail("The gateway did not pick up the change in time.");
    }
}
