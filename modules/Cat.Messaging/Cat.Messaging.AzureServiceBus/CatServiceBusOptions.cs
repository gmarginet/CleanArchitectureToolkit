namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// Settings of the Azure Service Bus transport.
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

    internal string ResolveAdministrationConnectionString() =>
        string.IsNullOrWhiteSpace(AdministrationConnectionString) ? ConnectionString : AdministrationConnectionString;
}
