using System.Net;
using System.Text;
using Cat.Demo.ServiceDefaults;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class ClientCredentialsTokenProviderTests
{
    private sealed class FakeIdentityProvider : HttpMessageHandler
    {
        public int Calls { get; private set; }
        public string? Body { get; private set; }
        public Uri? Uri { get; private set; }
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public string Json { get; set; } = """{"access_token":"token-1","expires_in":300}""";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Calls++;
            Uri = request.RequestUri;
            Body = await request.Content!.ReadAsStringAsync(cancellationToken);
            return new HttpResponseMessage(Status) { Content = new StringContent(Json, Encoding.UTF8, "application/json") };
        }
    }

    private sealed class FakeFactory(HttpMessageHandler handler) : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new(handler, disposeHandler: false);
    }

    private sealed class MutableTimeProvider(DateTimeOffset now) : TimeProvider
    {
        public DateTimeOffset Now { get; set; } = now;

        public override DateTimeOffset GetUtcNow() => Now;
    }

    private FakeIdentityProvider _identity = null!;
    private MutableTimeProvider _time = null!;
    private ClientCredentialsTokenProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _identity = new FakeIdentityProvider();
        _time = new MutableTimeProvider(new DateTimeOffset(2026, 11, 13, 12, 0, 0, TimeSpan.Zero));
        _provider = new ClientCredentialsTokenProvider(
            new FakeFactory(_identity),
            new ClientCredentialsSettings("http://keycloak/realms/cat-demo/protocol/openid-connect/token", "cat-demo-orders", "secret"),
            _time,
            NullLogger<ClientCredentialsTokenProvider>.Instance);
    }

    [TearDown]
    public void TearDown() => _identity.Dispose();

    [Test]
    public async Task GetToken_ShouldAskForAClientCredentialsToken()
    {
        var token = await _provider.GetTokenAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(token, Is.EqualTo("token-1"));
            Assert.That(_identity.Uri!.AbsoluteUri, Is.EqualTo("http://keycloak/realms/cat-demo/protocol/openid-connect/token"));
            Assert.That(_identity.Body, Does.Contain("grant_type=client_credentials"));
            Assert.That(_identity.Body, Does.Contain("client_id=cat-demo-orders"));
            Assert.That(_identity.Body, Does.Contain("client_secret=secret"));
        }
    }

    [Test]
    public async Task GetToken_ShouldKeepTheTokenUntilShortlyBeforeItExpires()
    {
        await _provider.GetTokenAsync();
        _time.Now = _time.Now.AddSeconds(200);
        await _provider.GetTokenAsync();

        Assert.That(_identity.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task GetToken_AfterTheTokenExpired_ShouldAskAgain()
    {
        await _provider.GetTokenAsync();
        _identity.Json = """{"access_token":"token-2","expires_in":300}""";
        _time.Now = _time.Now.AddSeconds(280);

        var token = await _provider.GetTokenAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(token, Is.EqualTo("token-2"));
            Assert.That(_identity.Calls, Is.EqualTo(2));
        }
    }

    [Test]
    public async Task GetToken_WhenTheIdentityProviderRefuses_ShouldGiveNull()
    {
        _identity.Status = HttpStatusCode.Unauthorized;

        Assert.That(await _provider.GetTokenAsync(), Is.Null);
    }

    [Test]
    public async Task GetToken_WhenTheAnswerIsNotAToken_ShouldGiveNull()
    {
        _identity.Json = """{"error":"nope"}""";

        Assert.That(await _provider.GetTokenAsync(), Is.Null);
    }
}
