using System.Linq;
using Microsoft.Extensions.Logging;

namespace Cat.Responses.Abstractions.Extensions;

/// <summary>
/// Extension methods for logging <see cref="ICatResponse"/> errors.
/// </summary>
public static class LoggerExtensions
{
    /// <summary>
    /// Logs a message, followed by one log entry per error in the response's <see cref="ICatResponse.ErrorList"/>.
    /// </summary>
    /// <param name="logger">The logger to write to.</param>
    /// <param name="catResponse">The response whose errors should be logged.</param>
    /// <param name="message">The message to log before the individual errors.</param>
    /// <param name="args">The values to substitute into <paramref name="message"/>'s placeholders.</param>
    public static void LogCatResponseErrors(this ILogger logger, ICatResponse catResponse, string message, params object[] args)
    {
        logger.LogError(message, args);
        foreach (var error in catResponse.ErrorList)
        {
            logger.LogError($"\t{error.Code}: {error.Message}", error.Arguments.ToArray());
        }
    }
}