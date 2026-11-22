using System.Threading;
using System.Threading.Tasks;
using Cat.Caching.Abstractions;
using Cat.Demo.CatalogService.CoreService;
using Cat.Demo.CatalogService.CoreService.Commands;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.Demo.CatalogService.Infrastructure.QueryHandlers;
using Cat.EFCore.Commands;
using Cat.Localizations.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.CommandHandlers;

public class CategorySaveCommandHandler(CatalogDbContext dbContext, ICatTranslator translator, ICatQueryCache queryCache)
    : CatEfCommandHandlerBase<CatalogDbContext, CategorySaveCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(CategorySaveCommand command, CancellationToken cancellationToken = default)
    {
        var category = await DbContext.Categories.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        if (category is null)
        {
            category = new Category { Name = command.Name };
            DbContext.Categories.Add(category);
        }
        else
        {
            category.Name = command.Name;
        }

        // The translation joins the same SaveChanges as the category, so both are saved or neither.
        await translator.SetTextAsync<Category>(category.Id, nameof(Category.Name), CategoryGetQueryHandler.DutchCulture, command.NameNl, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        // The cached category list and the cached searches show the category name.
        await queryCache.RemoveByTagAsync(CatalogCacheTags.Categories, cancellationToken);
        await queryCache.RemoveByTagAsync(CatalogCacheTags.Books, cancellationToken);

        return CatResponse.Ok();
    }
}
