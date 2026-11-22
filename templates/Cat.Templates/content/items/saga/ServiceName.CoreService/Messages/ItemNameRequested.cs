using Cat.Messaging.Abstractions;

namespace ServiceName.CoreService.Messages;

/// <summary>
/// The request that the saga ItemNameSaga sends and waits on. It goes to a queue.
/// The saga puts its instance id in the correlation id. The service that answers must copy it into <see cref="ItemNameAnswered"/>.
/// </summary>
public class ItemNameRequested : CatCommandMessage
{
    public Guid Id { get; set; }
}
