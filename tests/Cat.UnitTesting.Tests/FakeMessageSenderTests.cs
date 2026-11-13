using Cat.Messaging.Abstractions;
using Cat.UnitTesting.Messaging;

namespace Cat.UnitTesting.Tests;

[TestFixture]
public class FakeMessageSenderTests
{
    private sealed class OrderPlaced : CatEventMessage;

    private sealed class SendMail : CatCommandMessage;

    [Test]
    public async Task PublishAsync_And_SendAsync_ShouldRecordBothInOrderWithTheirSchedule()
    {
        var sender = new FakeMessageSender();
        var published = new OrderPlaced();
        var sent = new SendMail();
        var at = new DateTimeOffset(2026, 11, 14, 8, 0, 0, TimeSpan.Zero);

        await sender.PublishAsync(published);
        await sender.SendAsync(sent, at);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(sender.Sent.Select(item => item.Message), Is.EqualTo(new ICatMessage[] { published, sent }));
            Assert.That(sender.Sent.Select(item => item.ScheduledAt), Is.EqualTo(new DateTimeOffset?[] { null, at }));
        }
    }

    [Test]
    public async Task Of_ShouldFilterByMessageClassOrByKind()
    {
        var sender = new FakeMessageSender();
        await sender.PublishAsync(new OrderPlaced());
        await sender.SendAsync(new SendMail());
        await sender.PublishAsync(new OrderPlaced());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(sender.Of<OrderPlaced>().Count(), Is.EqualTo(2));
            Assert.That(sender.Of<ICatCommandMessage>().Count(), Is.EqualTo(1));
            Assert.That(sender.Of<ICatEventMessage>().Count(), Is.EqualTo(2));
        }
    }

    [Test]
    public async Task Reset_ShouldClearTheMessages()
    {
        var sender = new FakeMessageSender();
        await sender.PublishAsync(new OrderPlaced());

        sender.Reset();

        Assert.That(sender.Sent, Is.Empty);
    }
}
