using System.Text.Json;
using Cat.Api.Client;
using Cat.Responses;

using ServiceProblemDetails = Cat.Minimal.Api.CatProblemDetails;

namespace Cat.Api.Client.Tests;

/// <summary>
/// Keeps <see cref="CatProblemDetails"/> of the client equal to the body that <see cref="ServiceProblemDetails"/> of <c>Cat.Minimal.Api</c> sends.
/// </summary>
[TestFixture]
public class CatProblemDetailsTests
{
    [Test]
    public void ABodyOfAService_IsReadIntoTheClientClass()
    {
        var sent = new ServiceProblemDetails
        {
            Type = "https://example.test/problem",
            Title = "Not Found",
            Status = 404,
            Detail = "Look at the CatErrors property.",
            Instance = "/catalog/books/1",
            CatErrors = [CatError.Create("CAT-CTL-1001", "Book {Id} was not found.", "Id", "b1")],
            CatTraceId = "trace-1",
        };

        var json = JsonSerializer.Serialize(sent, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        var received = JsonSerializer.Deserialize<CatProblemDetails>(json);

        Assert.That(received, Is.Not.Null);
        Assert.That(received!.Type, Is.EqualTo(sent.Type));
        Assert.That(received.Title, Is.EqualTo(sent.Title));
        Assert.That(received.Status, Is.EqualTo(sent.Status));
        Assert.That(received.Detail, Is.EqualTo(sent.Detail));
        Assert.That(received.Instance, Is.EqualTo(sent.Instance));
        Assert.That(received.CatTraceId, Is.EqualTo(sent.CatTraceId));
        Assert.That(received.CatErrors, Has.Count.EqualTo(1));
        Assert.That(received.CatErrors![0].Code, Is.EqualTo("CAT-CTL-1001"));
        Assert.That(received.CatErrors[0].Message, Is.EqualTo("Book {Id} was not found."));
        Assert.That(received.CatErrors[0].Arguments, Has.Count.EqualTo(2));
    }

    [Test]
    public void TheClientClass_HasTheSamePropertyNamesAsTheBodyOfTheService()
    {
        var sent = JsonSerializer.Serialize(
            new ServiceProblemDetails { Type = "t", Title = "t", Status = 1, Detail = "t", Instance = "t", CatErrors = [CatError.Create("c", "m")], CatTraceId = "t" },
            new JsonSerializerOptions(JsonSerializerDefaults.Web));
        var client = JsonSerializer.Serialize(
            new CatProblemDetails { Type = "t", Title = "t", Status = 1, Detail = "t", Instance = "t", CatErrors = [new CatProblemDetailsItem { Code = "c", Message = "m", Arguments = [] }], CatTraceId = "t" });

        Assert.That(Names(client), Is.EquivalentTo(Names(sent)));
        Assert.That(Names(JsonDocument.Parse(client).RootElement.GetProperty("catErrors")[0]),
            Is.EquivalentTo(Names(JsonDocument.Parse(sent).RootElement.GetProperty("catErrors")[0])));
    }

    private static IEnumerable<string> Names(string json) => Names(JsonDocument.Parse(json).RootElement);

    private static IEnumerable<string> Names(JsonElement element) => element.EnumerateObject().Select(property => property.Name);
}
