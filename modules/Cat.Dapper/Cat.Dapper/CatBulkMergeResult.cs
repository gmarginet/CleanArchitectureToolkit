namespace Cat.Dapper;

/// <summary>
/// The outcome of a bulk merge, on every database that has one.
/// </summary>
public sealed class CatBulkMergeResult
{
    /// <summary>
    /// Creates the result.
    /// </summary>
    /// <param name="inserted">The number of rows that were inserted.</param>
    /// <param name="updated">The number of rows that were updated.</param>
    public CatBulkMergeResult(int inserted, int updated)
    {
        Inserted = inserted;
        Updated = updated;
    }

    /// <summary>
    /// The number of rows that did not exist and were inserted.
    /// </summary>
    public int Inserted { get; }

    /// <summary>
    /// The number of rows that existed and were updated.
    /// </summary>
    public int Updated { get; }
}
