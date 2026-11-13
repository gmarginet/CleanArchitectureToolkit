using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Cat.Demo.NotificationService.CoreService.ServiceRequestHandlers;

namespace Cat.Demo.NotificationService.CoreService.Tests;

[TestFixture]
public class LowStockReportTests
{
    private static LowStockReport Report(params LowStockLine[] lines) => new() { Limit = 10, Lines = [.. lines] };

    private static LowStockLine Line(string isbn, int quantity) => new() { Isbn = isbn, Warehouse = "Main warehouse", QuantityOnHand = quantity };

    [Test]
    public void Build_ShouldAddressTheAdminAndListEveryItem()
    {
        var mail = LowStockReportMailBuilder.Build("admin@example.com", Report(Line("9780141036144", 2), Line("9780261103573", 4)));

        Assert.Multiple(() =>
        {
            Assert.That(mail.To, Is.EqualTo("admin@example.com"));
            Assert.That(mail.Subject, Is.EqualTo("Low stock: 2 items"));
            Assert.That(mail.Body, Does.Contain("limit of 10"));
            Assert.That(mail.Body, Does.Contain("ISBN 9780141036144, Main warehouse: 2 left"));
            Assert.That(mail.Body, Does.Contain("ISBN 9780261103573, Main warehouse: 4 left"));
        });
    }

    [Test]
    public void Build_WithOneItem_ShouldUseTheSingularInTheSubject()
    {
        var mail = LowStockReportMailBuilder.Build("admin@example.com", Report(Line("9780141036144", 0)));

        Assert.That(mail.Subject, Is.EqualTo("Low stock: 1 item"));
    }

    [Test]
    public async Task Handle_ShouldMailTheReportToTheAdminOfTheSettings()
    {
        var sender = new FakeMailSender();
        var handler = new LowStockReportHandler(sender, new NotificationSettings("boss@example.com"));

        var response = await handler.HandleAsync(Report(Line("9780141036144", 1)));

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(sender.Mails.Single().To, Is.EqualTo("boss@example.com"));
        });
    }

    [Test]
    public async Task Handle_WithoutLines_ShouldSendNothing()
    {
        var sender = new FakeMailSender();
        var handler = new LowStockReportHandler(sender, new NotificationSettings("boss@example.com"));

        var response = await handler.HandleAsync(Report());

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(sender.Mails, Is.Empty);
        });
    }

    private sealed class FakeMailSender : IMailSender
    {
        public List<OutgoingMail> Mails { get; } = [];

        public Task SendAsync(OutgoingMail mail, CancellationToken cancellationToken = default)
        {
            Mails.Add(mail);
            return Task.CompletedTask;
        }
    }
}
