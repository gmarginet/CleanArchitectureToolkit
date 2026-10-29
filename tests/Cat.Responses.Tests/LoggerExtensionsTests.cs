using Cat.Responses.Abstractions.Extensions;
using Cat.Responses.Tests.Helpers;
using Microsoft.Extensions.Logging;

namespace Cat.Responses.Tests;

[TestFixture]
public class LoggerExtensionsTests
{
    [Test]
    public void LogCatResponseErrors_LogsTheMessageAndOneEntryPerError()
    {
        var logger = new TestLogger();
        var response = CatResponse.BadRequest(
            CatError.Create("T-1", "Product {name} is missing", "Chair"),
            CatError.Create("T-2", "Amount {amount} is too low", 3));

        logger.LogCatResponseErrors(response, "Could not process {request}", "OrderRequest");

        Assert.That(logger.Entries, Has.Count.EqualTo(3));
        Assert.That(logger.Entries.Select(e => e.Level), Is.All.EqualTo(LogLevel.Error));
        Assert.That(logger.Entries[0].Message, Is.EqualTo("Could not process OrderRequest"));
        Assert.That(logger.Entries[1].Message, Does.StartWith("\t"));
        Assert.That(logger.Entries[1].Message, Does.Contain("T-1").And.Contain("Product Chair is missing"));
        Assert.That(logger.Entries[2].Message, Does.Contain("T-2").And.Contain("Amount 3 is too low"));
    }

    [Test]
    public void LogCatResponseErrors_ResponseWithoutErrors_LogsOnlyTheMessage()
    {
        var logger = new TestLogger();

        logger.LogCatResponseErrors(CatResponse.Ok(), "Nothing wrong");

        Assert.That(logger.Entries, Has.Count.EqualTo(1));
        Assert.That(logger.Entries[0].Message, Is.EqualTo("Nothing wrong"));
    }
}
