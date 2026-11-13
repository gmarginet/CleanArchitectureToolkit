using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Cat.Demo.NotificationService.CoreService.ServiceRequestHandlers;
using Cat.Demo.NotificationService.CoreService.Validators;
using Cat.Expressions.Extensions;
using Cat.UnitTesting.NUnit;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.NotificationService.CoreService.Tests;

[TestFixture]
public class StockChangedTests : UnitTestBase
{
    private const string Isbn = "9780141036144";

    private ICatValidatorProcessor _validatorProcessor = null!;

    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddCatCompiledMemberExpressionCache();
        services.AddCatValidatorsModule(typeof(StockChangedValidator));
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _validatorProcessor = ServiceProvider.GetRequiredService<ICatValidatorProcessor>();
    }

    private static StockChanged Change(int? oldQuantity, int? newQuantity, int limit = 10, string isbn = Isbn, int warehouseId = 2) => new()
    {
        Isbn = isbn,
        WarehouseId = warehouseId,
        OldQuantity = oldQuantity,
        NewQuantity = newQuantity,
        Limit = limit
    };

    [TestCase(10, 9, true, TestName = "From the limit to below it is a drop")]
    [TestCase(25, 3, true, TestName = "A big drop is a drop")]
    [TestCase(9, 8, false, TestName = "Already below the limit is no new drop")]
    [TestCase(20, 12, false, TestName = "Still at or above the limit is no drop")]
    [TestCase(3, 30, false, TestName = "A rise is no drop")]
    [TestCase(5, null, false, TestName = "A delete is no drop")]
    [TestCase(null, 2, false, TestName = "An insert is no drop")]
    public void IsDrop_ShouldOnlyBeTrueWhenTheQuantityCrossesTheLimitDownwards(int? oldQuantity, int? newQuantity, bool expected)
    {
        Assert.That(StockChangedHandler.IsDrop(Change(oldQuantity, newQuantity)), Is.EqualTo(expected));
    }

    [Test]
    public async Task Handle_WithADrop_ShouldMailTheAdminOfTheSettings()
    {
        var sender = new FakeMailSender();
        var handler = new StockChangedHandler(sender, new NotificationSettings("boss@example.com"));

        var response = await handler.HandleAsync(Change(12, 4));

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(sender.Mails, Has.Count.EqualTo(1));
            Assert.That(sender.Mails[0].To, Is.EqualTo("boss@example.com"));
        });
    }

    [Test]
    public async Task Handle_WithoutADrop_ShouldAnswerSuccessAndSendNothing()
    {
        var sender = new FakeMailSender();
        var handler = new StockChangedHandler(sender, new NotificationSettings("boss@example.com"));

        var response = await handler.HandleAsync(Change(20, 18));

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSucceeded, Is.True);
            Assert.That(sender.Mails, Is.Empty);
        });
    }

    [Test]
    public void Build_ShouldNameTheBookTheWarehouseTheQuantityAndTheLimit()
    {
        var mail = StockDropMailBuilder.Build("admin@example.com", Change(12, 3));

        Assert.Multiple(() =>
        {
            Assert.That(mail.To, Is.EqualTo("admin@example.com"));
            Assert.That(mail.Subject, Is.EqualTo($"Low stock: ISBN {Isbn}"));
            Assert.That(mail.Body, Does.Contain($"The stock of ISBN {Isbn} in warehouse 2 dropped to 3. The limit is 10."));
        });
    }

    [Test]
    public async Task Validate_ShouldAcceptAChangeThatIsNoDrop()
    {
        var response = await _validatorProcessor.ValidateAsync(Change(20, 18));

        Assert.That(response.IsSucceeded, Is.True);
    }

    [Test]
    public async Task Validate_ShouldAcceptAnInsertAndADelete()
    {
        var insert = await _validatorProcessor.ValidateAsync(Change(null, 5));
        var delete = await _validatorProcessor.ValidateAsync(Change(5, null));

        Assert.Multiple(() =>
        {
            Assert.That(insert.IsSucceeded, Is.True);
            Assert.That(delete.IsSucceeded, Is.True);
        });
    }

    [TestCase("", 2, 10, 5, 4, TestName = "No ISBN is malformed")]
    [TestCase("123", 2, 10, 5, 4, TestName = "A short ISBN is malformed")]
    [TestCase(Isbn, 0, 10, 5, 4, TestName = "No warehouse is malformed")]
    [TestCase(Isbn, 2, 0, 5, 4, TestName = "No limit is malformed")]
    [TestCase(Isbn, 2, 10, -1, 4, TestName = "A negative old quantity is malformed")]
    [TestCase(Isbn, 2, 10, 5, -1, TestName = "A negative new quantity is malformed")]
    public async Task Validate_ShouldRejectAMalformedMessage(string isbn, int warehouseId, int limit, int oldQuantity, int newQuantity)
    {
        var response = await _validatorProcessor.ValidateAsync(Change(oldQuantity, newQuantity, limit, isbn, warehouseId));

        Assert.That(response.IsFailed, Is.True);
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
