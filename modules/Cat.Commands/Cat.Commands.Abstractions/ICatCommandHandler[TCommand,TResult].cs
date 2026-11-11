using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Commands.Abstractions;

/// <summary>
/// Handles one kind of command that returns a result.
/// Implement it once per command type. The module finds and registers it for you.
/// </summary>
/// <typeparam name="TCommand">The command this handler can run.</typeparam>
/// <typeparam name="TResult">The type of the data the handler returns.</typeparam>
public interface ICatCommandHandler<in TCommand, TResult>
    where TCommand : class, ICatCommand<TResult>
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    /// <param name="command">The command to handle.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A response with the result when it succeeded, or the errors when it failed.</returns>
    Task<ICatResponse<TResult>> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
