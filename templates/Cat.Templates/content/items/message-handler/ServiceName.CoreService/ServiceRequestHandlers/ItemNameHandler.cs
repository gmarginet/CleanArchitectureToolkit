using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using MESSAGE_NAMESPACE;

namespace ServiceName.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles the message <see cref="ItemName"/>. It does nothing yet. Write it so that it can run twice for the same message,
/// or switch the inbox on for the message type.
/// </summary>
public class ItemNameHandler : ICatServiceRequestHandler<ItemName>
{
    public Task<ICatResponse> HandleAsync(ItemName serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(CatResponse.NoContent());
}
