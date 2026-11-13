using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Demo.CatalogService.Contracts.ServiceRequests;
using Cat.Demo.CatalogService.CoreService.Validators;
using Cat.Expressions.Extensions;
using Cat.NUnit;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Cat.Validators;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.CatalogService.CoreService.Tests;

[TestFixture]
public class BookValidationTests : UnitTestBase
{
    private const string Isbn = "9780132350884";

    private readonly FakeQueryProcessor _queryProcessor = new();
    private ICatValidatorProcessor _validatorProcessor = null!;

    // Fully qualified, because the namespace Cat.ServiceCollection.Extensions is in scope through the Api project.
    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddCatCompiledMemberExpressionCache();
        services.AddCatValidatorsModule(typeof(BookModelValidator));
        services.AddSingleton<ICatQueryProcessor>(_queryProcessor);
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _validatorProcessor = ServiceProvider.GetRequiredService<ICatValidatorProcessor>();
    }

    [SetUp]
    public void SetUp()
    {
        _queryProcessor.Reset();
    }

    private static BookModel NewBook(Guid? id = null, string isbn = Isbn, decimal? price = 10m) => new()
    {
        Id = id ?? Guid.Empty,
        Isbn = isbn,
        CategoryId = Guid.NewGuid(),
        Title = "Clean Code",
        Author = "Robert C. Martin",
        Price = price
    };

    private static void AssertSingleError(ICatResponse response, string code, params object?[] arguments)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsFailed, Is.True);
            Assert.That(response.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.ErrorList[0].Code, Is.EqualTo(code));
            Assert.That(response.ErrorList[0].Arguments, Is.EquivalentTo(arguments));
        }
    }

    #region ISBN already in use

    [Test]
    public async Task Isbn_NotInUse_ShouldSucceed()
    {
        var result = await _validatorProcessor.ValidateAsync(NewBook());

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task Isbn_InUse_ShouldFail()
    {
        _queryProcessor.IsbnExists = true;

        var result = await _validatorProcessor.ValidateAsync(NewBook());

        AssertSingleError(result, CatalogErrorDefinitions.IsbnAlreadyExists.Code, "Isbn", Isbn);
    }

    [Test]
    public async Task Isbn_InUse_ThroughSaveRequest_ShouldPrefixTheFieldName()
    {
        _queryProcessor.IsbnExists = true;

        var result = await _validatorProcessor.ValidateAsync(new BookSaveRequest(NewBook()));

        AssertSingleError(result, CatalogErrorDefinitions.IsbnAlreadyExists.Code, "Book.Isbn", Isbn);
    }

    [Test]
    public async Task Isbn_NewBook_ShouldNotExcludeAnyBook()
    {
        await _validatorProcessor.ValidateAsync(NewBook());

        Assert.That(_queryProcessor.IsbnQueries, Has.Count.EqualTo(1));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_queryProcessor.IsbnQueries[0].Isbn, Is.EqualTo(Isbn));
            Assert.That(_queryProcessor.IsbnQueries[0].ExcludeBookId, Is.Null);
        }
    }

    [Test]
    public async Task Isbn_ExistingBook_ShouldExcludeItself()
    {
        var bookId = Guid.NewGuid();

        await _validatorProcessor.ValidateAsync(NewBook(bookId));

        Assert.That(_queryProcessor.IsbnQueries, Has.Count.EqualTo(1));
        Assert.That(_queryProcessor.IsbnQueries[0].ExcludeBookId, Is.EqualTo(bookId));
    }

    [Test]
    public async Task Isbn_Empty_ShouldNotLookItUp()
    {
        var result = await _validatorProcessor.ValidateAsync(NewBook(isbn: ""));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(_queryProcessor.IsbnQueries, Is.Empty);
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList.Select(e => e.Code), Does.Contain(CatValidatorErrorDefinitions.NotEmpty.Code));
        }
    }

    [Test]
    public async Task Isbn_WrongLength_ShouldReportTheLength()
    {
        var result = await _validatorProcessor.ValidateAsync(NewBook(isbn: "123"));

        AssertSingleError(result, CatValidatorErrorDefinitions.ExactLength.Code, "Isbn", 13, 3);
    }

    [Test]
    public async Task Isbn_LookupFails_ShouldThrow()
    {
        _queryProcessor.FailLookup = true;

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _validatorProcessor.ValidateAsync(NewBook()));
    }

    #endregion ISBN already in use

    #region Other rules

    [Test]
    public async Task Price_Empty_ShouldSucceed()
    {
        var result = await _validatorProcessor.ValidateAsync(NewBook(price: null));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task Price_Zero_ShouldSucceed()
    {
        var result = await _validatorProcessor.ValidateAsync(NewBook(price: 0m));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task Price_Negative_ShouldFail()
    {
        var result = await _validatorProcessor.ValidateAsync(NewBook(price: -0.01m));

        AssertSingleError(result, CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Code, "Price", 0m);
    }

    [Test]
    public async Task Title_Empty_ShouldFail()
    {
        var book = NewBook();
        book.Title = "";

        var result = await _validatorProcessor.ValidateAsync(book);

        AssertSingleError(result, CatValidatorErrorDefinitions.NotEmpty.Code, "Title");
    }

    [Test]
    public async Task Category_Empty_ShouldFail()
    {
        var book = NewBook();
        book.CategoryId = Guid.Empty;

        var result = await _validatorProcessor.ValidateAsync(book);

        AssertSingleError(result, CatValidatorErrorDefinitions.NotEmpty.Code, "CategoryId");
    }

    #endregion Other rules

    #region Price list

    [TestCase(1)]
    [TestCase(BookPriceListRequestValidator.MaximumBooks)]
    public async Task PriceList_WithinTheLimit_ShouldSucceed(int count)
    {
        var request = new BookPriceListRequest([.. System.Linq.Enumerable.Range(0, count).Select(_ => Guid.NewGuid())]);

        var result = await _validatorProcessor.ValidateAsync(request);

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task PriceList_Empty_ShouldFail()
    {
        var result = await _validatorProcessor.ValidateAsync(new BookPriceListRequest([]));

        AssertSingleError(result, CatValidatorErrorDefinitions.NotEmpty.Code, "BookIds");
    }

    [Test]
    public async Task PriceList_OverTheLimit_ShouldFail()
    {
        var count = BookPriceListRequestValidator.MaximumBooks + 1;
        var request = new BookPriceListRequest([.. System.Linq.Enumerable.Range(0, count).Select(_ => Guid.NewGuid())]);

        var result = await _validatorProcessor.ValidateAsync(request);

        AssertSingleError(result, CatValidatorErrorDefinitions.MaximumCount.Code, "BookIds", BookPriceListRequestValidator.MaximumBooks, count);
    }

    #endregion Price list
}
