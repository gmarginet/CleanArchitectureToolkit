using System;
using Microsoft.Data.SqlClient;

namespace Cat.Db.Errors.SqlServer;

/// <summary>
/// Extension methods that recognize SQL Server errors by their error number.
/// Each check looks at the exception itself and at the exceptions inside it, so you can call it on
/// the <c>DbUpdateException</c> of Entity Framework Core as well as on the <see cref="SqlException"/> of Dapper.
/// </summary>
public static class CatSqlServerErrorExtensions
{
    /// <summary>
    /// Finds the first <see cref="SqlException"/> in the exception chain.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns>The SQL Server exception, or <c>null</c> when the chain has none.</returns>
    public static SqlException? FindSqlException(this Exception? exception)
    {
        while (exception != null)
        {
            if (exception is SqlException sqlException) return sqlException;
            exception = exception.InnerException;
        }

        return null;
    }

    /// <summary>
    /// A unique constraint, primary key or unique index was violated. Numbers 2627 and 2601.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a unique key or unique index violation.</returns>
    public static bool IsUniqueViolation(this Exception? exception)
    {
        var number = exception.FindSqlException()?.Number;
        return number == CatSqlServerErrorNumbers.UniqueKeyViolation
               || number == CatSqlServerErrorNumbers.UniqueIndexViolation;
    }

    /// <summary>
    /// A foreign key constraint was violated. Number 547.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a foreign key violation.</returns>
    public static bool IsForeignKeyViolation(this Exception? exception)
    {
        return exception.FindSqlException()?.Number == CatSqlServerErrorNumbers.ForeignKeyViolation;
    }

    /// <summary>
    /// The transaction was chosen as the deadlock victim. Number 1205. Running the work again usually helps.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a deadlock.</returns>
    public static bool IsDeadlock(this Exception? exception)
    {
        return exception.FindSqlException()?.Number == CatSqlServerErrorNumbers.Deadlock;
    }

    /// <summary>
    /// A command timed out, or the server gave up waiting for a lock. Numbers -2 and 1222.
    /// </summary>
    /// <param name="exception">The exception to look at.</param>
    /// <returns><c>true</c> when the exception is a command timeout or a lock timeout.</returns>
    public static bool IsTimeout(this Exception? exception)
    {
        var number = exception.FindSqlException()?.Number;
        return number == CatSqlServerErrorNumbers.CommandTimeout
               || number == CatSqlServerErrorNumbers.LockRequestTimeout;
    }
}
