using Cat.Responses.Abstractions;
using Cat.Validators.Tests.Validators;

namespace Cat.Validators.Tests;

[TestFixture]
public class RuleOptionTests : ValidatorTestBase
{
    #region WithCode

    [Test]
    public async Task WithCode_ReplacesTheErrorCode()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_WithCodeValidator(""));

        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.ErrorList.Single().Code, Is.EqualTo("APP-1001"));
    }

    [Test]
    public async Task WithCode_KeepsTheMessageOfTheRule()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_WithCodeValidator(""));

        Assert.That(result.ErrorList.Single().Message, Is.EqualTo("'{propertyName}' should not be empty."));
    }

    [Test]
    public async Task WithCode_KeepsThePropertyNameAsTheFirstArgument()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_WithCodeValidator(""));

        Assert.That(result.ErrorList.Single().Arguments, Is.EqualTo(new object?[] { "Name" }));
    }

    [Test]
    public async Task WithCode_ValidModel_Succeeds()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_WithCodeValidator("Anna"));

        Assert.That(result.IsSucceeded, Is.True);
    }

    #endregion WithCode

    #region All options together

    [Test]
    public async Task AllOptions_ReplaceTheCodeTheFieldNameAndTheMessage()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_AllRuleOptionsValidator("Annabel"));

        var error = result.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("APP-1002"));
        Assert.That(error.Message, Is.EqualTo("Too long, the limit is {maxLength}."));
        Assert.That(error.Arguments[0], Is.EqualTo("name"));
    }

    [Test]
    public async Task AllOptions_TheRuleArgumentsStillFillThePlaceholders()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_AllRuleOptionsValidator("Annabel"));

        // field name first, then the arguments of the rule: the limit and the length that was entered
        Assert.That(result.ErrorList.Single().Arguments, Is.EqualTo(new object?[] { "name", 3, 7 }));
    }

    [Test]
    public async Task AllOptions_ValidModel_Succeeds()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_AllRuleOptionsValidator("Ann"));

        Assert.That(result.IsSucceeded, Is.True);
    }

    #endregion All options together

    #region Several rules on one property

    [Test]
    public async Task SeveralRules_EveryFailingRuleAddsItsOwnError()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_MultipleRulesOnOnePropertyValidator(""));

        // an empty string fails NotEmpty, MinimumLength and the regex
        Assert.That(result.ErrorList.Select(e => e.Code), Is.EqualTo(new[] { "CAT-VAL-1003", "CAT-VAL-1008", "CAT-VAL-1009" }));
    }

    [Test]
    public async Task SeveralRules_TheErrorsComeInTheOrderOfTheRules()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_MultipleRulesOnOnePropertyValidator("ab"));

        Assert.That(result.ErrorList.Select(e => e.Code), Is.EqualTo(new[] { "CAT-VAL-1008", "CAT-VAL-1009" }));
    }

    [Test]
    public async Task SeveralRules_OnlyTheFailingRulesReport()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_MultipleRulesOnOnePropertyValidator("Anna"));

        Assert.That(result.IsSucceeded, Is.True);
        Assert.That(result.ErrorList, Is.Empty);
    }

    [Test]
    public async Task SeveralRules_FailedResultIsABadRequest()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_MultipleRulesOnOnePropertyValidator(""));

        Assert.That(result.Type, Is.InstanceOf<CatResponseType.Failed.BadRequest>());
    }

    #endregion Several rules on one property
}
