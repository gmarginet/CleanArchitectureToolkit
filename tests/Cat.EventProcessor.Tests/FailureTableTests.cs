using Cat.EventProcessor.Abstractions;
using Cat.Responses;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class FailureTableTests
{
    private static readonly FakeError Error = new("DEM-ORD-1001", "Something.");

    [TestCase(nameof(CatResponse.BadRequest))]
    [TestCase(nameof(CatResponse.NotFound))]
    [TestCase(nameof(CatResponse.Conflict))]
    [TestCase(nameof(CatResponse.Forbidden))]
    [TestCase(nameof(CatResponse.Unauthorized))]
    public void Settle_DeadLettersAFailureThatTryingAgainWillNotFix(string failure)
    {
        var response = failure switch
        {
            nameof(CatResponse.BadRequest) => CatResponse.BadRequest(Error),
            nameof(CatResponse.NotFound) => CatResponse.NotFound(Error),
            nameof(CatResponse.Conflict) => CatResponse.Conflict(Error),
            nameof(CatResponse.Forbidden) => CatResponse.Forbidden(Error),
            _ => CatResponse.Unauthorized(Error)
        };

        var result = CatFailureTable.Settle(response, new CatReceiveOptions());

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
    }

    [Test]
    public void Settle_CompletesASucceededResponse()
    {
        Assert.That(CatFailureTable.Settle(CatResponse.NoContent(), new CatReceiveOptions()).Settlement, Is.EqualTo(CatSettlement.Complete));
        Assert.That(CatFailureTable.Settle(CatResponse.Created(), new CatReceiveOptions()).Settlement, Is.EqualTo(CatSettlement.Complete));
    }

    [Test]
    public void Settle_LetsTheOptionsOverrideTheTable()
    {
        var options = new CatReceiveOptions();
        options.FailureOverrides["NotFound"] = CatSettlement.Complete;
        options.FailureOverrides["InternalServerError"] = CatSettlement.DeadLetter;

        Assert.That(CatFailureTable.Settle(CatResponse.NotFound(Error), options).Settlement, Is.EqualTo(CatSettlement.Complete));
        Assert.That(CatFailureTable.Settle(CatResponse.InternalServerError(Error), options).Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(CatFailureTable.Settle(CatResponse.Conflict(Error), options).Settlement, Is.EqualTo(CatSettlement.DeadLetter));
    }

    [Test]
    public void Settle_UsesTheResponseTypeAsReasonWhenThereAreNoErrors()
    {
        var result = CatFailureTable.Settle(CatResponse.NotFound(), new CatReceiveOptions());

        Assert.That(result.Reason, Is.EqualTo("NotFound"));
    }
}
