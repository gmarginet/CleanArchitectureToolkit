using System.Reflection;
using Azure.Messaging.ServiceBus.Administration;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// Default <see cref="ICatServiceBusTopology"/>, on the administration client.
/// </summary>
internal sealed class ServiceBusTopology : ICatServiceBusTopology
{
    private readonly ServiceBusAdministrationClient _admin;
    private readonly ICatMessageNameResolver _nameResolver;

    /// <summary>
    /// Creates the topology helper.
    /// </summary>
    /// <param name="admin">The administration client. It needs the manage right.</param>
    /// <param name="nameResolver">Finds the entity name and the kind of a message type.</param>
    public ServiceBusTopology(ServiceBusAdministrationClient admin, ICatMessageNameResolver nameResolver)
    {
        _admin = admin;
        _nameResolver = nameResolver;
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
                    BuildQueueOptions(name, _nameResolver.RequiresSession(type)),
                    cancellationToken);
                created.Add($"queue:{name}");
            }
            else
            {
                if (await _admin.TopicExistsAsync(name, cancellationToken))
                {
                    continue;
                }

                await _admin.CreateTopicAsync(BuildTopicOptions(name), cancellationToken);
                created.Add($"topic:{name}");
            }
        }

        return created;
    }

    /// <summary>
    /// Builds the options of a queue. Duplicate detection is on, so the bus drops a repeated message with the same
    /// message ID. The time window keeps the default of Azure Service Bus.
    /// </summary>
    internal static CreateQueueOptions BuildQueueOptions(string name, bool requiresSession) =>
        new(name) { RequiresSession = requiresSession, RequiresDuplicateDetection = true };

    /// <summary>
    /// Builds the options of a topic. Duplicate detection is on, so the bus drops a repeated message with the same
    /// message ID. The time window keeps the default of Azure Service Bus.
    /// </summary>
    internal static CreateTopicOptions BuildTopicOptions(string name) =>
        new(name) { RequiresDuplicateDetection = true };

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
