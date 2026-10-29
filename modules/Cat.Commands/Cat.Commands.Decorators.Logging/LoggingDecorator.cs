using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Responses.Abstractions;
using Cat.Responses.Abstractions.Extensions;
using Microsoft.Extensions.Logging;

namespace Cat.Commands.Decorators.Logging;

/// <summary>
/// Wraps command handlers with debug logging and error logging.
/// </summary>
internal static  class LoggingDecorator
{
    /// <summary>
    /// Logs the start and end of a command handler.
    /// </summary>
    /// <typeparam name="TCommand">The command being handled.</typeparam>
    internal sealed class CatCommandHandler<TCommand>
        : ICatCommandHandler<TCommand>
        where TCommand : class, ICatCommand
    {
        private readonly ICatCommandHandler<TCommand> _innerHandler;
        private readonly ILogger<CatCommandHandler<TCommand>> _logger;

        /// <summary>
        /// Creates the decorator.
        /// </summary>
        /// <param name="innerHandler">The handler to wrap.</param>
        /// <param name="logger">Receives the log entries.</param>
        public CatCommandHandler(
            ICatCommandHandler<TCommand> innerHandler,
            ILogger<CatCommandHandler<TCommand>> logger)
        {
            _innerHandler = innerHandler;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<ICatResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
        {
            var commandType = command.GetType();
            
            _logger.LogDebug("Start handling Command {commandName}", commandType.Name);
            
            var response = await _innerHandler.HandleAsync(command, cancellationToken);

            if (response.IsSucceeded)
            {
                _logger.LogDebug("Finished handling Command {commandName}", commandType.Name);
            }
            else
            {
                _logger.LogCatResponseErrors(response, "Error occurred during handling of Command {commandName}:", commandType.Name);
            }

            return response;
        }
    }
}