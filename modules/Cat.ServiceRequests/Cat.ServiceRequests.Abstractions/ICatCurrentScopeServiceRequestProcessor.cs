using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.ServiceRequests.Abstractions;

/// <summary>
/// Runs a service request in the scope of the caller, instead of in a scope of its own.
/// The handler and everything it uses, such as a <c>DbContext</c>, are the same instances the caller sees in its scope.
/// Use it when the caller prepares work that the handler must commit together with its own, like the receiver of a message that adds an inbox row.
/// <see cref="ICatServiceRequestProcessor"/> keeps opening a scope per request.
/// </summary>
public interface ICatCurrentScopeServiceRequestProcessor
{
    /// <summary>
    /// Runs a service request that returns no payload, in the scope of the caller.
    /// </summary>
    /// <param name="catServiceRequest">The request to run.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The response of the handler.</returns>
    Task<ICatResponse> ProcessInCurrentScopeAsync(ICatServiceRequest catServiceRequest, CancellationToken cancellationToken = default);
}
