using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.CoreService;
using Cat.Demo.CatalogService.CoreService.Commands;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Db.Errors.SqlServer;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Users.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.CommandHandlers;

public class BookSaveCommandHandler(CatalogDbContext dbContext, ICatUser user)
    : CatEfCommandHandlerBase<CatalogDbContext, BookSaveCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(BookSaveCommand command, CancellationToken cancellationToken = default)
    {
        var incoming = command.Book;

        var book = await DbContext.Books
            .Include(x => x.BookPrice)
            .FirstOrDefaultAsync(x => x.Id == incoming.Id, cancellationToken);

        if (book is null)
        {
            book = incoming;
            DbContext.Books.Add(book);
        }
        else
        {
            book.Isbn = incoming.Isbn;
            book.CategoryId = incoming.CategoryId;
            book.Title = incoming.Title;
            book.Author = incoming.Author;
        }

        if (command.Price is { } price)
        {
            if (book.BookPrice is null)
            {
                book.BookPrice = new BookPrice { BookId = book.Id, Amount = price, LastUpdatedBy = user.UserId };
            }
            else if (book.BookPrice.Amount != price)
            {
                // The update is enough. The temporal table keeps the old amount and who set it in its history.
                book.BookPrice.Amount = price;
                book.BookPrice.LastUpdatedBy = user.UserId;
            }
        }

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex) when (ex.IsUniqueViolation())
        {
            // Two saves with the same new ISBN passed the validator at the same moment. The unique index stopped the second.
            return CatResponse.BadRequest(CatalogErrorDefinitions.IsbnAlreadyExists.CreateCatError(book.Isbn));
        }

        return CatResponse.Ok();
    }
}
