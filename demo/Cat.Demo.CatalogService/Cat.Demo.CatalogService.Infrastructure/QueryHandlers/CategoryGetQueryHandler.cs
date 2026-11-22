using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.EFCore.Queries;
using Cat.Localizations.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.QueryHandlers;

public class CategoryGetQueryHandler(CatalogDbContext dbContext, ICatTranslator translator)
    : CatEfQueryHandlerBase<CatalogDbContext, CategoryGetQuery, CategoryEditModel>(dbContext)
{
    public const string DutchCulture = "nl";

    public override async Task<ICatResponse<CategoryEditModel>> HandleAsync(CategoryGetQuery query, CancellationToken cancellationToken = default)
    {
        var category = await Set<Category>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == query.CategoryId, cancellationToken);
        if (category is null)
        {
            return CatResponse.NotFound<CategoryEditModel>(
                CatError.Create(
                    CatGeneralErrorDefinitions.ResourceNotFound.Code,
                    CatGeneralErrorDefinitions.ResourceNotFound.Message,
                    "Category",
                    query.CategoryId));
        }

        var translations = await translator.GetTranslationsAsync<Category>(category.Id, nameof(Category.Name), cancellationToken);
        translations.TryGetValue(DutchCulture, out var dutch);
        return CatResponse.Ok(new CategoryEditModel { Id = category.Id, Name = category.Name, NameNl = dutch });
    }
}
