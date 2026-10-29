using Cat.Localizations.Abstractions;
using Cat.String.Extensions;
using Cat.Strings.Extensions;

namespace Cat.Localizations;

/// <summary>
/// Default <see cref="ICatLocalizer"/> implementation that performs no localization. It returns the key as-is,
/// only filling in placeholders for the indexer that takes arguments.
/// </summary>
internal class NoLocalizationCatLocalizer : ICatLocalizer
{
    /// <inheritdoc />
    public string this[string key] => key;

    /// <inheritdoc />
    public string this[string key, params object[] arguments] => key.NamedFormat(arguments);
}