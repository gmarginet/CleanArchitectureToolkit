using Cat.Demo.InventoryService.Contracts.Models;
using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.InventoryService.CoreService.ServiceRequestHandlers;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.Tests;

[TestFixture]
public class StockRequestHandlerTests
{
    private const string IsbnA = "9780141036144";
    private const string IsbnB = "9780261103573";

    private FakeCommandProcessor _commandProcessor = null!;

    [SetUp]
    public void SetUp()
    {
        _commandProcessor = new FakeCommandProcessor();
    }

    private static StockReserveRequest Reserve(params (string Isbn, int Quantity)[] lines) => new(new StockReservationModel
    {
        OrderNumber = "20261106-0001",
        Lines = [.. lines.Select(l => new StockLineModel { Isbn = l.Isbn, Quantity = l.Quantity })]
    });

    [Test]
    public async Task Reserve_ShouldSendOneCommandWithTheOrderNumberAndTheLines()
    {
        var handler = new StockReserveRequestHandler(_commandProcessor);

        var response = await handler.HandleAsync(Reserve((IsbnA, 2), (IsbnB, 1)));

        var command = (StockReserveCommand)_commandProcessor.Commands.Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(command.OrderNumber, Is.EqualTo("20261106-0001"));
            Assert.That(command.Lines, Is.EqualTo(new[] { new StockLine(IsbnA, 2), new StockLine(IsbnB, 1) }));
        }
    }

    [Test]
    public async Task Reserve_WhenABookIsOnTwoLines_ShouldReserveTheSumOnce()
    {
        var handler = new StockReserveRequestHandler(_commandProcessor);

        await handler.HandleAsync(Reserve((IsbnA, 2), (IsbnB, 1), (IsbnA, 3)));

        var command = (StockReserveCommand)_commandProcessor.Commands.Single();
        Assert.That(command.Lines, Is.EqualTo(new[] { new StockLine(IsbnA, 5), new StockLine(IsbnB, 1) }));
    }

    [Test]
    public async Task Reserve_WhenTheCommandFails_ShouldPassTheFailureOn()
    {
        _commandProcessor.Response = CatResponse.Conflict(InventoryErrorDefinitions.OutOfStock.CreateCatError(IsbnA, "20261106-0001"));
        var handler = new StockReserveRequestHandler(_commandProcessor);

        var response = await handler.HandleAsync(Reserve((IsbnA, 51)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.Conflict>());
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(InventoryErrorDefinitions.OutOfStock.Code));
        }
    }

    [Test]
    public async Task Release_ShouldSendTheCommandWithTheOrderNumber()
    {
        var handler = new StockReleaseRequestHandler(_commandProcessor);

        var response = await handler.HandleAsync(new StockReleaseRequest("20261106-0001"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(_commandProcessor.Commands.Single(), Is.EqualTo(new StockReleaseCommand("20261106-0001")));
        }
    }
}
