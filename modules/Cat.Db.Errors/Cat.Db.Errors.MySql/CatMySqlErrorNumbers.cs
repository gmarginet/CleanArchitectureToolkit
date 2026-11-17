namespace Cat.Db.Errors.MySql;

/// <summary>
/// The MySQL error numbers that <see cref="CatMySqlErrorExtensions"/> looks for.
/// Use them when you need the number itself, for example in your own pattern match.
/// </summary>
public static class CatMySqlErrorNumbers
{
    /// <summary>
    /// A unique constraint, primary key or unique index was violated.
    /// </summary>
    public const int DuplicateEntry = 1062;

    /// <summary>
    /// A row that you tried to delete or change is still referenced by a foreign key.
    /// </summary>
    public const int RowIsReferenced = 1451;

    /// <summary>
    /// A row that you tried to add or change points to a row that does not exist.
    /// </summary>
    public const int NoReferencedRow = 1452;

    /// <summary>
    /// The transaction was chosen as the deadlock victim.
    /// </summary>
    public const int Deadlock = 1213;

    /// <summary>
    /// The server gave up waiting for a lock, because the lock wait timeout ran out.
    /// </summary>
    public const int LockWaitTimeout = 1205;

    /// <summary>
    /// The command ran longer than its command timeout. The client raises this one, not the server.
    /// </summary>
    public const int CommandTimeout = -1;
}
