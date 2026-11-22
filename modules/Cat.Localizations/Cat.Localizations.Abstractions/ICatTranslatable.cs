namespace Cat.Localizations.Abstractions;

/// <summary>
/// Marks an entity that has texts an admin translates, such as the name of a category.
/// The entity keeps the default text in its own field. The translations live in the translation table.
/// </summary>
public interface ICatTranslatable
{
    /// <summary>
    /// Gets the id of the entity. A translation points to it.
    /// </summary>
    Guid Id { get; }
}
