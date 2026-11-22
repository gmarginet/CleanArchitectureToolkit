using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace ServiceName.CoreService.Messages;

/// <summary>
/// The answer to <see cref="ItemNameRequested"/>. It is a message and a service request at the same time,
/// so the event processor hands it to the saga. Register it with <c>AddCatSagaAnswer</c> and <c>Receive</c>.
/// </summary>
public class ItemNameAnswered : CatEventMessage, ICatServiceRequest
{
    public Guid Id { get; set; }
}
