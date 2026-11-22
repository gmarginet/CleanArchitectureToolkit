using Cat.EFCore.Entities;

namespace ServiceName.DataModels.Entities;

/// <summary>The entity ItemName. It has an id and a sequence number from <see cref="CatEntityBase"/>. Add the properties.</summary>
public class ItemName : CatEntityBase
{
    public required string Name { get; set; }
}
