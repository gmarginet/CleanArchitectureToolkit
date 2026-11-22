using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Localizations.Abstractions;

namespace Cat.Demo.CatalogService.Infrastructure.Extensions;

public static class CategoryTranslationExtensions
{
    /// <summary>
    /// Puts the name in the language of the request on each category, with one database call.
    /// Use it on categories that were read without tracking, so the new name is never saved.
    /// </summary>
    public static async Task TranslateNamesAsync(this ICatTranslator translator, IEnumerable<Category?> categories, CancellationToken cancellationToken)
    {
        var list = categories.OfType<Category>().ToList();
        if (list.Count == 0)
        {
            return;
        }

        var defaults = list.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.First().Name);
        var names = await translator.GetTextsAsync<Category>(defaults, nameof(Category.Name), cancellationToken);
        foreach (var category in list)
        {
            category.Name = names[category.Id];
        }
    }
}
