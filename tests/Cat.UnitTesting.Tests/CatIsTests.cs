using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.UnitTesting.Responses.NUnit;

namespace Cat.UnitTesting.Tests;

[TestFixture]
public class CatIsTests
{
    private static readonly CatErrorDefinition NotThere = CatErrorDefinition.Create("TST-1", "Not there");
    private static readonly CatErrorDefinition TooMany = CatErrorDefinition.Create("TST-2", "Too many");

    private static ICatResponse NotFoundWith(params CatErrorDefinition[] errors)
        => CatResponse.NotFound(errors.Select(error => error.CreateCatError()).ToArray());

    [Test]
    public void Succeeded_ShouldAcceptAnyOutcomeThatSucceeded()
    {
        Assert.That(CatResponse.Ok(), CatIs.Succeeded);
        Assert.That(CatResponse.Created(), CatIs.Succeeded);
        Assert.That(CatResponse.Ok(5), CatIs.Succeeded);
    }

    [Test]
    public void Succeeded_ShouldRejectAFailure()
    {
        Assert.Throws<AssertionException>(() => Assert.That(CatResponse.NotFound(), CatIs.Succeeded));
    }

    [Test]
    public void SucceededWith_ShouldCheckTheType()
    {
        Assert.That(CatResponse.Created(), CatIs.SucceededWith(CatResponseType.Created));
        Assert.Throws<AssertionException>(() => Assert.That(CatResponse.Ok(), CatIs.SucceededWith(CatResponseType.Created)));
    }

    [Test]
    public void Failed_ShouldAcceptAnyFailureAndRejectASuccess()
    {
        Assert.That(CatResponse.Conflict(), CatIs.Failed);
        Assert.Throws<AssertionException>(() => Assert.That(CatResponse.Ok(), CatIs.Failed));
    }

    [Test]
    public void FailedWith_ShouldCheckTheType()
    {
        Assert.That(CatResponse.NotFound(), CatIs.FailedWith(CatResponseType.NotFound));
        Assert.Throws<AssertionException>(() => Assert.That(CatResponse.Conflict(), CatIs.FailedWith(CatResponseType.NotFound)));
    }

    [Test]
    public void FailedWithCode_ShouldAcceptTheCodeAmongSeveralErrors()
    {
        Assert.That(NotFoundWith(NotThere, TooMany), CatIs.FailedWithCode("TST-2"));
        Assert.Throws<AssertionException>(() => Assert.That(NotFoundWith(NotThere), CatIs.FailedWithCode("TST-2")));
    }

    [Test]
    public void FailedWith_TypeAndCode_ShouldCheckBoth()
    {
        Assert.That(NotFoundWith(NotThere), CatIs.FailedWith(CatResponseType.NotFound, "TST-1"));
        Assert.Throws<AssertionException>(() => Assert.That(NotFoundWith(NotThere), CatIs.FailedWith(CatResponseType.Conflict, "TST-1")));
        Assert.Throws<AssertionException>(() => Assert.That(NotFoundWith(NotThere), CatIs.FailedWith(CatResponseType.NotFound, "TST-9")));
    }

    [Test]
    public void ATypedResponse_ShouldWorkLikeAnyOther()
    {
        Assert.That(CatResponse.NotFound<int>(), CatIs.FailedWith(CatResponseType.NotFound));
    }

    [Test]
    public void ANegatedConstraint_ShouldWork()
    {
        Assert.That(CatResponse.Ok(), !CatIs.Failed);
    }

    [Test]
    public void AFailure_ShouldShowTheResponseAndWhatWasExpected()
    {
        var exception = Assert.Throws<AssertionException>(() => Assert.That(NotFoundWith(NotThere), CatIs.FailedWith(CatResponseType.Conflict, "TST-1")));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(exception.Message, Does.Contain("a failed response of type Conflict with error TST-1"));
            Assert.That(exception.Message, Does.Contain("Failed NotFound [TST-1]"));
        }
    }

    [Test]
    public void ANonResponse_ShouldFail()
    {
        object notAResponse = DateTime.Today;

        Assert.Throws<AssertionException>(() => Assert.That(notAResponse, CatIs.Succeeded));
    }
}
