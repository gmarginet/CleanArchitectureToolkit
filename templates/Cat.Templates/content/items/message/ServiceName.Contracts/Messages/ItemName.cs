using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace ServiceName.Contracts.Messages;

/// <summary>
/// The message ItemName. The sender publishes or sends it through the messaging module.
/// A service that receives it writes a handler for it, as for any service request, so the message is a service request too.
/// </summary>
public class ItemName : KIND_BASE, ICatServiceRequest
{
    public Guid Id { get; set; }
}
