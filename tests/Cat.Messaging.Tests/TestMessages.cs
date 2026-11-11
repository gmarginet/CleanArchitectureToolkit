using Cat.Messaging.Abstractions;

namespace Cat.Messaging.Tests;

public class OrderPlaced : CatEventMessage
{
    public string OrderNumber { get; set; } = string.Empty;
}

public class ReserveStock : CatCommandMessage
{
    public int Quantity { get; set; }
}

[CatMessage(Name = "payment-expired", RequiresSession = true)]
public class PaymentExpired : CatCommandMessage, ICatSessionMessage
{
    public string SessionId { get; set; } = string.Empty;
}

public abstract class AbstractMessage : CatEventMessage;

public class NotAMessage;

public class FakeTransport : ICatMessageTransport
{
    public List<CatOutgoingMessage> Sent { get; } = [];

    public Task SendAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default)
    {
        Sent.Add(message);
        return Task.CompletedTask;
    }
}
