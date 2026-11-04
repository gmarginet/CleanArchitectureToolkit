using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Extensions;
using Cat.Demo.CatalogService.DataModels.Entities;

namespace Cat.Demo.CatalogService.CoreService.Tests;

[TestFixture]
public class MappingExtensionsTests
{
    private static BookModel NewModel(Guid? id = null, decimal? price = 12.5m) => new()
    {
        Id = id ?? Guid.Empty,
        Isbn = "9780132350884",
        CategoryId = Guid.NewGuid(),
        Title = "Clean Code",
        Author = "Robert C. Martin",
        Price = price
    };

    [Test]
    public void BookSearchRequest_ToQuery_ShouldCopyTheFilters()
    {
        var categoryId = Guid.NewGuid();

        var query = new BookSearchRequest("clean", categoryId).ToQuery();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(query.Text, Is.EqualTo("clean"));
            Assert.That(query.CategoryId, Is.EqualTo(categoryId));
        }
    }

    [Test]
    public void BookSearchRequest_ToQuery_WithoutFilters_ShouldKeepThemEmpty()
    {
        var query = new BookSearchRequest(null, null).ToQuery();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(query.Text, Is.Null);
            Assert.That(query.CategoryId, Is.Null);
        }
    }

    [Test]
    public void BookGetRequest_ToQuery_ShouldCopyTheId()
    {
        var bookId = Guid.NewGuid();

        Assert.That(new BookGetRequest(bookId).ToQuery().BookId, Is.EqualTo(bookId));
    }

    [Test]
    public void Book_ToModel_ShouldFlattenCategoryAndPrice()
    {
        var category = new Category { Id = Guid.NewGuid(), Name = "Software" };
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Isbn = "9780132350884",
            CategoryId = category.Id,
            Category = category,
            Title = "Clean Code",
            Author = "Robert C. Martin",
            BookPrice = new BookPrice { Amount = 31.95m }
        };

        var model = book.ToModel();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(model.Id, Is.EqualTo(book.Id));
            Assert.That(model.Isbn, Is.EqualTo(book.Isbn));
            Assert.That(model.CategoryId, Is.EqualTo(category.Id));
            Assert.That(model.CategoryName, Is.EqualTo("Software"));
            Assert.That(model.Title, Is.EqualTo("Clean Code"));
            Assert.That(model.Author, Is.EqualTo("Robert C. Martin"));
            Assert.That(model.Price, Is.EqualTo(31.95m));
        }
    }

    [Test]
    public void Book_ToModel_WithoutCategoryAndPrice_ShouldLeaveThemEmpty()
    {
        var book = new Book { Isbn = "9780132350884", Title = "Clean Code", Author = "Robert C. Martin" };

        var model = book.ToModel();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(model.CategoryName, Is.Null);
            Assert.That(model.Price, Is.Null);
        }
    }

    [Test]
    public void Category_ToModel_ShouldCopyIdAndName()
    {
        var category = new Category { Id = Guid.NewGuid(), Name = "History" };

        var model = category.ToModel();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(model.Id, Is.EqualTo(category.Id));
            Assert.That(model.Name, Is.EqualTo("History"));
        }
    }

    [Test]
    public void BookSaveRequest_ToCommand_NewBook_ShouldKeepTheGeneratedId()
    {
        var model = NewModel();

        var command = new BookSaveRequest(model).ToCommand();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(command.Book.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(command.Book.Isbn, Is.EqualTo(model.Isbn));
            Assert.That(command.Book.CategoryId, Is.EqualTo(model.CategoryId));
            Assert.That(command.Book.Title, Is.EqualTo(model.Title));
            Assert.That(command.Book.Author, Is.EqualTo(model.Author));
            Assert.That(command.Price, Is.EqualTo(12.5m));
        }
    }

    [Test]
    public void BookSaveRequest_ToCommand_ExistingBook_ShouldUseTheModelId()
    {
        var id = Guid.NewGuid();

        var command = new BookSaveRequest(NewModel(id)).ToCommand();

        Assert.That(command.Book.Id, Is.EqualTo(id));
    }

    [Test]
    public void BookSaveRequest_ToCommand_WithoutPrice_ShouldLeaveThePriceEmpty()
    {
        var command = new BookSaveRequest(NewModel(price: null)).ToCommand();

        Assert.That(command.Price, Is.Null);
    }
}
