using Cat.Validators.Tests.Validators;
using Cat.UnitTesting.Responses.NUnit;

namespace Cat.Validators.Tests;

[TestFixture]
public class CollectionCountTests : ValidatorTestBase
{
    private static IEnumerable<int> Lazy(int count)
    {
        for (var i = 0; i < count; i++) yield return i;
    }

    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(1, false)]
    [TestCase(0, false)]
    public async Task MinimumCount_ShouldCheckTheCount(int count, bool expectedValid)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyMinimumCountValidator([.. Lazy(count)]));

        Assert.That(result.IsSucceeded, Is.EqualTo(expectedValid));
        if (expectedValid) return;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MinimumCount.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MinimumCount.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EqualTo(new object?[] { "Items", 2, count }));
        }
    }

    [Test]
    public async Task MinimumCount_Null_ShouldSucceed()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyMinimumCountValidator(null));

        Assert.That(result, CatIs.Succeeded);
    }

    [TestCase(0, true)]
    [TestCase(2, true)]
    [TestCase(3, false)]
    [TestCase(10, false)]
    public async Task MaximumCount_ShouldCheckTheCountOfALazySequence(int count, bool expectedValid)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyMaximumCountValidator(Lazy(count)));

        Assert.That(result.IsSucceeded, Is.EqualTo(expectedValid));
        if (expectedValid) return;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MaximumCount.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MaximumCount.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EqualTo(new object?[] { "Items", 2, count }));
        }
    }

    [Test]
    public async Task MaximumCount_Null_ShouldSucceed()
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyMaximumCountValidator(null));

        Assert.That(result, CatIs.Succeeded);
    }

    [Test]
    public async Task MaximumCount_WithFunc_ShouldTakeTheLimitFromTheModel()
    {
        var ok = await Processor.ValidateAsync(new TestModelFor_PropertyMaximumCountWithFuncValidator([1, 2, 3], 3));
        var tooMany = await Processor.ValidateAsync(new TestModelFor_PropertyMaximumCountWithFuncValidator([1, 2, 3], 2));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ok, CatIs.Succeeded);
            Assert.That(tooMany, CatIs.Failed);
            Assert.That(tooMany.ErrorList[0].Arguments, Is.EqualTo(new object?[] { "Items", 2, 3 }));
        }
    }

    [TestCase(1, false)]
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, false)]
    public async Task CountBetween_ShouldIncludeBothBounds(int count, bool expectedValid)
    {
        var result = await Processor.ValidateAsync(new TestModelFor_PropertyCountBetweenValidator([.. Lazy(count)]));

        Assert.That(result.IsSucceeded, Is.EqualTo(expectedValid));
        if (expectedValid) return;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.CountBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.CountBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EqualTo(new object?[] { "Items", 2, 3, count }));
        }
    }

    [Test]
    public async Task CountBetween_WhenMinIsGreaterThanMax_ShouldThrow()
    {
        await Assert.ThrowsAsync<ArgumentException>(
            async () => await Processor.ValidateAsync(new TestModelFor_PropertyCountBetweenInvalidValidator([1, 2])));
    }

    [TestCase(1, false)]
    [TestCase(2, true)]
    [TestCase(4, true)]
    [TestCase(5, false)]
    public async Task CountBetween_WithFunc_ShouldTakeBothBoundsFromTheModel(int count, bool expectedValid)
    {
        var model = new TestModelFor_PropertyCountBetweenWithFuncValidator([.. Lazy(count)], 2, 4);

        var result = await Processor.ValidateAsync(model);

        Assert.That(result.IsSucceeded, Is.EqualTo(expectedValid));
        if (expectedValid) return;

        Assert.That(result.ErrorList[0].Arguments, Is.EqualTo(new object?[] { "Items", 2, 4, count }));
    }

    [Test]
    public async Task CountBetween_WithFunc_WhenMinIsGreaterThanMax_ShouldThrow()
    {
        await Assert.ThrowsAsync<ArgumentException>(
            async () => await Processor.ValidateAsync(new TestModelFor_PropertyCountBetweenWithFuncValidator([1], 5, 2)));
    }
}
