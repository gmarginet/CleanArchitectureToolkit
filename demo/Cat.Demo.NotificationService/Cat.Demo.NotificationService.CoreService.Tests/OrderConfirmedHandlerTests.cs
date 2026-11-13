using Cat.Commands.Abstractions;
using Cat.Demo.NotificationService.CoreService.Commands;
using Cat.Demo.NotificationService.CoreService.ServiceRequestHandlers;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.UnitTesting.Commands;
using Cat.UnitTesting.Responses.NUnit;

namespace Cat.Demo.NotificationService.CoreService.Tests;

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

    private static OrderConfirmed Message(string email) => new()
    {
        OrderId = Guid.NewGuid(),
        OrderNumber = "20261113-0001",
        Total = 25m,
        CustomerName = "Alice",
        CustomerEmail = email
    };

    [Test]
    public async Task Handle_ShouldSendTheMailCommandWithTheDataOfTheMessage()
    {
        var message = Message("alice@example.com");

        var response = await _handler.HandleAsync(message);

        Assert.Multiple(() =>
        {
            Assert.That(response, CatIs.Succeeded);
            Assert.That(
                _commandProcessor.Commands.Single(),
                Is.EqualTo(new SendOrderConfirmedMailCommand(message.OrderId, "20261113-0001", 25m, "Alice", "alice@example.com")));
        });
    }

    [Test]
    public async Task Handle_ShouldSendNothingWhenTheCustomerHasNoEmail()
    {
        var response = await _handler.HandleAsync(Message(""));

        Assert.Multiple(() =>
        {
            Assert.That(response, CatIs.Succeeded);
            Assert.That(_commandProcessor.Commands, Is.Empty);
        });
    }

}
