using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.Validators.Tests;

[TestFixture]
public class ValidatorErrorTests
{
    #region CatValidatorError

    [Test]
    public void Create_KeepsTheCodeTheFieldNameTheMessageAndTheArguments()
    {
        var error = CatValidatorError.Create("T-1", "Name", "{propertyName} is {state}", "broken");

        Assert.That(error.Code, Is.EqualTo("T-1"));
        Assert.That(error.FieldName, Is.EqualTo("Name"));
        Assert.That(error.Message, Is.EqualTo("{propertyName} is {state}"));
        Assert.That(error.Arguments, Is.EqualTo(new object?[] { "broken" }));
    }

    [Test]
    public void Create_WithoutArguments_HasNoArguments()
    {
        var error = CatValidatorError.Create("T-1", "Name", "message");

        Assert.That(error.Arguments, Is.Empty);
    }

    [Test]
    public void TheFieldName_CanBeChangedAfterwards()
    {
        var error = CatValidatorError.Create("T-1", "Name", "message");

        error.FieldName = "Parent.Name";

        Assert.That(error.FieldName, Is.EqualTo("Parent.Name"));
    }

    #endregion CatValidatorError

    #region CatValidatorResult

    [Test]
    public void Valid_IsAnEmptyList()
    {
        Assert.That(CatValidatorResult.Valid(), Is.Empty);
    }

    [Test]
    public void Valid_ReturnsANewListEachTime()
    {
        var first = CatValidatorResult.Valid();
        var second = CatValidatorResult.Valid();

        Assert.That(first, Is.Not.SameAs(second));
    }

    [Test]
    public void Invalid_HoldsTheErrorsInOrder()
    {
        var first = CatValidatorError.Create("T-1", "A", "first");
        var second = CatValidatorError.Create("T-2", "B", "second");

        var result = CatValidatorResult.Invalid(first, second);

        Assert.That(result, Is.EqualTo(new ICatValidatorError[] { first, second }));
    }

    #endregion CatValidatorResult

    #region ToCatError

    [Test]
    public void ToCatError_KeepsTheCodeAndTheMessage()
    {
        var error = CatValidatorError.Create("T-1", "Name", "{propertyName} is {state}", "broken");

        var catError = error.ToCatError();

        Assert.That(catError.Code, Is.EqualTo("T-1"));
        Assert.That(catError.Message, Is.EqualTo("{propertyName} is {state}"));
    }

    [Test]
    public void ToCatError_PutsTheFieldNameInFrontOfTheArguments()
    {
        var error = CatValidatorError.Create("T-1", "Name", "{propertyName} is {state}", "broken", 5);

        var catError = error.ToCatError();

        Assert.That(catError.Arguments, Is.EqualTo(new object?[] { "Name", "broken", 5 }));
    }

    [Test]
    public void ToCatError_WithoutArguments_HasOnlyTheFieldName()
    {
        var error = CatValidatorError.Create("T-1", "Name", "message");

        Assert.That(error.ToCatError().Arguments, Is.EqualTo(new object?[] { "Name" }));
    }

    [Test]
    public void ToCatError_UsesTheCurrentFieldName()
    {
        var error = CatValidatorError.Create("T-1", "Name", "message");
        error.FieldName = "Items[0].Name";

        Assert.That(error.ToCatError().Arguments[0], Is.EqualTo("Items[0].Name"));
    }

    #endregion ToCatError
}
