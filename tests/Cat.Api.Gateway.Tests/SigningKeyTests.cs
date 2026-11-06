using System.Net;
using System.Security.Cryptography;
using System.Text.Json;
using Cat.Api.Gateway.Abstractions;
using Cat.Api.Gateway.Assertion;
using Cat.Api.Gateway.Configuration;
using Cat.Api.Gateway.Tests.Helpers;
using Cat.Api.Gateway.Verification;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class SigningKeyTests
{
    private sealed class Environment(string name) : IHostEnvironment
    {
        public string EnvironmentName { get; set; } = name;
        public string ApplicationName { get; set; } = "test";
        public string ContentRootPath { get; set; } = ".";
        public IFileProvider ContentRootFileProvider { get; set; } = new NullFileProvider();
    }

    private static CatGatewaySigningKeys Keys(CatGatewayAssertionOptions options, string environment = "Production") =>
        new(options, new Environment(environment), NullLogger<CatGatewaySigningKeys>.Instance);

    [Test]
    public void Production_has_no_key_unless_one_is_configured()
    {
        using var keys = Keys(new CatGatewayAssertionOptions());

        Assert.That(keys.HasKey, Is.False);
        Assert.Throws<InvalidOperationException>(() => keys.GetAssertion("catalog"));
        Assert.Throws<InvalidOperationException>(() => keys.GetJwks());
    }

    [Test]
    public void Development_generates_a_key_when_none_is_configured()
    {
        using var first = Keys(new CatGatewayAssertionOptions(), "Development");
        using var second = Keys(new CatGatewayAssertionOptions(), "Development");

        Assert.That(first.HasKey, Is.True);
        Assert.That(first.GetJwks(), Is.Not.EqualTo(second.GetJwks()), "A generated key is new every time.");
    }

    [Test]
    public void A_configured_key_is_used_in_every_environment_and_stays_the_same()
    {
        var (privatePem, _) = TestKeys.CreatePemPair();
        var options = new CatGatewayAssertionOptions { PrivateKeyPem = privatePem };

        using var production = Keys(options);
        using var development = Keys(options, "Development");

        Assert.That(production.GetJwks(), Is.EqualTo(development.GetJwks()));
    }

    [Test]
    public void A_key_can_come_from_a_file()
    {
        var (privatePem, _) = TestKeys.CreatePemPair();
        var path = Path.Combine(Path.GetTempPath(), $"cat-gateway-{Guid.NewGuid():N}.pem");
        File.WriteAllText(path, privatePem);
        try
        {
            using var keys = Keys(new CatGatewayAssertionOptions { PrivateKeyPemFile = path });

            Assert.That(keys.HasKey, Is.True);
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Test]
    public void A_key_on_another_curve_is_refused()
    {
        using var key = ECDsa.Create(ECCurve.NamedCurves.nistP384);

        var exception = Assert.Throws<InvalidOperationException>(() =>
            Keys(new CatGatewayAssertionOptions { PrivateKeyPem = key.ExportPkcs8PrivateKeyPem() }));

        Assert.That(exception!.Message, Does.Contain("P-256"));
    }

    [Test]
    public void The_public_keys_never_hold_private_key_material()
    {
        using var keys = Keys(new CatGatewayAssertionOptions(), "Development");

        using var jwks = JsonDocument.Parse(keys.GetJwks());
        var key = jwks.RootElement.GetProperty("keys")[0];

        Assert.That(key.TryGetProperty("d", out _), Is.False);
        Assert.That(key.GetProperty("kty").GetString(), Is.EqualTo("EC"));
        Assert.That(key.GetProperty("crv").GetString(), Is.EqualTo("P-256"));
        Assert.That(key.GetProperty("alg").GetString(), Is.EqualTo("ES256"));
    }

    [Test]
    public void The_key_id_of_a_published_key_matches_the_id_in_the_assertion()
    {
        using var keys = Keys(new CatGatewayAssertionOptions(), "Development");
        using var jwks = JsonDocument.Parse(keys.GetJwks());
        var published = jwks.RootElement.GetProperty("keys")[0].GetProperty("kid").GetString();

        var assertion = new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(keys.GetAssertion("catalog"));

        Assert.That(assertion.Kid, Is.EqualTo(published));
    }

    [Test]
    public void Earlier_public_keys_are_published_next_to_the_current_one()
    {
        var (_, previous) = TestKeys.CreatePemPair();
        using var keys = Keys(new CatGatewayAssertionOptions { PreviousPublicKeyPems = [previous] }, "Development");

        using var jwks = JsonDocument.Parse(keys.GetJwks());

        Assert.That(jwks.RootElement.GetProperty("keys").GetArrayLength(), Is.EqualTo(2));
    }

    [Test]
    public void The_key_id_is_the_thumbprint_of_the_public_key()
    {
        // The example key of RFC 7638 has no P-256 version, so compare with a second computation.
        using var key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var parameters = key.ExportParameters(false);

        var id = CatGatewayKeyId.ForP256(parameters.Q.X!, parameters.Q.Y!);

        Assert.That(id, Is.EqualTo(CatGatewayKeyId.ForP256(parameters.Q.X!, parameters.Q.Y!)));
        Assert.That(id, Has.Length.EqualTo(43));
        Assert.That(id, Does.Not.Contain("=").And.Not.Contain("+").And.Not.Contain("/"));
    }

    [Test]
    public async Task The_gateway_publishes_its_public_keys_without_a_token()
    {
        await using var gateway = await TestGateway.StartAsync(new(), development: true);

        var response = await gateway.SendAsync(HttpMethod.Get, CatGatewayDefaults.DefaultJwksPath, token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));
        Assert.That(await response.Content.ReadAsStringAsync(), Does.Contain("\"keys\"").And.Not.Contain("\"d\""));
    }

    [Test]
    public async Task The_gateway_publishes_nothing_when_it_has_no_key()
    {
        await using var gateway = await TestGateway.StartAsync(new());

        var anonymous = await gateway.SendAsync(HttpMethod.Get, CatGatewayDefaults.DefaultJwksPath, token: false);
        var signedIn = await gateway.SendAsync(HttpMethod.Get, CatGatewayDefaults.DefaultJwksPath);

        // A caller without a token learns nothing about the paths of the gateway.
        Assert.That(anonymous.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(signedIn.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task A_gateway_only_service_in_production_without_a_key_does_not_start()
    {
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await TestGateway.StartAsync(new()
            {
                ["CatGateway:Services:catalog:Address"] = "http://catalog",
                ["CatGateway:Services:catalog:GatewayOnly"] = "true"
            }));

        Assert.That(exception!.Message, Does.Contain("signing key"));
    }

    [Test]
    public async Task A_service_finds_the_keys_at_the_address_of_the_gateway()
    {
        var gatewayPort = TestKeys.FreePort();
        var jwks = $"http://127.0.0.1:{gatewayPort}{CatGatewayDefaults.DefaultJwksPath}";
        await using var catalog = await FakeService.StartAsync(
            configureBuilder: builder => builder.Services.AddCatGatewayVerification(o =>
            {
                o.Audience = "catalog";
                o.JwksAddress = jwks;
            }),
            configureApp: app => app.UseCatGatewayOnly());
        await using var gateway = await TestGateway.StartAsync(
            new()
            {
                ["CatGateway:Services:catalog:Address"] = catalog.Address,
                ["CatGateway:Services:catalog:GatewayOnly"] = "true"
            },
            development: true,
            port: gatewayPort);

        var response = await gateway.SendAsync(HttpMethod.Get, "/catalog/x");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task An_assertion_of_the_old_key_stays_valid_while_the_key_is_replaced()
    {
        var (oldPrivate, oldPublic) = TestKeys.CreatePemPair();
        var (newPrivate, _) = TestKeys.CreatePemPair();
        var gatewayPort = TestKeys.FreePort();
        await using var catalog = await FakeService.StartAsync(
            configureBuilder: builder => builder.Services.AddCatGatewayVerification(o =>
            {
                o.Audience = "catalog";
                o.JwksAddress = $"http://127.0.0.1:{gatewayPort}{CatGatewayDefaults.DefaultJwksPath}";
            }),
            configureApp: app => app.UseCatGatewayOnly());
        await using var gateway = await TestGateway.StartAsync(
            new()
            {
                ["CatGateway:Assertion:PrivateKeyPem"] = newPrivate,
                ["CatGateway:Assertion:PreviousPublicKeyPems:0"] = oldPublic,
                ["CatGateway:Services:catalog:Address"] = catalog.Address,
                ["CatGateway:Services:catalog:GatewayOnly"] = "true"
            },
            port: gatewayPort);

        using var client = new HttpClient { BaseAddress = new Uri(catalog.Address) };
        using var withOld = new HttpRequestMessage(HttpMethod.Get, "/x");
        withOld.Headers.Add(CatGatewayDefaults.AssertionHeaderName, TestKeys.CreateAssertion(oldPrivate, "catalog"));

        Assert.That((await client.SendAsync(withOld)).StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That((await gateway.SendAsync(HttpMethod.Get, "/catalog/x")).StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task A_service_without_an_audience_does_not_start()
    {
        var (_, publicPem) = TestKeys.CreatePemPair();

        await Assert.ThrowsAsync<OptionsValidationException>(async () =>
            await FakeService.StartAsync(configureBuilder: builder =>
                builder.Services.AddCatGatewayVerification(o => o.PublicKeyPems = [publicPem])));
    }

    [Test]
    public async Task A_service_without_any_key_source_does_not_start() =>
        await Assert.ThrowsAsync<OptionsValidationException>(async () =>
            await FakeService.StartAsync(configureBuilder: builder =>
                builder.Services.AddCatGatewayVerification(o => o.Audience = "catalog")));
}
