using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// Settings of the Azure Service Bus transport.
/// The module starts from the defaults of Azure Service Bus. Every <c>Configure</c> callback gets the SDK options
/// after the module has filled in its own values, so you can change anything.
/// </summary>
public class CatServiceBusOptions
{
    /// <summary>
    /// The connection string of the namespace, for the real service and for the emulator.
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// The connection string for the administration client, which creates the queues, topics and subscriptions.
    /// Leave it empty to use <see cref="ConnectionString"/>. The emulator needs its own, because it answers
    /// management calls on a different port than the messages.
    /// </summary>
    public string AdministrationConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// Changes the options of the <see cref="ServiceBusClient"/>, such as the retry options for failed calls to the bus.
    /// The module sets nothing here, so the defaults of the SDK apply.
    /// </summary>
    public Action<ServiceBusClientOptions>? ConfigureClient { get; set; }

    /// <summary>
    /// Changes the options of the <see cref="ServiceBusAdministrationClient"/>.
    /// The module sets nothing here, so the defaults of the SDK apply.
    /// </summary>
    public Action<ServiceBusAdministrationClientOptions>? ConfigureAdministrationClient { get; set; }

    /// <summary>
    /// Changes the options of a queue that the topology helper creates, such as the lock duration or the maximum delivery count.
    /// The module turns duplicate detection on before the callback runs, so the callback can turn it off.
    /// The module sets <see cref="CreateQueueOptions.RequiresSession"/> after the callback, because the message type decides it.
    /// </summary>
    public Action<CreateQueueOptions>? ConfigureQueue { get; set; }

    /// <summary>
    /// Changes the options of a topic that the topology helper creates.
    /// The module turns duplicate detection on before the callback runs, so the callback can turn it off.
    /// </summary>
    public Action<CreateTopicOptions>? ConfigureTopic { get; set; }

    internal string ResolveAdministrationConnectionString() =>
        string.IsNullOrWhiteSpace(AdministrationConnectionString) ? ConnectionString : AdministrationConnectionString;
}
