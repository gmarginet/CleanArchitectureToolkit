using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.InventoryService.Infrastructure.Fakes;

/// <summary>
/// A stand-in for the bus. It only logs the message, so a plain <c>dotnet run</c> works without a Service Bus.
/// </summary>
public class FakeMessageTransport : ICatMessageTransport
{
    private readonly ILogger<FakeMessageTransport> _logger;

    public FakeMessageTransport(ILogger<FakeMessageTransport> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("No Service Bus is configured. The message {MessageId} for {EntityName} was not sent.", message.MessageId, message.EntityName);
        return Task.CompletedTask;
    }
}
