using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Commands.Abstractions;

/// <summary>
/// Handles one kind of command.
/// Implement it once per command type. The module finds and registers it for you.
/// </summary>
/// <typeparam name="TCommand">The command this handler can run.</typeparam>
public interface ICatCommandHandler<in TCommand>
    where TCommand : class, ICatCommand
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    /// <param name="command">The command to handle.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A response that tells whether the command succeeded, and why not if it failed.</returns>
    public Task<ICatResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}