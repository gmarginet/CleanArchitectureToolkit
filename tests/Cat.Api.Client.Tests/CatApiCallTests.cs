using System.Net.Http;
using Cat.Api.Client;
using Cat.Responses.Abstractions;

namespace Cat.Api.Client.Tests;

[TestFixture]
public class CatApiCallTests
{
    private const string ServiceName = "Catalog";

    private static readonly IReadOnlyDictionary<string, IEnumerable<string>> NoHeaders = new Dictionary<string, IEnumerable<string>>();

    private static CatApiException Failure(int status, string? body)
        => new("Failed", status, body, NoHeaders, null);

    private const string NotFoundBody = """
        {
          "title": "Not Found",
          "status": 404,
          "catErrors": [
            { "code": "DEM-ORD-1005", "message": "Book {BookId} has no price.", "arguments": ["b1", 3, true, null] }
          ],
          "catTraceId": "trace-1"
        }
        """;

    [Test]
    public async Task ACallThatSucceeds_GivesAnOkResponseWithTheValue()
    {
        var response = await CatApiCall.ExecuteAsync(() => Task.FromResult(42), ServiceName);

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Ok>());
        Assert.That(response.Value, Is.EqualTo(42));
    }

    [Test]
    public async Task ACallWithoutAValueThatSucceeds_GivesAnOkResponse()
    {
        var response = await CatApiCall.ExecuteAsync(() => Task.CompletedTask, ServiceName);

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Ok>());
    }

    [TestCase(400, typeof(CatResponseType.Failed.BadRequest))]
    [TestCase(401, typeof(CatResponseType.Failed.Unauthorized))]
    [TestCase(403, typeof(CatResponseType.Failed.Forbidden))]
    [TestCase(404, typeof(CatResponseType.Failed.NotFound))]
    [TestCase(409, typeof(CatResponseType.Failed.Conflict))]
    [TestCase(500, typeof(CatResponseType.Failed.InternalServerError))]
    [TestCase(503, typeof(CatResponseType.Failed.InternalServerError))]
    public async Task TheStatusOfTheAnswer_PicksTheTypeOfTheResponse(int status, Type expected)
    {
        var response = await CatApiCall.ExecuteAsync<int>(() => throw Failure(status, NotFoundBody), ServiceName);

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.InstanceOf(expected));
    }

    [Test]
    public async Task TheErrorsOfTheService_AreKeptWithTheirArguments()
    {
        var response = await CatApiCall.ExecuteAsync<int>(() => throw Failure(404, NotFoundBody), ServiceName);

        var error = response.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("DEM-ORD-1005"));
        Assert.That(error.Message, Is.EqualTo("Book {BookId} has no price."));
        Assert.That(error.Arguments, Is.EqualTo(new object?[] { "b1", 3L, true, null }));
    }

    [Test]
    public async Task ABodyThatTheGeneratedClientHasRead_IsFoundInTheModel()
    {
        // A generated client keeps no body text for a body it could read. It only keeps the model.
        var model = new CatProblemDetails
        {
            CatErrors = [new CatProblemDetailsItem { Code = "DEM-CTL-1001", Message = "Book {BookId} does not exist.", Arguments = ["b1"] }],
        };

        var response = await CatApiCall.ExecuteAsync<int>(
            () => throw new CatApiException<CatProblemDetails>("Not Found", 404, string.Empty, NoHeaders, model, null),
            ServiceName);

        var error = response.ErrorList.Single();
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.NotFound>());
        Assert.That(error.Code, Is.EqualTo("DEM-CTL-1001"));
        Assert.That(error.Arguments, Is.EqualTo(new object?[] { "b1" }));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("not json")]
    [TestCase("{ \"title\": \"Bad\" }")]
    public async Task AnAnswerWithoutUsableErrors_GivesTheUnexpectedResponseError(string? body)
    {
        var response = await CatApiCall.ExecuteAsync<int>(() => throw Failure(500, body), ServiceName);

        var error = response.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("CAT-GEN-1001"));
        Assert.That(error.Arguments, Is.EqualTo(new object?[] { ServiceName }));
    }

    [Test]
    public async Task AConnectionProblem_GivesAnInternalServerErrorResponse()
    {
        var response = await CatApiCall.ExecuteAsync<int>(() => throw new HttpRequestException("down"), ServiceName);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.InternalServerError>());
        Assert.That(response.ErrorList.Single().Code, Is.EqualTo("CAT-GEN-1001"));
    }

    [Test]
    public async Task ATimeout_GivesAnInternalServerErrorResponse()
    {
        var response = await CatApiCall.ExecuteAsync<int>(() => throw new TaskCanceledException(), ServiceName);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.InternalServerError>());
    }

    [Test]
    public async Task ACancelByTheCaller_IsNotTurnedIntoAResponse()
    {
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();

        await Assert.ThrowsAsync<TaskCanceledException>(() =>
            CatApiCall.ExecuteAsync<int>(() => throw new TaskCanceledException(), ServiceName, cancellation.Token));
    }

    [Test]
    public async Task AnUnknownException_IsNotCaught()
    {
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            CatApiCall.ExecuteAsync<int>(() => throw new InvalidOperationException("bug"), ServiceName));
    }

    [Test]
    public async Task ACallWithoutAValueThatFails_GivesAFailedResponse()
    {
        var response = await CatApiCall.ExecuteAsync(() => throw Failure(409, NotFoundBody), ServiceName);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.Conflict>());
    }
}
