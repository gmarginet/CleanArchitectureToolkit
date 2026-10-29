using System.Runtime.CompilerServices;
using Cat.EventAggregators.Abstractions;
using Cat.EventAggregators.Extensions;
using Cat.EventAggregators.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventAggregators.Tests;

[TestFixture]
public class EventAggregatorEdgeCaseTests
{
    private ServiceProvider _provider = null!;

    private ICatEventAggregator Aggregator => _provider.GetRequiredService<ICatEventAggregator>();

    [SetUp]
    public void SetUp()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatEventAggregatorsModule();
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown()
    {
        _provider.Dispose();
    }

    #region Arguments

    [Test]
    public void Subscribe_Null_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => Aggregator.Subscribe(null!));
    }

    [Test]
    public void Unsubscribe_Null_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => Aggregator.Unsubscribe(null!));
    }

    [Test]
    public void PublishAsync_Null_Throws()
    {
        Assert.ThrowsAsync<ArgumentNullException>(async () => await Aggregator.PublishAsync(null!));
    }

    #endregion Arguments

    #region Subscribing

    [Test]
    public async Task Subscribe_TheSameSubscriberTwice_HandlesAnEventOnlyOnce()
    {
        var subscriber = new CountingSubscriber();

        Aggregator.Subscribe(subscriber);
        Aggregator.Subscribe(subscriber);
        await Aggregator.PublishAsync(new OrderPlacedEvent("1"));

        Assert.That(subscriber.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task Subscribe_SeveralSubscribers_AllReceiveTheEvent()
    {
        var first = new CountingSubscriber();
        var second = new CountingSubscriber();
        Aggregator.Subscribe(first);
        Aggregator.Subscribe(second);

        await Aggregator.PublishAsync(new OrderPlacedEvent("1"));

        Assert.That(first.Count, Is.EqualTo(1));
        Assert.That(second.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task Subscribe_ASubscriberWithoutEventHandlers_IsIgnored()
    {
        var subscriber = new NoHandlersSubscriber();

        Aggregator.Subscribe(subscriber);

        Assert.That(Aggregator.HasSubscribersForEvent(typeof(OrderPlacedEvent)), Is.False);
        Assert.DoesNotThrowAsync(async () => await Aggregator.PublishAsync(new OrderPlacedEvent("1")));
        await Task.CompletedTask;
    }

    [Test]
    public async Task Subscribe_ASubscriberForTwoEventTypes_ReceivesBoth()
    {
        var subscriber = new MultiEventSubscriber();
        Aggregator.Subscribe(subscriber);

        await Aggregator.PublishAsync(new OrderPlacedEvent("1"));
        await Aggregator.PublishAsync(new OrderShippedEvent("1"));

        Assert.That(subscriber.Seen, Is.EqualTo(new[] { "placed:1", "shipped:1" }));
    }

    [Test]
    public void HasSubscribersForEvent_OnlyForTheEventsTheSubscriberHandles()
    {
        Aggregator.Subscribe(new CountingSubscriber());

        Assert.That(Aggregator.HasSubscribersForEvent(typeof(OrderPlacedEvent)), Is.True);
        Assert.That(Aggregator.HasSubscribersForEvent(typeof(OrderShippedEvent)), Is.False);
    }

    #endregion Subscribing

    #region Unsubscribing

    [Test]
    public void Unsubscribe_ASubscriberThatWasNeverSubscribed_DoesNothing()
    {
        Assert.DoesNotThrow(() => Aggregator.Unsubscribe(new CountingSubscriber()));
    }

    [Test]
    public async Task Unsubscribe_StopsTheEventsFromArriving()
    {
        var subscriber = new CountingSubscriber();
        Aggregator.Subscribe(subscriber);
        await Aggregator.PublishAsync(new OrderPlacedEvent("1"));

        Aggregator.Unsubscribe(subscriber);
        await Aggregator.PublishAsync(new OrderPlacedEvent("2"));

        Assert.That(subscriber.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task Unsubscribe_OnlyRemovesThatSubscriber()
    {
        var first = new CountingSubscriber();
        var second = new CountingSubscriber();
        Aggregator.Subscribe(first);
        Aggregator.Subscribe(second);

        Aggregator.Unsubscribe(first);
        await Aggregator.PublishAsync(new OrderPlacedEvent("1"));

        Assert.That(first.Count, Is.EqualTo(0));
        Assert.That(second.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task Subscribe_AfterUnsubscribing_WorksAgain()
    {
        var subscriber = new CountingSubscriber();
        Aggregator.Subscribe(subscriber);
        Aggregator.Unsubscribe(subscriber);

        Aggregator.Subscribe(subscriber);
        await Aggregator.PublishAsync(new OrderPlacedEvent("1"));

        Assert.That(subscriber.Count, Is.EqualTo(1));
    }

    #endregion Unsubscribing

    #region Publishing

    [Test]
    public async Task PublishAsync_PassesTheCancellationTokenToTheHandler()
    {
        using var source = new CancellationTokenSource();
        var subscriber = new CountingSubscriber();
        Aggregator.Subscribe(subscriber);

        await Aggregator.PublishAsync(new OrderPlacedEvent("1"), source.Token);

        Assert.That(subscriber.LastToken, Is.EqualTo(source.Token));
    }

    [Test]
    public async Task PublishAsync_WaitsForAllHandlersToFinish()
    {
        var slow = new SlowSubscriber();
        Aggregator.Subscribe(slow);

        await Aggregator.PublishAsync(new OrderPlacedEvent("1"));

        Assert.That(slow.Done, Is.True);
    }

    [Test]
    public async Task PublishAsync_OnlyHandlersOfThatEventTypeRun()
    {
        var subscriber = new MultiEventSubscriber();
        Aggregator.Subscribe(subscriber);

        await Aggregator.PublishAsync(new OrderShippedEvent("9"));

        Assert.That(subscriber.Seen, Is.EqualTo(new[] { "shipped:9" }));
    }

    [Test]
    public async Task PublishAsync_AHandlerFails_TheExceptionReachesThePublisher()
    {
        Aggregator.Subscribe(new ThrowingSubscriber());

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Aggregator.PublishAsync(new OrderPlacedEvent("1")));

        Assert.That(exception!.Message, Is.EqualTo("handler failed"));
        await Task.CompletedTask;
    }

    [Test]
    public async Task PublishAsync_AHandlerFails_TheOtherHandlersStillRun()
    {
        var counting = new CountingSubscriber();
        Aggregator.Subscribe(new ThrowingSubscriber());
        Aggregator.Subscribe(counting);

        Assert.ThrowsAsync<InvalidOperationException>(async () => await Aggregator.PublishAsync(new OrderPlacedEvent("1")));

        Assert.That(counting.Count, Is.EqualTo(1));
        await Task.CompletedTask;
    }

    [Test]
    public async Task PublishAsync_ManyEventsAtTheSameTime_AreAllHandled()
    {
        var subscriber = new CountingSubscriber();
        Aggregator.Subscribe(subscriber);

        await Task.WhenAll(Enumerable.Range(0, 50).Select(i => Aggregator.PublishAsync(new OrderPlacedEvent(i.ToString()))));

        Assert.That(subscriber.Count, Is.EqualTo(50));
    }

    #endregion Publishing

    #region Subscribers that are gone

    [MethodImpl(MethodImplOptions.NoInlining)]
    private WeakReference SubscribeAndForget()
    {
        var subscriber = new CountingSubscriber();
        Aggregator.Subscribe(subscriber);
        return new WeakReference(subscriber);
    }

    [Test]
    public void Subscribe_TheAggregatorDoesNotKeepTheSubscriberAlive()
    {
        var reference = SubscribeAndForget();

        for (var i = 0; i < 5 && reference.IsAlive; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        if (reference.IsAlive) Assert.Inconclusive("The garbage collector did not collect the subscriber.");

        Assert.That(Aggregator.HasSubscribersForEvent(typeof(OrderPlacedEvent)), Is.False);
    }

    [Test]
    public async Task PublishAsync_ASubscriberThatIsGone_IsSkippedWithoutAnError()
    {
        var reference = SubscribeAndForget();
        for (var i = 0; i < 5 && reference.IsAlive; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        if (reference.IsAlive) Assert.Inconclusive("The garbage collector did not collect the subscriber.");

        Assert.DoesNotThrowAsync(async () => await Aggregator.PublishAsync(new OrderPlacedEvent("1")));
        await Task.CompletedTask;
    }

    #endregion Subscribers that are gone
}
