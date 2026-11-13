using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Commands;
using Cat.Demo.CatalogService.CoreService.Queries;
using Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.UnitTesting.Commands;
using Cat.UnitTesting.Queries;
using Cat.UnitTesting.Responses.NUnit;

namespace Cat.Demo.CatalogService.CoreService.Tests;

[TestFixture]
public class ServiceRequestHandlerTests
{
    private FakeQueryProcessor _queryProcessor = null!;
    private FakeCommandProcessor _commandProcessor = null!;

    [SetUp]
    public void SetUp()
    {
        _queryProcessor = new FakeQueryProcessor();
        _commandProcessor = new FakeCommandProcessor();
    }

    private static Book NewBook(string title, Category? category = null) => new()
    {
        Id = Guid.NewGuid(),
        Isbn = "9780132350884",
        Title = title,
        Author = "Someone",
        Category = category,
        BookPrice = new BookPrice { Amount = 10m }
    };

    #region BookSearch

    [Test]
    public async Task BookSearch_ShouldSendTheQueryAndMapTheBooks()
    {
        var categoryId = Guid.NewGuid();
        _queryProcessor.Respond<BookSearchQuery, IList<Book>>(
            CatResponse.Ok<IList<Book>>([NewBook("A", new Category { Name = "Software" }), NewBook("B")]));
        var handler = new BookSearchRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new BookSearchRequest("clean", categoryId));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response, CatIs.Succeeded);
            Assert.That(response.Value!.Select(b => b.Title), Is.EqualTo(new[] { "A", "B" }));
            Assert.That(response.Value![0].CategoryName, Is.EqualTo("Software"));
            Assert.That(response.Value![0].Price, Is.EqualTo(10m));
            Assert.That(_queryProcessor.Queries.Single(), Is.EqualTo(new BookSearchQuery("clean", categoryId)));
        }
    }

    [Test]
    public async Task BookSearch_WhenTheQueryFails_ShouldPassTheFailureOn()
    {
        _queryProcessor.Respond<BookSearchQuery, IList<Book>>(CatResponse.InternalServerError<IList<Book>>());
        var handler = new BookSearchRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new BookSearchRequest(null, null));

        Assert.That(response, CatIs.Failed);
    }

    #endregion BookSearch

    #region BookGet

    [Test]
    public async Task BookGet_ShouldSendTheQueryAndMapTheBook()
    {
        var book = NewBook("Clean Code");
        _queryProcessor.Respond<BookGetQuery, Book>(CatResponse.Ok(book));
        var handler = new BookGetRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new BookGetRequest(book.Id));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response, CatIs.Succeeded);
            Assert.That(response.Value!.Id, Is.EqualTo(book.Id));
            Assert.That(response.Value!.Title, Is.EqualTo("Clean Code"));
            Assert.That(_queryProcessor.Queries.Single(), Is.EqualTo(new BookGetQuery(book.Id)));
        }
    }

    [Test]
    public async Task BookGet_WhenTheBookIsMissing_ShouldPassNotFoundOn()
    {
        _queryProcessor.Respond<BookGetQuery, Book>(CatResponse.NotFound<Book>());
        var handler = new BookGetRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new BookGetRequest(Guid.NewGuid()));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound));
        }
    }

    #endregion BookGet

    #region BookPriceList

    [Test]
    public async Task BookPriceList_ShouldAskForTheDistinctIdsAndKeepTheRequestOrder()
    {
        var first = Guid.NewGuid();
        var second = Guid.NewGuid();
        _queryProcessor.Respond<BookPriceListQuery, IList<BookPriceInfo>>(CatResponse.Ok<IList<BookPriceInfo>>(
        [
            new BookPriceInfo(second, "9780000000002", 20m),
            new BookPriceInfo(first, "9780000000001", 10m)
        ]));
        var handler = new BookPriceListRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new BookPriceListRequest([first, second, first]));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response, CatIs.Succeeded);
            Assert.That(response.Value!.Select(p => (p.BookId, p.Isbn, p.Price)), Is.EqualTo(new[] { (first, "9780000000001", 10m), (second, "9780000000002", 20m) }));
            Assert.That(((BookPriceListQuery)_queryProcessor.Queries.Single()).BookIds, Is.EqualTo(new[] { first, second }));
        }
    }

    [Test]
    public async Task BookPriceList_WhenABookHasNoPrice_ShouldReturnNotFoundThatNamesTheId()
    {
        var known = Guid.NewGuid();
        var unknown = Guid.NewGuid();
        _queryProcessor.Respond<BookPriceListQuery, IList<BookPriceInfo>>(CatResponse.Ok<IList<BookPriceInfo>>(
            [new BookPriceInfo(known, "9780000000001", 10m)]));
        var handler = new BookPriceListRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new BookPriceListRequest([known, unknown]));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound));
            Assert.That(response.ErrorList.Single().Code, Is.EqualTo(CatalogErrorDefinitions.BookPriceNotFound.Code));
            Assert.That(response.ErrorList.Single().Arguments, Is.EqualTo(new object?[] { unknown }));
        }
    }

    [Test]
    public async Task BookPriceList_WhenTheQueryFails_ShouldPassTheFailureOn()
    {
        _queryProcessor.Respond<BookPriceListQuery, IList<BookPriceInfo>>(CatResponse.InternalServerError<IList<BookPriceInfo>>());
        var handler = new BookPriceListRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new BookPriceListRequest([Guid.NewGuid()]));

        Assert.That(response, CatIs.Failed);
    }

    #endregion BookPriceList

    #region BookSave

    [Test]
    public async Task BookSave_ShouldSendTheCommandAndReturnItsResponse()
    {
        var handler = new BookSaveRequestHandler(_commandProcessor);
        var model = new Contracts.Models.BookModel
        {
            Isbn = "9780132350884",
            CategoryId = Guid.NewGuid(),
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Price = 20m
        };

        var response = await handler.HandleAsync(new BookSaveRequest(model));

        var command = (BookSaveCommand)_commandProcessor.Commands.Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response, CatIs.Succeeded);
            Assert.That(command.Book.Isbn, Is.EqualTo(model.Isbn));
            Assert.That(command.Price, Is.EqualTo(20m));
        }
    }

    [Test]
    public async Task BookSave_WhenTheCommandFails_ShouldPassTheFailureOn()
    {
        _commandProcessor.DefaultResponse = CatResponse.InternalServerError();
        var handler = new BookSaveRequestHandler(_commandProcessor);
        var model = new Contracts.Models.BookModel { Isbn = "1", Title = "T", Author = "A" };

        var response = await handler.HandleAsync(new BookSaveRequest(model));

        Assert.That(response, CatIs.Failed);
    }

    #endregion BookSave

    #region CategoryGetList

    [Test]
    public async Task CategoryGetList_ShouldMapTheCategories()
    {
        var categories = new List<Category>
        {
            new() { Id = Guid.NewGuid(), Name = "Fiction" },
            new() { Id = Guid.NewGuid(), Name = "History" }
        };
        _queryProcessor.Respond<CategoryGetListQuery, IList<Category>>(CatResponse.Ok<IList<Category>>(categories));
        var handler = new CategoryGetListRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new CategoryGetListRequest());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response, CatIs.Succeeded);
            Assert.That(response.Value!.Select(c => c.Name), Is.EqualTo(new[] { "Fiction", "History" }));
            Assert.That(response.Value!.Select(c => c.Id), Is.EqualTo(categories.Select(c => c.Id)));
        }
    }

    [Test]
    public async Task CategoryGetList_WhenTheQueryFails_ShouldPassTheFailureOn()
    {
        _queryProcessor.Respond<CategoryGetListQuery, IList<Category>>(CatResponse.InternalServerError<IList<Category>>());
        var handler = new CategoryGetListRequestHandler(_queryProcessor);

        var response = await handler.HandleAsync(new CategoryGetListRequest());

        Assert.That(response, CatIs.Failed);
    }

    #endregion CategoryGetList
}
