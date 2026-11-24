using Cat.Validators.Tests.Validators;
using Cat.UnitTesting.Responses.NUnit;

namespace Cat.Validators.Tests;

/// <summary>
/// The string rules accept <c>string</c> and <c>string?</c> properties. A <c>null</c> passes, and a character array counts as text.
/// </summary>
[TestFixture]
public class NullableTextRuleTests : ValidatorTestBase
{
    [Test]
    public async Task NullableString_Null_Passes()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableTextValidator(null));

        Assert.That(result, CatIs.Succeeded);
    }

    [Test]
    public async Task NullableString_ValidText_Passes()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableTextValidator("hello"));

        Assert.That(result, CatIs.Succeeded);
    }

    [Test]
    public async Task NullableString_TooLongText_Fails()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableTextValidator("helloworldx"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, CatIs.Failed);
            Assert.That(result.ErrorList.Select(e => e.Code), Does.Contain(CatValidatorErrorDefinitions.MaximumLength.Code));
        }
    }

    [Test]
    public async Task CharacterArray_Null_Passes()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CharacterArrayTextValidator(null));

        Assert.That(result, CatIs.Succeeded);
    }

    [Test]
    public async Task CharacterArray_ShortEnough_Passes()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CharacterArrayTextValidator(['a', 'b', 'c']));

        Assert.That(result, CatIs.Succeeded);
    }

    [Test]
    public async Task CharacterArray_TooLong_Fails()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CharacterArrayTextValidator(['a', 'b', 'c', 'd']));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, CatIs.Failed);
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MaximumLength.Code));
        }
    }
}
