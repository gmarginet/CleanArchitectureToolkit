using System.Reflection;
using Azure.Messaging.ServiceBus.Administration;
using Cat.Messaging.Abstractions;
using Microsoft.Extensions.Options;

namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// Default <see cref="ICatServiceBusTopology"/>, on the administration client.
/// </summary>
internal sealed class ServiceBusTopology : ICatServiceBusTopology
{
    private readonly ServiceBusAdministrationClient _admin;
    private readonly ICatMessageNameResolver _nameResolver;
    private readonly IOptions<CatServiceBusOptions> _options;

    /// <summary>
    /// Creates the topology helper.
    /// </summary>
    /// <param name="admin">The administration client. It needs the manage right.</param>
    /// <param name="nameResolver">Finds the entity name and the kind of a message type.</param>
    /// <param name="options">The settings of the transport, with the callbacks that change the queue and topic options.</param>
    public ServiceBusTopology(ServiceBusAdministrationClient admin, ICatMessageNameResolver nameResolver,
        IOptions<CatServiceBusOptions> options)
    {
        _admin = admin;
        _nameResolver = nameResolver;
        _options = options;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<string>> EnsureTopologyAsync(IEnumerable<Assembly> assemblies, CancellationToken cancellationToken = default)
    {
        var created = new List<string>();

        foreach (var type in FindMessageTypes(assemblies))
        {
            var name = _nameResolver.GetName(type);

            if (_nameResolver.GetKind(type) == CatMessageKind.Command)
            {
                if (await _admin.QueueExistsAsync(name, cancellationToken))
                {
                    continue;
                }

                await _admin.CreateQueueAsync(
                    BuildQueueOptions(name, _nameResolver.RequiresSession(type), _options.Value.ConfigureQueue),
                    cancellationToken);
                created.Add($"queue:{name}");
            }
            else
            {
                if (await _admin.TopicExistsAsync(name, cancellationToken))
                {
                    continue;
                }

                await _admin.CreateTopicAsync(BuildTopicOptions(name, _options.Value.ConfigureTopic), cancellationToken);
                created.Add($"topic:{name}");
            }
        }

        return created;
    }

    /// <summary>
    /// Builds the options of a queue. Duplicate detection is on, so the bus drops a repeated message with the same
    /// message ID. The time window keeps the default of Azure Service Bus. The callback runs next, and the session
    /// setting is applied after it, because the message type decides it.
    /// </summary>
    internal static CreateQueueOptions BuildQueueOptions(string name, bool requiresSession, Action<CreateQueueOptions>? configure = null)
    {
        var options = new CreateQueueOptions(name) { RequiresSession = requiresSession, RequiresDuplicateDetection = true };
        configure?.Invoke(options);
        options.RequiresSession = requiresSession;
        return options;
    }

    /// <summary>
    /// Builds the options of a topic. Duplicate detection is on, so the bus drops a repeated message with the same
    /// message ID. The time window keeps the default of Azure Service Bus. The callback runs last.
    /// </summary>
    internal static CreateTopicOptions BuildTopicOptions(string name, Action<CreateTopicOptions>? configure = null)
    {
        var options = new CreateTopicOptions(name) { RequiresDuplicateDetection = true };
        configure?.Invoke(options);
        return options;
    }

    /// <summary>
    /// Finds the concrete message types. Two types with the same name give one entity.
    /// </summary>
    internal static IEnumerable<Type> FindMessageTypes(IEnumerable<Assembly> assemblies)
    {
        return assemblies
            .SelectMany(GetTypesSafely)
            .Where(type => type is { IsClass: true, IsAbstract: false, IsGenericTypeDefinition: false }
                           && (typeof(ICatEventMessage).IsAssignableFrom(type) || typeof(ICatCommandMessage).IsAssignableFrom(type)))
            .Distinct();
    }

    private static IEnumerable<Type> GetTypesSafely(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException exception)
        {
            return exception.Types.Where(type => type is not null)!;
        }
    }
}
