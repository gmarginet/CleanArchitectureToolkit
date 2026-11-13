using System.Threading;
using System.Threading.Tasks;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// Checks who sent a message and whether the message type allows that caller. The receiver calls it before the handler runs.
/// It is scoped, and it is resolved from the scope of the message, so it can set the user of that scope.
/// A service without an implementation runs its messages without a user and without a policy.
/// The implementation lives in an optional project, such as <c>Cat.EventProcessor.Authorization</c>.
/// </summary>
public interface ICatMessageAuthorizer
{
    /// <summary>
    /// Reads the token of the message, sets the user of the scope and checks the policy of the message type.
    /// </summary>
    /// <param name="message">The incoming message.</param>
    /// <param name="options">The settings of the message type, with its policy.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>Whether the handler may run, and why not when it may not.</returns>
    Task<CatAuthorizationResult> AuthorizeAsync(CatIncomingMessage message, CatReceiveOptions options, CancellationToken cancellationToken = default);
}
