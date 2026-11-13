using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Cat.Commands.Abstractions;
using Cat.Demo.CatalogService.Api.Extensions;
using Cat.Demo.CatalogService.CoreService.Commands;
using Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;
using Cat.Demo.ServiceDefaults;
using Cat.Minimal.Api.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.UnitTesting.Commands;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cat.Demo.CatalogService.CoreService.Tests;

/// <summary>
/// Calls the save endpoint of the Catalog on a real local web server, with the real endpoint mapping and the real
/// <c>admin</c> policy. The token is replaced by a test scheme that reads the roles from a header.
/// </summary>
[TestFixture]
public class BookSaveAuthorizationTests
{
    private const string RolesHeader = "X-Test-Roles";

    private WebApplication _app = null!;
    private HttpClient _client = null!;
    private FakeCommandProcessor _commandProcessor = null!;

    [SetUp]
    public async Task SetUp()
    {
        _commandProcessor = new FakeCommandProcessor();

        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { EnvironmentName = "Production" });
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Logging.ClearProviders();

        builder.Services.AddCatMinimalApiModule();
        builder.Services.AddCatServiceRequestsModule(typeof(BookSaveRequestHandler));
        builder.Services.AddSingleton<ICatCommandProcessor>(_commandProcessor);

        builder.Services.AddAuthentication(TestAuthenticationHandler.SchemeName)
            .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(TestAuthenticationHandler.SchemeName, null);
        builder.Services.AddDemoAuthorization();

        _app = builder.Build();
        _app.UseCatMinimalApiModule();
        _app.UseAuthentication();
        _app.UseAuthorization();
        _app.MapCatalogServiceEndpoints(requireLogin: true);
        await _app.StartAsync();

        var address = _app.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses.First();
        _client = new HttpClient { BaseAddress = new Uri(address) };
    }

    [TearDown]
    public async Task TearDown()
    {
        _client.Dispose();
        await _app.StopAsync();
        await _app.DisposeAsync();
    }

    private static object NewBook() => new
    {
        isbn = "9780596007126",
        categoryId = Guid.NewGuid(),
        title = "Head First Design Patterns",
        author = "Eric Freeman",
        price = 44.50m
    };

    private Task<HttpResponseMessage> SaveAsync(string? roles)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/catalog/books/") { Content = JsonContent.Create(NewBook()) };
        if (roles is not null)
        {
            request.Headers.Add(RolesHeader, roles);
        }

        return _client.SendAsync(request);
    }

    [Test]
    public async Task BookSave_WithoutALogin_ShouldReturn401AndNotRunTheCommand()
    {
        var response = await SaveAsync(null);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(_commandProcessor.Commands, Is.Empty);
        }
    }

    [Test]
    public async Task BookSave_AsAUserWhoIsNotAnAdmin_ShouldReturn403AndNotRunTheCommand()
    {
        var response = await SaveAsync("customer");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
            Assert.That(_commandProcessor.Commands, Is.Empty);
        }
    }

    [Test]
    public async Task BookSave_AsAnAdmin_ShouldRunTheCommand()
    {
        var response = await SaveAsync("admin");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(_commandProcessor.Commands.Single(), Is.TypeOf<BookSaveCommand>());
        }
    }

    /// <summary>
    /// Logs in the caller when the roles header is there. The role claim is named <c>roles</c>, like the flat claim of the
    /// Keycloak realm that <c>AddCatUsersJwtBearer</c> gives the real scheme.
    /// </summary>
    private sealed class TestAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
    {
        public const string SchemeName = "Test";

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(RolesHeader, out var roles))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            var claims = new List<Claim> { new("sub", "alice"), new("preferred_username", "alice") };
            claims.AddRange(roles.ToString().Split(',').Select(role => new Claim("roles", role)));

            var identity = new ClaimsIdentity(claims, SchemeName, "preferred_username", "roles");
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), SchemeName);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
