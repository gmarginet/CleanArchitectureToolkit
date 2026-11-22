using Cat.UnitTesting.Responses.NUnit;
using MESSAGE_NAMESPACE;
using ServiceName.CoreService.ServiceRequestHandlers;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameHandlerTests
{
    [Test]
    public async Task Handle_ShouldSucceed()
    {
        var response = await new ItemNameHandler().HandleAsync(new ItemName());

        Assert.That(response, CatIs.Succeeded);
    }
}
