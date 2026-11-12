using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Cat.EventProcessor.AzureServiceBus;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class ServiceBusOverrideTests
{
    [Test]
    public void Processor_WithoutCallback_KeepsTheDefaultsAndSettlesItself()
    {
        var defaults = new ServiceBusProcessorOptions();

        var options = ServiceBusListener.BuildProcessorOptions(typeof(string), null, null);

        Assert.That(options.AutoCompleteMessages, Is.False);
        Assert.That(options.MaxConcurrentCalls, Is.EqualTo(defaults.MaxConcurrentCalls));
        Assert.That(options.PrefetchCount, Is.EqualTo(defaults.PrefetchCount));
        Assert.That(options.MaxAutoLockRenewalDuration, Is.EqualTo(defaults.MaxAutoLockRenewalDuration));
    }

    [Test]
    public void Processor_Callback_GetsTheMessageTypeAndTheConcurrencyOfThatType()
    {
        Type? seenType = null;
        int? seenConcurrency = null;

        ServiceBusListener.BuildProcessorOptions(typeof(OrderPlaced), 4, (type, options) =>
        {
            seenType = type;
            seenConcurrency = options.MaxConcurrentCalls;
        });

        Assert.That(seenType, Is.EqualTo(typeof(OrderPlaced)));
        Assert.That(seenConcurrency, Is.EqualTo(4));
    }

    [Test]
    public void Processor_Callback_WinsOverTheConcurrencyOfTheMessageType()
    {
        var options = ServiceBusListener.BuildProcessorOptions(typeof(OrderPlaced), 4, (_, processor) =>
        {
            processor.MaxConcurrentCalls = 9;
            processor.PrefetchCount = 20;
        });

        Assert.That(options.MaxConcurrentCalls, Is.EqualTo(9));
        Assert.That(options.PrefetchCount, Is.EqualTo(20));
    }

    [Test]
    public void Processor_Callback_CannotTurnAutoCompleteOn()
    {
        var options = ServiceBusListener.BuildProcessorOptions(typeof(OrderPlaced), null,
            (_, processor) => processor.AutoCompleteMessages = true);

        Assert.That(options.AutoCompleteMessages, Is.False);
    }

    [Test]
    public void SessionProcessor_WithoutCallback_KeepsTheDefaultsAndSettlesItself()
    {
        var defaults = new ServiceBusSessionProcessorOptions();

        var options = ServiceBusListener.BuildSessionProcessorOptions(typeof(string), null, null);

        Assert.That(options.AutoCompleteMessages, Is.False);
        Assert.That(options.MaxConcurrentSessions, Is.EqualTo(defaults.MaxConcurrentSessions));
        Assert.That(options.SessionIdleTimeout, Is.EqualTo(defaults.SessionIdleTimeout));
    }

    [Test]
    public void SessionProcessor_Callback_GetsTheMessageTypeAndWinsOverTheSessions()
    {
        Type? seenType = null;

        var options = ServiceBusListener.BuildSessionProcessorOptions(typeof(OrderPlaced), 2, (type, processor) =>
        {
            seenType = type;
            processor.MaxConcurrentSessions = 5;
            processor.AutoCompleteMessages = true;
        });

        Assert.That(seenType, Is.EqualTo(typeof(OrderPlaced)));
        Assert.That(options.MaxConcurrentSessions, Is.EqualTo(5));
        Assert.That(options.AutoCompleteMessages, Is.False);
    }

    [Test]
    public void Subscription_WithoutCallback_KeepsTheDefaultsOfTheSdk()
    {
        var defaults = new CreateSubscriptionOptions("x", "y");

        var options = EventProcessorTopology.BuildSubscriptionOptions("OrderPlaced", "inventory");

        Assert.That(options.TopicName, Is.EqualTo("OrderPlaced"));
        Assert.That(options.SubscriptionName, Is.EqualTo("inventory"));
        Assert.That(options.MaxDeliveryCount, Is.EqualTo(defaults.MaxDeliveryCount));
        Assert.That(options.LockDuration, Is.EqualTo(defaults.LockDuration));
    }

    [Test]
    public void Subscription_Callback_CanChangeAnOption()
    {
        var options = EventProcessorTopology.BuildSubscriptionOptions("OrderPlaced", "inventory",
            subscription => subscription.MaxDeliveryCount = 3);

        Assert.That(options.MaxDeliveryCount, Is.EqualTo(3));
    }
}
