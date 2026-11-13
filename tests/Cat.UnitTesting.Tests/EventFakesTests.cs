using Cat.EventAggregators.Abstractions;
using Cat.UnitTesting.EventAggregators;

namespace Cat.UnitTesting.Tests;

[TestFixture]
public class EventFakesTests
{
    private interface IShopEvent;

    private sealed record Opened(string Name) : IShopEvent;

    private sealed record Closed(string Name) : IShopEvent;

    [Test]
    public async Task RecordingSubscriber_ShouldCollectEveryEventInOrder()
    {
        var subscriber = new RecordingSubscriber<IShopEvent>();

        await subscriber.HandleEventAsync(new Opened("a"));
        await subscriber.HandleEventAsync(new Closed("b"));

        Assert.That(subscriber.Events, Is.EqualTo(new IShopEvent[] { new Opened("a"), new Closed("b") }));
    }

    [Test]
    public async Task PublishAsync_ShouldRecordTheEventAndCallNoSubscriber()
    {
        var aggregator = new FakeEventAggregator();
        var subscriber = new RecordingSubscriber<Opened>();
        aggregator.Subscribe(subscriber);

        await aggregator.PublishAsync(new Opened("a"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(aggregator.Published, Is.EqualTo(new object[] { new Opened("a") }));
            Assert.That(subscriber.Events, Is.Empty);
        }
    }

    [Test]
    public async Task Of_ShouldGiveThePublishedEventsOfOneTypeInOrder()
    {
        var aggregator = new FakeEventAggregator();

        await aggregator.PublishAsync(new Opened("a"));
        await aggregator.PublishAsync(new Closed("b"));
        await aggregator.PublishAsync(new Opened("c"));

        Assert.That(aggregator.Of<Opened>(), Is.EqualTo(new[] { new Opened("a"), new Opened("c") }));
    }

    [Test]
    public void HasSubscribersForEvent_ShouldFollowTheSubscribers()
    {
        var aggregator = new FakeEventAggregator();
        var subscriber = new RecordingSubscriber<Opened>();

        Assert.That(aggregator.HasSubscribersForEvent(typeof(Opened)), Is.False);

        aggregator.Subscribe(subscriber);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(aggregator.HasSubscribersForEvent(typeof(Opened)), Is.True);
            Assert.That(aggregator.HasSubscribersForEvent(typeof(Closed)), Is.False);
        }

        aggregator.Unsubscribe(subscriber);
        Assert.That(aggregator.HasSubscribersForEvent(typeof(Opened)), Is.False);
    }

    [Test]
    public async Task Reset_ShouldClearTheEventsAndTheSubscribers()
    {
        var aggregator = new FakeEventAggregator();
        aggregator.Subscribe(new RecordingSubscriber<Opened>());
        await aggregator.PublishAsync(new Opened("a"));

        aggregator.Reset();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(aggregator.Published, Is.Empty);
            Assert.That(aggregator.Subscribers, Is.Empty);
        }
    }
}
