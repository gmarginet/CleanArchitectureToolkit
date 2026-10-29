using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.ServiceRequests.Decorators.ActivitySource;

/// <summary>
/// Wraps service request handlers in an <see cref="System.Diagnostics.Activity"/> for tracing.
/// </summary>
internal static class ActivitySourceDecorator
{
    /// <summary>
    /// Traces a handler that returns no payload.
    /// </summary>
    /// <typeparam name="TRequest">The service request being handled.</typeparam>
    internal sealed class CatServiceRequestHandler<TRequest>
        : ICatServiceRequestHandler<TRequest>
        where TRequest : class, ICatServiceRequest
    {
        private readonly ICatServiceRequestHandler<TRequest> _innerHandler;

        /// <summary>
        /// Creates the decorator.
        /// </summary>
        /// <param name="innerHandler">The handler to wrap.</param>
        public CatServiceRequestHandler(ICatServiceRequestHandler<TRequest> innerHandler)
        {
            _innerHandler = innerHandler;
        }

        /// <inheritdoc />
        public async Task<ICatResponse> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default)
        {
            var serviceRequestType = serviceRequest.GetType();
            using (var activity = ServiceRequestActivitySource.CreateActivity($"Start handling ServiceRequest {serviceRequestType.Name}"))
            {
                activity?.AddTag("ServiceRequestType", serviceRequestType.Name);

                return await _innerHandler.HandleAsync(serviceRequest, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Traces a handler that returns a payload.
    /// </summary>
    /// <typeparam name="TRequest">The service request being handled.</typeparam>
    /// <typeparam name="TResponse">The type of the payload.</typeparam>
    internal sealed class CatServiceRequestHandler<TRequest,TResponse>
        : ICatServiceRequestHandler<TRequest,TResponse>
        where TRequest : class, ICatServiceRequest<TResponse>
    {
        private readonly ICatServiceRequestHandler<TRequest,TResponse> _innerHandler;

        /// <summary>
        /// Creates the decorator.
        /// </summary>
        /// <param name="innerHandler">The handler to wrap.</param>
        public CatServiceRequestHandler(ICatServiceRequestHandler<TRequest,TResponse> innerHandler)
        {
            _innerHandler = innerHandler;
        }

        /// <inheritdoc />
        public async Task<ICatResponse<TResponse>> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default)
        {
            var serviceRequestType = serviceRequest.GetType();
            using (var activity = ServiceRequestActivitySource.CreateActivity($"Start handling ServiceRequest {serviceRequestType.Name}"))
            {
                activity?.AddTag("ServiceRequestType", serviceRequestType.Name);

                return await _innerHandler.HandleAsync(serviceRequest, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Owns the shared <see cref="System.Diagnostics.ActivitySource"/> named "Cat.ServiceRequests".
    /// </summary>
    private static class ServiceRequestActivitySource
    {
        private const string ActivitySourceName = "Cat.ServiceRequests";
        private static readonly System.Diagnostics.ActivitySource Instance = new(ActivitySourceName);

        /// <summary>
        /// Starts a client activity.
        /// </summary>
        /// <param name="name">The display name of the activity.</param>
        /// <returns>The activity, or <c>null</c> when nobody listens to the source.</returns>
        public static Activity? CreateActivity(string name)
        {
            return Instance.StartActivity(name, ActivityKind.Client);
        }
    }
}