using System.Threading;
using System.Threading.Tasks;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Validators.Abstractions;

namespace Cat.ServiceRequests.Decorators.Validation;

/// <summary>
/// Wraps service request handlers with request validation.
/// </summary>
internal static class ValidationDecorator
{
    /// <summary>
    /// Validates requests for a handler that returns no payload.
    /// </summary>
    /// <typeparam name="TRequest">The service request being handled.</typeparam>
    internal sealed class CatServiceRequestHandler<TRequest>
        : ICatServiceRequestHandler<TRequest>
        where TRequest : class, ICatServiceRequest
    {
        private readonly ICatServiceRequestHandler<TRequest> _innerHandler;
        private readonly ICatValidatorProcessor _catValidatorProcessor;
        private readonly bool _validationRequired;

        /// <summary>
        /// Creates the decorator.
        /// </summary>
        /// <param name="innerHandler">The handler to wrap.</param>
        /// <param name="catValidatorProcessor">Runs the validators for the request.</param>
        /// <param name="validationRequired">When <c>true</c>, a request without a validator counts as a failure.</param>
        public CatServiceRequestHandler(
            ICatServiceRequestHandler<TRequest> innerHandler,
            ICatValidatorProcessor catValidatorProcessor,
            bool validationRequired)
        {
            _innerHandler = innerHandler;
            _catValidatorProcessor = catValidatorProcessor;
            _validationRequired = validationRequired;
        }

        /// <inheritdoc />
        public async Task<ICatResponse> HandleAsync(TRequest serviceRequest,
            CancellationToken cancellationToken = default)
        {
            var validationResponse = _catValidatorProcessor.Validate(serviceRequest, _validationRequired);

            if (validationResponse.IsSucceeded)
            {
                return await _innerHandler.HandleAsync(serviceRequest, cancellationToken);
            }

            return validationResponse;
        }
    }

    /// <summary>
    /// Validates requests for a handler that returns a payload.
    /// </summary>
    /// <typeparam name="TRequest">The service request being handled.</typeparam>
    /// <typeparam name="TResponse">The type of the payload.</typeparam>
    internal sealed class CatServiceRequestHandler<TRequest,TResponse>
        : ICatServiceRequestHandler<TRequest,TResponse>
        where TRequest : class, ICatServiceRequest<TResponse>
    {
        private readonly ICatServiceRequestHandler<TRequest,TResponse> _innerHandler;
        private readonly ICatValidatorProcessor _catValidatorProcessor;
        private readonly bool _validationRequired;

        /// <summary>
        /// Creates the decorator.
        /// </summary>
        /// <param name="innerHandler">The handler to wrap.</param>
        /// <param name="catValidatorProcessor">Runs the validators for the request.</param>
        /// <param name="validationRequired">When <c>true</c>, a request without a validator counts as a failure.</param>
        public CatServiceRequestHandler(
            ICatServiceRequestHandler<TRequest, TResponse> innerHandler,
            ICatValidatorProcessor catValidatorProcessor,
            bool validationRequired)
        {
            _innerHandler = innerHandler;
            _catValidatorProcessor = catValidatorProcessor;
            _validationRequired = validationRequired;
        }

        /// <inheritdoc />
        public async Task<ICatResponse<TResponse>> HandleAsync(TRequest serviceRequest, CancellationToken ct = default)
        {
            var validationResponse = await _catValidatorProcessor.ValidateAsync(serviceRequest, _validationRequired, ct);

            return validationResponse.Type switch
            {
                CatResponseType.Succeeded => await _innerHandler.HandleAsync(serviceRequest, ct),
                CatResponseType.Failed => validationResponse.Cast<TResponse>(),
                _ => CatResponse.InternalServerError<TResponse>([ CatGeneralErrorDefinitions.UnexpectedResponse.CreateCatError()])
            };
        }
    }
}