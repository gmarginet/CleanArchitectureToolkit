using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Validators;
using Cat.Expressions.Extensions;
using Cat.NUnit;
using Cat.Validators.Abstractions;
using Cat.Validators;
using Cat.Validators.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class PlaceOrderValidationTests : UnitTestBase
{
    private ICatValidatorProcessor _validatorProcessor = null!;

    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddCatCompiledMemberExpressionCache();
        services.AddCatValidatorsModule(typeof(PlaceOrderRequestValidator));
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _validatorProcessor = ServiceProvider.GetRequiredService<ICatValidatorProcessor>();
    }

    private static PlaceOrderRequest NewRequest(params PlaceOrderLineModel[] lines) => new(new PlaceOrderModel { Lines = [.. lines] });

    private static PlaceOrderLineModel NewLine(int quantity = 1, Guid? bookId = null) => new() { BookId = bookId ?? Guid.NewGuid(), Quantity = quantity };

    [Test]
    public async Task ValidOrder_ShouldSucceed()
    {
        var result = await _validatorProcessor.ValidateAsync(NewRequest(NewLine(2), NewLine(99)));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task OrderWithoutLines_ShouldFail()
    {
        var result = await _validatorProcessor.ValidateAsync(NewRequest());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList.Single().Arguments, Does.Contain("Order.Lines"));
        }
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(PlaceOrderLineModelValidator.MaximumQuantity + 1)]
    public async Task QuantityOutsideTheRange_ShouldFail(int quantity)
    {
        var result = await _validatorProcessor.ValidateAsync(NewRequest(NewLine(quantity)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList.Single().Arguments, Has.Some.Contains("Quantity"));
        }
    }

    [Test]
    public async Task LineWithoutABook_ShouldFail()
    {
        var result = await _validatorProcessor.ValidateAsync(NewRequest(NewLine(bookId: Guid.Empty)));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList.Single().Arguments, Has.Some.Contains("BookId"));
        }
    }

    [Test]
    public async Task OrderWithTheMaximumNumberOfLines_ShouldSucceed()
    {
        var lines = System.Linq.Enumerable.Range(0, PlaceOrderModelValidator.MaximumLines).Select(_ => NewLine()).ToArray();

        var result = await _validatorProcessor.ValidateAsync(NewRequest(lines));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task OrderWithTooManyLines_ShouldFail()
    {
        var count = PlaceOrderModelValidator.MaximumLines + 1;
        var lines = System.Linq.Enumerable.Range(0, count).Select(_ => NewLine()).ToArray();

        var result = await _validatorProcessor.ValidateAsync(NewRequest(lines));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList.Single().Code, Is.EqualTo(CatValidatorErrorDefinitions.MaximumCount.Code));
            Assert.That(result.ErrorList.Single().Arguments, Is.EqualTo(new object?[] { "Order.Lines", PlaceOrderModelValidator.MaximumLines, count }));
        }
    }
}
