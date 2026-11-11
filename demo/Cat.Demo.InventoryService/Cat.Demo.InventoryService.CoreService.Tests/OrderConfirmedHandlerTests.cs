using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Demo.InventoryService.CoreService.ServiceRequestHandlers;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.Tests;

[TestFixture]
public class OrderConfirmedHandlerTests
{
    private FakeCommandProcessor _commandProcessor = null!;
    private OrderConfirmedHandler _handler = null!;

    [SetUp]
    public void SetUp()
    {
        _commandProcessor = new FakeCommandProcessor();
        _handler = new OrderConfirmedHandler(_commandProcessor);
    }

    private static OrderConfirmed Message() => new() { OrderId = Guid.NewGuid(), OrderNumber = "20261111-0001", Total = 25m };

    [Test]
    public async Task Handle_ShouldConfirmTheReservationsOfTheOrder()
    {
        var response = await _handler.HandleAsync(Message());

        var command = (StockReservationConfirmCommand)_commandProcessor.Commands.Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(command.OrderNumber, Is.EqualTo("20261111-0001"));
        }
    }

    [Test]
    public async Task Handle_WhenTheOrderHasNoReservation_ShouldPassTheNotFoundOn()
    {
        _commandProcessor.Response = CatResponse.NotFound(InventoryErrorDefinitions.UnknownOrder.CreateCatError("20261111-0001"));

        var response = await _handler.HandleAsync(Message());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.Type, Is.TypeOf<CatResponseType.Failed.NotFound>());
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(InventoryErrorDefinitions.UnknownOrder.Code));
        }
    }
}
