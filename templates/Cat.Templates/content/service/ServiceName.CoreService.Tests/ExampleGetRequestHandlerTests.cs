using Cat.Responses;
using Cat.UnitTesting.Queries;
using Cat.UnitTesting.Responses.NUnit;
using ServiceName.Contracts.ServiceRequests;
using ServiceName.CoreService.Queries;
using ServiceName.CoreService.ServiceRequestHandlers;
using ServiceName.DataModels.Entities;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ExampleGetRequestHandlerTests
{
    [Test]
    public async Task Handle_ShouldSendTheQueryAndMapTheItem()
    {
        var queryProcessor = new FakeQueryProcessor();
        var item = new ExampleItem { Name = "First" };
        queryProcessor.Respond<ExampleGetQuery, ExampleItem>(CatResponse.Ok(item));
        var handler = new ExampleGetRequestHandler(queryProcessor);

        var response = await handler.HandleAsync(new ExampleGetRequest(item.Id));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response, CatIs.Succeeded);
            Assert.That(response.Value!.Name, Is.EqualTo("First"));
            Assert.That(queryProcessor.Queries.Single(), Is.EqualTo(new ExampleGetQuery(item.Id)));
        }
    }
}
