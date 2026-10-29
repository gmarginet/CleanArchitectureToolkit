using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Cat.Minimal.Api.Tests.Helpers;

namespace Cat.Minimal.Api.Tests;

[TestFixture]
public class EndpointTests
{
    private TestApp _app = null!;

    private HttpClient Client => _app.Client;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        _app = await TestApp.StartAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _app.DisposeAsync();
    }

    private static async Task<JsonElement> ReadJsonAsync(HttpResponseMessage response)
    {
        var text = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(text).RootElement;
    }

    #region Requests with a payload

    [Test]
    public async Task SucceededRequest_Answers200WithThePayload()
    {
        var response = await Client.PostAsJsonAsync("/echo", new { text = "hello" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await response.Content.ReadFromJsonAsync<string>(), Is.EqualTo("echo:hello"));
    }

    [Test]
    public async Task BadRequestResponse_Answers400WithProblemDetails()
    {
        var response = await Client.PostAsJsonAsync("/echo", new { text = "bad" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/problem+json"));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("status").GetInt32(), Is.EqualTo(400));
        Assert.That(body.GetProperty("instance").GetString(), Is.EqualTo("/echo"));
    }

    [Test]
    public async Task FailedResponse_TheBodyHoldsTheCatErrors()
    {
        var response = await Client.PostAsJsonAsync("/echo", new { text = "bad" });

        var body = await ReadJsonAsync(response);
        var error = body.GetProperty("catErrors").EnumerateArray().Single();
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("ECH-1"));
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Echo {text} failed"));
        Assert.That(error.GetProperty("arguments")[0].GetString(), Is.EqualTo("bad"));
        Assert.That(body.GetProperty("catTraceId").GetString(), Is.Not.Empty);
    }

    [Test]
    public async Task NotFoundResponse_Answers404()
    {
        var response = await Client.PostAsJsonAsync("/echo", new { text = "notfound" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task UnauthorizedResponse_Answers401()
    {
        var response = await Client.PostAsJsonAsync("/echo", new { text = "unauthorized" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task InternalServerErrorResponse_Answers500WithProblemDetails()
    {
        var response = await Client.PostAsJsonAsync("/echo", new { text = "server" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("catErrors").GetArrayLength(), Is.EqualTo(1));
    }

    #endregion Requests with a payload

    #region Requests without a payload

    [Test]
    public async Task SucceededRequestWithoutAPayload_Answers200WithoutABody()
    {
        var response = await Client.PostAsJsonAsync("/ping", new { text = "hi" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await response.Content.ReadAsStringAsync(), Is.Empty);
    }

    [Test]
    public async Task FailedRequestWithoutAPayload_Answers400WithProblemDetails()
    {
        var response = await Client.PostAsJsonAsync("/ping", new { text = "bad" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("catErrors")[0].GetProperty("code").GetString(), Is.EqualTo("PNG-1"));
    }

    #endregion Requests without a payload

    #region The request body

    [Test]
    public async Task RequestBody_IsReadIntoTheRequest()
    {
        var response = await Client.PostAsJsonAsync("/positional", new { name = "Anna" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await response.Content.ReadFromJsonAsync<string>(), Is.EqualTo("hello Anna"));
    }

    [Test]
    public async Task EmptyBody_RequestWithAParameterlessConstructor_StillRuns()
    {
        var response = await Client.PostAsync("/echo", new StringContent("", System.Text.Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await response.Content.ReadFromJsonAsync<string>(), Is.EqualTo("echo:"));
    }

    [Test]
    public async Task EmptyBody_RequestWithoutAParameterlessConstructor_Answers400()
    {
        var response = await Client.PostAsync("/positional", new StringContent("", System.Text.Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("The request body is required."));
        Assert.That(body.GetProperty("catErrors").GetArrayLength(), Is.EqualTo(0));
    }

    [Test]
    public async Task OnlyPostIsMapped()
    {
        var response = await Client.GetAsync("/echo");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
    }

    #endregion The request body

    #region Exceptions

    [Test]
    public async Task HandlerThrows_InProduction_Answers500WithoutTheDetails()
    {
        var response = await Client.PostAsJsonAsync("/echo", new { text = "throw" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        var text = await response.Content.ReadAsStringAsync();
        Assert.That(text, Does.Not.Contain("secret detail"));
        var body = JsonDocument.Parse(text).RootElement;
        Assert.That(body.GetProperty("title").GetString(), Is.EqualTo("An unexpected error occurred."));
        Assert.That(body.GetProperty("catTraceId").GetString(), Is.Not.Empty);
    }

    [Test]
    public async Task HandlerThrows_InDevelopment_ShowsTheExceptionMessage()
    {
        await using var developmentApp = await TestApp.StartAsync("Development");

        var response = await developmentApp.Client.PostAsJsonAsync("/echo", new { text = "throw" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("secret detail"));
        Assert.That(body.GetProperty("type").GetString(), Is.EqualTo("InvalidOperationException"));
    }

    #endregion Exceptions
}
