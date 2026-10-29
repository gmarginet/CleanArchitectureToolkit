using System.Text.RegularExpressions;
using Cat.Validators.Tests.Validators;

namespace Cat.Validators.Tests;

/// <summary>
/// A <c>null</c> string passes every form of the regex rule, like it does for the length rules.
/// </summary>
[TestFixture]
public class MatchesRegexNullTests : ValidatorTestBase
{
    [Test]
    public async Task MatchesRegex_WithARegex_NullPasses()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyStringMatchesRegexValidator(null!));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task MatchesRegex_WithARegexFromTheModel_NullPasses()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyStringMatchesRegexWithFuncValidator(null!, new Regex("^x")));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task MatchesRegex_WithAPattern_NullPasses()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyStringMatchesRegexWithPatternValidator(null!));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task MatchesRegex_WithAPatternAndOptions_NullPasses()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyStringMatchesRegexWithPatternAndOptionsValidator(null!));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task MatchesRegex_WithAPatternFromTheModel_NullPasses()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyStringMatchesRegexWithPatternFuncValidator(null!, "^x"));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task MatchesRegex_WithAPatternFromTheModelAndOptions_NullPasses()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator(null!, "^x"));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task MatchesRegex_AValueThatDoesNotMatch_StillFails()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyStringMatchesRegexWithPatternValidator("Mike"));

        Assert.That(result.IsFailed, Is.True);
    }
}
