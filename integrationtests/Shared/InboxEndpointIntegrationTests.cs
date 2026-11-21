using Cat.Inbox.AspNetCore.Extensions;
using Cat.Inbox.EFCore;
using Cat.Inbox.EFCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cat.EFCore.IntegrationTests;

/// <summary>
/// An endpoint with the HTTP inbox and the real EF Core store on a real database.
/// The inbox row and the change of the endpoint go out in one save, so a call that fails leaves no row.
/// This part shares the class, the database and the clean up of <see cref="ReceiverInboxIntegrationTests"/>.
/// </summary>
public partial class ReceiverInboxIntegrationTests
{
    private async Task<(WebApplication App, HttpClient Client)> StartEndpointAsync()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Logging.ClearProviders();
        builder.Services.AddDbContext<ReceiverDbContext>(options => UseDatabase(options, ConnectionString));
        builder.Services.AddCatInboxEfCore<ReceiverDbContext>();
        var app = builder.Build();

        // The endpoint saves through the context of its own scope, which is the one the inbox filter added its row to.
        app.MapPost("/hook", async (ReceiverDbContext db, HttpRequest request) =>
        {
            db.Set<Visit>().Add(new Visit { Id = Guid.NewGuid(), Note = request.Headers["note"].ToString() });
            if (request.Headers["fail"] == "yes")
            {
                throw new InvalidOperationException("The endpoint fails after it added its row.");
            }

            await db.SaveChangesAsync();
            return Results.Ok();
        }).WithCatInbox("webhook-id");

        await app.StartAsync();
        return (app, new HttpClient { BaseAddress = new Uri(app.Urls.Single()) });
    }

    private static async Task<int> CallAsync(HttpClient client, string id, bool fail = false)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "/hook");
        request.Headers.Add("webhook-id", id);
        request.Headers.Add("note", "from the webhook");
        if (fail)
        {
            request.Headers.Add("fail", "yes");
        }

        using var response = await client.SendAsync(request);
        return (int)response.StatusCode;
    }

    [Test]
    public async Task Endpoint_TheSecondCallWithTheSameId_IsSkipped()
    {
        var (app, client) = await StartEndpointAsync();
        await using var appScope = app;
        using var clientScope = client;

        var first = await CallAsync(client, "evt-1");
        var second = await CallAsync(client, "evt-1");
        var other = await CallAsync(client, "evt-2");

        Assert.That(first, Is.EqualTo(200));
        Assert.That(second, Is.EqualTo(200));
        Assert.That(other, Is.EqualTo(200));
        Assert.That(await CountAsync<Visit>(), Is.EqualTo(2));
        Assert.That(await CountAsync<CatInboxMessage>(), Is.EqualTo(2));
    }

    [Test]
    public async Task Endpoint_ACallThatFails_LeavesNoRowAndTheRetryIsHandled()
    {
        var (app, client) = await StartEndpointAsync();
        await using var appScope = app;
        using var clientScope = client;

        var failed = await CallAsync(client, "evt-1", fail: true);
        var inboxAfterTheFailure = await CountAsync<CatInboxMessage>();
        var visitsAfterTheFailure = await CountAsync<Visit>();
        var retried = await CallAsync(client, "evt-1");

        Assert.That(failed, Is.EqualTo(500));
        Assert.That(inboxAfterTheFailure, Is.EqualTo(0));
        Assert.That(visitsAfterTheFailure, Is.EqualTo(0));
        Assert.That(retried, Is.EqualTo(200));
        Assert.That(await CountAsync<Visit>(), Is.EqualTo(1));
        Assert.That(await CountAsync<CatInboxMessage>(), Is.EqualTo(1));
    }
}
