using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.ServiceRequests.Abstractions;

/// <summary>
/// Handles one kind of service request that returns a payload.
/// Implement it once per request type. The module finds and registers it for you.
/// </summary>
/// <typeparam name="TRequest">The service request this handler can process.</typeparam>
/// <typeparam name="TResponse">The type of the payload the handler returns.</typeparam>
public interface ICatServiceRequestHandler<in TRequest, TResponse>
    where TRequest : class, ICatServiceRequest<TResponse>
{
    /// <summary>
    /// Runs the service request.
    /// </summary>
    /// <param name="serviceRequest">The request to handle.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A response with the payload when it succeeded, or the errors when it failed.</returns>
    Task<ICatResponse<TResponse>> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default);
}