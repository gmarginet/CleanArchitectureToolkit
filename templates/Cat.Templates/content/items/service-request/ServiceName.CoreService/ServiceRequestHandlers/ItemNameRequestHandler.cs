using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using ServiceName.Contracts.ServiceRequests;

namespace ServiceName.CoreService.ServiceRequestHandlers;

/// <summary>Handles <see cref="ItemNameRequest"/>. It does nothing yet. Send a query or a command from here.</summary>
public class ItemNameRequestHandler : ICatServiceRequestHandler<ItemNameRequest>
{
    public Task<ICatResponse> HandleAsync(ItemNameRequest serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(CatResponse.NoContent());
}
