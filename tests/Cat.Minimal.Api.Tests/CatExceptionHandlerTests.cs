using System.Text.Json;
using Cat.Minimal.Api.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using DiServiceCollection = Microsoft.Extensions.DependencyInjection.ServiceCollection;

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

    /// <summary>
    /// A response that has already started, so a body can't be written anymore.
    /// </summary>
    private class StartedResponseFeature : HttpResponseFeature
    {
        public override bool HasStarted => true;
    }

    private static IExceptionHandler CreateHandler(string environmentName)
    {
        var services = new DiServiceCollection();
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

    #region Unexpected exceptions

    [Test]
    public async Task TryHandleAsync_AnUnexpectedException_IsHandled()
    {
        var context = CreateContext();

        var handled = await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("boom"), CancellationToken.None);

        Assert.That(handled, Is.True);
    }

    [Test]
    public async Task TryHandleAsync_AnUnexpectedException_Answers500WithProblemJson()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("boom"), CancellationToken.None);

        Assert.That(context.Response.StatusCode, Is.EqualTo(500));
        Assert.That(context.Response.ContentType, Does.StartWith("application/problem+json"));
    }

    [Test]
    public async Task TryHandleAsync_InProduction_HidesTheExceptionDetails()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("secret detail"), CancellationToken.None);

        var body = ReadBody(context);
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("Use the CatTraceId to find the error in the logs."));
        Assert.That(body.ToString(), Does.Not.Contain("secret detail"));
        Assert.That(body.ToString(), Does.Not.Contain("InvalidOperationException"));
    }

    [Test]
    public async Task TryHandleAsync_InDevelopment_ShowsTheExceptionTypeAndMessageInTheDetail()
    {
        var context = CreateContext();

        await CreateHandler("Development").TryHandleAsync(context, new InvalidOperationException("secret detail"), CancellationToken.None);

        var body = ReadBody(context);
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("InvalidOperationException: secret detail"));
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
    public async Task TryHandleAsync_TheBodyHasNoFrameworkTraceId()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("boom"), CancellationToken.None);

        Assert.That(ReadBody(context).TryGetProperty("traceId", out _), Is.False);
    }

    #endregion Unexpected exceptions

    #region Binding failures

    [Test]
    public async Task TryHandleAsync_ABindingFailure_KeepsItsStatusCodeAndMessage()
    {
        var context = CreateContext();

        var handled = await CreateHandler("Production").TryHandleAsync(
            context, new BadHttpRequestException("The value isn't a number.", StatusCodes.Status400BadRequest), CancellationToken.None);

        Assert.That(handled, Is.True);
        Assert.That(context.Response.StatusCode, Is.EqualTo(400));
        Assert.That(context.Response.ContentType, Does.StartWith("application/problem+json"));
        var body = ReadBody(context);
        Assert.That(body.GetProperty("status").GetInt32(), Is.EqualTo(400));
        Assert.That(body.GetProperty("title").GetString(), Is.EqualTo("The request isn't valid."));
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("The value isn't a number."));
        Assert.That(body.GetProperty("catTraceId").GetString(), Is.EqualTo("trace-42"));
        Assert.That(body.GetProperty("catErrors").GetArrayLength(), Is.EqualTo(0));
    }

    [Test]
    public async Task TryHandleAsync_ABindingFailureWithAnotherStatusCode_KeepsThatStatusCode()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(
            context, new BadHttpRequestException("Too large.", StatusCodes.Status413PayloadTooLarge), CancellationToken.None);

        Assert.That(context.Response.StatusCode, Is.EqualTo(413));
        var body = ReadBody(context);
        Assert.That(body.GetProperty("status").GetInt32(), Is.EqualTo(413));
        Assert.That(body.GetProperty("title").GetString(), Is.Not.Empty);
    }

    [Test]
    public async Task TryHandleAsync_ABindingFailure_ShowsTheMessageInProductionToo()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(
            context, new BadHttpRequestException("The value isn't a number.", StatusCodes.Status400BadRequest), CancellationToken.None);

        Assert.That(ReadBody(context).GetProperty("detail").GetString(), Is.EqualTo("The value isn't a number."));
    }

    #endregion Binding failures

    #region A client that closed the request

    [Test]
    public async Task TryHandleAsync_TheClientClosedTheRequest_Answers499WithoutABody()
    {
        using var cancellation = new CancellationTokenSource();
        var context = CreateContext();
        context.RequestAborted = cancellation.Token;
        await cancellation.CancelAsync();

        var handled = await CreateHandler("Production").TryHandleAsync(context, new OperationCanceledException(), CancellationToken.None);

        Assert.That(handled, Is.True);
        Assert.That(context.Response.StatusCode, Is.EqualTo(499));
        Assert.That(context.Response.Body.Length, Is.EqualTo(0));
    }

    [Test]
    public async Task TryHandleAsync_ACancellationThatIsNotFromTheClient_IsAnUnexpectedError()
    {
        var context = CreateContext();

        await CreateHandler("Production").TryHandleAsync(context, new OperationCanceledException(), CancellationToken.None);

        Assert.That(context.Response.StatusCode, Is.EqualTo(500));
    }

    #endregion A client that closed the request

    #region A response that has started

    [Test]
    public async Task TryHandleAsync_TheResponseHasStarted_IsNotHandledAndWritesNothing()
    {
        var context = new DefaultHttpContext { TraceIdentifier = "trace-42" };
        context.Features.Set<IHttpResponseFeature>(new StartedResponseFeature());
        context.Response.Body = new MemoryStream();

        var handled = await CreateHandler("Production").TryHandleAsync(context, new InvalidOperationException("boom"), CancellationToken.None);

        Assert.That(handled, Is.False);
        Assert.That(context.Response.Body.Length, Is.EqualTo(0));
    }

    #endregion A response that has started
}
