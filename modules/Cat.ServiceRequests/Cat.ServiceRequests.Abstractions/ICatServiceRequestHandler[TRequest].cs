using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.ServiceRequests.Abstractions;

/// <summary>
/// Handles one kind of service request that returns no payload.
/// Implement it once per request type. The module finds and registers it for you.
/// </summary>
/// <typeparam name="TRequest">The service request this handler can process.</typeparam>
public interface ICatServiceRequestHandler<in TRequest>
    where TRequest : class, ICatServiceRequest
{
    /// <summary>
    /// Runs the service request.
    /// </summary>
    /// <param name="serviceRequest">The request to handle.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A response that tells whether the request succeeded, and why not if it failed.</returns>
    Task<ICatResponse> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default);
}
