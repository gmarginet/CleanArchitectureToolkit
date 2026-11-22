namespace Cat.Localizations.Abstractions;

/// <summary>
/// One translated text: one entity, one field and one language. The table holds one row for each combination.
/// There is no foreign key to the entity, so one table serves every translatable entity.
/// </summary>
public class CatTranslation
{
    /// <summary>
    /// Gets or sets the unique id of the translation. It is the key.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the type name of the entity, such as <c>Category</c>.
    /// </summary>
    public string EntityType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the id of the translated entity.
    /// </summary>
    public Guid EntityId { get; set; }

    /// <summary>
    /// Gets or sets the name of the translated field, such as <c>Name</c>.
    /// </summary>
    public string Field { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the culture name, such as <c>nl</c> or <c>nl-BE</c>.
    /// </summary>
    public string Culture { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the translated text.
    /// </summary>
    public string Text { get; set; } = string.Empty;
}
