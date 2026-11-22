using Cat.UnitTesting.Responses.NUnit;
using ServiceName.Contracts.ServiceRequests;
using ServiceName.CoreService.ServiceRequestHandlers;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ExampleJobRequestHandlerTests
{
    [Test]
    public async Task Handle_ShouldSucceed()
    {
        var response = await new ExampleJobRequestHandler().HandleAsync(new ExampleJobRequest());

        Assert.That(response, CatIs.Succeeded);
    }
}
