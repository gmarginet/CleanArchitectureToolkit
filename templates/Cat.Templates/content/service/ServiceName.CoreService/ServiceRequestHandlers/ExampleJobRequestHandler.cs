using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using ServiceName.Contracts.ServiceRequests;

namespace ServiceName.CoreService.ServiceRequestHandlers;

/// <summary>Handles the request of the example job. It does nothing yet. Replace it with the work of your job.</summary>
public class ExampleJobRequestHandler : ICatServiceRequestHandler<ExampleJobRequest>
{
    public Task<ICatResponse> HandleAsync(ExampleJobRequest serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(CatResponse.NoContent());
}
