using System.Reflection;

namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// The easy way to create the queues and topics of the message types. Nothing is created when a service starts.
/// Call it from a deployment step, a small tool or a test. It needs the manage right on the namespace.
/// </summary>
public interface ICatServiceBusTopology
{
    /// <summary>
    /// Creates a queue for every command message and a topic for every event in the assemblies, and skips what exists.
    /// A subscription belongs to the receiving service, so this method does not create subscriptions.
    /// </summary>
    /// <param name="assemblies">The assemblies that hold the message types, such as the <c>Contracts</c> assemblies.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The names of the entities that were created, as <c>queue:Name</c> or <c>topic:Name</c>.</returns>
    public Task<IReadOnlyList<string>> EnsureTopologyAsync(IEnumerable<Assembly> assemblies, CancellationToken cancellationToken = default);
}
