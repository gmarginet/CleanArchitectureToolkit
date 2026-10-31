using Cat.Responses.Abstractions;

namespace Cat.Responses.Tests;

[TestFixture]
public class CatListResponseTests
{
    private static readonly ICatError ErrorOne = CatError.Create("T-1", "first");
    private static readonly ICatError ErrorTwo = CatError.Create("T-2", "second");

    private static readonly IReadOnlyList<int> Items = [1, 2, 3];

    private static IEnumerable<TestCaseData> FailedListFactories()
    {
        yield return new TestCaseData(new Func<ICatError[], ICatResponse<IReadOnlyList<int>>>(e => CatResponse.List.BadRequest<int>(e)), typeof(CatResponseType.Failed.BadRequest)).SetName("List.BadRequest");
        yield return new TestCaseData(new Func<ICatError[], ICatResponse<IReadOnlyList<int>>>(e => CatResponse.List.NotFound<int>(e)), typeof(CatResponseType.Failed.NotFound)).SetName("List.NotFound");
        yield return new TestCaseData(new Func<ICatError[], ICatResponse<IReadOnlyList<int>>>(e => CatResponse.List.Unauthorized<int>(e)), typeof(CatResponseType.Failed.Unauthorized)).SetName("List.Unauthorized");
        yield return new TestCaseData(new Func<ICatError[], ICatResponse<IReadOnlyList<int>>>(e => CatResponse.List.InternalServerError<int>(e)), typeof(CatResponseType.Failed.InternalServerError)).SetName("List.InternalServerError");
    }

    private static IEnumerable<TestCaseData> FailedPagedListFactories()
    {
        yield return new TestCaseData(new Func<ICatError[], ICatResponse<ICatPagedList<int>>>(e => CatResponse.PagedList.BadRequest<int>(e)), typeof(CatResponseType.Failed.BadRequest)).SetName("PagedList.BadRequest");
        yield return new TestCaseData(new Func<ICatError[], ICatResponse<ICatPagedList<int>>>(e => CatResponse.PagedList.NotFound<int>(e)), typeof(CatResponseType.Failed.NotFound)).SetName("PagedList.NotFound");
        yield return new TestCaseData(new Func<ICatError[], ICatResponse<ICatPagedList<int>>>(e => CatResponse.PagedList.Unauthorized<int>(e)), typeof(CatResponseType.Failed.Unauthorized)).SetName("PagedList.Unauthorized");
        yield return new TestCaseData(new Func<ICatError[], ICatResponse<ICatPagedList<int>>>(e => CatResponse.PagedList.InternalServerError<int>(e)), typeof(CatResponseType.Failed.InternalServerError)).SetName("PagedList.InternalServerError");
    }

    #region List responses

    [Test]
    public void ListOk_IsSucceededAndCarriesTheList()
    {
        var response = CatResponse.List.Ok(Items);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Ok>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.ErrorList, Is.Empty);
        Assert.That(response.Value, Is.SameAs(Items));
    }

    [Test]
    public void ListOk_WithAnArray_CarriesTheArray()
    {
        var array = new[] { "a", "b" };

        var response = CatResponse.List.Ok(array);

        Assert.That(response.Value, Is.EqualTo(array));
    }

    [Test]
    public void ListCreated_IsSucceededAndCarriesTheList()
    {
        var response = CatResponse.List.Created(Items);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Created>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.SameAs(Items));
    }

    [Test]
    public void ListNoContent_IsSucceededWithoutAList()
    {
        var response = CatResponse.List.NoContent<int>();

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.NoContent>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.ErrorList, Is.Empty);
        Assert.That(response.Value, Is.Null);
    }

    [TestCaseSource(nameof(FailedListFactories))]
    public void ListFailed_IsFailedWithTheErrorsInOrder(
        Func<ICatError[], ICatResponse<IReadOnlyList<int>>> factory,
        Type expectedType)
    {
        var response = factory([ErrorOne, ErrorTwo]);

        Assert.That(response.Type, Is.InstanceOf(expectedType));
        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList, Is.EqualTo(new[] { ErrorOne, ErrorTwo }));
        Assert.That(response.Value, Is.Null);
    }

    #endregion List responses

    #region Paged list responses

    [Test]
    public void PagedListOk_WithAPage_IsSucceededAndCarriesThePage()
    {
        var page = new CatPagedList<int>(Items, 1, 10, 3);

        var response = CatResponse.PagedList.Ok(page);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Ok>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.SameAs(page));
    }

    [Test]
    public void PagedListOk_WithValues_BuildsThePage()
    {
        var response = CatResponse.PagedList.Ok(Items, 2, 3, 7);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Ok>());
        Assert.That(response.Value.List, Is.SameAs(Items));
        Assert.That(response.Value.PageNumber, Is.EqualTo(2));
        Assert.That(response.Value.PageSize, Is.EqualTo(3));
        Assert.That(response.Value.TotalItemCount, Is.EqualTo(7));
        Assert.That(response.Value.TotalPages, Is.EqualTo(3));
    }

    [Test]
    public void PagedListOk_WithInvalidValues_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CatResponse.PagedList.Ok(Items, 0, 3, 7));
        Assert.Throws<ArgumentOutOfRangeException>(() => CatResponse.PagedList.Ok(Items, 1, 0, 7));
        Assert.Throws<ArgumentOutOfRangeException>(() => CatResponse.PagedList.Ok(Items, 1, 3, -1));
        Assert.Throws<ArgumentNullException>(() => CatResponse.PagedList.Ok<int>(null!, 1, 3, 0));
    }

    [Test]
    public void PagedListCreated_WithAPage_IsSucceededAndCarriesThePage()
    {
        var page = new CatPagedList<int>(Items, 1, 10, 3);

        var response = CatResponse.PagedList.Created(page);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Created>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.SameAs(page));
    }

    [Test]
    public void PagedListCreated_WithValues_BuildsThePage()
    {
        var response = CatResponse.PagedList.Created(Items, 1, 10, 3);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Created>());
        Assert.That(response.Value.List, Is.SameAs(Items));
        Assert.That(response.Value.PageNumber, Is.EqualTo(1));
        Assert.That(response.Value.PageSize, Is.EqualTo(10));
        Assert.That(response.Value.TotalItemCount, Is.EqualTo(3));
        Assert.That(response.Value.TotalPages, Is.EqualTo(1));
    }

    [Test]
    public void PagedListCreated_WithInvalidValues_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CatResponse.PagedList.Created(Items, 0, 3, 7));
        Assert.Throws<ArgumentOutOfRangeException>(() => CatResponse.PagedList.Created(Items, 1, 0, 7));
        Assert.Throws<ArgumentOutOfRangeException>(() => CatResponse.PagedList.Created(Items, 1, 3, -1));
        Assert.Throws<ArgumentNullException>(() => CatResponse.PagedList.Created<int>(null!, 1, 3, 0));
    }

    [Test]
    public void PagedListNoContent_IsSucceededWithoutAPage()
    {
        var response = CatResponse.PagedList.NoContent<int>();

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.NoContent>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.ErrorList, Is.Empty);
        Assert.That(response.Value, Is.Null);
    }

    [TestCaseSource(nameof(FailedPagedListFactories))]
    public void PagedListFailed_IsFailedWithTheErrorsInOrder(
        Func<ICatError[], ICatResponse<ICatPagedList<int>>> factory,
        Type expectedType)
    {
        var response = factory([ErrorOne, ErrorTwo]);

        Assert.That(response.Type, Is.InstanceOf(expectedType));
        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList, Is.EqualTo(new[] { ErrorOne, ErrorTwo }));
        Assert.That(response.Value, Is.Null);
    }

    #endregion Paged list responses
}
