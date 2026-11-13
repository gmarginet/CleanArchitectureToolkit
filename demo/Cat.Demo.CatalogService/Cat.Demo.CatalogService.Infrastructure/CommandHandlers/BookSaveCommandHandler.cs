using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.CatalogService.CoreService;
using Cat.Demo.CatalogService.CoreService.Commands;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Users.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.CommandHandlers;

public class BookSaveCommandHandler : ICatCommandHandler<BookSaveCommand>
{
    private const int UniqueKeyViolation = 2627;
    private const int UniqueIndexViolation = 2601;

    private readonly CatalogDbContext _dbContext;
    private readonly ICatUser _user;

    public BookSaveCommandHandler(CatalogDbContext dbContext, ICatUser user)
    {
        _dbContext = dbContext;
        _user = user;
    }

    public async Task<ICatResponse> HandleAsync(BookSaveCommand command, CancellationToken cancellationToken = default)
    {
        var incoming = command.Book;

        var book = await _dbContext.Books
            .Include(x => x.BookPrice)
            .FirstOrDefaultAsync(x => x.Id == incoming.Id, cancellationToken);

        if (book is null)
        {
            book = incoming;
            _dbContext.Books.Add(book);
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
                book.BookPrice = new BookPrice { BookId = book.Id, Amount = price, LastUpdatedBy = _user.UserId };
            }
            else if (book.BookPrice.Amount != price)
            {
                // The update is enough. The temporal table keeps the old amount and who set it in its history.
                book.BookPrice.Amount = price;
                book.BookPrice.LastUpdatedBy = _user.UserId;
            }
        }

        try
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException { Number: UniqueKeyViolation or UniqueIndexViolation })
        {
            // Two saves with the same new ISBN passed the validator at the same moment. The unique index stopped the second.
            return CatResponse.BadRequest(CatalogErrorDefinitions.IsbnAlreadyExists.CreateCatError(book.Isbn));
        }

        return CatResponse.Ok();
    }
}
