using System.Text.Json;
using Cat.Messaging.Abstractions;
using Cat.Messaging.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Messaging.Tests;

[TestFixture]
public class MessageSenderTests
{
    private FakeTransport _transport = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _transport = new FakeTransport();
        var services = new ServiceCollection();
        services.AddSingleton<ICatMessageTransport>(_transport);
        services.AddCatMessagingModule();
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown() => _provider.Dispose();

    [Test]
    public async Task Publish_SendsEventToTopicNamedAfterTheType()
    {
        using var scope = _provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ICatMessageSender>();
        var message = new OrderPlaced { OrderNumber = "ORD-1" };

        await sender.PublishAsync(message);

        var sent = _transport.Sent.Single();
        Assert.That(sent.EntityName, Is.EqualTo("OrderPlaced"));
        Assert.That(sent.Subject, Is.EqualTo("OrderPlaced"));
        Assert.That(sent.Kind, Is.EqualTo(CatMessageKind.Event));
        Assert.That(sent.ContentType, Is.EqualTo("application/json"));
        Assert.That(sent.MessageId, Is.EqualTo(message.MessageId));
        Assert.That(sent.CorrelationId, Is.EqualTo(message.CorrelationId));
        Assert.That(sent.ScheduledAt, Is.Null);
        Assert.That(sent.SessionId, Is.Null);
    }

    [Test]
    public async Task Publish_SerializesTheBodyAsJson()
    {
        using var scope = _provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ICatMessageSender>();

        await sender.PublishAsync(new OrderPlaced { OrderNumber = "ORD-1" });

        using var document = JsonDocument.Parse(_transport.Sent.Single().Body);
        Assert.That(document.RootElement.GetProperty("orderNumber").GetString(), Is.EqualTo("ORD-1"));
    }

    [Test]
    public async Task Send_SendsCommandMessageToQueueWithScheduledTime()
    {
        using var scope = _provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ICatMessageSender>();
        var at = DateTimeOffset.UtcNow.AddHours(24);

        await sender.SendAsync(new ReserveStock { Quantity = 2 }, at);

        var sent = _transport.Sent.Single();
        Assert.That(sent.Kind, Is.EqualTo(CatMessageKind.Command));
        Assert.That(sent.EntityName, Is.EqualTo("ReserveStock"));
        Assert.That(sent.ScheduledAt, Is.EqualTo(at));
    }

    [Test]
    public async Task Send_UsesTheNameFromTheAttributeAndTheSessionId()
    {
        using var scope = _provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ICatMessageSender>();

        await sender.SendAsync(new PaymentExpired { SessionId = "order-7" });

        var sent = _transport.Sent.Single();
        Assert.That(sent.EntityName, Is.EqualTo("payment-expired"));
        Assert.That(sent.Subject, Is.EqualTo("payment-expired"));
        Assert.That(sent.SessionId, Is.EqualTo("order-7"));
    }

    [Test]
    public void NewMessage_GetsNewIdsAndTheCurrentTime()
    {
        var first = new OrderPlaced();
        var second = new OrderPlaced();

        Assert.That(first.MessageId, Is.Not.EqualTo(Guid.Empty));
        Assert.That(first.MessageId, Is.Not.EqualTo(second.MessageId));
        Assert.That(first.CorrelationId, Is.Not.EqualTo(second.CorrelationId));
        Assert.That(first.OccurredAt, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(5)));
    }
}
