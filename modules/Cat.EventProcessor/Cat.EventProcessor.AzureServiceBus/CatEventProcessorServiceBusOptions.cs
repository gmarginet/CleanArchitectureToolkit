using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace Cat.EventProcessor.AzureServiceBus;

/// <summary>
/// Settings of the Azure Service Bus listener.
/// The listener starts from the defaults of Azure Service Bus. Every <c>Configure</c> callback gets the SDK options
/// after the listener has filled in its own values, so you can change anything.
/// </summary>
public class CatEventProcessorServiceBusOptions
{
    /// <summary>
    /// The name of the subscription this service uses on the topic of every event, usually the name of the service.
    /// Command messages come from a queue, so they need no subscription.
    /// </summary>
    public string SubscriptionName { get; set; } = string.Empty;

    /// <summary>
    /// Changes the options of a subscription that the topology helper creates, such as the lock duration or the maximum delivery count.
    /// The subscription options hold the names of the topic and the subscription.
    /// </summary>
    public Action<CreateSubscriptionOptions>? ConfigureSubscription { get; set; }

    /// <summary>
    /// Changes the options of the processor of a message type that does not need sessions, such as the prefetch count.
    /// The first argument is the message type. The listener sets the concurrency of the message type before the callback runs,
    /// so the callback wins. The listener sets <see cref="ServiceBusProcessorOptions.AutoCompleteMessages"/> to false after the callback,
    /// because it settles every message itself.
    /// </summary>
    public Action<Type, ServiceBusProcessorOptions>? ConfigureProcessor { get; set; }

    /// <summary>
    /// Changes the options of the processor of a message type that needs sessions.
    /// The first argument is the message type. The listener sets the number of sessions of the message type before the callback runs,
    /// so the callback wins. The listener sets <see cref="ServiceBusSessionProcessorOptions.AutoCompleteMessages"/> to false after the callback,
    /// because it settles every message itself.
    /// </summary>
    public Action<Type, ServiceBusSessionProcessorOptions>? ConfigureSessionProcessor { get; set; }
}
