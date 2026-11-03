namespace Cat.EFCore.Entities;

/// <summary>
/// Base class for entities that live in a regular table.
/// It gives every entity a unique id and a database generated sequence number.
/// </summary>
public class CatEntityBase
{
    /// <summary>
    /// Gets or sets the unique id of the entity. It is the non-clustered primary key.
    /// A new <see cref="Guid"/> is created when the entity is instantiated.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the sequence number of the entity.
    /// The database generates it as an identity column and it is the clustered index.
    /// It never changes after the first save.
    /// </summary>
    public int SequenceId { get; set; }
}
