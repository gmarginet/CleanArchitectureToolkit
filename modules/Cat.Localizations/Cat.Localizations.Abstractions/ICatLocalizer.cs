namespace Cat.Localizations.Abstractions;

/// <summary>
/// Looks up localized strings by key.
/// </summary>
public interface ICatLocalizer
{
    /// <summary>
    /// Gets the localized string for the given key.
    /// </summary>
    /// <param name="key">The key to look up.</param>
    string this[string key] { get; }

    /// <summary>
    /// Gets the localized string for the given key, with placeholders filled in from the given arguments.
    /// </summary>
    /// <param name="key">The key to look up. Its localized value can contain placeholders, filled in order by <paramref name="arguments"/>.</param>
    /// <param name="arguments">The values to substitute into the localized string's placeholders, in order.</param>
    string this[string key, params object[] arguments] { get; }
}