using System.Globalization;
using Cat.Localizations.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cat.Localizations.EFCore;

/// <summary>
/// Default <see cref="ICatTranslator"/> on a <c>DbContext</c> that maps <see cref="CatTranslation"/>.
/// </summary>
/// <typeparam name="TDbContext">The <c>DbContext</c> with the translation table.</typeparam>
internal sealed class CatTranslator<TDbContext> : ICatTranslator
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly ILogger<CatTranslator<TDbContext>> _logger;

    /// <summary>
    /// Creates the translator.
    /// </summary>
    /// <param name="dbContext">The context that holds the translation table.</param>
    /// <param name="logger">Writes a debug line for a missing translation.</param>
    public CatTranslator(TDbContext dbContext, ILogger<CatTranslator<TDbContext>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<string> GetTextAsync<TEntity>(Guid id, string field, string defaultText, CancellationToken cancellationToken = default)
        where TEntity : ICatTranslatable
    {
        var texts = await GetTextsAsync<TEntity>(new Dictionary<Guid, string> { [id] = defaultText }, field, cancellationToken).ConfigureAwait(false);
        return texts[id];
    }

    /// <inheritdoc />
    public async Task<IReadOnlyDictionary<Guid, string>> GetTextsAsync<TEntity>(IReadOnlyDictionary<Guid, string> defaultTexts, string field,
        CancellationToken cancellationToken = default)
        where TEntity : ICatTranslatable
    {
        var entityType = typeof(TEntity).Name;
        var cultures = CultureChain(CultureInfo.CurrentUICulture);
        var result = new Dictionary<Guid, string>();
        foreach (var pair in defaultTexts)
        {
            result[pair.Key] = pair.Value;
        }

        if (defaultTexts.Count == 0 || cultures.Count == 0)
        {
            return result;
        }

        var ids = defaultTexts.Keys.ToList();
        var rows = await _dbContext.Set<CatTranslation>()
            .AsNoTracking()
            .Where(x => x.EntityType == entityType && x.Field == field && ids.Contains(x.EntityId) && cultures.Contains(x.Culture))
            .Select(x => new { x.EntityId, x.Culture, x.Text })
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        foreach (var id in ids)
        {
            // The most specific culture wins: nl-BE before nl.
            var found = cultures
                .Select(culture => rows.FirstOrDefault(r => r.EntityId == id && r.Culture == culture))
                .FirstOrDefault(r => r != null);
            if (found != null)
            {
                result[id] = found.Text;
            }
            else
            {
                // A missing translation is normal while an admin works, so it is no warning.
                _logger.LogDebug("No translation of {EntityType} {EntityId} field {Field} in {Culture}. The default text is used.",
                    entityType, id, field, CultureInfo.CurrentUICulture.Name);
            }
        }

        return result;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyDictionary<string, string>> GetTranslationsAsync<TEntity>(Guid id, string field,
        CancellationToken cancellationToken = default)
        where TEntity : ICatTranslatable
    {
        var entityType = typeof(TEntity).Name;
        var rows = await _dbContext.Set<CatTranslation>()
            .AsNoTracking()
            .Where(x => x.EntityType == entityType && x.EntityId == id && x.Field == field)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
        return rows.ToDictionary(x => x.Culture, x => x.Text);
    }

    /// <inheritdoc />
    public async Task SetTextAsync<TEntity>(Guid id, string field, string culture, string? text, CancellationToken cancellationToken = default)
        where TEntity : ICatTranslatable
    {
        var entityType = typeof(TEntity).Name;
        var set = _dbContext.Set<CatTranslation>();
        var existing = await set
            .FirstOrDefaultAsync(x => x.EntityType == entityType && x.EntityId == id && x.Field == field && x.Culture == culture, cancellationToken)
            .ConfigureAwait(false);

        if (text == null || string.IsNullOrWhiteSpace(text))
        {
            if (existing != null)
            {
                set.Remove(existing);
            }

            return;
        }

        if (existing == null)
        {
            set.Add(new CatTranslation { EntityType = entityType, EntityId = id, Field = field, Culture = culture, Text = text });
        }
        else
        {
            existing.Text = text;
        }
    }

    /// <summary>
    /// Lists the culture and its parents, most specific first, without the invariant culture. <c>nl-BE</c> gives <c>nl-BE</c> and <c>nl</c>.
    /// </summary>
    private static List<string> CultureChain(CultureInfo culture)
    {
        var chain = new List<string>();
        while (!string.IsNullOrEmpty(culture.Name))
        {
            chain.Add(culture.Name);
            culture = culture.Parent;
        }

        return chain;
    }
}
