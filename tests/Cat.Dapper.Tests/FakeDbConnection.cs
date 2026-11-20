using System.Data;
using System.Data.Common;
using Cat.Dapper.Abstractions;

namespace Cat.Dapper.Tests;

/// <summary>
/// A connection that only counts what the session does with it. It runs no SQL.
/// </summary>
public class FakeDbConnection : DbConnection
{
    private ConnectionState _state = ConnectionState.Closed;

    public int OpenCount { get; private set; }

    public bool IsDisposed { get; private set; }

    public FakeDbTransaction? LastTransaction { get; private set; }

    /// <summary>
    /// Makes the transactions behave like the ones of Npgsql: a completed transaction keeps its connection and throws when it is asked for its isolation level.
    /// </summary>
    public bool CompletedTransactionsKeepTheirConnection { get; set; }

    [System.Diagnostics.CodeAnalysis.AllowNull]
    public override string ConnectionString { get; set; } = string.Empty;

    public override string Database => "fake";

    public override string DataSource => "fake";

    public override string ServerVersion => "1.0";

    public override ConnectionState State => _state;

    public override void ChangeDatabase(string databaseName)
    {
    }

    public override void Close() => _state = ConnectionState.Closed;

    public override void Open()
    {
        OpenCount++;
        _state = ConnectionState.Open;
    }

    protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
    {
        LastTransaction = new FakeDbTransaction(this, isolationLevel, CompletedTransactionsKeepTheirConnection);
        return LastTransaction;
    }

    protected override DbCommand CreateDbCommand() => throw new NotSupportedException();

    protected override void Dispose(bool disposing)
    {
        IsDisposed = true;
        base.Dispose(disposing);
    }
}

public class FakeDbTransaction : DbTransaction
{
    private readonly IsolationLevel _isolationLevel;
    private readonly bool _keepsConnection;
    private DbConnection? _connection;
    private bool _completed;

    public FakeDbTransaction(DbConnection connection, IsolationLevel isolationLevel, bool keepsConnection = false)
    {
        _connection = connection;
        _isolationLevel = isolationLevel;
        _keepsConnection = keepsConnection;
    }

    public bool Committed { get; private set; }

    public bool RolledBack { get; private set; }

    public override IsolationLevel IsolationLevel =>
        _keepsConnection && _completed ? throw new InvalidOperationException("Transaction is already completed") : _isolationLevel;

    protected override DbConnection? DbConnection => _connection;

    public override void Commit()
    {
        Committed = true;
        Complete();
    }

    public override void Rollback()
    {
        RolledBack = true;
        Complete();
    }

    private void Complete()
    {
        _completed = true;
        if (!_keepsConnection) _connection = null;
    }

    protected override void Dispose(bool disposing)
    {
        // Like a real transaction, a transaction that is not completed rolls back when it is disposed.
        if (!_completed)
        {
            Rollback();
        }

        base.Dispose(disposing);
    }
}

public class FakeDbConnectionFactory : ICatDbConnectionFactory
{
    public List<FakeDbConnection> Created { get; } = new();

    public bool CompletedTransactionsKeepTheirConnection { get; set; }

    public DbConnection CreateConnection()
    {
        var connection = new FakeDbConnection { CompletedTransactionsKeepTheirConnection = CompletedTransactionsKeepTheirConnection };
        Created.Add(connection);
        return connection;
    }
}
