using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Cat.Dapper.Abstractions;

namespace Cat.Dapper;

/// <summary>
/// The default <see cref="ICatDbSession"/>. It takes one connection from the factory, opens it on first use
/// and disposes it, and a transaction that was not committed, with the scope.
/// </summary>
public sealed class CatDbSession : ICatDbSession
{
    private readonly ICatDbConnectionFactory _connectionFactory;
    private DbConnection? _connection;
    private DbTransaction? _transaction;
    private bool _disposed;

    /// <summary>
    /// Creates the session.
    /// </summary>
    /// <param name="connectionFactory">Creates the connection of the session.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="connectionFactory"/> is <c>null</c>.</exception>
    public CatDbSession(ICatDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    /// <inheritdoc />
    public DbTransaction? Transaction
    {
        get
        {
            // A transaction that was committed or rolled back gives up its connection.
            return _transaction?.Connection == null ? null : _transaction;
        }
    }

    /// <inheritdoc />
    public async Task<DbConnection> GetConnectionAsync(CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();

        _connection ??= _connectionFactory.CreateConnection();
        if (_connection.State == ConnectionState.Closed)
        {
            await _connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        }

        return _connection;
    }

    /// <inheritdoc />
    public async Task<DbTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Unspecified, CancellationToken cancellationToken = default)
    {
        if (Transaction != null)
        {
            throw new InvalidOperationException("A transaction is already running on this session. Commit or roll it back first.");
        }

        var connection = await GetConnectionAsync(cancellationToken).ConfigureAwait(false);
        _transaction?.Dispose();
        _transaction = connection.BeginTransaction(isolationLevel);
        return _transaction;
    }

    /// <summary>
    /// Disposes the transaction, which rolls it back when it is not committed, and then the connection.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        _transaction?.Dispose();
        _transaction = null;
        _connection?.Dispose();
        _connection = null;
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(CatDbSession));
        }
    }
}
