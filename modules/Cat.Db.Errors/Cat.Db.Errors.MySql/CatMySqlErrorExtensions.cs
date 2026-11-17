using System;
using MySqlConnector;

namespace Cat.Db.Errors.MySql;

/// <summary>
/// Extension methods that recognize MySQL errors by their error number.
/// Each check looks at the exception itself and at the exceptions inside it, so you can call it on
/// the <c>DbUpdateException</c> of Entity Framework Core as well as on the <see cref="MySqlException"/> of Dapper.
/// </summary>
public static class CatMySqlErrorExtensions
{
    /// <summary>
    /// Finds the first <see cref="MySqlException"/> in the exception chain.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns>The MySQL exception, or <c>null</c> when the chain has none.</returns>
    public static MySqlException? FindMySqlException(this Exception? exception)
    {
        while (exception != null)
        {
            if (exception is MySqlException mySqlException) return mySqlException;
            exception = exception.InnerException;
        }

        return null;
    }

    /// <summary>
    /// A unique constraint, primary key or unique index was violated. Number 1062.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a unique key or unique index violation.</returns>
    public static bool IsUniqueViolation(this Exception? exception)
    {
        return exception.GetNumber() == CatMySqlErrorNumbers.DuplicateEntry;
    }

    /// <summary>
    /// A foreign key constraint was violated. Numbers 1451 and 1452.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a foreign key violation.</returns>
    public static bool IsForeignKeyViolation(this Exception? exception)
    {
        var number = exception.GetNumber();
        return number == CatMySqlErrorNumbers.RowIsReferenced
               || number == CatMySqlErrorNumbers.NoReferencedRow;
    }

    /// <summary>
    /// The transaction was chosen as the deadlock victim. Number 1213. Running the work again usually helps.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a deadlock.</returns>
    public static bool IsDeadlock(this Exception? exception)
    {
        return exception.GetNumber() == CatMySqlErrorNumbers.Deadlock;
    }

    /// <summary>
    /// A command timed out, or the server gave up waiting for a lock. Numbers -1 and 1205.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a command timeout or a lock wait timeout.</returns>
    public static bool IsTimeout(this Exception? exception)
    {
        var number = exception.GetNumber();
        return number == CatMySqlErrorNumbers.CommandTimeout
               || number == CatMySqlErrorNumbers.LockWaitTimeout;
    }

    private static int? GetNumber(this Exception? exception)
    {
        var mySqlException = exception.FindMySqlException();
        return mySqlException == null ? (int?)null : (int)mySqlException.ErrorCode;
    }
}
