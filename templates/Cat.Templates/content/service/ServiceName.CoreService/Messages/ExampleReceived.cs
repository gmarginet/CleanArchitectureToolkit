using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace ServiceName.CoreService.Messages;

/// <summary>
/// An example of a message that the service receives. It is a message and a service request at the same time.
/// The sender owns the real message type. Replace this one with the types of the messages you receive.
/// </summary>
public class ExampleReceived : CatEventMessage, ICatServiceRequest
{
    public string Text { get; set; } = string.Empty;
}
