using Cat.UnitTesting.EventAggregators;
using ServiceName.CoreService.EventSubscribers;
using ServiceName.CoreService.Events;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameSubscriberTests
{
    [Test]
    public void Create_ShouldSubscribeItself()
    {
        var eventAggregator = new FakeEventAggregator();

        var subscriber = new ItemNameSubscriber(eventAggregator);

        Assert.That(eventAggregator.Subscribers, Has.Member(subscriber));
    }

    [Test]
    public async Task HandleEvent_ShouldComplete()
    {
        var subscriber = new ItemNameSubscriber(new FakeEventAggregator());

        await subscriber.HandleEventAsync(new ItemNameEvent(Guid.NewGuid()));

        Assert.Pass();
    }
}
