using Cat.Demo.InventoryService.Contracts.Models;
using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Demo.InventoryService.CoreService.Validators;
using Cat.Expressions.Extensions;
using Cat.UnitTesting.NUnit;
using Cat.Responses.Abstractions;
using Cat.Validators;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.InventoryService.CoreService.Tests;

[TestFixture]
public class StockValidationTests : UnitTestBase
{
    private const string Isbn = "9780141036144";

    private ICatValidatorProcessor _validatorProcessor = null!;

    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddCatCompiledMemberExpressionCache();
        services.AddCatValidatorsModule(typeof(StockReserveRequestValidator));
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _validatorProcessor = ServiceProvider.GetRequiredService<ICatValidatorProcessor>();
    }

    private static StockReserveRequest Reserve(string orderNumber, params StockLineModel[] lines) => new(new StockReservationModel
    {
        OrderNumber = orderNumber,
        Lines = [.. lines]
    });

    private static StockLineModel Line(string isbn = Isbn, int quantity = 1) => new() { Isbn = isbn, Quantity = quantity };

    private static void AssertSingleError(ICatResponse response, string code)
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.IsFailed, Is.True);
            Assert.That(response.ErrorList, Has.Count.EqualTo(1));
        }
        Assert.That(response.ErrorList[0].Code, Is.EqualTo(code));
    }

    [Test]
    public async Task Reserve_WithAValidOrder_ShouldSucceed()
    {
        var result = await _validatorProcessor.ValidateAsync(Reserve("20261106-0001", Line(), Line("9780261103573", 3)));

        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task Reserve_WithoutAnOrderNumber_ShouldFail()
    {
        var result = await _validatorProcessor.ValidateAsync(Reserve("", Line()));

        AssertSingleError(result, CatValidatorErrorDefinitions.NotEmpty.Code);
    }

    [Test]
    public async Task Reserve_WithAnOrderNumberThatIsTooLong_ShouldFail()
    {
        var orderNumber = new string('1', StockReservationModelValidator.MaximumOrderNumberLength + 1);

        var result = await _validatorProcessor.ValidateAsync(Reserve(orderNumber, Line()));

        AssertSingleError(result, CatValidatorErrorDefinitions.MaximumLength.Code);
    }

    [Test]
    public async Task Reserve_WithoutLines_ShouldFail()
    {
        var result = await _validatorProcessor.ValidateAsync(Reserve("20261106-0001"));

        AssertSingleError(result, CatValidatorErrorDefinitions.NotEmpty.Code);
    }

    [Test]
    public async Task Reserve_WithTooManyLines_ShouldFail()
    {
        var lines = System.Linq.Enumerable.Range(0, StockReservationModelValidator.MaximumLines + 1).Select(_ => Line()).ToArray();

        var result = await _validatorProcessor.ValidateAsync(Reserve("20261106-0001", lines));

        AssertSingleError(result, CatValidatorErrorDefinitions.MaximumCount.Code);
    }

    [Test]
    public async Task Reserve_WithAnIsbnOfTheWrongLength_ShouldFail()
    {
        var result = await _validatorProcessor.ValidateAsync(Reserve("20261106-0001", Line("123")));

        AssertSingleError(result, CatValidatorErrorDefinitions.ExactLength.Code);
    }

    [TestCase(0)]
    [TestCase(-1)]
    public async Task Reserve_WithAQuantityBelowOne_ShouldFail(int quantity)
    {
        var result = await _validatorProcessor.ValidateAsync(Reserve("20261106-0001", Line(quantity: quantity)));

        AssertSingleError(result, CatValidatorErrorDefinitions.GreaterThan.Code);
    }

    [Test]
    public async Task Release_WithoutAnOrderNumber_ShouldFail()
    {
        var result = await _validatorProcessor.ValidateAsync(new StockReleaseRequest(""));

        AssertSingleError(result, CatValidatorErrorDefinitions.NotEmpty.Code);
    }
}
