using System.Collections.Concurrent;
using Azure.Messaging.ServiceBus;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// <see cref="ICatMessageTransport"/> for Azure Service Bus. A queue and a topic are both reached by a sender with the entity name.
/// </summary>
internal sealed class ServiceBusMessageTransport : ICatMessageTransport, IAsyncDisposable
{
    private readonly ServiceBusClient _client;
    private readonly ConcurrentDictionary<string, ServiceBusSender> _senders = new();

    /// <summary>
    /// Creates the transport.
    /// </summary>
    /// <param name="client">The shared client. It owns the connection.</param>
    public ServiceBusMessageTransport(ServiceBusClient client)
    {
        _client = client;
    }

    /// <inheritdoc />
    public Task SendAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default)
    {
        var sender = _senders.GetOrAdd(message.EntityName, name => _client.CreateSender(name));
        return sender.SendMessageAsync(CatServiceBusMessageMapper.ToServiceBusMessage(message), cancellationToken);
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        foreach (var sender in _senders.Values)
        {
            await sender.DisposeAsync();
        }
    }
}
