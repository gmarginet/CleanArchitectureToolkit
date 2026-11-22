using Cat.Demo.NotificationService.CoreService.Commands;

namespace Cat.Demo.NotificationService.CoreService.Tests;

[TestFixture]
public class OrderConfirmedMailBuilderTests
{
    private readonly OrderConfirmedMailBuilder _builder = new(MailTestCulture.Localizer());

    [Test]
    public void Build_ShouldAddressTheCustomerAndNameTheOrderAndTheTotal()
    {
        using var culture = MailTestCulture.Use("en");
        var command = new SendOrderConfirmedMailCommand(Guid.NewGuid(), "20261113-0001", 37.5m, "Alice", "alice@example.com");

        var mail = _builder.Build(command);

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
        using var culture = MailTestCulture.Use("en");
        var command = new SendOrderConfirmedMailCommand(Guid.NewGuid(), "20261113-0002", 10m, "", "x@example.com");

        Assert.That(_builder.Build(command).Body, Does.Contain("Hello customer"));
    }

    [Test]
    public void Build_InDutch_ShouldUseDutchTextsAndAComma()
    {
        using var culture = MailTestCulture.Use("nl");
        var command = new SendOrderConfirmedMailCommand(Guid.NewGuid(), "20261113-0003", 12.5m, "Alice", "alice@example.com");

        var mail = _builder.Build(command);

        Assert.Multiple(() =>
        {
            Assert.That(mail.Subject, Is.EqualTo("Je bestelling 20261113-0003 is bevestigd"));
            Assert.That(mail.Body, Does.Contain("Hallo Alice"));
            Assert.That(mail.Body, Does.Contain("EUR 12,50"));
        });
    }

    [Test]
    public void Build_InALanguageWithoutTexts_ShouldFallBackToEnglish()
    {
        using var culture = MailTestCulture.Use("fr");
        var command = new SendOrderConfirmedMailCommand(Guid.NewGuid(), "20261113-0004", 10m, "Alice", "alice@example.com");

        Assert.That(_builder.Build(command).Subject, Is.EqualTo("Your order 20261113-0004 is confirmed"));
    }
}
