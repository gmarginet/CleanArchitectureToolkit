using Cat.UnitTesting.Responses.NUnit;
using ServiceName.CoreService.Messages;
using ServiceName.CoreService.ServiceRequestHandlers;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ExampleReceivedHandlerTests
{
    [Test]
    public async Task Handle_ShouldSucceed()
    {
        var response = await new ExampleReceivedHandler().HandleAsync(new ExampleReceived { Text = "Hello" });

        Assert.That(response, CatIs.Succeeded);
    }
}
