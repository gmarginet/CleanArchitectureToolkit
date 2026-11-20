using System;
using Npgsql;

namespace Cat.Db.Errors.PostgreSQL;

/// <summary>
/// Extension methods that recognize PostgreSQL errors by their SQLSTATE code.
/// Each check looks at the exception itself and at the exceptions inside it, so you can call it on
/// the <c>DbUpdateException</c> of Entity Framework Core as well as on the <see cref="PostgresException"/> of Dapper.
/// </summary>
public static class CatPostgreSQLErrorExtensions
{
    /// <summary>
    /// Finds the first <see cref="PostgresException"/> in the exception chain.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns>The PostgreSQL exception, or <c>null</c> when the chain has none.</returns>
    public static PostgresException? FindPostgresException(this Exception? exception)
    {
        while (exception != null)
        {
            if (exception is PostgresException postgresException) return postgresException;
            exception = exception.InnerException;
        }

        return null;
    }

    /// <summary>
    /// A unique constraint, primary key or unique index was violated. Code 23505.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a unique key or unique index violation.</returns>
    public static bool IsUniqueViolation(this Exception? exception)
    {
        return exception.GetSqlState() == CatPostgreSQLErrorCodes.UniqueViolation;
    }

    /// <summary>
    /// A foreign key constraint was violated. Code 23503.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a foreign key violation.</returns>
    public static bool IsForeignKeyViolation(this Exception? exception)
    {
        return exception.GetSqlState() == CatPostgreSQLErrorCodes.ForeignKeyViolation;
    }

    /// <summary>
    /// The transaction was chosen as the deadlock victim. Code 40P01. Running the work again usually helps.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a deadlock.</returns>
    public static bool IsDeadlock(this Exception? exception)
    {
        return exception.GetSqlState() == CatPostgreSQLErrorCodes.DeadlockDetected;
    }

    /// <summary>
    /// A command timed out, the server cancelled the statement, or a lock was not available.
    /// A <see cref="TimeoutException"/> in the exception chain, and the codes 57014 and 55P03.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a command timeout, a cancelled statement or a lock that is not available.</returns>
    public static bool IsTimeout(this Exception? exception)
    {
        var sqlState = exception.GetSqlState();
        return sqlState == CatPostgreSQLErrorCodes.QueryCanceled
               || sqlState == CatPostgreSQLErrorCodes.LockNotAvailable
               || exception.HasTimeoutException();
    }

    private static string? GetSqlState(this Exception? exception)
    {
        return exception.FindPostgresException()?.SqlState;
    }

    private static bool HasTimeoutException(this Exception? exception)
    {
        while (exception != null)
        {
            if (exception is TimeoutException) return true;
            exception = exception.InnerException;
        }

        return false;
    }
}
