namespace Cat.EFCore.Entities;

/// <summary>
/// Base class for entities that live in a temporal table.
/// The database keeps the history of every change in a separate history table.
/// </summary>
public class CatTemporalEntityBase : CatEntityBase
{
    // TODO: Uncomment next 2 lines after release of EF Core 11
    // public DateTime ValidFrom { get; set; }
    // public DateTime ValidUntil { get; set; }
}
