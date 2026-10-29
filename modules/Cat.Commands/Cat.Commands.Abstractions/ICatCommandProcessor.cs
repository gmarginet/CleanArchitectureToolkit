using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Commands.Abstractions;

/// <summary>
/// Single entry point for running commands.
/// It finds the handler for a command, runs it through the registered decorators and returns the response.
/// </summary>
public interface ICatCommandProcessor
{
    /// <summary>
    /// Runs a command.
    /// </summary>
    /// <param name="catCommand">The command to run.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The response of the handler.</returns>
    public Task<ICatResponse> ProcessAsync(ICatCommand catCommand, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs a command and blocks until it finishes.
    /// Prefer <see cref="ProcessAsync(ICatCommand, CancellationToken)"/> when you can.
    /// </summary>
    /// <param name="catCommand">The command to run.</param>
    /// <returns>The response of the handler.</returns>
    public ICatResponse Process(ICatCommand catCommand);
}