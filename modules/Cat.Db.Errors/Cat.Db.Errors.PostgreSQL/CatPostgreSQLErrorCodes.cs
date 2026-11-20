namespace Cat.Db.Errors.PostgreSQL;

/// <summary>
/// The PostgreSQL error codes that <see cref="CatPostgreSQLErrorExtensions"/> looks for.
/// PostgreSQL reports a five character SQLSTATE code, so these constants are text and not numbers.
/// Use them when you need the code itself, for example in your own pattern match.
/// </summary>
public static class CatPostgreSQLErrorCodes
{
    /// <summary>
    /// A unique constraint, primary key or unique index was violated.
    /// </summary>
    public const string UniqueViolation = "23505";

    /// <summary>
    /// A row that you tried to add, change or delete breaks a foreign key.
    /// </summary>
    public const string ForeignKeyViolation = "23503";

    /// <summary>
    /// The transaction was chosen as the deadlock victim.
    /// </summary>
    public const string DeadlockDetected = "40P01";

    /// <summary>
    /// The server cancelled the statement, for example because the statement timeout ran out.
    /// </summary>
    public const string QueryCanceled = "57014";

    /// <summary>
    /// A lock that the statement asked for with no waiting is not available.
    /// </summary>
    public const string LockNotAvailable = "55P03";
}
