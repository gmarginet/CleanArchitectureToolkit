using System;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Commands;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Demo.CatalogService.DataModels.Entities;
using Riok.Mapperly.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Extensions;

[Mapper]
public static partial class MappingExtensions
{
    public static partial BookSearchQuery ToQuery(this BookSearchRequest request);

    public static partial BookGetQuery ToQuery(this BookGetRequest request);

    [MapProperty(nameof(Book.Category) + "." + nameof(Category.Name), nameof(BookModel.CategoryName))]
    [MapProperty(nameof(Book.BookPrice) + "." + nameof(BookPrice.Amount), nameof(BookModel.Price))]
    [MapperIgnoreSource(nameof(Book.SequenceId))]
    public static partial BookModel ToModel(this Book book);

    [MapperIgnoreSource(nameof(Category.SequenceId))]
    public static partial CategoryModel ToModel(this Category category);

    public static BookPriceModel ToPriceModel(this BookPrice bookPrice)
        => new() { BookId = bookPrice.BookId, Price = bookPrice.Amount };

    public static BookSaveCommand ToCommand(this BookSaveRequest request)
    {
        var model = request.Book;
        var book = new Book
        {
            Isbn = model.Isbn,
            CategoryId = model.CategoryId,
            Title = model.Title,
            Author = model.Author
        };

        if (model.Id != Guid.Empty)
        {
            book.Id = model.Id;
        }

        return new BookSaveCommand(book, model.Price);
    }
}
