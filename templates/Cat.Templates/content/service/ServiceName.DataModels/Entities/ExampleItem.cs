#if (DatabaseFirst)
namespace ServiceName.DataModels.Entities;

/// <summary>
/// The example entity. Scaffold the entities from the database again when the schema changes, see the readme.
/// Replace it with the entities of the service.
/// </summary>
public partial class ExampleItem
{
    public Guid Id { get; set; }

    public int SequenceId { get; set; }

    public string Name { get; set; } = null!;
}
#else
using Cat.EFCore.Entities;

namespace ServiceName.DataModels.Entities;

/// <summary>The example entity. Replace it with the entities of the service.</summary>
public class ExampleItem : CatEntityBase
{
    public required string Name { get; set; }
}
#endif
