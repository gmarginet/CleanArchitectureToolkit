using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.CatalogService.CoreService.Commands;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.Demo.CatalogService.Infrastructure.CommandHandlers;

public class BookSaveCommandHandler : ICatCommandHandler<BookSaveCommand>
{
    private readonly CatalogDbContext _dbContext;

    public BookSaveCommandHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
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
                book.BookPrice = new BookPrice { BookId = book.Id, Amount = price };
            }
            else if (book.BookPrice.Amount != price)
            {
                // The update is enough. The temporal table keeps the old amount in its history.
                book.BookPrice.Amount = price;
            }
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
