using Cat.Responses.Abstractions;
using Cat.Validators.Tests.Validators;

namespace Cat.Validators.Tests;

[TestFixture]
public class NullablePropertyRuleTests : ValidatorTestBase
{
    private static void AssertSucceeded(ICatResponse result)
    {
        Assert.That(result.IsSucceeded, Is.True);
    }

    private static void AssertFailed(ICatResponse result, string code, params object?[] arguments)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(code));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(arguments));
        }
    }

    #region Comparison with a value

    [TestCase(null, true)]
    [TestCase(9, true)]
    [TestCase(10, false)]
    [TestCase(11, false)]
    public async Task LessThan_ShouldCheckValue(int? discount, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableLessThanValidator(discount));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.LessThan.Code, "Discount", 10);
    }

    [TestCase(null, true)]
    [TestCase(10, true)]
    [TestCase(11, false)]
    public async Task LessThanOrEqualTo_ShouldCheckValue(int? discount, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableLessThanOrEqualToValidator(discount));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.LessThanOrEqualTo.Code, "Discount", 10);
    }

    [TestCase(null, true)]
    [TestCase(11, true)]
    [TestCase(10, false)]
    [TestCase(9, false)]
    public async Task GreaterThan_ShouldCheckValue(int? discount, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableGreaterThanValidator(discount));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.GreaterThan.Code, "Discount", 10);
    }

    [Test]
    public async Task GreaterThanOrEqualTo_Decimal_ShouldCheckValue()
    {
        AssertSucceeded(await Processor.ValidateAsync(new TestModelFor_NullableGreaterThanOrEqualToValidator(null)));
        AssertSucceeded(await Processor.ValidateAsync(new TestModelFor_NullableGreaterThanOrEqualToValidator(10m)));
        AssertSucceeded(await Processor.ValidateAsync(new TestModelFor_NullableGreaterThanOrEqualToValidator(10.01m)));
        AssertFailed(
            await Processor.ValidateAsync(new TestModelFor_NullableGreaterThanOrEqualToValidator(9.99m)),
            CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Code, "Price", 10m);
    }

    #endregion Comparison with a value

    #region Comparison with another property

    [TestCase(null, 10, true)]
    [TestCase(5, null, true)]
    [TestCase(null, null, true)]
    [TestCase(5, 10, true)]
    [TestCase(10, 10, false)]
    [TestCase(11, 10, false)]
    public async Task LessThan_WithExpression_ShouldCompareWithOtherProperty(int? discount, int? other, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableLessThanWithExpressionValidator(discount, other));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.LessThan.Code, "Discount", other);
    }

    [TestCase(null, 10, true)]
    [TestCase(5, null, true)]
    [TestCase(10, 10, true)]
    [TestCase(11, 10, false)]
    public async Task LessThanOrEqualTo_WithExpression_ShouldCompareWithOtherProperty(int? discount, int? other, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableLessThanOrEqualToWithExpressionValidator(discount, other));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.LessThanOrEqualTo.Code, "Discount", other);
    }

    [TestCase(null, 10, true)]
    [TestCase(15, null, true)]
    [TestCase(11, 10, true)]
    [TestCase(10, 10, false)]
    [TestCase(9, 10, false)]
    public async Task GreaterThan_WithExpression_ShouldCompareWithOtherProperty(int? discount, int? other, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableGreaterThanWithExpressionValidator(discount, other));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.GreaterThan.Code, "Discount", other);
    }

    [TestCase(null, 10, true)]
    [TestCase(15, null, true)]
    [TestCase(10, 10, true)]
    [TestCase(9, 10, false)]
    public async Task GreaterThanOrEqualTo_WithExpression_ShouldCompareWithOtherProperty(int? discount, int? other, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableGreaterThanOrEqualToWithExpressionValidator(discount, other));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Code, "Discount", other);
    }

    #endregion Comparison with another property

    #region Inclusive between

    [TestCase(null, true)]
    [TestCase(5, true)]
    [TestCase(7, true)]
    [TestCase(10, true)]
    [TestCase(4, false)]
    [TestCase(11, false)]
    public async Task InclusiveBetween_ShouldCheckBounds(int? discount, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableInclusiveBetweenValidator(discount));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.InclusiveBetween.Code, "Discount", 5, 10, discount);
    }

    [TestCase(null, 5, 10, true)]
    [TestCase(7, null, 10, true)]
    [TestCase(7, 5, null, true)]
    [TestCase(5, 5, 10, true)]
    [TestCase(10, 5, 10, true)]
    [TestCase(4, 5, 10, false)]
    [TestCase(11, 5, 10, false)]
    public async Task InclusiveBetween_WithFunc_ShouldCheckBounds(int? discount, int? min, int? max, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableInclusiveBetweenWithFuncValidator(discount, min, max));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.InclusiveBetween.Code, "Discount", min, max, discount);
    }

    [TestCase(null, true)]
    [TestCase(5, true)]
    [TestCase(10, true)]
    [TestCase(4, false)]
    [TestCase(11, false)]
    public async Task InclusiveBetween_WithComparer_ShouldCheckBounds(int? discount, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableInclusiveBetweenWithComparerValidator(discount));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.InclusiveBetween.Code, "Discount", 5, 10, discount);
    }

    [TestCase(null, 5, 10, true)]
    [TestCase(7, null, 10, true)]
    [TestCase(10, 5, 10, true)]
    [TestCase(4, 5, 10, false)]
    [TestCase(11, 5, 10, false)]
    public async Task InclusiveBetween_WithFuncAndComparer_ShouldCheckBounds(int? discount, int? min, int? max, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableInclusiveBetweenWithFuncAndComparerValidator(discount, min, max));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.InclusiveBetween.Code, "Discount", min, max, discount);
    }

    [Test]
    public async Task InclusiveBetween_InvalidBounds_ShouldThrow()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            await Processor.ValidateAsync(new TestModelFor_NullableInclusiveBetweenInvalidValidator(7)));
    }

    [Test]
    public async Task InclusiveBetween_WithFunc_InvalidBounds_ShouldThrow()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            await Processor.ValidateAsync(new TestModelFor_NullableInclusiveBetweenWithFuncValidator(7, 10, 5)));
    }

    #endregion Inclusive between

    #region Exclusive between

    [TestCase(null, true)]
    [TestCase(6, true)]
    [TestCase(9, true)]
    [TestCase(5, false)]
    [TestCase(10, false)]
    public async Task ExclusiveBetween_ShouldCheckBounds(int? discount, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableExclusiveBetweenValidator(discount));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.ExclusiveBetween.Code, "Discount", 5, 10, discount);
    }

    [TestCase(null, 5, 10, true)]
    [TestCase(7, null, 10, true)]
    [TestCase(7, 5, null, true)]
    [TestCase(6, 5, 10, true)]
    [TestCase(5, 5, 10, false)]
    [TestCase(10, 5, 10, false)]
    public async Task ExclusiveBetween_WithFunc_ShouldCheckBounds(int? discount, int? min, int? max, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableExclusiveBetweenWithFuncValidator(discount, min, max));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.ExclusiveBetween.Code, "Discount", min, max, discount);
    }

    [TestCase(null, true)]
    [TestCase(6, true)]
    [TestCase(5, false)]
    [TestCase(10, false)]
    public async Task ExclusiveBetween_WithComparer_ShouldCheckBounds(int? discount, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableExclusiveBetweenWithComparerValidator(discount));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.ExclusiveBetween.Code, "Discount", 5, 10, discount);
    }

    [TestCase(null, 5, 10, true)]
    [TestCase(7, null, 10, true)]
    [TestCase(6, 5, 10, true)]
    [TestCase(5, 5, 10, false)]
    [TestCase(10, 5, 10, false)]
    public async Task ExclusiveBetween_WithFuncAndComparer_ShouldCheckBounds(int? discount, int? min, int? max, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableExclusiveBetweenWithFuncAndComparerValidator(discount, min, max));
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, CatValidatorErrorDefinitions.ExclusiveBetween.Code, "Discount", min, max, discount);
    }

    [Test]
    public async Task ExclusiveBetween_InvalidBounds_ShouldThrow()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            await Processor.ValidateAsync(new TestModelFor_NullableExclusiveBetweenInvalidValidator(7)));
    }

    #endregion Exclusive between

    #region Chaining

    [Test]
    public async Task NotNullAndGreaterThanOrEqualTo_ShouldCombine()
    {
        AssertSucceeded(await Processor.ValidateAsync(new TestModelFor_NullableNotNullAndGreaterThanOrEqualToValidator(0m)));
        AssertSucceeded(await Processor.ValidateAsync(new TestModelFor_NullableNotNullAndGreaterThanOrEqualToValidator(5m)));
        AssertFailed(
            await Processor.ValidateAsync(new TestModelFor_NullableNotNullAndGreaterThanOrEqualToValidator(null)),
            CatValidatorErrorDefinitions.NotNull.Code, "Price");
        AssertFailed(
            await Processor.ValidateAsync(new TestModelFor_NullableNotNullAndGreaterThanOrEqualToValidator(-1m)),
            CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Code, "Price", 0m);
    }

    [Test]
    public async Task Options_ShouldReplaceFieldNameCodeAndMessage()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableWithOptionsValidator(3));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo("MY-1"));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo("Too low."));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Rebate", 10 }));
        }
    }

    [Test]
    public async Task Options_NullValue_ShouldPass()
    {
        AssertSucceeded(await Processor.ValidateAsync(new TestModelFor_NullableWithOptionsValidator(null)));
    }

    #endregion Chaining
}
