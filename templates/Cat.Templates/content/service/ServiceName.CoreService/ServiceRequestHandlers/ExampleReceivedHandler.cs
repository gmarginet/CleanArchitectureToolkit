using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using ServiceName.CoreService.Messages;

namespace ServiceName.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles <see cref="ExampleReceived"/>. It does nothing yet. Replace it with the work for your message.
/// The inbox skips a message that arrives twice, so the handler runs once for each message.
/// The inbox row is committed by the <c>SaveChanges</c> of the work the handler does, so a handler that
/// writes to the database saves through its own context, and a handler that saves nothing leaves no row.
/// </summary>
public class ExampleReceivedHandler : ICatServiceRequestHandler<ExampleReceived>
{
    public Task<ICatResponse> HandleAsync(ExampleReceived serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(CatResponse.NoContent());
}
