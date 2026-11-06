using System.Net;
using System.Text;
using System.Text.Json;
using Cat.Api.Gateway.Abstractions;
using Cat.Api.Gateway.Tests.Helpers;
using Cat.Api.Gateway.Verification;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class GatewayOnlyTests
{
    private string _privatePem = null!;
    private string _publicPem = null!;
    private FakeService _catalog = null!;
    private FakeService _orders = null!;
    private TestGateway _gateway = null!;

    [SetUp]
    public async Task SetUp()
    {
        (_privatePem, _publicPem) = TestKeys.CreatePemPair();
        _catalog = await StartServiceAsync("catalog", _publicPem);
        _orders = await StartServiceAsync("orders", _publicPem);
        _gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Assertion:PrivateKeyPem"] = _privatePem,
            ["CatGateway:Services:catalog:Address"] = _catalog.Address,
            ["CatGateway:Services:catalog:GatewayOnly"] = "true",
            ["CatGateway:Services:catalog:Anonymous:0"] = "GET /books/**",
            ["CatGateway:Services:orders:Address"] = _orders.Address,
            ["CatGateway:Services:orders:GatewayOnly"] = "true"
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        await _gateway.DisposeAsync();
        await _catalog.DisposeAsync();
        await _orders.DisposeAsync();
    }

    private static Task<FakeService> StartServiceAsync(string name, string publicPem, int port = 0) =>
        FakeService.StartAsync(
            port,
            builder => builder.Services.AddCatGatewayVerification(o =>
            {
                o.Audience = name;
                o.PublicKeyPems = [publicPem];
            }),
            app => app.UseCatGatewayOnly());

    private static async Task<HttpResponseMessage> CallDirectAsync(
        FakeService service,
        string path = "/x",
        params (string Name, string Value)[] headers)
    {
        using var client = new HttpClient { BaseAddress = new Uri(service.Address) };
        using var request = new HttpRequestMessage(HttpMethod.Get, path);
        foreach (var (name, value) in headers) request.Headers.TryAddWithoutValidation(name, value);
        return await client.SendAsync(request);
    }

    [Test]
    public async Task A_call_through_the_gateway_reaches_a_gateway_only_service()
    {
        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/x");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(_catalog.Last.Headers.ContainsKey(CatGatewayDefaults.AssertionHeaderName), Is.True);
    }

    [Test]
    public async Task An_anonymous_endpoint_still_comes_with_an_assertion_so_the_service_knows_it_was_the_gateway()
    {
        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/books/1", token: false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(_catalog.Last.Headers.ContainsKey(CatGatewayDefaults.AssertionHeaderName), Is.True);
    }

    [Test]
    public async Task A_direct_call_without_an_assertion_is_rejected()
    {
        var response = await CallDirectAsync(_catalog);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(_catalog.Requests, Is.Empty);
    }

    [Test]
    public async Task An_endpoint_that_allows_direct_access_stays_reachable()
    {
        var response = await CallDirectAsync(_catalog, "/health");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task A_caller_cannot_replace_the_assertion_through_the_gateway()
    {
        var (otherPrivate, _) = TestKeys.CreatePemPair();
        var forged = TestKeys.CreateAssertion(otherPrivate, "catalog");

        var response = await _gateway.SendAsync(HttpMethod.Get, "/catalog/x", configure: request =>
            request.Headers.Add(CatGatewayDefaults.AssertionHeaderName, forged));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(_catalog.Last.Headers[CatGatewayDefaults.AssertionHeaderName], Is.Not.EqualTo(forged));
    }

    [Test]
    public async Task The_assertion_is_short_lived_and_for_one_service()
    {
        await _gateway.SendAsync(HttpMethod.Get, "/catalog/x");

        var token = new JsonWebToken(_catalog.Last.Headers[CatGatewayDefaults.AssertionHeaderName]);

        Assert.That(token.Alg, Is.EqualTo("ES256"));
        Assert.That(token.Kid, Is.Not.Empty);
        Assert.That(token.Issuer, Is.EqualTo("cat-gateway"));
        Assert.That(token.Audiences, Is.EqualTo(new[] { "catalog" }));
        Assert.That(token.ValidTo - token.ValidFrom, Is.EqualTo(TimeSpan.FromSeconds(30)));
    }

    [Test]
    public async Task An_assertion_for_one_service_is_rejected_by_another_service()
    {
        await _gateway.SendAsync(HttpMethod.Get, "/catalog/x");
        var catalogAssertion = _catalog.Last.Headers[CatGatewayDefaults.AssertionHeaderName];

        var response = await CallDirectAsync(_orders, "/x", (CatGatewayDefaults.AssertionHeaderName, catalogAssertion));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(_orders.Requests, Is.Empty);
    }

    [Test]
    public async Task A_valid_assertion_is_accepted_when_it_arrives_directly()
    {
        var assertion = TestKeys.CreateAssertion(_privatePem, "catalog");

        var response = await CallDirectAsync(_catalog, "/x", (CatGatewayDefaults.AssertionHeaderName, assertion));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task The_gateway_reuses_an_assertion_for_a_while()
    {
        await _gateway.SendAsync(HttpMethod.Get, "/catalog/x");
        await _gateway.SendAsync(HttpMethod.Get, "/catalog/y");

        var assertions = _catalog.Requests.Select(r => r.Headers[CatGatewayDefaults.AssertionHeaderName]).Distinct();
        Assert.That(assertions, Has.Exactly(1).Items);
    }

    [Test]
    public async Task A_service_can_turn_the_default_off()
    {
        await using var plain = await FakeService.StartAsync();
        await using var gateway = await TestGateway.StartAsync(new()
        {
            ["CatGateway:Assertion:PrivateKeyPem"] = _privatePem,
            ["CatGateway:Defaults:GatewayOnly"] = "true",
            ["CatGateway:Services:catalog:Address"] = _catalog.Address,
            ["CatGateway:Services:plain:Address"] = plain.Address,
            ["CatGateway:Services:plain:GatewayOnly"] = "false"
        });

        await gateway.SendAsync(HttpMethod.Get, "/catalog/x");
        await gateway.SendAsync(HttpMethod.Get, "/plain/x");

        Assert.That(_catalog.Last.Headers.ContainsKey(CatGatewayDefaults.AssertionHeaderName), Is.True);
        Assert.That(plain.Last.Headers.ContainsKey(CatGatewayDefaults.AssertionHeaderName), Is.False);
    }

    // The service must say no to every assertion that is wrong in some way.

    [Test]
    public async Task An_assertion_signed_with_another_key_is_rejected()
    {
        var (otherPrivate, _) = TestKeys.CreatePemPair();

        var response = await CallDirectAsync(_catalog, "/x",
            (CatGatewayDefaults.AssertionHeaderName, TestKeys.CreateAssertion(otherPrivate, "catalog")));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task An_assertion_with_another_issuer_is_rejected()
    {
        var response = await CallDirectAsync(_catalog, "/x",
            (CatGatewayDefaults.AssertionHeaderName, TestKeys.CreateAssertion(_privatePem, "catalog", issuer: "someone-else")));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task An_expired_assertion_is_rejected()
    {
        var assertion = TestKeys.CreateAssertion(_privatePem, "catalog", issuedAgo: TimeSpan.FromMinutes(5));

        var response = await CallDirectAsync(_catalog, "/x", (CatGatewayDefaults.AssertionHeaderName, assertion));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task An_assertion_that_expired_before_it_was_issued_is_rejected()
    {
        var assertion = TestKeys.CreateAssertion(_privatePem, "catalog", lifetime: TimeSpan.FromSeconds(-60));

        var response = await CallDirectAsync(_catalog, "/x", (CatGatewayDefaults.AssertionHeaderName, assertion));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task An_assertion_without_an_expiry_is_rejected()
    {
        using var key = System.Security.Cryptography.ECDsa.Create();
        key.ImportFromPem(_privatePem);
        // The handler adds a default expiry to a descriptor, so write the payload by hand.
        var assertion = new JsonWebTokenHandler().CreateToken(
            "{\"iss\":\"cat-gateway\",\"aud\":\"catalog\"}",
            new SigningCredentials(new ECDsaSecurityKey(key), SecurityAlgorithms.EcdsaSha256));

        var response = await CallDirectAsync(_catalog, "/x", (CatGatewayDefaults.AssertionHeaderName, assertion));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task A_token_signed_with_a_shared_secret_made_from_the_public_key_is_rejected()
    {
        // The classic algorithm confusion attack: sign with HMAC, using the public key text as the secret.
        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_publicPem));
        var forged = new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor
        {
            Issuer = "cat-gateway",
            Audience = "catalog",
            Expires = DateTime.UtcNow.AddSeconds(30),
            SigningCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256)
        });

        var response = await CallDirectAsync(_catalog, "/x", (CatGatewayDefaults.AssertionHeaderName, forged));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task An_unsigned_token_is_rejected()
    {
        static string Encode(string json) => Convert.ToBase64String(Encoding.UTF8.GetBytes(json)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        var exp = DateTimeOffset.UtcNow.AddMinutes(1).ToUnixTimeSeconds();
        var unsigned = $"{Encode("{\"alg\":\"none\",\"typ\":\"JWT\"}")}.{Encode($"{{\"iss\":\"cat-gateway\",\"aud\":\"catalog\",\"exp\":{exp}}}")}.";

        var response = await CallDirectAsync(_catalog, "/x", (CatGatewayDefaults.AssertionHeaderName, unsigned));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [TestCase("garbage")]
    [TestCase("a.b.c")]
    [TestCase("")]
    public async Task Something_that_is_not_a_token_is_rejected(string value)
    {
        var response = await CallDirectAsync(_catalog, "/x", (CatGatewayDefaults.AssertionHeaderName, value));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task Two_assertions_in_one_request_are_rejected()
    {
        var assertion = TestKeys.CreateAssertion(_privatePem, "catalog");

        var response = await CallDirectAsync(_catalog, "/x",
            (CatGatewayDefaults.AssertionHeaderName, assertion),
            (CatGatewayDefaults.AssertionHeaderName, assertion));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task The_user_token_does_not_stand_in_for_the_assertion()
    {
        var response = await CallDirectAsync(_catalog, "/x", ("Authorization", "Bearer " + TestGateway.CreateToken()));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }
}
