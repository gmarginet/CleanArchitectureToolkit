namespace Cat.Sql.Cdc.Abstractions;

/// <summary>
/// What happened to the row.
/// </summary>
public enum CatChangeOperation
{
    /// <summary>
    /// A row was inserted. <see cref="CatChange.New"/> holds its values.
    /// </summary>
    Insert,

    /// <summary>
    /// A row was updated. <see cref="CatChange.Old"/> and <see cref="CatChange.New"/> hold the values before and after.
    /// </summary>
    Update,

    /// <summary>
    /// A row was deleted. <see cref="CatChange.Old"/> holds its values.
    /// </summary>
    Delete
}
