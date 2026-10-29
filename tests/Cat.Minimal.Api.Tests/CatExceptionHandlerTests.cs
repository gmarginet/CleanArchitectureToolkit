using System.Text.Json;
using Cat.Minimal.Api.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Minimal.Api.Tests;

[TestFixture]
public class CatExceptionHandlerTests
{
    private class TestEnvironment : IHostEnvironment
    {
        public string EnvironmentName { get; set; } = Environments.Production;
        public string ApplicationName { get; set; } = "Tests";
        public string ContentRootPath { get; set; } = "";
        public Microsoft.Extensions.FileProviders.IFileProvider ContentRootFileProvider { get; set; } = null!;
    }

    private static IExceptionHandler CreateHandler(string environmentName)
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddSingleton<IHostEnvironment>(new TestEnvironment { EnvironmentName = environmentName });
        services.AddCatMinimalApiModule();

        var provider = services.BuildServiceProvider();
        return provider.GetServices<IExceptionHandler>().Single();
    }

    private static DefaultHttpContext CreateContext()
    {
        var context = new DefaultHttpContext { TraceIdentifier = "trace-42" };
        context.Request.Path = "/orders/1";
        context.Response.Body = new MemoryStream();
        return context;
    }

    private static JsonElement ReadBody(DefaultHttpContext context)
    {
        context.Response.Body.Position = 0;
        return JsonDocument.Parse(context.Response.Body).RootElement;
    }

    [Test]
    public async Task TryHandleAsync_AlwaysHandlesTheException()
    {
        var context = CreateContext();

        var handled = await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("boom"), CancellationToken.None);

        Assert.That(handled, Is.True);
    }

    [Test]
    public async Task TryHandleAsync_Answers500WithJson()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("boom"), CancellationToken.None);

        Assert.That(context.Response.StatusCode, Is.EqualTo(500));
        Assert.That(context.Response.ContentType, Does.StartWith("application/json"));
    }

    [Test]
    public async Task TryHandleAsync_InProduction_HidesTheExceptionDetails()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("secret detail"), CancellationToken.None);

        var body = ReadBody(context);
        Assert.That(body.TryGetProperty("type", out var type) ? type.ValueKind : JsonValueKind.Null, Is.EqualTo(JsonValueKind.Null));
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("Use the CatTraceId to find the error in the logs."));
        Assert.That(body.ToString(), Does.Not.Contain("secret detail"));
    }

    [Test]
    public async Task TryHandleAsync_InDevelopment_ShowsTheTypeAndTheMessage()
    {
        var context = CreateContext();

        await CreateHandler("Development").TryHandleAsync(context, new InvalidOperationException("secret detail"), CancellationToken.None);

        var body = ReadBody(context);
        Assert.That(body.GetProperty("type").GetString(), Is.EqualTo("InvalidOperationException"));
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("secret detail"));
    }

    [Test]
    public async Task TryHandleAsync_TheBodyHasTheStatusTheTitleTheInstanceAndTheTraceId()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("boom"), CancellationToken.None);

        var body = ReadBody(context);
        Assert.That(body.GetProperty("status").GetInt32(), Is.EqualTo(500));
        Assert.That(body.GetProperty("title").GetString(), Is.EqualTo("An unexpected error occurred."));
        Assert.That(body.GetProperty("instance").GetString(), Is.EqualTo("/orders/1"));
        Assert.That(body.GetProperty("catTraceId").GetString(), Is.EqualTo("trace-42"));
        Assert.That(body.GetProperty("catErrors").GetArrayLength(), Is.EqualTo(0));
    }

    [Test]
    public void AddCatMinimalApiModule_RegistersTheExceptionHandler()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatMinimalApiModule();

        Assert.That(services.Any(s => s.ServiceType == typeof(IExceptionHandler)), Is.True);
    }

    [Test]
    public void AddCatMinimalApiModule_RegistersTheProblemDetailsServices()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatMinimalApiModule();

        Assert.That(services.Any(s => s.ServiceType == typeof(IProblemDetailsService)), Is.True);
    }
}
