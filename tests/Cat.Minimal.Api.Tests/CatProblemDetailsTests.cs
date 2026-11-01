using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Cat.Minimal.Api.Tests;

[TestFixture]
public class CatProblemDetailsTests
{
    private static readonly ICatError Error = CatError.Create("T-1", "Something {what} failed", "odd");

    [Test]
    public void ANewInstance_StartsEmpty()
    {
        var details = new CatProblemDetails();

        Assert.That(details.Status, Is.Null);
        Assert.That(details.Title, Is.Null);
        Assert.That(details.CatErrors, Is.Null);
        Assert.That(details.CatTraceId, Is.Null);
    }

    [Test]
    public void TheCatPropertiesAreKept()
    {
        var details = new CatProblemDetails
        {
            CatErrors = [Error],
            CatTraceId = "trace-1"
        };

        Assert.That(details.CatErrors, Is.EqualTo(new[] { Error }));
        Assert.That(details.CatTraceId, Is.EqualTo("trace-1"));
    }

    [Test]
    public void ItIsAStandardProblemDetails()
    {
        Assert.That(new CatProblemDetails(), Is.InstanceOf<ProblemDetails>());
    }
}
