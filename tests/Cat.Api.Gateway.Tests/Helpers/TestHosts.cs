using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using Cat.Api.Gateway;
using Cat.Api.Gateway.Verification;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Cat.Api.Gateway.Tests.Helpers;

/// <summary>
/// What a service saw of one request that reached it.
/// </summary>
public sealed record SeenRequest(string Method, string Path, string Query, IReadOnlyDictionary<string, string> Headers);

/// <summary>
/// A small service that records the requests it receives.
/// </summary>
public sealed class FakeService : IAsyncDisposable
{
    private readonly WebApplication _app;

    private FakeService(WebApplication app, string address, ConcurrentQueue<SeenRequest> requests)
    {
        _app = app;
        Address = address;
        Requests = requests;
    }

    public string Address { get; }

    public ConcurrentQueue<SeenRequest> Requests { get; }

    public SeenRequest Last => Requests.Last();

    /// <summary>
    /// Starts a service. Use <paramref name="configure"/> to add the gateway verification.
    /// </summary>
    public static async Task<FakeService> StartAsync(
        int port = 0,
        Action<WebApplicationBuilder>? configureBuilder = null,
        Action<WebApplication>? configureApp = null)
    {
        var builder = WebApplication.CreateBuilder();
        builder.Logging.ClearProviders();
        builder.WebHost.UseUrls($"http://127.0.0.1:{port}");
        configureBuilder?.Invoke(builder);

        var app = builder.Build();
        configureApp?.Invoke(app);

        var requests = new ConcurrentQueue<SeenRequest>();
        app.MapGet("/health", () => "ok").AllowDirectAccess();
        app.Map("/{**path}", async (HttpContext context) =>
        {
            requests.Enqueue(new SeenRequest(
                context.Request.Method,
                context.Request.Path.Value ?? string.Empty,
                context.Request.QueryString.Value ?? string.Empty,
                context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString(), StringComparer.OrdinalIgnoreCase)));
            await context.Response.WriteAsync("from the service");
        });

        await app.StartAsync();
        return new FakeService(app, app.Urls.First(), requests);
    }

    public async ValueTask DisposeAsync()
    {
        await _app.StopAsync();
        await _app.DisposeAsync();
    }
}

/// <summary>
/// A running gateway, with a client that talks to it.
/// </summary>
public sealed class TestGateway : IAsyncDisposable
{
    public const string Issuer = "https://idp.test";
    public const string Audience = "gateway-test";

    private static readonly SymmetricSecurityKey TokenKey = new(RandomNumberGenerator.GetBytes(32)) { KeyId = "test" };

    private readonly WebApplication _app;

    private TestGateway(WebApplication app)
    {
        _app = app;
        Address = app.Urls.First();
        Client = new HttpClient { BaseAddress = new Uri(Address) };
    }

    public string Address { get; }

    public HttpClient Client { get; }

    private ReloadableConfiguration _configuration = null!;

    /// <summary>
    /// Changes the configuration and raises a reload, as a file provider does.
    /// </summary>
    public void Change(Action<IDictionary<string, string?>> change) => _configuration.Change(change);

    /// <summary>
    /// Starts a gateway that trusts the tokens of <see cref="CreateToken"/>.
    /// </summary>
    public static async Task<TestGateway> StartAsync(
        Dictionary<string, string?> settings,
        bool development = false,
        Action<IServiceCollection>? configureServices = null,
        int port = 0,
        Action<IReverseProxyBuilder>? configureProxy = null)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            EnvironmentName = development ? Environments.Development : Environments.Production
        });
        builder.Logging.ClearProviders();
        builder.WebHost.UseUrls($"http://127.0.0.1:{port}");

        var all = new Dictionary<string, string?>
        {
            ["CatGateway:Authentication:Authority"] = Issuer,
            ["CatGateway:Authentication:Audience"] = Audience,
            ["CatGateway:RateLimit:Enabled"] = "false"
        };
        foreach (var (key, value) in settings) all[key] = value;
        var configuration = new ReloadableConfiguration(all);
        ((IConfigurationBuilder)builder.Configuration).Add(configuration);

        var proxy = builder.Services.AddCatApiGateway(builder.Configuration);
        configureProxy?.Invoke(proxy);
        builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.Configuration = new OpenIdConnectConfiguration { Issuer = Issuer };
            options.Configuration.SigningKeys.Add(TokenKey);
        });
        configureServices?.Invoke(builder.Services);

        var app = builder.Build();
        app.UseCatApiGateway();
        app.MapCatApiGateway();
        await app.StartAsync();
        return new TestGateway(app) { _configuration = configuration };
    }

    /// <summary>
    /// Creates a token that the gateway accepts.
    /// </summary>
    public static string CreateToken(string subject = "alice") =>
        new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor
        {
            Issuer = Issuer,
            Audience = Audience,
            Subject = new System.Security.Claims.ClaimsIdentity([new System.Security.Claims.Claim("sub", subject)]),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials(TokenKey, SecurityAlgorithms.HmacSha256)
        });

    /// <summary>
    /// Sends a request, with a valid token unless <paramref name="token"/> is <c>false</c>.
    /// </summary>
    public async Task<HttpResponseMessage> SendAsync(
        HttpMethod method,
        string path,
        bool token = true,
        Action<HttpRequestMessage>? configure = null)
    {
        using var request = new HttpRequestMessage(method, path);
        if (token) request.Headers.Authorization = new("Bearer", CreateToken());
        configure?.Invoke(request);
        return await Client.SendAsync(request);
    }

    public async ValueTask DisposeAsync()
    {
        Client.Dispose();
        await _app.StopAsync();
        await _app.DisposeAsync();
    }
}

/// <summary>
/// A configuration source that tests can change while the host runs.
/// </summary>
public sealed class ReloadableConfiguration : ConfigurationProvider, IConfigurationSource
{
    public ReloadableConfiguration(IDictionary<string, string?> initial) =>
        Data = new Dictionary<string, string?>(initial, StringComparer.OrdinalIgnoreCase);

    public IConfigurationProvider Build(IConfigurationBuilder builder) => this;

    public void Change(Action<IDictionary<string, string?>> change)
    {
        change(Data);
        OnReload();
    }
}

/// <summary>
/// Helpers for the keys and assertions of the tests.
/// </summary>
public static class TestKeys
{
    public static (string PrivatePem, string PublicPem) CreatePemPair()
    {
        using var key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        return (key.ExportPkcs8PrivateKeyPem(), key.ExportSubjectPublicKeyInfoPem());
    }

    public static int FreePort()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }

    /// <summary>
    /// Creates an assertion the way the gateway does, with room to make it wrong on purpose.
    /// </summary>
    public static string CreateAssertion(
        string privatePem,
        string audience,
        string issuer = "cat-gateway",
        TimeSpan? issuedAgo = null,
        TimeSpan? lifetime = null,
        string algorithm = SecurityAlgorithms.EcdsaSha256)
    {
        var key = ECDsa.Create();
        key.ImportFromPem(privatePem);
        var issued = DateTime.UtcNow - (issuedAgo ?? TimeSpan.Zero);

        return new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor
        {
            Issuer = issuer,
            Audience = audience,
            IssuedAt = issued,
            NotBefore = issued,
            Expires = issued + (lifetime ?? TimeSpan.FromSeconds(30)),
            SigningCredentials = new SigningCredentials(new ECDsaSecurityKey(key), algorithm)
        });
    }

    public static JsonDocument Parse(string json) => JsonDocument.Parse(json);
}
