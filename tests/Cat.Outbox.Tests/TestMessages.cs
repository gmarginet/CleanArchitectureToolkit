using Cat.Messaging.Abstractions;

namespace Cat.Outbox.Tests;

public class OrderPlaced : CatEventMessage
{
    public string OrderNumber { get; set; } = string.Empty;
}

public class FakeTransport : ICatMessageTransport
{
    public List<CatOutgoingMessage> Sent { get; } = [];

    public Task SendAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default)
    {
        Sent.Add(message);
        return Task.CompletedTask;
    }
}