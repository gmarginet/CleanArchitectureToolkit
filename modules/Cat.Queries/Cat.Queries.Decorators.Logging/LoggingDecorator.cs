using System.Threading;
using System.Threading.Tasks;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Cat.Responses.Abstractions.Extensions;
using Microsoft.Extensions.Logging;

namespace Cat.Queries.Decorators.Logging;

/// <summary>
/// Wraps query handlers with debug logging and error logging.
/// </summary>
internal static  class LoggingDecorator
{
    /// <summary>
    /// Logs the start and end of a query handler.
    /// </summary>
    /// <typeparam name="TQuery">The query being handled.</typeparam>
    /// <typeparam name="TQueryResult">The type of the data the handler returns.</typeparam>
    internal sealed class CatQueryHandler<TQuery, TQueryResult>
        : ICatQueryHandler<TQuery, TQueryResult>
        where TQuery : class, ICatQuery<TQueryResult>
    {
        private readonly ICatQueryHandler<TQuery, TQueryResult> _innerHandler;
        private readonly ILogger<CatQueryHandler<TQuery, TQueryResult>> _logger;

        /// <summary>
        /// Creates the decorator.
        /// </summary>
        /// <param name="innerHandler">The handler to wrap.</param>
        /// <param name="logger">Receives the log entries.</param>
        public CatQueryHandler(
            ICatQueryHandler<TQuery, TQueryResult> innerHandler,
            ILogger<CatQueryHandler<TQuery, TQueryResult>> logger)
        {
            _innerHandler = innerHandler;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<ICatResponse<TQueryResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
        {
            var queryType = query.GetType();
            
            _logger.LogDebug("Start handling Query {QueryName}", queryType.Name);
            
            var response = await _innerHandler.HandleAsync(query, cancellationToken);

            if (response.IsSucceeded)
            {
                _logger.LogDebug("Finished handling Query {QueryName}", queryType.Name);
            }
            else
            {
                _logger.LogCatResponseErrors(response, "Error occurred during handling of Query {queryName}:", queryType.Name);
            }

            return response;
        }
    }
}