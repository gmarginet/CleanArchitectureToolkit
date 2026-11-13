using Azure.Messaging.ServiceBus;
using Cat.EventProcessor.Abstractions;

namespace Cat.EventProcessor.AzureServiceBus;

/// <summary>
/// Turns a received Service Bus message into a <see cref="CatIncomingMessage"/>.
/// </summary>
public static class ServiceBusIncomingMessageMapper
{
    /// <summary>
    /// Maps the message. The application properties are copied as text.
    /// </summary>
    /// <param name="message">The received message.</param>
    /// <returns>The broker neutral message.</returns>
    public static CatIncomingMessage ToIncomingMessage(ServiceBusReceivedMessage message)
    {
        var incoming = new CatIncomingMessage
        {
            Body = message.Body.ToArray(),
            ContentType = message.ContentType ?? string.Empty,
            MessageId = message.MessageId ?? string.Empty,
            DeliveryCount = message.DeliveryCount,
            EnqueuedTime = message.EnqueuedTime == default ? null : message.EnqueuedTime,
            IsScheduled = message.ScheduledEnqueueTime != default
        };

        foreach (var property in message.ApplicationProperties)
        {
            incoming.Properties[property.Key] = property.Value?.ToString() ?? string.Empty;
        }

        return incoming;
    }
}
