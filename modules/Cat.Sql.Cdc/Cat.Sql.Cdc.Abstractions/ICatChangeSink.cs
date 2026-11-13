using System.Threading;
using System.Threading.Tasks;

namespace Cat.Sql.Cdc.Abstractions;

/// <summary>
/// Receives the changes the reader found. Implement it to send a change anywhere. <c>Cat.Sql.Cdc.Messaging</c> has one that sends through <c>Cat.Messaging</c>.
/// The module delivers at least once. After a crash the same change can arrive again, so the sink or the receiver must cope with a repeat.
/// </summary>
public interface ICatChangeSink
{
    /// <summary>
    /// Sends one change. When it throws, the module does not move its position and tries the same change again.
    /// </summary>
    /// <param name="change">The row change.</param>
    /// <param name="message">What the registration of the table made of the change. It is the change itself when the table has no mapping.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that ends when the change is handed over.</returns>
    Task SendAsync(CatChange change, object message, CancellationToken cancellationToken = default);
}
