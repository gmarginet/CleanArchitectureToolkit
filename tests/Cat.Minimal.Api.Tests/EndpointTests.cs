using System.Net;
using System.Text;
using System.Text.Json;
using Cat.Minimal.Api.Tests.Helpers;

namespace Cat.Minimal.Api.Tests;

[TestFixture]
public class EndpointTests
{
    private const string ProblemJson = "application/problem+json";

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

    private static StringContent JsonBody(string json, string contentType = "application/json")
        => new(json, Encoding.UTF8, contentType);

    private Task<HttpResponseMessage> SendAsync(HttpMethod method, string url, HttpContent? content = null)
        => Client.SendAsync(new HttpRequestMessage(method, url) { Content = content });

    /// <summary>
    /// Checks the parts every problem details response has, and returns the body.
    /// </summary>
    private static async Task<JsonElement> AssertProblemAsync(HttpResponseMessage response, HttpStatusCode expectedStatus)
    {
        Assert.That(response.StatusCode, Is.EqualTo(expectedStatus));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo(ProblemJson));

        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("status").GetInt32(), Is.EqualTo((int)expectedStatus));
        Assert.That(body.GetProperty("catTraceId").GetString(), Is.Not.Empty);
        Assert.That(body.TryGetProperty("catErrors", out _), Is.True);
        Assert.That(body.TryGetProperty("traceId", out _), Is.False, "The framework traceId is removed, catTraceId holds the id.");
        return body;
    }

    #region GET

    [Test]
    public async Task Get_Ok_Answers200WithTheValue()
    {
        var response = await Client.GetAsync("/items/7");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("id").GetInt32(), Is.EqualTo(7));
        Assert.That(body.GetProperty("name").GetString(), Is.EqualTo("item 7"));
    }

    [TestCase("badrequest", 400, "The request isn't valid.")]
    [TestCase("notfound", 404, "The requested resource was not found.")]
    [TestCase("conflict", 409, "The request conflicts with the current state of the resource.")]
    [TestCase("unauthorized", 401, "Authentication is required for this request.")]
    [TestCase("forbidden", 403, "The caller isn't allowed to perform this request.")]
    public async Task Get_FailedResponse_AnswersTheStatusAndTheTitleOfItsType(string outcome, int status, string title)
    {
        var response = await Client.GetAsync($"/items/1?outcome={outcome}");

        var body = await AssertProblemAsync(response, (HttpStatusCode)status);
        Assert.That(body.GetProperty("title").GetString(), Is.EqualTo(title));
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("Look at the CatErrors property for more details."));
        Assert.That(body.GetProperty("instance").GetString(), Is.EqualTo("/items/1"));
    }

    [Test]
    public async Task Get_FailedResponse_TheBodyHoldsTheCatErrors()
    {
        var response = await Client.GetAsync("/items/1?outcome=notfound");

        var body = await AssertProblemAsync(response, HttpStatusCode.NotFound);
        var error = body.GetProperty("catErrors").EnumerateArray().Single();
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("ITM-1"));
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Item {what} failed"));
        Assert.That(error.GetProperty("arguments")[0].GetString(), Is.EqualTo("x"));
    }

    [Test]
    public async Task Get_InternalServerErrorResponse_IsAlwaysAllowedAndHoldsTheCatErrors()
    {
        var response = await Client.GetAsync("/defaults/1?outcome=server");

        var body = await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
        Assert.That(body.GetProperty("title").GetString(), Is.EqualTo("An unexpected error occurred."));
        Assert.That(body.GetProperty("catErrors").GetArrayLength(), Is.EqualTo(1));
    }

    [Test]
    public async Task Get_BadRequestResponse_IsAlwaysAllowed()
    {
        var response = await Client.GetAsync("/defaults/1?outcome=badrequest");

        await AssertProblemAsync(response, HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task Get_ResponseTypeThatIsNotAllowed_Answers500()
    {
        var response = await Client.GetAsync("/restricted/1?outcome=conflict");

        var body = await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("Use the CatTraceId to find the error in the logs."));
    }

    [Test]
    public async Task Get_ResponseTypeThatIsNotAllowed_InDevelopment_ExplainsWhichTypeToAdd()
    {
        await using var developmentApp = await TestApp.StartAsync("Development");

        var response = await developmentApp.Client.GetAsync("/restricted/1?outcome=conflict");

        var body = await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
        var detail = body.GetProperty("detail").GetString();
        Assert.That(detail, Does.Contain("returned CatResponseType Conflict"));
        Assert.That(detail, Does.Contain("only allows Ok, NotFound, BadRequest, InternalServerError"));
        Assert.That(detail, Does.Contain("Add Conflict to the responseTypes argument"));
    }

    [Test]
    public async Task Get_DefaultsDoNotAllowOtherSuccessTypes()
    {
        var response = await Client.GetAsync("/defaults/1?outcome=nocontent");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
    }

    [Test]
    public async Task Get_DuplicateResponseTypes_StillWork()
    {
        var ok = await Client.GetAsync("/duplicates/1");
        var notFound = await Client.GetAsync("/duplicates/1?outcome=notfound");

        Assert.That(ok.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(notFound.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetList_Answers200WithTheItems()
    {
        var response = await Client.GetAsync("/items");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetArrayLength(), Is.EqualTo(2));
        Assert.That(body[0].GetProperty("name").GetString(), Is.EqualTo("first"));
        Assert.That(body[1].GetProperty("name").GetString(), Is.EqualTo("second"));
    }

    [Test]
    public async Task GetList_ValueThatCannotBeBound_Answers400WithProblemDetails()
    {
        var response = await Client.GetAsync("/items?page=abc");

        var body = await AssertProblemAsync(response, HttpStatusCode.BadRequest);
        Assert.That(body.GetProperty("detail").GetString(), Does.Contain("abc"));
        Assert.That(body.GetProperty("catErrors").GetArrayLength(), Is.EqualTo(0));
    }

    [Test]
    public async Task GetPagedList_Answers200WithThePage()
    {
        var response = await Client.GetAsync("/items/paged");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("list").GetArrayLength(), Is.EqualTo(2));
        Assert.That(body.GetProperty("pageNumber").GetInt32(), Is.EqualTo(1));
        Assert.That(body.GetProperty("pageSize").GetInt32(), Is.EqualTo(10));
        Assert.That(body.GetProperty("totalItemCount").GetInt32(), Is.EqualTo(2));
        Assert.That(body.GetProperty("totalPages").GetInt32(), Is.EqualTo(1));
    }

    #endregion GET

    #region POST

    [Test]
    public async Task Post_Created_Answers201WithTheValueAndTheLocationHeader()
    {
        var response = await Client.PostAsync("/items", JsonBody("""{"id":5,"name":"five"}"""));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.Headers.Location?.ToString(), Is.EqualTo("/items/5"));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("id").GetInt32(), Is.EqualTo(5));
        Assert.That(body.GetProperty("name").GetString(), Is.EqualTo("five"));
    }

    [Test]
    public async Task Post_Created_WithoutALocation_HasNoLocationHeader()
    {
        var response = await Client.PostAsync("/items-without-location", JsonBody("""{"id":5,"name":"five"}"""));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.Headers.Location, Is.Null);
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("id").GetInt32(), Is.EqualTo(5));
    }

    [Test]
    public async Task Post_Created_WhenTheLocationIsNull_HasNoLocationHeader()
    {
        var response = await Client.PostAsync("/items-null-location", JsonBody("""{"id":5,"name":"five"}"""));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(response.Headers.Location, Is.Null);
    }

    [Test]
    public async Task Post_Accepted_Answers202WithTheValueAndTheLocationHeader()
    {
        var response = await Client.PostAsync("/items-accepted?outcome=accepted", JsonBody("""{"id":5,"name":"five"}"""));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        Assert.That(response.Headers.Location?.ToString(), Is.EqualTo("/items/5"));
        var body = await ReadJsonAsync(response);
        Assert.That(body.GetProperty("id").GetInt32(), Is.EqualTo(5));
        Assert.That(body.GetProperty("name").GetString(), Is.EqualTo("five"));
    }

    [Test]
    public async Task Post_Accepted_WithoutALocation_HasNoLocationHeader()
    {
        var response = await Client.PostAsync("/items-accepted-without-location?outcome=accepted", JsonBody("""{"id":5,"name":"five"}"""));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        Assert.That(response.Headers.Location, Is.Null);
        Assert.That((await ReadJsonAsync(response)).GetProperty("id").GetInt32(), Is.EqualTo(5));
    }

    [Test]
    public async Task PostWithoutAValue_Accepted_Answers202WithoutABody()
    {
        var response = await Client.PostAsync("/ping-accepted?outcome=accepted", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        Assert.That(await response.Content.ReadAsStringAsync(), Is.Empty);
    }

    [Test]
    public async Task Post_AcceptedThatIsNotAllowed_Answers500()
    {
        var response = await Client.PostAsync("/items?outcome=accepted", JsonBody("""{"id":5,"name":"five"}"""));

        await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
    }

    [Test]
    public async Task Post_AllowedFailedResponse_AnswersItsStatus()
    {
        var response = await Client.PostAsync("/items?outcome=conflict", JsonBody("""{"id":5,"name":"five"}"""));

        await AssertProblemAsync(response, HttpStatusCode.Conflict);
    }

    [Test]
    public async Task Post_ResponseTypeThatIsNotAllowed_Answers500()
    {
        var response = await Client.PostAsync("/items?outcome=nocontent", JsonBody("""{"id":5,"name":"five"}"""));

        await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
    }

    [Test]
    public async Task PostWithoutAValue_UsesCreatedAsTheDefault()
    {
        var response = await Client.PostAsync("/ping", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(await response.Content.ReadAsStringAsync(), Is.Empty);
    }

    [Test]
    public async Task PostWithoutAValue_FailedResponse_AnswersItsStatus()
    {
        var response = await Client.PostAsync("/ping?outcome=badrequest", null);

        await AssertProblemAsync(response, HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task PostWithoutAValue_ResponseTypeThatIsNotAllowed_Answers500()
    {
        var response = await Client.PostAsync("/ping?outcome=nocontent", null);

        await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
    }

    #endregion POST

    #region PUT, PATCH and DELETE

    [Test]
    public async Task Put_UsesNoContentAsTheDefault()
    {
        var response = await SendAsync(HttpMethod.Put, "/items/3", JsonBody("""{"id":3,"name":"three"}"""));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(await response.Content.ReadAsStringAsync(), Is.Empty);
    }

    [Test]
    public async Task Put_ResponseTypeThatIsNotAllowed_Answers500()
    {
        var response = await SendAsync(HttpMethod.Put, "/items/3?outcome=ok", JsonBody("""{"id":3,"name":"three"}"""));

        await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
    }

    [Test]
    public async Task Patch_GivenResponseTypesReplaceTheDefault()
    {
        var ok = await SendAsync(HttpMethod.Patch, "/items/3?outcome=ok", JsonBody("""{"id":3,"name":"three"}"""));
        var noContent = await SendAsync(HttpMethod.Patch, "/items/3?outcome=nocontent", JsonBody("""{"id":3,"name":"three"}"""));

        Assert.That(ok.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(await ok.Content.ReadAsStringAsync(), Is.Empty);
        Assert.That(noContent.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
    }

    [Test]
    public async Task Delete_NoContent_Answers204()
    {
        var response = await SendAsync(HttpMethod.Delete, "/items/3");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
    }

    [Test]
    public async Task Delete_NotFound_Answers404()
    {
        var response = await SendAsync(HttpMethod.Delete, "/items/3?outcome=notfound");

        await AssertProblemAsync(response, HttpStatusCode.NotFound);
    }

    [Test]
    public async Task Delete_ResponseTypeThatIsNotAllowed_Answers500()
    {
        var response = await SendAsync(HttpMethod.Delete, "/items/3?outcome=conflict");

        await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
    }

    #endregion PUT, PATCH and DELETE

    #region Patch document

    [Test]
    public async Task PatchDocument_AppliesTheOperationsAndAnswers204()
    {
        var content = JsonBody("""[{"op":"replace","path":"/name","value":"patched"}]""", "application/json-patch+json");

        var response = await SendAsync(HttpMethod.Patch, "/items/9/document", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(_app.PatchRecorder.Id, Is.EqualTo(9));
        Assert.That(_app.PatchRecorder.OperationCount, Is.EqualTo(1));
        Assert.That(_app.PatchRecorder.Name, Is.EqualTo("patched"));
    }

    [Test]
    public async Task PatchDocument_WithoutAPatchDocument_Answers400()
    {
        var response = await SendAsync(HttpMethod.Patch, "/items/9/document", JsonBody("", "application/json-patch+json"));

        var body = await AssertProblemAsync(response, HttpStatusCode.BadRequest);
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("The request has no patch document in its body."));
    }

    [Test]
    public async Task PatchDocument_WithMalformedJson_Answers400()
    {
        var response = await SendAsync(HttpMethod.Patch, "/items/9/document", JsonBody("[{bad", "application/json-patch+json"));

        await AssertProblemAsync(response, HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task PatchDocument_WithAWrongContentType_Answers415()
    {
        var response = await SendAsync(HttpMethod.Patch, "/items/9/document", JsonBody("[]", "text/plain"));

        await AssertProblemAsync(response, HttpStatusCode.UnsupportedMediaType);
    }

    [Test]
    public async Task PatchDocument_ResponseTypeThatIsNotAllowed_Answers500()
    {
        var content = JsonBody("""[{"op":"replace","path":"/name","value":"patched"}]""", "application/json-patch+json");

        var response = await SendAsync(HttpMethod.Patch, "/items/9/document?outcome=ok", content);

        await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
    }

    #endregion Patch document

    #region Requests the framework rejects

    [Test]
    public async Task MalformedJsonBody_InProduction_Answers400WithProblemDetails()
    {
        var response = await Client.PostAsync("/items", JsonBody("{bad json"));

        var body = await AssertProblemAsync(response, HttpStatusCode.BadRequest);
        Assert.That(body.GetProperty("title").GetString(), Is.EqualTo("The request isn't valid."));
        Assert.That(body.GetProperty("detail").GetString(), Does.Contain("Failed to read parameter"));
        Assert.That(body.GetProperty("instance").GetString(), Is.EqualTo("/items"));
        Assert.That(body.GetProperty("catErrors").GetArrayLength(), Is.EqualTo(0));
    }

    [Test]
    public async Task MalformedJsonBody_InDevelopment_Answers400AndNot500()
    {
        await using var developmentApp = await TestApp.StartAsync("Development");

        var response = await developmentApp.Client.PostAsync("/items", JsonBody("{bad json"));

        await AssertProblemAsync(response, HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task WrongContentType_Answers415WithProblemDetails()
    {
        var response = await Client.PostAsync("/items", JsonBody("hello", "text/plain"));

        await AssertProblemAsync(response, HttpStatusCode.UnsupportedMediaType);
    }

    [Test]
    public async Task UnknownRoute_Answers404WithProblemDetails()
    {
        var response = await Client.GetAsync("/nope");

        var body = await AssertProblemAsync(response, HttpStatusCode.NotFound);
        Assert.That(body.GetProperty("instance").GetString(), Is.EqualTo("/nope"));
        Assert.That(body.GetProperty("catErrors").GetArrayLength(), Is.EqualTo(0));
    }

    [Test]
    public async Task RouteValueThatDoesNotMatchTheConstraint_Answers404WithProblemDetails()
    {
        var response = await Client.GetAsync("/items/abc");

        await AssertProblemAsync(response, HttpStatusCode.NotFound);
    }

    [Test]
    public async Task MethodThatIsNotMapped_Answers405WithProblemDetails()
    {
        var response = await SendAsync(HttpMethod.Delete, "/items");

        await AssertProblemAsync(response, HttpStatusCode.MethodNotAllowed);
    }

    #endregion Requests the framework rejects

    #region Exceptions

    [Test]
    public async Task HandlerThrows_InProduction_Answers500WithoutTheDetails()
    {
        var response = await Client.GetAsync("/items/1?outcome=throw");

        var body = await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
        var text = body.ToString();
        Assert.That(text, Does.Not.Contain("secret detail"));
        Assert.That(text, Does.Not.Contain("InvalidOperationException"));
        Assert.That(body.GetProperty("title").GetString(), Is.EqualTo("An unexpected error occurred."));
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("Use the CatTraceId to find the error in the logs."));
    }

    [Test]
    public async Task HandlerThrows_InDevelopment_ShowsTheExceptionTypeAndMessage()
    {
        await using var developmentApp = await TestApp.StartAsync("Development");

        var response = await developmentApp.Client.GetAsync("/items/1?outcome=throw");

        var body = await AssertProblemAsync(response, HttpStatusCode.InternalServerError);
        Assert.That(body.GetProperty("detail").GetString(), Is.EqualTo("InvalidOperationException: secret detail"));
    }

    #endregion Exceptions
}
