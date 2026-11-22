namespace Cat.Localizations.Abstractions;

/// <summary>
/// Reads and saves the translations of reference data. Reads use <c>CultureInfo.CurrentUICulture</c>,
/// the culture that <c>IStringLocalizer</c> reads too. A request, or a message of <c>Cat.EventProcessor</c>, sets it.
/// A text that has no translation comes back as the default text of the entity.
/// </summary>
public interface ICatTranslator
{
    /// <summary>
    /// Gets one text in the current culture.
    /// </summary>
    /// <typeparam name="TEntity">The translatable entity type.</typeparam>
    /// <param name="id">The id of the entity.</param>
    /// <param name="field">The name of the field, such as <c>Name</c>.</param>
    /// <param name="defaultText">The text of the entity itself, returned when there is no translation.</param>
    /// <param name="cancellationToken">Cancels the read.</param>
    /// <returns>The translation, or the default text.</returns>
    Task<string> GetTextAsync<TEntity>(Guid id, string field, string defaultText, CancellationToken cancellationToken = default)
        where TEntity : ICatTranslatable;

    /// <summary>
    /// Gets the same field of many entities in the current culture, with one database call.
    /// </summary>
    /// <typeparam name="TEntity">The translatable entity type.</typeparam>
    /// <param name="defaultTexts">The default text per entity id.</param>
    /// <param name="field">The name of the field, such as <c>Name</c>.</param>
    /// <param name="cancellationToken">Cancels the read.</param>
    /// <returns>The same ids, each with the translation or its default text.</returns>
    Task<IReadOnlyDictionary<Guid, string>> GetTextsAsync<TEntity>(IReadOnlyDictionary<Guid, string> defaultTexts, string field,
        CancellationToken cancellationToken = default)
        where TEntity : ICatTranslatable;

    /// <summary>
    /// Gets every translation of one field of one entity, for an admin screen.
    /// </summary>
    /// <typeparam name="TEntity">The translatable entity type.</typeparam>
    /// <param name="id">The id of the entity.</param>
    /// <param name="field">The name of the field, such as <c>Name</c>.</param>
    /// <param name="cancellationToken">Cancels the read.</param>
    /// <returns>The text per culture name.</returns>
    Task<IReadOnlyDictionary<string, string>> GetTranslationsAsync<TEntity>(Guid id, string field, CancellationToken cancellationToken = default)
        where TEntity : ICatTranslatable;

    /// <summary>
    /// Adds, changes or removes the translation of one field in one culture. It saves nothing,
    /// so the change goes into the same <c>SaveChanges</c> as the change of the entity.
    /// </summary>
    /// <typeparam name="TEntity">The translatable entity type.</typeparam>
    /// <param name="id">The id of the entity.</param>
    /// <param name="field">The name of the field, such as <c>Name</c>.</param>
    /// <param name="culture">The culture name, such as <c>nl</c>.</param>
    /// <param name="text">The translation. Null or white space removes it.</param>
    /// <param name="cancellationToken">Cancels the call.</param>
    /// <returns>A task that completes when the change is staged.</returns>
    Task SetTextAsync<TEntity>(Guid id, string field, string culture, string? text, CancellationToken cancellationToken = default)
        where TEntity : ICatTranslatable;
}
