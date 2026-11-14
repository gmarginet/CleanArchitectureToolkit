using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;
using Cat.Responses.Abstractions;
using Cat.Sagas.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// The handler for an answer message. It gives the answer to the saga with the same correlation id.
/// Register it for a message type with <c>AddCatSagaAnswer</c>, and declare the type with <c>Receive</c> on the event processor.
/// </summary>
/// <typeparam name="TAnswer">The answer message.</typeparam>
public sealed class CatSagaAnswerHandler<TAnswer> : ICatServiceRequestHandler<TAnswer>
    where TAnswer : class, ICatMessage, ICatServiceRequest
{
    private readonly ICatSagaDispatcher _dispatcher;

    /// <summary>
    /// Creates the handler.
    /// </summary>
    /// <param name="dispatcher">Resumes the saga.</param>
    public CatSagaAnswerHandler(ICatSagaDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    /// <inheritdoc />
    public Task<ICatResponse> HandleAsync(TAnswer serviceRequest, CancellationToken cancellationToken = default)
    {
        return _dispatcher.ResumeAsync(serviceRequest.CorrelationId, serviceRequest, cancellationToken);
    }
}
