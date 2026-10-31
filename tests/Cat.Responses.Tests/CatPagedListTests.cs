using Cat.Responses.Abstractions;

namespace Cat.Responses.Tests;

[TestFixture]
public class CatPagedListTests
{
    private static CatPagedList<string> CreatePage(
        IReadOnlyList<string>? list = null,
        int pageNumber = 2,
        int pageSize = 10,
        int totalItemCount = 25)
        => new(list ?? ["a", "b"], pageNumber, pageSize, totalItemCount);

    #region Constructor

    [Test]
    public void Constructor_WithValidValues_KeepsTheValues()
    {
        var list = new[] { "a", "b" };

        var page = new CatPagedList<string>(list, 2, 10, 25);

        Assert.That(page.List, Is.SameAs(list));
        Assert.That(page.PageNumber, Is.EqualTo(2));
        Assert.That(page.PageSize, Is.EqualTo(10));
        Assert.That(page.TotalItemCount, Is.EqualTo(25));
    }

    [Test]
    public void Constructor_WithAnEmptyListAndNoItems_IsValid()
    {
        var page = new CatPagedList<string>([], 1, 10, 0);

        Assert.That(page.List, Is.Empty);
        Assert.That(page.TotalPages, Is.Zero);
    }

    [Test]
    public void Constructor_WithANullList_Throws()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => new CatPagedList<string>(null!, 1, 10, 0));

        Assert.That(exception!.ParamName, Is.EqualTo("List"));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void Constructor_WithAPageNumberBelowOne_Throws(int pageNumber)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CreatePage(pageNumber: pageNumber));

        Assert.That(exception!.ParamName, Is.EqualTo("PageNumber"));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void Constructor_WithAPageSizeBelowOne_Throws(int pageSize)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CreatePage(pageSize: pageSize));

        Assert.That(exception!.ParamName, Is.EqualTo("PageSize"));
    }

    [Test]
    public void Constructor_WithANegativeTotalItemCount_Throws()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CreatePage(totalItemCount: -1));

        Assert.That(exception!.ParamName, Is.EqualTo("TotalItemCount"));
    }

    #endregion Constructor

    #region TotalPages

    [TestCase(0, 10, 0)]
    [TestCase(1, 10, 1)]
    [TestCase(10, 10, 1)]
    [TestCase(11, 10, 2)]
    [TestCase(25, 10, 3)]
    [TestCase(5, 1, 5)]
    [TestCase(int.MaxValue, 1, int.MaxValue)]
    [TestCase(int.MaxValue, int.MaxValue, 1)]
    public void TotalPages_RoundsUpToWholePages(int totalItemCount, int pageSize, int expectedTotalPages)
    {
        var page = CreatePage(pageSize: pageSize, totalItemCount: totalItemCount);

        Assert.That(page.TotalPages, Is.EqualTo(expectedTotalPages));
    }

    #endregion TotalPages

    #region With expressions

    [Test]
    public void With_ChangingAValue_CopiesThePageWithTheNewValue()
    {
        var page = CreatePage();

        var copy = page with { PageNumber = 3 };

        Assert.That(copy.PageNumber, Is.EqualTo(3));
        Assert.That(copy.PageSize, Is.EqualTo(page.PageSize));
        Assert.That(copy.TotalItemCount, Is.EqualTo(page.TotalItemCount));
        Assert.That(copy.List, Is.SameAs(page.List));
        Assert.That(page.PageNumber, Is.EqualTo(2));
    }

    [Test]
    public void With_ChangingThePageSize_UpdatesTotalPages()
    {
        var page = CreatePage(pageSize: 10, totalItemCount: 25);

        var copy = page with { PageSize = 5 };

        Assert.That(page.TotalPages, Is.EqualTo(3));
        Assert.That(copy.TotalPages, Is.EqualTo(5));
    }

    [Test]
    public void With_ANullList_Throws()
    {
        var page = CreatePage();

        Assert.Throws<ArgumentNullException>(() => _ = page with { List = null! });
    }

    [Test]
    public void With_APageNumberBelowOne_Throws()
    {
        var page = CreatePage();

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = page with { PageNumber = 0 });
    }

    [Test]
    public void With_APageSizeBelowOne_Throws()
    {
        var page = CreatePage();

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = page with { PageSize = 0 });
    }

    [Test]
    public void With_ANegativeTotalItemCount_Throws()
    {
        var page = CreatePage();

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = page with { TotalItemCount = -1 });
    }

    #endregion With expressions

    #region Equality

    [Test]
    public void Equals_SameValuesInDifferentLists_IsEqual()
    {
        var first = CreatePage(["a", "b"]);
        var second = CreatePage(["a", "b"]);

        Assert.That(first, Is.EqualTo(second));
        Assert.That(first == second, Is.True);
        Assert.That(first != second, Is.False);
        Assert.That(first.GetHashCode(), Is.EqualTo(second.GetHashCode()));
    }

    [Test]
    public void Equals_SameInstance_IsEqual()
    {
        var page = CreatePage();

        Assert.That(page.Equals(page), Is.True);
    }

    [Test]
    public void Equals_Null_IsNotEqual()
    {
        var page = CreatePage();

        Assert.That(page.Equals(null), Is.False);
        Assert.That(page == null, Is.False);
    }

    [Test]
    public void Equals_DifferentItems_IsNotEqual()
    {
        Assert.That(CreatePage(["a", "b"]), Is.Not.EqualTo(CreatePage(["a", "c"])));
    }

    [Test]
    public void Equals_SameItemsInAnotherOrder_IsNotEqual()
    {
        Assert.That(CreatePage(["a", "b"]), Is.Not.EqualTo(CreatePage(["b", "a"])));
    }

    [Test]
    public void Equals_DifferentNumberOfItems_IsNotEqual()
    {
        Assert.That(CreatePage(["a"]), Is.Not.EqualTo(CreatePage(["a", "b"])));
    }

    [Test]
    public void Equals_DifferentPageNumber_IsNotEqual()
    {
        Assert.That(CreatePage(pageNumber: 1), Is.Not.EqualTo(CreatePage(pageNumber: 2)));
    }

    [Test]
    public void Equals_DifferentPageSize_IsNotEqual()
    {
        Assert.That(CreatePage(pageSize: 10), Is.Not.EqualTo(CreatePage(pageSize: 20)));
    }

    [Test]
    public void Equals_DifferentTotalItemCount_IsNotEqual()
    {
        Assert.That(CreatePage(totalItemCount: 25), Is.Not.EqualTo(CreatePage(totalItemCount: 26)));
    }

    [Test]
    public void GetHashCode_DifferentItems_DiffersInPractice()
    {
        Assert.That(CreatePage(["a", "b"]).GetHashCode(), Is.Not.EqualTo(CreatePage(["a", "c"]).GetHashCode()));
    }

    [Test]
    public void GetHashCode_ListWithANullItem_DoesNotThrow()
    {
        var page = new CatPagedList<string?>([null, "a"], 1, 10, 2);

        Assert.DoesNotThrow(() => page.GetHashCode());
    }

    [Test]
    public void Equals_PagesWithNullItems_ComparesByValue()
    {
        var first = new CatPagedList<string?>([null, "a"], 1, 10, 2);
        var second = new CatPagedList<string?>([null, "a"], 1, 10, 2);

        Assert.That(first, Is.EqualTo(second));
    }

    #endregion Equality

    #region Interface

    [Test]
    public void ICatPagedList_ExposesTheSameValues()
    {
        ICatPagedList<string> page = CreatePage(["a"], 1, 10, 1);

        Assert.That(page.List, Is.EqualTo(new[] { "a" }));
        Assert.That(page.PageNumber, Is.EqualTo(1));
        Assert.That(page.PageSize, Is.EqualTo(10));
        Assert.That(page.TotalItemCount, Is.EqualTo(1));
        Assert.That(page.TotalPages, Is.EqualTo(1));
    }

    #endregion Interface
}
