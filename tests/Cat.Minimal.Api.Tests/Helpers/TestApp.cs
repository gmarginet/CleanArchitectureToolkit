using Cat.Minimal.Api.Extensions;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Minimal.Api.Tests.Helpers;

/// <summary>
/// A real web server on a free local port, with the module set up and a set of endpoints mapped.
/// Each endpoint is mapped with its own list of response types, so a test can pick the one it needs.
/// </summary>
public sealed class TestApp : IAsyncDisposable
{
    private readonly WebApplication _app;

    private TestApp(WebApplication app, HttpClient client)
    {
        _app = app;
        Client = client;
    }

    public HttpClient Client { get; }

    public PatchRecorder PatchRecorder => _app.Services.GetRequiredService<PatchRecorder>();

    public static async Task<TestApp> StartAsync(string environmentName = "Production")
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { EnvironmentName = environmentName });
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Logging.ClearProviders();

        builder.Services.AddCatMinimalApiModule();
        builder.Services.AddCatServiceRequestsModule(typeof(ItemGetRequestHandler));
        builder.Services.AddSingleton<PatchRecorder>();

        var app = builder.Build();
        app.UseCatMinimalApiModule();

        // GET: every failed response type is allowed here.
        app.MapCatGet<ItemGetRequest, ItemModel>("/items/{id:int}",
            CatResponseType.Ok, CatResponseType.BadRequest, CatResponseType.NotFound, CatResponseType.Conflict,
            CatResponseType.Unauthorized, CatResponseType.Forbidden);

        // GET: only Ok and NotFound are allowed.
        app.MapCatGet<ItemGetRequest, ItemModel>("/restricted/{id:int}", CatResponseType.Ok, CatResponseType.NotFound);

        // GET: no response types, so the defaults are used.
        app.MapCatGet<ItemGetRequest, ItemModel>("/defaults/{id:int}");

        // GET: the same response types more than once.
        app.MapCatGet<ItemGetRequest, ItemModel>("/duplicates/{id:int}",
            CatResponseType.Ok, CatResponseType.Ok, CatResponseType.NotFound, CatResponseType.NotFound);

        app.MapCatGetList<ItemListRequest, ItemModel>("/items");
        app.MapCatGetPagedList<ItemPagedRequest, ItemModel>("/items/paged");

        // POST: with a value in the body of the response.
        app.MapCatPost<ItemCreateRequest, ItemModel>("/items", item => $"/items/{item.Id}", CatResponseType.Created, CatResponseType.Conflict);
        app.MapCatPost<ItemCreateRequest, ItemModel>("/items-without-location", CatResponseType.Created);
        app.MapCatPost<ItemCreateRequest, ItemModel>("/items-null-location", _ => null, CatResponseType.Created);

        // POST: work that is accepted and not finished yet.
        app.MapCatPost<ItemCreateRequest, ItemModel>("/items-accepted", item => $"/items/{item.Id}", CatResponseType.Accepted);
        app.MapCatPost<ItemCreateRequest, ItemModel>("/items-accepted-without-location", CatResponseType.Accepted);

        // POST: without a value in the body of the response.
        app.MapCatPost<PingRequest>("/ping");
        app.MapCatPost<PingRequest>("/ping-accepted", CatResponseType.Accepted);

        app.MapCatPut<ItemUpdateRequest>("/items/{id:int}");
        app.MapCatPatch<ItemUpdateRequest>("/items/{id:int}", CatResponseType.Ok, CatResponseType.NotFound);
        app.MapCatDelete<ItemDeleteRequest>("/items/{id:int}", CatResponseType.NoContent, CatResponseType.NotFound);

        app.MapCatPatchDocument<ItemRouteParameters, ItemPatchModel>("/items/{id:int}/document");

        await app.StartAsync();

        var address = app.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses.First();
        var client = new HttpClient { BaseAddress = new Uri(address) };

        return new TestApp(app, client);
    }

    /// <summary>
    /// Gets the endpoint metadata, which is what an OpenAPI generator reads.
    /// </summary>
    public RouteEndpoint GetEndpoint(string httpMethod, string pattern)
        => ((IEndpointRouteBuilder)_app).DataSources
            .SelectMany(source => source.Endpoints)
            .OfType<RouteEndpoint>()
            .Single(endpoint => endpoint.RoutePattern.RawText == pattern
                                && endpoint.Metadata.GetMetadata<IHttpMethodMetadata>()!.HttpMethods.Contains(httpMethod));

    public IReadOnlyList<IProducesResponseTypeMetadata> GetProducedResponses(string httpMethod, string pattern)
        => GetEndpoint(httpMethod, pattern).Metadata.OfType<IProducesResponseTypeMetadata>().ToList();

    public async ValueTask DisposeAsync()
    {
        Client.Dispose();
        await _app.StopAsync();
        await _app.DisposeAsync();
    }
}
