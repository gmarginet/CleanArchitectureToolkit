using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.InventoryService.CoreService.ServiceRequestHandlers;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.Tests;

[TestFixture]
public class LowStockReportRequestHandlerTests
{
    private FakeCommandProcessor _commandProcessor = null!;
    private LowStockReportRequestHandler _handler = null!;

    [SetUp]
    public void SetUp()
    {
        _commandProcessor = new FakeCommandProcessor();
        _handler = new LowStockReportRequestHandler(_commandProcessor, new LowStockSettings(7));
    }

    [Test]
    public async Task Handle_ShouldPublishTheReportWithTheLimitOfTheSettings()
    {
        var response = await _handler.HandleAsync(new LowStockReportRequest());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Succeeded.NoContent>());
            Assert.That(_commandProcessor.Commands.Single(), Is.EqualTo(new LowStockReportPublishCommand(7)));
        }
    }

    [Test]
    public async Task Handle_WhenTheCommandFails_ShouldPassTheFailureOn()
    {
        _commandProcessor.Response = CatResponse.InternalServerError();

        var response = await _handler.HandleAsync(new LowStockReportRequest());

        Assert.That(response.IsFailed, Is.True);
    }
}
