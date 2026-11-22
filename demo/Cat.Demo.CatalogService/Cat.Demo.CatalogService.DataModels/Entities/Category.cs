using Cat.EFCore.Entities;
using Cat.Localizations.Abstractions;

namespace Cat.Demo.CatalogService.DataModels.Entities;

/// <summary>A book category. <see cref="Name"/> is the English default. The Dutch name lives in the translation table.</summary>
public class Category : CatEntityBase, ICatTranslatable
{
    public required string Name { get; set; }
}
