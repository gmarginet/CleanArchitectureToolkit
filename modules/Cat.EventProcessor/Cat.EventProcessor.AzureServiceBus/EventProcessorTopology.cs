using Azure.Messaging.ServiceBus.Administration;
using Cat.EventProcessor.Abstractions;
using Cat.Messaging.Abstractions;
using Microsoft.Extensions.Options;

namespace Cat.EventProcessor.AzureServiceBus;

/// <summary>
/// Default <see cref="ICatEventProcessorTopology"/>, on the administration client.
/// </summary>
internal sealed class EventProcessorTopology : ICatEventProcessorTopology
{
    private readonly ServiceBusAdministrationClient _admin;
    private readonly ICatReceiveRegistry _registry;
    private readonly ICatMessageNameResolver _nameResolver;
    private readonly IOptions<CatEventProcessorServiceBusOptions> _options;

    /// <summary>
    /// Creates the topology helper.
    /// </summary>
    /// <param name="admin">The administration client. It needs the manage right.</param>
    /// <param name="registry">The declared message types.</param>
    /// <param name="nameResolver">Finds the topic name and the kind of a message type.</param>
    /// <param name="options">The settings of the listener, with the subscription name.</param>
    public EventProcessorTopology(ServiceBusAdministrationClient admin, ICatReceiveRegistry registry,
        ICatMessageNameResolver nameResolver, IOptions<CatEventProcessorServiceBusOptions> options)
    {
        _admin = admin;
        _registry = registry;
        _nameResolver = nameResolver;
        _options = options;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<string>> EnsureSubscriptionsAsync(CancellationToken cancellationToken = default)
    {
        var subscription = _options.Value.SubscriptionName;
        if (string.IsNullOrWhiteSpace(subscription))
        {
            throw new InvalidOperationException("Set the SubscriptionName before the subscriptions are created.");
        }

        var created = new List<string>();

        foreach (var registration in _registry.Registrations)
        {
            if (_nameResolver.GetKind(registration.MessageType) != CatMessageKind.Event)
            {
                continue;
            }

            var topic = _nameResolver.GetName(registration.MessageType);
            if (await _admin.SubscriptionExistsAsync(topic, subscription, cancellationToken))
            {
                continue;
            }

            await _admin.CreateSubscriptionAsync(new CreateSubscriptionOptions(topic, subscription), cancellationToken);
            created.Add($"subscription:{topic}/{subscription}");
        }

        return created;
    }
}
