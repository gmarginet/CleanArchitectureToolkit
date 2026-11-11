using Azure.Messaging.ServiceBus;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging.AzureServiceBus;

/// <summary>
/// Turns a <see cref="CatOutgoingMessage"/> into a Service Bus message.
/// </summary>
public static class CatServiceBusMessageMapper
{
    /// <summary>
    /// Maps the message. The message ID is copied, so duplicate detection of the bus can use it.
    /// The trace context is not added here, the Service Bus SDK puts its <c>Diagnostic-Id</c> on the message when it sends.
    /// </summary>
    /// <param name="message">The message to map.</param>
    /// <returns>The Service Bus message.</returns>
    public static ServiceBusMessage ToServiceBusMessage(CatOutgoingMessage message)
    {
        var serviceBusMessage = new ServiceBusMessage(BinaryData.FromBytes(message.Body))
        {
            ContentType = message.ContentType,
            MessageId = message.MessageId.ToString(),
            CorrelationId = message.CorrelationId.ToString(),
            Subject = message.Subject,
            SessionId = message.SessionId
        };

        if (message.ScheduledAt is { } scheduledAt)
        {
            serviceBusMessage.ScheduledEnqueueTime = scheduledAt;
        }

        foreach (var property in message.Properties)
        {
            serviceBusMessage.ApplicationProperties[property.Key] = property.Value;
        }

        return serviceBusMessage;
    }
}
