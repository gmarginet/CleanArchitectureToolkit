using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.Users.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.CatalogService.Infrastructure.Extensions;

public static class CatalogDatabaseInitializer
{
    // The seed is not a person. Its prices belong to the named system user of the service.
    private static readonly CatUser SeedUser = CatUser.System("catalog");

    /// <summary>
    /// Applies the migrations and fills an empty database with a few categories and books.
    /// Call it in development only.
    /// </summary>
    public static async Task InitializeCatalogDatabaseAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();

        await dbContext.Database.MigrateAsync(cancellationToken);

        if (await dbContext.Categories.AnyAsync(cancellationToken))
        {
            return;
        }

        var fiction = new Category { Name = "Fiction" };
        var science = new Category { Name = "Science" };
        var history = new Category { Name = "History" };
        var technology = new Category { Name = "Technology" };
        dbContext.Categories.AddRange(fiction, science, history, technology);

        dbContext.Books.AddRange(
            NewBook("9780141036144", fiction, "1984", "George Orwell", 9.99m),
            NewBook("9780261103573", fiction, "The Fellowship of the Ring", "J.R.R. Tolkien", 12.50m),
            NewBook("9780553380163", science, "A Brief History of Time", "Stephen Hawking", 11.95m),
            NewBook("9780198788607", science, "The Selfish Gene", "Richard Dawkins", 10.99m),
            NewBook("9780099590088", history, "Sapiens", "Yuval Noah Harari", 14.99m),
            NewBook("9780132350884", technology, "Clean Code", "Robert C. Martin", 39.95m),
            NewBook("9780134494166", technology, "Clean Architecture", "Robert C. Martin", 34.95m));

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private static Book NewBook(string isbn, Category category, string title, string author, decimal price)
    {
        var book = new Book
        {
            Isbn = isbn,
            Category = category,
            Title = title,
            Author = author
        };
        book.BookPrice = new BookPrice { BookId = book.Id, Amount = price, LastUpdatedBy = SeedUser.UserId };
        return book;
    }
}
