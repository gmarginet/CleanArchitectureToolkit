using Cat.Responses.Abstractions;

namespace Cat.Responses.Tests;

[TestFixture]
public class CatResponseTypeTests
{
    [Test]
    public void SucceededTypes_AreSucceededAndNotFailed()
    {
        Assert.That(CatResponseType.Ok, Is.InstanceOf<CatResponseType.Succeeded>());
        Assert.That(CatResponseType.Created, Is.InstanceOf<CatResponseType.Succeeded>());
        Assert.That(CatResponseType.NoContent, Is.InstanceOf<CatResponseType.Succeeded>());

        Assert.That(CatResponseType.Ok, Is.Not.InstanceOf<CatResponseType.Failed>());
        Assert.That(CatResponseType.Created, Is.Not.InstanceOf<CatResponseType.Failed>());
        Assert.That(CatResponseType.NoContent, Is.Not.InstanceOf<CatResponseType.Failed>());
    }

    [Test]
    public void FailedTypes_AreFailedAndNotSucceeded()
    {
        Assert.That(CatResponseType.BadRequest, Is.InstanceOf<CatResponseType.Failed>());
        Assert.That(CatResponseType.NotFound, Is.InstanceOf<CatResponseType.Failed>());
        Assert.That(CatResponseType.Unauthorized, Is.InstanceOf<CatResponseType.Failed>());
        Assert.That(CatResponseType.InternalServerError, Is.InstanceOf<CatResponseType.Failed>());

        Assert.That(CatResponseType.BadRequest, Is.Not.InstanceOf<CatResponseType.Succeeded>());
        Assert.That(CatResponseType.NotFound, Is.Not.InstanceOf<CatResponseType.Succeeded>());
        Assert.That(CatResponseType.Unauthorized, Is.Not.InstanceOf<CatResponseType.Succeeded>());
        Assert.That(CatResponseType.InternalServerError, Is.Not.InstanceOf<CatResponseType.Succeeded>());
    }

    [Test]
    public void EachProperty_ReturnsItsOwnTypeAndNoOtherOne()
    {
        Assert.That(CatResponseType.Ok, Is.TypeOf<CatResponseType.Succeeded.Ok>());
        Assert.That(CatResponseType.Created, Is.TypeOf<CatResponseType.Succeeded.Created>());
        Assert.That(CatResponseType.NoContent, Is.TypeOf<CatResponseType.Succeeded.NoContent>());
        Assert.That(CatResponseType.BadRequest, Is.TypeOf<CatResponseType.Failed.BadRequest>());
        Assert.That(CatResponseType.NotFound, Is.TypeOf<CatResponseType.Failed.NotFound>());
        Assert.That(CatResponseType.Unauthorized, Is.TypeOf<CatResponseType.Failed.Unauthorized>());
        Assert.That(CatResponseType.InternalServerError, Is.TypeOf<CatResponseType.Failed.InternalServerError>());
    }

    [Test]
    public void ASwitchOnTheTypes_PicksTheMostSpecificPatternFirst()
    {
        static string Describe(CatResponseType type) => type switch
        {
            CatResponseType.Succeeded.Created => "created",
            CatResponseType.Succeeded => "succeeded",
            CatResponseType.Failed.NotFound => "not found",
            CatResponseType.Failed => "failed",
            _ => "unknown"
        };

        Assert.That(Describe(CatResponseType.Created), Is.EqualTo("created"));
        Assert.That(Describe(CatResponseType.Ok), Is.EqualTo("succeeded"));
        Assert.That(Describe(CatResponseType.NotFound), Is.EqualTo("not found"));
        Assert.That(Describe(CatResponseType.BadRequest), Is.EqualTo("failed"));
    }
}
