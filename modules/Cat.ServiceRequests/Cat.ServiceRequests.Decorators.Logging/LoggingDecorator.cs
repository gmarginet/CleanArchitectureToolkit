using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;
using Cat.Responses.Abstractions.Extensions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.ServiceRequests.Decorators.Logging;

/// <summary>
/// Wraps service request handlers with debug logging and error logging.
/// </summary>
internal static  class LoggingDecorator
{
    /// <summary>
    /// Logs a handler that returns no payload.
    /// </summary>
    /// <typeparam name="TRequest">The service request being handled.</typeparam>
    internal sealed class CatServiceRequestHandler<TRequest>
        : ICatServiceRequestHandler<TRequest>
        where TRequest : class, ICatServiceRequest
    {
        private readonly ICatServiceRequestHandler<TRequest> _innerHandler;
        private readonly ILogger<CatServiceRequestHandler<TRequest>> _logger;

        /// <summary>
        /// Creates the decorator.
        /// </summary>
        /// <param name="innerHandler">The handler to wrap.</param>
        /// <param name="logger">Receives the log entries.</param>
        public CatServiceRequestHandler(
            ICatServiceRequestHandler<TRequest> innerHandler,
            ILogger<CatServiceRequestHandler<TRequest>> logger)
        {
            _innerHandler = innerHandler;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<ICatResponse> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default)
        {
            var serviceRequestType = serviceRequest.GetType();
            
            _logger.LogDebug("Start handling ServiceRequest {ServiceRequestName}", serviceRequestType.Name);
            
            var response = await _innerHandler.HandleAsync(serviceRequest, cancellationToken);

            if (response.IsSucceeded)
            {
                _logger.LogDebug("Finished handling ServiceRequest {ServiceRequestName}", serviceRequestType.Name);
            }
            else
            {
                _logger.LogCatResponseErrors(response, "Error occurred during handling of ServiceRequest {serviceRequestName}:", serviceRequestType.Name);
            }

            return response;
        }
    }

    /// <summary>
    /// Logs a handler that returns a payload.
    /// </summary>
    /// <typeparam name="TRequest">The service request being handled.</typeparam>
    /// <typeparam name="TResponse">The type of the payload.</typeparam>
    internal sealed class CatServiceRequestHandler<TRequest,TResponse>
        : ICatServiceRequestHandler<TRequest,TResponse>
        where TRequest : class, ICatServiceRequest<TResponse>
    {
        private readonly ICatServiceRequestHandler<TRequest,TResponse> _innerHandler;
        private readonly ILogger<CatServiceRequestHandler<TRequest, TResponse>> _logger;

        /// <summary>
        /// Creates the decorator.
        /// </summary>
        /// <param name="innerHandler">The handler to wrap.</param>
        /// <param name="logger">Receives the log entries.</param>
        public CatServiceRequestHandler(
            ICatServiceRequestHandler<TRequest,TResponse> innerHandler,
            ILogger<CatServiceRequestHandler<TRequest,TResponse>> logger)
        {
            _innerHandler = innerHandler;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<ICatResponse<TResponse>> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default)
        {
            var serviceRequestType = serviceRequest.GetType();
            
            _logger.LogDebug("Start handling ServiceRequest {ServiceRequestName}", serviceRequestType.Name);
            
            var response = await _innerHandler.HandleAsync(serviceRequest, cancellationToken);

            if (response.IsSucceeded)
            {
                _logger.LogDebug("Finished handling ServiceRequest {ServiceRequestName}", serviceRequestType.Name);
            }
            else
            {
                _logger.LogCatResponseErrors(response, "Error occurred during handling of ServiceRequest {serviceRequestName}:", serviceRequestType.Name);
            }

            return response;
        }
    }
}