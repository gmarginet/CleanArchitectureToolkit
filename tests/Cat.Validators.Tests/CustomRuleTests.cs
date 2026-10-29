using Cat.Validators.Tests.Validators;

namespace Cat.Validators.Tests;

/// <summary>
/// Rules you write yourself by deriving from the base classes.
/// </summary>
[TestFixture]
public class CustomRuleTests : ValidatorTestBase
{
    #region A synchronous property rule

    [Test]
    public async Task CustomPropertyRule_ValidValue_Succeeds()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CustomRuleValidator("TODO buy milk"));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task CustomPropertyRule_InvalidValue_UsesItsOwnCodeAndMessage()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CustomRuleValidator("buy milk"));

        var error = result.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("APP-1001"));
        Assert.That(error.Message, Is.EqualTo("'{propertyName}' should start with TODO."));
        Assert.That(error.Arguments[0], Is.EqualTo("Title"));
    }

    [Test]
    public async Task CustomPropertyRule_TheOptionsWork_WhenTheConditionIsTrue()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CustomRuleWithOptionsValidator("buy milk", Check: true));

        var error = result.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("APP-9001"));
        Assert.That(error.Message, Is.EqualTo("Start with TODO please."));
        Assert.That(error.Arguments[0], Is.EqualTo("title"));
    }

    [Test]
    public async Task CustomPropertyRule_TheConditionOption_SkipsTheRule()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CustomRuleWithOptionsValidator("buy milk", Check: false));

        Assert.That(result.IsSucceeded, Is.True);
    }

    #endregion A synchronous property rule

    #region An asynchronous property rule

    [Test]
    public async Task CustomAsyncPropertyRule_ValidValue_Succeeds()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CustomAsyncRuleValidator("hello"));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task CustomAsyncPropertyRule_InvalidValue_ReturnsItsError()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CustomAsyncRuleValidator("  "));

        var error = result.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("APP-2001"));
        Assert.That(error.Arguments[0], Is.EqualTo("Title"));
    }

    #endregion An asynchronous property rule

    #region A model rule

    [Test]
    public async Task CustomModelRule_ValidModel_Succeeds()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CustomModelRuleValidator("a", "b"));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task CustomModelRule_InvalidModel_ReturnsItsError()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_CustomModelRuleValidator("same", "same"));

        var error = result.ErrorList.Single();
        Assert.That(error.Code, Is.EqualTo("APP-3001"));
        Assert.That(error.Arguments[0], Is.EqualTo("First"));
    }

    #endregion A model rule
}
