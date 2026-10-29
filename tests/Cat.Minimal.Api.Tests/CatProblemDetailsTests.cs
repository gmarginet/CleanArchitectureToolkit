using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Minimal.Api.Tests;

[TestFixture]
public class CatProblemDetailsTests
{
    private static readonly ICatError Error = CatError.Create("T-1", "Something {what} failed", "odd");

    [Test]
    public void BadRequest_Gives400()
    {
        var details = new CatProblemDetails(CatResponse.BadRequest(Error), "/orders", "trace-1");

        Assert.That(details.Status, Is.EqualTo(400));
        Assert.That(details.Title, Is.EqualTo("A bad request was made."));
    }

    [Test]
    public void NotFound_Gives404()
    {
        var details = new CatProblemDetails(CatResponse.NotFound(Error), "/orders", "trace-1");

        Assert.That(details.Status, Is.EqualTo(404));
        Assert.That(details.Title, Is.EqualTo("The requested resource was not found."));
    }

    [Test]
    public void Unauthorized_Gives401()
    {
        var details = new CatProblemDetails(CatResponse.Unauthorized(Error), "/orders", "trace-1");

        Assert.That(details.Status, Is.EqualTo(401));
    }

    [Test]
    public void InternalServerError_Gives500()
    {
        var details = new CatProblemDetails(CatResponse.InternalServerError(Error), "/orders", "trace-1");

        Assert.That(details.Status, Is.EqualTo(500));
        Assert.That(details.Title, Is.EqualTo("An unexpected error occurred."));
    }

    [Test]
    public void ASucceededResponse_FallsBackTo500()
    {
        var details = new CatProblemDetails(CatResponse.Ok(), "/orders", "trace-1");

        Assert.That(details.Status, Is.EqualTo(500));
    }

    [Test]
    public void TheDetailsPointToTheErrors()
    {
        var details = new CatProblemDetails(CatResponse.BadRequest(Error), "/orders", "trace-1");

        Assert.That(details.Detail, Is.EqualTo("Look at the CatErrors property for more details."));
    }

    [Test]
    public void TheErrorsInstanceAndTraceIdAreKept()
    {
        var second = CatError.Create("T-2", "second");

        var details = new CatProblemDetails(CatResponse.BadRequest(Error, second), "/orders", "trace-1");

        Assert.That(details.CatErrors, Is.EqualTo(new[] { Error, second }));
        Assert.That(details.Instance, Is.EqualTo("/orders"));
        Assert.That(details.CatTraceId, Is.EqualTo("trace-1"));
    }

    [Test]
    public void TheParameterlessConstructor_StartsEmpty()
    {
        var details = new CatProblemDetails();

        Assert.That(details.Status, Is.Null);
        Assert.That(details.Title, Is.Null);
        Assert.That(details.CatErrors, Is.Null);
        Assert.That(details.CatTraceId, Is.Null);
    }
}
