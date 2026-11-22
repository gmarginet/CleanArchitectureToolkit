using Cat.UnitTesting.Responses.NUnit;
using ServiceName.Contracts.ServiceRequests;
using ServiceName.CoreService.ServiceRequestHandlers;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameRequestHandlerTests
{
    [Test]
    public async Task Handle_ShouldSucceed()
    {
        var response = await new ItemNameRequestHandler().HandleAsync(new ItemNameRequest());

        Assert.That(response, CatIs.Succeeded);
    }
}
