namespace Cat.Db.Errors.SqlServer;

/// <summary>
/// The SQL Server error numbers that <see cref="CatSqlServerErrorExtensions"/> looks for.
/// Use them when you need the number itself, for example in your own pattern match.
/// </summary>
public static class CatSqlServerErrorNumbers
{
    /// <summary>
    /// A unique constraint or primary key was violated.
    /// </summary>
    public const int UniqueKeyViolation = 2627;

    /// <summary>
    /// A unique index was violated.
    /// </summary>
    public const int UniqueIndexViolation = 2601;

    /// <summary>
    /// A foreign key constraint was violated.
    /// </summary>
    public const int ForeignKeyViolation = 547;

    /// <summary>
    /// The transaction was chosen as the deadlock victim.
    /// </summary>
    public const int Deadlock = 1205;

    /// <summary>
    /// The command ran longer than its command timeout. The client raises this one, not the server.
    /// </summary>
    public const int CommandTimeout = -2;

    /// <summary>
    /// The server gave up waiting for a lock, because a lock timeout was set.
    /// </summary>
    public const int LockRequestTimeout = 1222;
}
