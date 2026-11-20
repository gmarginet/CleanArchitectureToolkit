using SequentialGuid;

namespace Cat.EFCore.Entities;

/// <summary>
/// Base class for entities that live in a regular table.
/// It gives every entity a unique id and a database generated sequence number.
/// </summary>
public class CatEntityBase
{
    /// <summary>
    /// Gets or sets the unique id of the entity. It is the primary key, and on SQL Server a non-clustered one.
    /// A new time ordered <see cref="Guid"/> (UUID version 7) is created when the entity is instantiated,
    /// so the index on the id fills at the end and not at random places.
    /// </summary>
    public Guid Id { get; set; } = GuidV7.NewGuid();

    /// <summary>
    /// Gets or sets the sequence number of the entity.
    /// The database generates it as an identity column. On SQL Server it is the clustered index.
    /// It never changes after the first save.
    /// </summary>
    public int SequenceId { get; set; }
}
