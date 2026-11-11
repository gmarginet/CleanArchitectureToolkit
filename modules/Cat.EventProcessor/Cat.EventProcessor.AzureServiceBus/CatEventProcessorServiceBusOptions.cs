namespace Cat.EventProcessor.AzureServiceBus;

/// <summary>
/// Settings of the Azure Service Bus listener.
/// </summary>
public class CatEventProcessorServiceBusOptions
{
    /// <summary>
    /// The name of the subscription this service uses on the topic of every event, usually the name of the service.
    /// Command messages come from a queue, so they need no subscription.
    /// </summary>
    public string SubscriptionName { get; set; } = string.Empty;
}
