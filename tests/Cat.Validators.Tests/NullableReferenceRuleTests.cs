using Cat.Responses.Abstractions;
using Cat.UnitTesting.Responses.NUnit;
using Cat.Validators.Tests.Validators;

namespace Cat.Validators.Tests;

/// <summary>
/// The rules accept <c>string?</c> and <c>int?</c> properties without a warning. These tests pin down what a <c>null</c> does.
/// Equal, NotEmpty and NotNull fail for a <c>null</c>. Empty, NotEqual, Null and the comparison rules let it pass.
/// </summary>
[TestFixture]
public class NullableReferenceRuleTests : ValidatorTestBase
{
    private static void AssertSucceeded(ICatResponse result) => Assert.That(result, CatIs.Succeeded);

    private static void AssertFailed(ICatResponse result, string code)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, CatIs.Failed);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        Assert.That(result.ErrorList[0].Code, Is.EqualTo(code));
    }

    private static void AssertResult(ICatResponse result, bool succeeds, string code)
    {
        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, code);
    }

    #region State rules

    [TestCase(null, false)]
    [TestCase("", true)]
    [TestCase("a", true)]
    public async Task NotNull_ShouldCheckNull(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringNotNullValidator(name)), succeeds, CatValidatorErrorDefinitions.NotNull.Code);

    [TestCase(null, true)]
    [TestCase("", false)]
    [TestCase("a", false)]
    public async Task Null_ShouldCheckNull(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringNullValidator(name)), succeeds, CatValidatorErrorDefinitions.Null.Code);

    [TestCase(null, false)]
    [TestCase("", false)]
    [TestCase(" ", false)]
    [TestCase("a", true)]
    public async Task NotEmpty_ShouldFailForNullAndBlank(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringNotEmptyValidator(name)), succeeds, CatValidatorErrorDefinitions.NotEmpty.Code);

    [TestCase(null, true)]
    [TestCase("", true)]
    [TestCase("a", false)]
    public async Task Empty_ShouldPassForNullAndBlank(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringEmptyValidator(name)), succeeds, CatValidatorErrorDefinitions.Empty.Code);

    [TestCase(null, false)]
    [TestCase(0, true)]
    [TestCase(5, true)]
    public async Task NotEmpty_NullableInteger_ShouldFailOnlyForNull(int? count, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableIntegerNotEmptyValidator(count)), succeeds, CatValidatorErrorDefinitions.NotEmpty.Code);

    #endregion State rules

    #region Equal and NotEqual

    [TestCase(null, false)]
    [TestCase("abc", true)]
    [TestCase("ABC", false)]
    public async Task Equal_ShouldCompareOrdinal(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringEqualValidator(name)), succeeds, CatValidatorErrorDefinitions.Equal.Code);

    [TestCase(null, false)]
    [TestCase("abc", true)]
    [TestCase("ABC", true)]
    [TestCase("abd", false)]
    public async Task Equal_WithComparer_ShouldUseTheComparer(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringEqualWithComparerValidator(name)), succeeds, CatValidatorErrorDefinitions.Equal.Code);

    [TestCase(null, null, true)]
    [TestCase("a", "a", true)]
    [TestCase("a", null, false)]
    [TestCase(null, "a", false)]
    public async Task Equal_WithExpression_ShouldCompareWithOtherProperty(string? name, string? other, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringEqualWithExpressionValidator(name, other)), succeeds, CatValidatorErrorDefinitions.Equal.Code);

    [TestCase(null, true)]
    [TestCase("abc", false)]
    [TestCase("ABC", true)]
    public async Task NotEqual_ShouldCompareOrdinal(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringNotEqualValidator(name)), succeeds, CatValidatorErrorDefinitions.NotEqual.Code);

    [TestCase(null, true)]
    [TestCase("abc", false)]
    [TestCase("ABC", false)]
    [TestCase("abd", true)]
    public async Task NotEqual_WithComparer_ShouldUseTheComparer(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringNotEqualWithComparerValidator(name)), succeeds, CatValidatorErrorDefinitions.NotEqual.Code);

    [TestCase(null, false)]
    [TestCase(1, true)]
    [TestCase(2, false)]
    public async Task Equal_NullableInteger_ShouldCompare(int? count, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableIntegerEqualValidator(count)), succeeds, CatValidatorErrorDefinitions.Equal.Code);

    [TestCase(null, true)]
    [TestCase(1, false)]
    [TestCase(2, true)]
    public async Task NotEqual_NullableInteger_ShouldCompare(int? count, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableIntegerNotEqualValidator(count)), succeeds, CatValidatorErrorDefinitions.NotEqual.Code);

    #endregion Equal and NotEqual

    #region Comparison and between

    [TestCase(null, true)]
    [TestCase("b", true)]
    [TestCase("m", false)]
    [TestCase("z", false)]
    public async Task LessThan_NullPasses(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringLessThanValidator(name)), succeeds, CatValidatorErrorDefinitions.LessThan.Code);

    [TestCase(null, true)]
    [TestCase("m", true)]
    [TestCase("z", true)]
    [TestCase("b", false)]
    public async Task GreaterThanOrEqualTo_NullPasses(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringGreaterThanOrEqualToValidator(name)), succeeds, CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Code);

    [TestCase(null, "m", true)]
    [TestCase("b", "m", true)]
    [TestCase("z", "m", false)]
    public async Task LessThan_WithExpression_NullPasses(string? name, string? limit, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringLessThanWithExpressionValidator(name, limit)), succeeds, CatValidatorErrorDefinitions.LessThan.Code);

    [TestCase(null, true)]
    [TestCase("b", true)]
    [TestCase("m", true)]
    [TestCase("y", true)]
    [TestCase("a", false)]
    [TestCase("z", false)]
    public async Task InclusiveBetween_NullPasses(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringInclusiveBetweenValidator(name)), succeeds, CatValidatorErrorDefinitions.InclusiveBetween.Code);

    [TestCase(null, true)]
    [TestCase("c", true)]
    [TestCase("b", false)]
    [TestCase("y", false)]
    public async Task ExclusiveBetween_WithComparer_NullPasses(string? name, bool succeeds)
        => AssertResult(await Processor.ValidateAsync(new TestModelFor_NullableStringExclusiveBetweenWithComparerValidator(name)), succeeds, CatValidatorErrorDefinitions.ExclusiveBetween.Code);

    #endregion Comparison and between

    #region Must

    [TestCase(null, false)]
    [TestCase("a", true)]
    public async Task Must_ShouldReceiveTheNull(string? name, bool succeeds)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_NullableStringMustValidator(name));

        if (succeeds) AssertSucceeded(result);
        else AssertFailed(result, "TEST-1");
    }

    #endregion Must
}
