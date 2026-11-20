using Cat.EFCore.Entities;

namespace Cat.EFCore.Entities.SqlServer;

/// <summary>
/// Base class for entities that live in a temporal table.
/// The database keeps the history of every change in a separate history table.
/// The period properties exist on <c>net11.0</c> only, because EF Core 10 needs them as shadow properties.
/// </summary>
public class CatTemporalEntityBase : CatEntityBase
{
#if NET11_0_OR_GREATER
    /// <summary>
    /// The start of the period in which this version of the row was current.
    /// EF Core and the database set it. Do not set it yourself.
    /// </summary>
    public DateTime ValidFrom { get; set; }

    /// <summary>
    /// The end of the period in which this version of the row was current.
    /// EF Core and the database set it. Do not set it yourself.
    /// </summary>
    public DateTime ValidUntil { get; set; }
#endif
}
