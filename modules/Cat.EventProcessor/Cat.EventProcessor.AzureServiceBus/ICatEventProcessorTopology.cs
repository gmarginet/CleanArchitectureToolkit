namespace Cat.EventProcessor.AzureServiceBus;

/// <summary>
/// The easy way to create the subscriptions of this service. A subscription belongs to the receiving service,
/// so the service creates its own, while the topic comes from the sender, see <c>ICatServiceBusTopology</c>.
/// Nothing is created when the service starts. It needs the manage right on the namespace.
/// </summary>
public interface ICatEventProcessorTopology
{
    /// <summary>
    /// Creates the subscription of this service on the topic of every declared event, and skips what exists.
    /// The topic must exist already.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The names of the subscriptions that were created, as <c>subscription:Topic/Name</c>.</returns>
    public Task<IReadOnlyList<string>> EnsureSubscriptionsAsync(CancellationToken cancellationToken = default);
}
