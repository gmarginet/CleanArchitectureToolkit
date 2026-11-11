namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// Settings of the dead letter metric. The metric is off until the developer adds it,
/// because reading the counts needs the manage right on the namespace.
/// </summary>
public class CatDeadLetterMetricsOptions
{
    /// <summary>
    /// The queues to watch.
    /// </summary>
    public IList<string> Queues { get; set; } = new List<string>();

    /// <summary>
    /// The subscriptions to watch, as pairs of a topic name and a subscription name.
    /// </summary>
    public IList<CatDeadLetterSubscription> Subscriptions { get; set; } = new List<CatDeadLetterSubscription>();

    /// <summary>
    /// How often the counts are read. The default is 60 seconds.
    /// </summary>
    public TimeSpan PollInterval { get; set; } = TimeSpan.FromSeconds(60);
}

/// <summary>
/// A subscription to watch for dead letters.
/// </summary>
/// <param name="Topic">The name of the topic.</param>
/// <param name="Subscription">The name of the subscription.</param>
public record CatDeadLetterSubscription(string Topic, string Subscription);
