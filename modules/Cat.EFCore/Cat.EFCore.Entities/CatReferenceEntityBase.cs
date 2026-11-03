namespace Cat.EFCore.Entities;

/// <summary>
/// Base class for read-only reference data.
/// The table is excluded from migrations, so something else owns its schema.
/// </summary>
public class CatReferenceEntityBase
{
    /// <summary>
    /// Gets or sets the unique id of the entity. It is the non-clustered primary key.
    /// </summary>
    public Guid Id { get; set; }
}
