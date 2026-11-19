using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Commands.Abstractions;

/// <summary>
/// Runs a command in the scope of the caller, instead of in a scope of its own.
/// The handler and everything it uses, such as a <c>DbContext</c>, are the same instances the caller sees in its scope.
/// Use it when a command must commit together with work the caller prepared, like a handler of a received message that has an inbox row.
/// <see cref="ICatCommandProcessor"/> keeps opening a scope per command.
/// </summary>
public interface ICatCurrentScopeCommandProcessor
{
    /// <summary>
    /// Runs a command in the scope of the caller.
    /// </summary>
    /// <param name="catCommand">The command to run.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The response of the handler.</returns>
    Task<ICatResponse> ProcessInCurrentScopeAsync(ICatCommand catCommand, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs a command that returns a result, in the scope of the caller.
    /// </summary>
    /// <typeparam name="TResult">The type of the data the command returns.</typeparam>
    /// <param name="catCommand">The command to run.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The response of the handler, with the result when it succeeded.</returns>
    Task<ICatResponse<TResult>> ProcessInCurrentScopeAsync<TResult>(ICatCommand<TResult> catCommand, CancellationToken cancellationToken = default);
}
