using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.ServiceRequests.Abstractions;

/// <summary>
/// Single entry point for running service requests.
/// It finds the handler for a request, runs it through the registered decorators and returns the response.
/// </summary>
public interface ICatServiceRequestProcessor
{
    /// <summary>
    /// Runs a service request that returns no payload.
    /// </summary>
    /// <param name="catServiceRequest">The request to run.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The response of the handler.</returns>
    Task<ICatResponse> ProcessAsync(ICatServiceRequest catServiceRequest, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs a service request that returns a payload.
    /// </summary>
    /// <typeparam name="TResponse">The type of the payload.</typeparam>
    /// <param name="catServiceRequest">The request to run.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The response of the handler, with the payload when it succeeded.</returns>
    Task<ICatResponse<TResponse>> ProcessAsync<TResponse>(ICatServiceRequest<TResponse> catServiceRequest,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs a service request that returns no payload and blocks until it finishes.
    /// Prefer <see cref="ProcessAsync(ICatServiceRequest, CancellationToken)"/> when you can.
    /// </summary>
    /// <param name="catServiceRequest">The request to run.</param>
    /// <returns>The response of the handler.</returns>
    ICatResponse Process(ICatServiceRequest catServiceRequest);

    /// <summary>
    /// Runs a service request that returns a payload and blocks until it finishes.
    /// Prefer <see cref="ProcessAsync{TResponse}(ICatServiceRequest{TResponse}, CancellationToken)"/> when you can.
    /// </summary>
    /// <typeparam name="TResponse">The type of the payload.</typeparam>
    /// <param name="catServiceRequest">The request to run.</param>
    /// <returns>The response of the handler, with the payload when it succeeded.</returns>
    ICatResponse<TResponse> Process<TResponse>(ICatServiceRequest<TResponse> catServiceRequest);
}