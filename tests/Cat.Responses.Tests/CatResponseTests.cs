using Cat.Responses.Abstractions;

namespace Cat.Responses.Tests;

[TestFixture]
public class CatResponseTests
{
    private static readonly ICatError ErrorOne = CatError.Create("T-1", "first");
    private static readonly ICatError ErrorTwo = CatError.Create("T-2", "second");

    #region Succeeded responses without a value

    [Test]
    public void Ok_IsSucceededWithoutErrors()
    {
        var response = CatResponse.Ok();

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Ok>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.IsFailed, Is.False);
        Assert.That(response.ErrorList, Is.Empty);
    }

    [Test]
    public void Created_IsSucceededWithoutErrors()
    {
        var response = CatResponse.Created();

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Created>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.ErrorList, Is.Empty);
    }

    [Test]
    public void NoContent_IsSucceededWithoutErrors()
    {
        var response = CatResponse.NoContent();

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.NoContent>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.ErrorList, Is.Empty);
    }

    #endregion Succeeded responses without a value

    #region Failed responses without a value

    [Test]
    public void BadRequest_IsFailedWithTheErrorsInOrder()
    {
        var response = CatResponse.BadRequest(ErrorOne, ErrorTwo);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.BadRequest>());
        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.IsSucceeded, Is.False);
        Assert.That(response.ErrorList, Is.EqualTo(new[] { ErrorOne, ErrorTwo }));
    }

    [Test]
    public void NotFound_IsFailedWithTheErrors()
    {
        var response = CatResponse.NotFound(ErrorOne);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.NotFound>());
        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList, Is.EqualTo(new[] { ErrorOne }));
    }

    [Test]
    public void Unauthorized_IsFailedWithTheErrors()
    {
        var response = CatResponse.Unauthorized(ErrorOne);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.Unauthorized>());
        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList, Is.EqualTo(new[] { ErrorOne }));
    }

    [Test]
    public void InternalServerError_IsFailedWithTheErrors()
    {
        var response = CatResponse.InternalServerError(ErrorOne);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.InternalServerError>());
        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList, Is.EqualTo(new[] { ErrorOne }));
    }

    [Test]
    public void Failed_WithoutErrors_HasAnEmptyErrorList()
    {
        var response = CatResponse.BadRequest();

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.ErrorList, Is.Empty);
    }

    #endregion Failed responses without a value

    #region Responses with a value

    [Test]
    public void OkWithValue_HoldsTheValue()
    {
        var response = CatResponse.Ok("hello");

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Ok>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.EqualTo("hello"));
    }

    [Test]
    public void CreatedWithValue_HoldsTheValue()
    {
        var response = CatResponse.Created(5);

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.Created>());
        Assert.That(response.Value, Is.EqualTo(5));
    }

    [Test]
    public void NoContentWithValueType_HasTheDefaultValue()
    {
        var response = CatResponse.NoContent<int>();

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Succeeded.NoContent>());
        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.EqualTo(0));
    }

    [Test]
    public void FailedWithValueType_HasTheErrorsAndTheDefaultValue()
    {
        var badRequest = CatResponse.BadRequest<string>(ErrorOne);
        var notFound = CatResponse.NotFound<string>(ErrorOne);
        var unauthorized = CatResponse.Unauthorized<string>(ErrorOne);
        var serverError = CatResponse.InternalServerError<string>(ErrorOne);

        Assert.That(badRequest.Type, Is.InstanceOf<CatResponseType.Failed.BadRequest>());
        Assert.That(notFound.Type, Is.InstanceOf<CatResponseType.Failed.NotFound>());
        Assert.That(unauthorized.Type, Is.InstanceOf<CatResponseType.Failed.Unauthorized>());
        Assert.That(serverError.Type, Is.InstanceOf<CatResponseType.Failed.InternalServerError>());

        foreach (var response in new[] { badRequest, notFound, unauthorized, serverError })
        {
            Assert.That(response.IsFailed, Is.True);
            Assert.That(response.ErrorList, Is.EqualTo(new[] { ErrorOne }));
            Assert.That(response.Value, Is.Null);
        }
    }

    #endregion Responses with a value

    #region Cast

    [Test]
    public void Cast_FailedResponse_KeepsTheTypeAndTheErrors()
    {
        var response = CatResponse.NotFound(ErrorOne, ErrorTwo);

        var cast = response.Cast<string>();

        Assert.That(cast.Type, Is.InstanceOf<CatResponseType.Failed.NotFound>());
        Assert.That(cast.ErrorList, Is.EqualTo(new[] { ErrorOne, ErrorTwo }));
        Assert.That(cast.Value, Is.Null);
    }

    [Test]
    public void Cast_SucceededResponseWithoutValue_Throws()
    {
        var response = CatResponse.Ok();

        Assert.Throws<InvalidOperationException>(() => response.Cast<string>());
    }

    [Test]
    public void CastWithValue_SucceededResponse_KeepsTheTypeAndAddsTheValue()
    {
        var response = CatResponse.Created();

        var cast = response.Cast("value");

        Assert.That(cast.Type, Is.InstanceOf<CatResponseType.Succeeded.Created>());
        Assert.That(cast.Value, Is.EqualTo("value"));
    }

    [Test]
    public void CastWithValue_FailedResponse_Throws()
    {
        var response = CatResponse.BadRequest(ErrorOne);

        Assert.Throws<InvalidOperationException>(() => response.Cast("value"));
    }

    [Test]
    public void CastWithConverter_SucceededResponse_ConvertsTheValue()
    {
        var response = CatResponse.Ok(21);

        var cast = response.Cast(x => (x * 2).ToString());

        Assert.That(cast.Type, Is.InstanceOf<CatResponseType.Succeeded.Ok>());
        Assert.That(cast.Value, Is.EqualTo("42"));
    }

    [Test]
    public void CastWithConverter_FailedResponse_Throws()
    {
        var response = CatResponse.BadRequest<int>(ErrorOne);

        Assert.Throws<InvalidOperationException>(() => response.Cast(x => x.ToString()));
    }

    [Test]
    public void CastFailedTypedResponse_ToAnotherType_KeepsTheTypeAndTheErrors()
    {
        ICatResponse response = CatResponse.InternalServerError<int>(ErrorOne);

        var cast = response.Cast<string>();

        Assert.That(cast.Type, Is.InstanceOf<CatResponseType.Failed.InternalServerError>());
        Assert.That(cast.ErrorList, Is.EqualTo(new[] { ErrorOne }));
    }

    #endregion Cast
}
