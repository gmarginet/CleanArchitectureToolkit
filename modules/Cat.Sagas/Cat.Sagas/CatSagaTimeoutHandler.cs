using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;
using Cat.Sagas.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// The handler for <see cref="CatSagaTimeout"/>. It gives the timeout to the dispatcher.
/// </summary>
public sealed class CatSagaTimeoutHandler : ICatServiceRequestHandler<CatSagaTimeout>
{
    private readonly ICatSagaDispatcher _dispatcher;

    /// <summary>
    /// Creates the handler.
    /// </summary>
    /// <param name="dispatcher">Resumes the saga.</param>
    public CatSagaTimeoutHandler(ICatSagaDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    /// <inheritdoc />
    public Task<ICatResponse> HandleAsync(CatSagaTimeout serviceRequest, CancellationToken cancellationToken = default)
    {
        return _dispatcher.TimeoutAsync(serviceRequest.CorrelationId, serviceRequest.WaitId, cancellationToken);
    }
}
