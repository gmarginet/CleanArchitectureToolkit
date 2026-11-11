using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// Turns one incoming message into a service request, runs it and tells the broker what to do with the message.
/// </summary>
public interface ICatMessageReceiver
{
    /// <summary>
    /// Handles one message. It never throws for a failure of the handler. It returns a result instead.
    /// </summary>
    /// <param name="messageType">The declared message type, which is also a service request.</param>
    /// <param name="message">The incoming message.</param>
    /// <param name="cancellationToken">Token to cancel the work, for example when the service shuts down.</param>
    /// <returns>What to do with the message.</returns>
    public Task<CatSettlementResult> ReceiveAsync(Type messageType, CatIncomingMessage message, CancellationToken cancellationToken = default);
}
