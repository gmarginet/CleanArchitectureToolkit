using System.Threading;
using System.Threading.Tasks;

namespace Cat.Messaging.Abstractions;

/// <summary>
/// Gives the token that travels with a message, so the receiver knows who sent the work.
/// The host implements it, for example by reading the <c>Authorization</c> header of the current request.
/// A host that registers none sends messages without a token.
/// </summary>
public interface ICatTokenProvider
{
    /// <summary>
    /// Gets the token for a message that is about to leave.
    /// </summary>
    /// <param name="subject">Whose token to give. A message with a scheduled time asks for the token of the system.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The raw token without the <c>Bearer</c> prefix, or null or empty when there is none.</returns>
    Task<string?> GetTokenAsync(CatTokenSubject subject, CancellationToken cancellationToken = default);
}
