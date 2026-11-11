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
}
