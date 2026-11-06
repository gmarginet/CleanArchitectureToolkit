using System.Net;
using Cat.Api.Gateway.Assertion;
using Cat.Api.Gateway.Configuration;
using Cat.Api.Gateway.Tests.Helpers;
using Cat.Api.Gateway.Verification;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Api.Gateway.Tests;

[TestFixture]
public class KeyProviderTests
{
    private sealed class FakeTime : TimeProvider
    {
        public DateTimeOffset Now { get; set; } = new(2026, 11, 6, 12, 0, 0, TimeSpan.Zero);

        public override DateTimeOffset GetUtcNow() => Now;
    }

    private sealed class StubHandler : HttpMessageHandler
    {
        public int Calls { get; private set; }

        public string Body { get; set; } = "{}";

        public bool Fail { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Calls++;
            return Task.FromResult(Fail
                ? new HttpResponseMessage(HttpStatusCode.InternalServerError)
                : new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(Body) });
        }
    }

    private sealed class StubFactory(HttpMessageHandler handler) : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new(handler, disposeHandler: false);
    }

    private sealed class DevelopmentEnvironment : IHostEnvironment
    {
        public string EnvironmentName { get; set; } = Environments.Development;
        public string ApplicationName { get; set; } = "test";
        public string ContentRootPath { get; set; } = ".";
        public Microsoft.Extensions.FileProviders.IFileProvider ContentRootFileProvider { get; set; } =
            new Microsoft.Extensions.FileProviders.NullFileProvider();
    }

    private StubHandler _handler = null!;
    private FakeTime _time = null!;
    private CatGatewaySigningKeys _gatewayKeys = null!;
    private string _keyId = null!;

    [SetUp]
    public void SetUp()
    {
        _gatewayKeys = new CatGatewaySigningKeys(
            new CatGatewayAssertionOptions(),
            new DevelopmentEnvironment(),
            NullLogger<CatGatewaySigningKeys>.Instance);
        _handler = new StubHandler { Body = _gatewayKeys.GetJwks() };
        _time = new FakeTime();
        _keyId = new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(_gatewayKeys.GetAssertion("catalog")).Kid;
    }

    [TearDown]
    public void TearDown()
    {
        _gatewayKeys.Dispose();
        _handler.Dispose();
    }

    private CatGatewayKeyProvider Provider(Action<CatGatewayVerificationOptions>? configure = null)
    {
        var options = new CatGatewayVerificationOptions { Audience = "catalog", JwksAddress = "https://gateway/jwks" };
        configure?.Invoke(options);
        return new CatGatewayKeyProvider(options, new StubFactory(_handler), _time, NullLogger<CatGatewayKeyProvider>.Instance);
    }

    [Test]
    public async Task The_keys_are_downloaded_once_and_then_kept()
    {
        using var provider = Provider();

        var first = await provider.GetKeysAsync(_keyId, CancellationToken.None);
        var second = await provider.GetKeysAsync(_keyId, CancellationToken.None);

        Assert.That(first, Has.Count.EqualTo(1));
        Assert.That(second, Has.Count.EqualTo(1));
        Assert.That(_handler.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task The_keys_are_downloaded_again_after_the_refresh_interval()
    {
        using var provider = Provider();
        await provider.GetKeysAsync(_keyId, CancellationToken.None);

        _time.Now += TimeSpan.FromMinutes(11);
        await provider.GetKeysAsync(_keyId, CancellationToken.None);

        Assert.That(_handler.Calls, Is.EqualTo(2));
    }

    [Test]
    public async Task An_unknown_key_id_makes_the_service_download_again_but_not_over_and_over()
    {
        using var provider = Provider();
        await provider.GetKeysAsync(_keyId, CancellationToken.None);

        await provider.GetKeysAsync("unknown", CancellationToken.None);
        Assert.That(_handler.Calls, Is.EqualTo(1), "Too soon after the last download.");

        _time.Now += TimeSpan.FromSeconds(31);
        await provider.GetKeysAsync("unknown", CancellationToken.None);
        await provider.GetKeysAsync("unknown", CancellationToken.None);
        Assert.That(_handler.Calls, Is.EqualTo(2));
    }

    [Test]
    public async Task A_failed_download_keeps_the_keys_we_have()
    {
        using var provider = Provider();
        await provider.GetKeysAsync(_keyId, CancellationToken.None);

        _handler.Fail = true;
        _time.Now += TimeSpan.FromMinutes(11);
        var keys = await provider.GetKeysAsync(_keyId, CancellationToken.None);

        Assert.That(keys, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task A_failed_download_is_not_tried_again_straight_away()
    {
        using var provider = Provider();
        _handler.Fail = true;

        await provider.GetKeysAsync(_keyId, CancellationToken.None);
        await provider.GetKeysAsync(_keyId, CancellationToken.None);

        Assert.That(_handler.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task Without_any_key_there_is_nothing_to_check_with()
    {
        using var provider = Provider();
        _handler.Fail = true;

        var keys = await provider.GetKeysAsync(_keyId, CancellationToken.None);

        Assert.That(keys, Is.Empty);
    }

    [Test]
    public async Task An_answer_without_a_p256_key_is_not_used()
    {
        using var provider = Provider();
        _handler.Body = "{\"keys\":[{\"kty\":\"oct\",\"k\":\"c2VjcmV0\",\"kid\":\"x\"}]}";

        var keys = await provider.GetKeysAsync("x", CancellationToken.None);

        Assert.That(keys, Is.Empty);
    }

    [Test]
    public async Task A_configured_key_needs_no_download()
    {
        var (_, publicPem) = TestKeys.CreatePemPair();
        using var provider = Provider(o =>
        {
            o.JwksAddress = null;
            o.PublicKeyPems = [publicPem];
        });

        var keys = await provider.GetKeysAsync(null, CancellationToken.None);

        Assert.That(keys, Has.Count.EqualTo(1));
        Assert.That(_handler.Calls, Is.Zero);
    }

    [Test]
    public void A_configured_key_on_another_curve_is_refused()
    {
        using var key = System.Security.Cryptography.ECDsa.Create(System.Security.Cryptography.ECCurve.NamedCurves.nistP384);

        Assert.Throws<InvalidOperationException>(() =>
            Provider(o => o.PublicKeyPems = [key.ExportSubjectPublicKeyInfoPem()]));
    }
}
