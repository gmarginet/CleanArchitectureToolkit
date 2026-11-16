using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Dapper.Abstractions;

/// <summary>
/// One database connection for the length of one scope, such as one request or one message.
/// The session takes the connection from <see cref="ICatDbConnectionFactory"/> and opens it on first use,
/// so a handler never opens or closes a connection. A session is not thread safe.
/// </summary>
public interface ICatDbSession : IDisposable
{
    /// <summary>
    /// The transaction that is running, or <c>null</c> when there is none.
    /// A transaction that was committed or rolled back is no longer running, so this is <c>null</c> after that.
    /// </summary>
    DbTransaction? Transaction { get; }

    /// <summary>
    /// Gives the connection of the session. It creates the connection and opens it on the first call.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The open connection.</returns>
    Task<DbConnection> GetConnectionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Starts a transaction on the connection of the session. Commit it explicitly.
    /// A transaction that is not committed rolls back when the session is disposed.
    /// </summary>
    /// <param name="isolationLevel">The isolation level. The default is the default of the database.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The new transaction.</returns>
    /// <exception cref="InvalidOperationException">Thrown when a transaction is already running.</exception>
    Task<DbTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Unspecified, CancellationToken cancellationToken = default);
}
