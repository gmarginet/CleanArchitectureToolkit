using Cat.Demo.NotificationService.CoreService.Commands;

namespace Cat.Demo.NotificationService.CoreService.Tests;

[TestFixture]
public class OrderConfirmedMailBuilderTests
{
    [Test]
    public void Build_ShouldAddressTheCustomerAndNameTheOrderAndTheTotal()
    {
        var command = new SendOrderConfirmedMailCommand(Guid.NewGuid(), "20261113-0001", 37.5m, "Alice", "alice@example.com");

        var mail = OrderConfirmedMailBuilder.Build(command);

        Assert.Multiple(() =>
        {
            Assert.That(mail.To, Is.EqualTo("alice@example.com"));
            Assert.That(mail.Subject, Is.EqualTo("Your order 20261113-0001 is confirmed"));
            Assert.That(mail.Body, Does.Contain("Hello Alice"));
            Assert.That(mail.Body, Does.Contain("EUR 37.50"));
        });
    }

    [Test]
    public void Build_ShouldGreetAnUnnamedCustomerAsCustomer()
    {
        var command = new SendOrderConfirmedMailCommand(Guid.NewGuid(), "20261113-0002", 10m, "", "x@example.com");

        Assert.That(OrderConfirmedMailBuilder.Build(command).Body, Does.Contain("Hello customer"));
    }
}
