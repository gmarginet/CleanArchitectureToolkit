using System.Text.RegularExpressions;
using Cat.Expressions.Extensions;
using Cat.NUnit;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using Cat.Validators.Tests.Validators;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable PreferConcreteValueOverDefault

namespace Cat.Validators.Tests;

[TestFixture]
public partial class ValidationTests : UnitTestBase
{
    private ICatValidatorProcessor _validatorProcessor;
    
    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddCatCompiledMemberExpressionCache();
        services.AddCatValidatorsModule(typeof(ModelMustAsyncValidator));
    }
    
    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        _validatorProcessor = ServiceProvider.GetRequiredService<ICatValidatorProcessor>();
    }

    #region Property Validators
    
    [Test]
    public async Task PropertyNotNullValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyNotNullValidator("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyNotNullValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyNotNullValidator(null);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotNull.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotNull.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name" }));
        }
    }
    
    [Test]
    public async Task PropertyNullValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyNullValidator(null);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyNullValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyNullValidator("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Null.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Null.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name" }));
        }
    }

    [Test]
    public async Task PropertyStringNotEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEmptyValidator("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringNotEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEmptyValidator("");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name" }));
        }
    }

    [Test]
    public async Task PropertyCollectionNotEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyCollectionNotEmptyValidator(["John Doe"]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyCollectionNotEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyCollectionNotEmptyValidator([]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Names" }));
        }
    }

    [Test]
    public async Task PropertyEnumerableNotEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyEnumerableNotEmptyValidator(["John Doe"]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyEnumerableNotEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyEnumerableNotEmptyValidator([]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Names" }));
        }
    }

    [Test]
    public async Task PropertyListNotEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyListNotEmptyValidator(["John Doe"]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyListNotEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyListNotEmptyValidator([]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Names" }));
        }
    }

    [Test]
    public async Task PropertyArrayNotEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyArrayNotEmptyValidator(["John Doe"]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyArrayNotEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyArrayNotEmptyValidator([]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Names" }));
        }
    }

    [Test]
    public async Task PropertyIntegerNotEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerNotEmptyValidator(1);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyIntegerNotEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerNotEmptyValidator(default(int));
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "StreetNumber" }));
        }
    }

    [Test]
    public async Task PropertyClassNotEmptyValidator_ShouldSucceed()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassNotEmptyValidator("Dover Patrol", 1);
        var model = new TestModelFor_PropertyClassNotEmptyValidator(subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyClassNotEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyClassNotEmptyValidator(default);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Address" }));
        }
    }

    [Test]
    public async Task PropertyStringEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEmptyValidator("");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEmptyValidator("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name" }));
        }
    }

    [Test]
    public async Task PropertyCollectionEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyCollectionEmptyValidator([]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyCollectionEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyCollectionEmptyValidator(["John Doe"]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Names" }));
        }
    }

    [Test]
    public async Task PropertyEnumerableEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyEnumerableEmptyValidator([]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyEnumerableEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyEnumerableEmptyValidator(["John Doe"]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Names" }));
        }
    }

    [Test]
    public async Task PropertyListEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyListEmptyValidator([]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyListEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyListEmptyValidator(["John Doe"]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Names" }));
        }
    }

    [Test]
    public async Task PropertyArrayEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyArrayEmptyValidator([]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyArrayEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyArrayEmptyValidator(["John Doe"]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Names" }));
        }
    }

    [Test]
    public async Task PropertyIntegerEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerEmptyValidator(default(int));
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyIntegerEmptyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerEmptyValidator(1);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "StreetNumber" }));
        }
    }

    [Test]
    public async Task PropertyClassEmptyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyClassEmptyValidator(default);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyClassEmptyValidator_ShouldFail()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassEmptyValidator("Dover Patrol", 1);
        var model = new TestModelFor_PropertyClassEmptyValidator(subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Empty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Address" }));
        }
    }

    [Test]
    public async Task PropertyStringNotEqualValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEqualValidator("John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringNotEqualValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEqualValidator("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", "John Doe" }));
        }
    }

    [Test]
    public async Task PropertyStringNotEqualWithComparerValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEqualWithComparerValidator("John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringNotEqualWithComparerValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEqualWithComparerValidator("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", "john doe" }));
        }
    }

    [Test]
    public async Task PropertyIntegerNotEqualValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerNotEqualValidator(20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyIntegerNotEqualValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerNotEqualValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "StreetNumber", 10 }));
        }
    }

    [Test]
    public async Task PropertyClassNotEqualValidator_ShouldSucceed()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassNotEqualValidator("Dover Patrol", 1);
        var model = new TestModelFor_PropertyClassNotEqualValidator(subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyClassNotEqualValidator_ShouldFail()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassNotEqualValidator("Dover Patrol", 10);
        var model = new TestModelFor_PropertyClassNotEqualValidator(subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Message));
            Assert.That(result.ErrorList[0].Arguments, Has.Count.EqualTo(2));
            Assert.That(result.ErrorList[0].Arguments[0], Is.EqualTo("Address"));
            Assert.That(result.ErrorList[0].Arguments[1], Is.Not.Null);
            Assert.That(((TestSubModelFor_PropertyClassNotEqualValidator)result.ErrorList[0].Arguments[1]!).Street, Is.EqualTo("Dover Patrol"));
            Assert.That(((TestSubModelFor_PropertyClassNotEqualValidator)result.ErrorList[0].Arguments[1]!).StreetNumber, Is.EqualTo(10));
        }
    }

    [Test]
    public async Task PropertyStringNotEqualWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEqualWithFuncValidator("John Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringNotEqualWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEqualWithFuncValidator("John Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", "John Doe" }));
        }
    }

    [Test]
    public async Task PropertyStringNotEqualWithFuncAndComparerValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEqualWithFuncAndComparerValidator("John Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringNotEqualWithFuncAndComparerValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringNotEqualWithFuncAndComparerValidator("John Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", "John Doe" }));
        }
    }

    [Test]
    public async Task PropertyIntegerNotEqualWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerNotEqualWithFuncValidator(20, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyIntegerNotEqualWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerNotEqualWithFuncValidator(10, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "StreetNumber", 10 }));
        }
    }

    [Test]
    public async Task PropertyClassNotEqualWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassNotEqualWithFuncValidator("Dover Patrol", 1);
        var wrongSubModel = new TestSubModelFor_PropertyClassNotEqualWithFuncValidator("Dover Patrol", 10);
        var model = new TestModelFor_PropertyClassNotEqualWithFuncValidator(subModel, wrongSubModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyClassNotEqualWithFuncValidator_ShouldFail()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassNotEqualWithFuncValidator("Dover Patrol", 10);
        var wrongSubModel = new TestSubModelFor_PropertyClassNotEqualWithFuncValidator("Dover Patrol", 10);
        var model = new TestModelFor_PropertyClassNotEqualWithFuncValidator(subModel, wrongSubModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEqual.Message));
            Assert.That(result.ErrorList[0].Arguments, Has.Count.EqualTo(2));
            Assert.That(result.ErrorList[0].Arguments[0], Is.EqualTo("Address"));
            Assert.That(result.ErrorList[0].Arguments[1], Is.Not.Null);
            Assert.That(((TestSubModelFor_PropertyClassNotEqualWithFuncValidator)result.ErrorList[0].Arguments[1]!).Street, Is.EqualTo("Dover Patrol"));
            Assert.That(((TestSubModelFor_PropertyClassNotEqualWithFuncValidator)result.ErrorList[0].Arguments[1]!).StreetNumber, Is.EqualTo(10));
        }
    }

    [Test]
    public async Task PropertyStringEqualValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEqualValidator("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringEqualValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEqualValidator("John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", "John Doe" }));
        }
    }

    [Test]
    public async Task PropertyStringEqualWithComparerValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEqualWithComparerValidator("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringEqualWithComparerValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEqualWithComparerValidator("John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", "john doe" }));
        }
    }

    [Test]
    public async Task PropertyIntegerEqualValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerEqualValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyIntegerEqualValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerEqualValidator(20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "StreetNumber", 10 }));
        }
    }

    [Test]
    public async Task PropertyClassEqualValidator_ShouldSucceed()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassEqualValidator("Dover Patrol", 10);
        var model = new TestModelFor_PropertyClassEqualValidator(subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyClassEqualValidator_ShouldFail()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassEqualValidator("Dover Patrol", 1);
        var model = new TestModelFor_PropertyClassEqualValidator(subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Message));
            Assert.That(result.ErrorList[0].Arguments, Has.Count.EqualTo(2));
            Assert.That(result.ErrorList[0].Arguments[0], Is.EqualTo("Address"));
            Assert.That(result.ErrorList[0].Arguments[1], Is.Not.Null);
            Assert.That(((TestSubModelFor_PropertyClassEqualValidator)result.ErrorList[0].Arguments[1]!).Street, Is.EqualTo("Dover Patrol"));
            Assert.That(((TestSubModelFor_PropertyClassEqualValidator)result.ErrorList[0].Arguments[1]!).StreetNumber, Is.EqualTo(10));
        }
    }

    [Test]
    public async Task PropertyStringEqualWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEqualWithFuncValidator("John Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringEqualWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEqualWithFuncValidator("John Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", "John" }));
        }
    }

    [Test]
    public async Task PropertyStringEqualWithFuncAndComparerValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEqualWithFuncAndComparerValidator("John Doe", "john doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringEqualWithFuncAndComparerValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringEqualWithFuncAndComparerValidator("John Doe", "john");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", "john" }));
        }
    }

    [Test]
    public async Task PropertyIntegerEqualWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerEqualWithFuncValidator(10, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyIntegerEqualWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyIntegerEqualWithFuncValidator(20, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "StreetNumber", 10 }));
        }
    }

    [Test]
    public async Task PropertyClassEqualWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassEqualWithFuncValidator("Dover Patrol", 10);
        var expectedSubModel = new TestSubModelFor_PropertyClassEqualWithFuncValidator("Dover Patrol", 10);
        var model = new TestModelFor_PropertyClassEqualWithFuncValidator(subModel, expectedSubModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyClassEqualWithFuncValidator_ShouldFail()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyClassEqualWithFuncValidator("Dover Patrol", 1);
        var expectedSubModel = new TestSubModelFor_PropertyClassEqualWithFuncValidator("Dover Patrol", 10);
        var model = new TestModelFor_PropertyClassEqualWithFuncValidator(subModel, expectedSubModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Message));
            Assert.That(result.ErrorList[0].Arguments, Has.Count.EqualTo(2));
            Assert.That(result.ErrorList[0].Arguments[0], Is.EqualTo("Address"));
            Assert.That(result.ErrorList[0].Arguments[1], Is.Not.Null);
            Assert.That(((TestSubModelFor_PropertyClassEqualWithFuncValidator)result.ErrorList[0].Arguments[1]!).Street, Is.EqualTo("Dover Patrol"));
            Assert.That(((TestSubModelFor_PropertyClassEqualWithFuncValidator)result.ErrorList[0].Arguments[1]!).StreetNumber, Is.EqualTo(10));
        }
    }

    [Test]
    public async Task PropertyLessThanValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanValidator(9);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyLessThanValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.LessThan.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.LessThan.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10 }));
        }
    }
    
    [Test]
    public async Task PropertyLessThanWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanWithFuncValidator(9, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyLessThanWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanWithFuncValidator(10, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.LessThan.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.LessThan.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10 }));
        }
    }
    
    [Test]
    public async Task PropertyLessThanOrEqualToValidator_9_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanOrEqualToValidator(9);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyLessThanOrEqualToValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanOrEqualToValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyLessThanOrEqualToValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanOrEqualToValidator(11);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.LessThanOrEqualTo.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.LessThanOrEqualTo.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10 }));
        }
    }
    
    [Test]
    public async Task PropertyLessThanOrEqualToWithFuncValidator_9_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanOrEqualToWithFuncValidator(9, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyLessThanOrEqualToWithFuncValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanOrEqualToWithFuncValidator(10, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyLessThanOrEqualToWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyLessThanOrEqualToWithFuncValidator(11, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.LessThanOrEqualTo.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.LessThanOrEqualTo.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10 }));
        }
    }

    [Test]
    public async Task PropertyGreaterThanValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanValidator(11);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyGreaterThanValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10 }));
        }
    }
 
    [Test]
    public async Task PropertyGreaterThanWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanWithFuncValidator(11, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
   
    [Test]
    public async Task PropertyGreaterThanWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanWithFuncValidator(10, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10 }));
        }
    }
 
    [Test]
    public async Task PropertyGreaterThanOrEqualToValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanOrEqualToValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyGreaterThanOrEqualToValidator_11_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanOrEqualToValidator(11);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyGreaterThanOrEqualToValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanOrEqualToValidator(9);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10 }));
        }
    }
    
    [Test]
    public async Task PropertyGreaterThanOrEqualToWithFuncValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanOrEqualToWithFuncValidator(10, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyGreaterThanOrEqualToWithFuncValidator_11_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanOrEqualToWithFuncValidator(11, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyGreaterThanOrEqualToWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyGreaterThanOrEqualToWithFuncValidator(9, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThanOrEqualTo.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10 }));
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenValidator_15_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenValidator(15);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenValidator_20_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenValidator(20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyInclusiveBetweenValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenValidator(9);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyInclusiveBetweenValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenValidator(21);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 21 }));
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithFuncValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncValidator(10, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithFuncValidator_15_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncValidator(15, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithFuncValidator_20_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncValidator(20, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyInclusiveBetweenWithFuncValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncValidator(9, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyInclusiveBetweenWithFuncValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncValidator(21, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 21 }));
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithComparerValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithComparerValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithComparerValidator_15_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithComparerValidator(15);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithComparerValidator_20_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithComparerValidator(20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithComparerValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithComparerValidator(9);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyInclusiveBetweenWithComparerValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithComparerValidator(21);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 21 }));
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithFuncAndComparerValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncAndComparerValidator(10, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithFuncAndComparerValidator_15_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncAndComparerValidator(15, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyInclusiveBetweenWithFuncAndComparerValidator_20_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncAndComparerValidator(20, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyInclusiveBetweenWithFuncAndComparerValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncAndComparerValidator(9, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyInclusiveBetweenWithFuncAndComparerValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithFuncAndComparerValidator(21, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.InclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 21 }));
        }
    }
    
    [Test]
    public async Task PropertyExclusiveBetweenValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenValidator(15);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenValidator(9);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenValidator_10_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 10 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenValidator_20_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenValidator(20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 20 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenValidator(21);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 21 }));
        }
    }
    
    [Test]
    public async Task PropertyExclusiveBetweenWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncValidator(15, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithFuncValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncValidator(9, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithFuncValidator_10_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncValidator(10, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 10 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithFuncValidator_20_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncValidator(20, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 20 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithFuncValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncValidator(21, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 21 }));
        }
    }
    
    [Test]
    public async Task PropertyExclusiveBetweenWithComparerValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithComparerValidator(15);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithComparerValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithComparerValidator(9);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithComparerValidator_10_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithComparerValidator(10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 10 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithComparerValidator_20_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithComparerValidator(20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 20 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithComparerValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithComparerValidator(21);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 21 }));
        }
    }
    
    [Test]
    public async Task PropertyExclusiveBetweenWithFuncAndComparerValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncAndComparerValidator(15, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithFuncAndComparerValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncAndComparerValidator(9, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithFuncAndComparerValidator_10_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncAndComparerValidator(10, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 10 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithFuncAndComparerValidator_20_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncAndComparerValidator(20, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 20 }));
        }
    }

    [Test]
    public async Task PropertyExclusiveBetweenWithFuncAndComparerValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenWithFuncAndComparerValidator(21, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExclusiveBetween.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Discount", 10, 20, 21 }));
        }
    }

    #region String Specific Validators

    [Test]
    public async Task PropertyStringLengthValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthValidator("1234567890");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringLengthValidator_15_Succeed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthValidator("123456789012345");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringLengthValidator_20_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthValidator("12345678901234567890");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }
    
    [Test]
    public async Task PropertyStringLengthValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthValidator("123456789");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Length.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Length.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", 10, 20, 9 }));
        }
    }

    [Test]
    public async Task PropertyStringLengthValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthValidator("123456789012345678901");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Length.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Length.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", 10, 20, 21}));
        }
    }
    
    [Test]
    public async Task PropertyStringLengthValidator_Null_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthValidator(null!);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringLengthWithFuncValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthWithFuncValidator("1234567890", 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringLengthWithFuncValidator_15_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthWithFuncValidator("123456789012345", 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringLengthWithFuncValidator_20_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthWithFuncValidator("12345678901234567890", 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringLengthWithFuncValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthWithFuncValidator("123456789", 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Length.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Length.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", 10, 20, 9}));
        }
    }

    [Test]
    public async Task PropertyStringLengthWithFuncValidator_21_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthWithFuncValidator("123456789012345678901", 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Length.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.Length.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", 10, 20, 21}));
        }
    }

    [Test]
    public async Task PropertyStringLengthWithFuncValidator_Null_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthWithFuncValidator(null!, 10, 20);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringExactLengthValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringExactLengthValidator("1234567890");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringExactLengthValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringExactLengthValidator("123456789");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExactLength.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExactLength.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] { "Name", 10, 9 }));
        }
    }

    [Test]
    public async Task PropertyStringExactLengthValidator_11_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringExactLengthValidator("12345678901");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExactLength.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExactLength.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", 10, 11}));
        }
    }

    [Test]
    public async Task PropertyStringExactLengthValidator_Null_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringExactLengthValidator(null!);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringExactLenghtWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringExactLenghtWithFuncValidator("1234567890", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringExactLenghtWithFuncValidator_9_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringExactLenghtWithFuncValidator("123456789", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExactLength.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExactLength.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", 10, 9}));
        }
    }

    [Test]
    public async Task PropertyStringExactLenghtWithFuncValidator_11_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringExactLenghtWithFuncValidator("12345678901", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.ExactLength.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.ExactLength.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name" ,10, 11}));
        }
    }

    [Test]
    public async Task PropertyStringExactLenghtWithFuncValidator_Null_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringExactLenghtWithFuncValidator(null!, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMaximumLengthValidator_9_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMaximumLengthValidator("123456789");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMaximumLengthValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMaximumLengthValidator("1234567890");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMaximumLengthValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMaximumLengthValidator("12345678901");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MaximumLength.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MaximumLength.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", 10, 11}));
        }
    }

    [Test]
    public async Task PropertyStringMaximumLengthValidator_Null_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMaximumLengthValidator(null!);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMinimumLengthValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMinimumLengthValidator("1234567890");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMaximumLengthWithFuncValidator_9_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMaximumLengthWithFuncValidator("123456789", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMaximumLengthWithFuncValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMaximumLengthWithFuncValidator("1234567890", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMaximumLengthWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMaximumLengthWithFuncValidator("12345678901", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MaximumLength.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MaximumLength.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", 10, 11}));
        }
    }

    [Test]
    public async Task PropertyStringMaximumLengthWithFuncValidator_Null_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMaximumLengthWithFuncValidator(null!, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMinimumLengthValidator_11_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMinimumLengthValidator("12345678901");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMinimumLengthValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMinimumLengthValidator("123456789");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MinimumLength.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MinimumLength.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", 10, 9}));
        }
    }

    [Test]
    public async Task PropertyStringMinimumLengthValidator_Null_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMinimumLengthValidator(null!);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMinimumLengthWithFuncValidator_10_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMinimumLengthWithFuncValidator("1234567890", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMinimumLengthWithFuncValidator_11_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMinimumLengthWithFuncValidator("12345678901", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMinimumLengthWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMinimumLengthWithFuncValidator("123456789", 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MinimumLength.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MinimumLength.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name",10, 9}));
        }
    }
    
    [Test]
    public async Task PropertyStringMinimumLengthWithFuncValidator_Null_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMinimumLengthWithFuncValidator(null!, 10);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithPatternValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithPatternValidator("John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithPatternValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithPatternValidator("Mike");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", "^[jJ][oO][hH][nN]"}));
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithPatternFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithPatternFuncValidator("John", "^[jJ][oO][hH][nN]");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithPatternFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithPatternFuncValidator("Mike", "^[jJ][oO][hH][nN]");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", "^[jJ][oO][hH][nN]"}));
        }
    }
    
    [Test]
    public async Task PropertyStringMatchesRegexValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexValidator("John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexValidator_NullValue_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexValidator(null!);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task PropertyStringMatchesRegexValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexValidator("Mike");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name","^[jJ][oO][hH][nN]"}));
        }
    }

    [GeneratedRegex("^[jJ][oO][hH][nN]")]
    private static partial Regex RegexDefinition();

    [Test]
    public async Task PropertyStringMatchesRegexWithFuncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithFuncValidator("John", RegexDefinition());
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithFuncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithFuncValidator("Mike", RegexDefinition());
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name","^[jJ][oO][hH][nN]"}));
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithPatternAndOptionsValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithPatternAndOptionsValidator("John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithPatternAndOptionsValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithPatternAndOptionsValidator("Mike");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", "^[jJ][oO][hH][nN]"}));
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator("John", "^[jJ][oO][hH][nN]");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyStringMatchesRegexWithPatternFuncAndOptionsValidator("Mike", "^[jJ][oO][hH][nN]");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.MatchesRegex.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", "^[jJ][oO][hH][nN]"}));
        }
    }
    
    #endregion String Specific Validators

    [Test]
    public async Task PropertyValidateValidator_ShouldSucceed()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyValidateValidator("Dover Patrol", 10);
        var model = new TestModelFor_PropertyValidateValidator("John Doe", subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyValidateValidator_ShouldFail()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyValidateValidator("", 0);
        var model = new TestModelFor_PropertyValidateValidator("John Doe", subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(2));
        }
        using (Assert.EnterMultipleScope())
        {
            var indexNotEmpty = -1;
            var indexGreaterThan = -1;
            for (var i = 0; i < result.ErrorList.Count; i++)
            {
                if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.NotEmpty.Code) indexNotEmpty = i;
                else if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.GreaterThan.Code) indexGreaterThan = i;
            }

            Assert.That(indexNotEmpty, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexNotEmpty].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[indexNotEmpty].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[indexNotEmpty].Arguments, Is.EquivalentTo(new object?[] {"Address.Street"}));

            Assert.That(indexGreaterThan, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexGreaterThan].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Code));
            Assert.That(result.ErrorList[indexGreaterThan].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Message));
            Assert.That(result.ErrorList[indexGreaterThan].Arguments, Is.EquivalentTo(new object?[] {"Address.Number", 0}));
        }
    }

    [Test]
    public async Task EnumerablePropertyValidateValidator_ShouldSucceed()
    {
        // arrange
        var subModel1 = new TestSubModelFor_PropertyValidateValidator("Dover Patrol", 10);
        var subModel2 = new TestSubModelFor_PropertyValidateValidator("Dover Patrol", 10);
        var model = new TestModelFor_EnumerablePropertyValidateValidator("John Doe", [subModel1, subModel2]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task EnumerablePropertyValidateValidator_ShouldFail()
    {
        // arrange
        var subModel1 = new TestSubModelFor_PropertyValidateValidator("", 0);
        var subModel2 = new TestSubModelFor_PropertyValidateValidator("", 0);
        var model = new TestModelFor_EnumerablePropertyValidateValidator("John Doe", [subModel1, subModel2]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(4));
        }
        using (Assert.EnterMultipleScope())
        {
            var indexNotEmpty0 = -1;
            var indexGreaterThan0 = -1;
            var indexNotEmpty1 = -1;
            var indexGreaterThan1 = -1;
            for (var i = 0; i < result.ErrorList.Count; i++)
            {
                if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.NotEmpty.Code
                    && (result.ErrorList[i].Arguments[0]?.ToString() ?? "").StartsWith("Addresses[0].")) indexNotEmpty0 = i;
                else if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.GreaterThan.Code
                         && (result.ErrorList[i].Arguments[0]?.ToString() ?? "").StartsWith("Addresses[0].")) indexGreaterThan0 = i;
                else if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.NotEmpty.Code
                    && (result.ErrorList[i].Arguments[0]?.ToString() ?? "").StartsWith("Addresses[1].")) indexNotEmpty1 = i;
                else if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.GreaterThan.Code
                         && (result.ErrorList[i].Arguments[0]?.ToString() ?? "").StartsWith("Addresses[1].")) indexGreaterThan1= i;
            }

            Assert.That(indexNotEmpty0, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexNotEmpty0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[indexNotEmpty0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[indexNotEmpty0].Arguments, Is.EquivalentTo(new object?[] {"Addresses[0].Street"}));

            Assert.That(indexGreaterThan0, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexGreaterThan0].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Code));
            Assert.That(result.ErrorList[indexGreaterThan0].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Message));
            Assert.That(result.ErrorList[indexGreaterThan0].Arguments, Is.EquivalentTo(new object?[] {"Addresses[0].Number", 0}));

            Assert.That(indexNotEmpty1, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexNotEmpty1].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[indexNotEmpty1].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[indexNotEmpty1].Arguments, Is.EquivalentTo(new object?[] {"Addresses[1].Street"}));

            Assert.That(indexGreaterThan1, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexGreaterThan1].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Code));
            Assert.That(result.ErrorList[indexGreaterThan1].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Message));
            Assert.That(result.ErrorList[indexGreaterThan1].Arguments, Is.EquivalentTo(new object?[] {"Addresses[1].Number", 0}));
        }
    }

    [Test]
    public async Task PropertyMustAsyncWithPropertyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyMustAsyncWithPropertyValidator("John", "Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyMustAsyncWithPropertyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyMustAsyncWithPropertyValidator("John", "Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(PropertyMustAsyncWithPropertyValidator.Error.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(PropertyMustAsyncWithPropertyValidator.Error.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"FullName", "John"}));
        }
    }

    [Test]
    public async Task PropertyMustWithPropertyValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyMustWithPropertyValidator("John", "Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyMustWithPropertyValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyMustWithPropertyValidator("John", "Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(PropertyMustWithPropertyValidator.Error.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(PropertyMustWithPropertyValidator.Error.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"FullName", "John"}));
        }
    }

    [Test]
    public async Task PropertyMustAsyncWithPropertyAndModelValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyMustAsyncWithPropertyAndModelValidator("John", "Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyMustAsyncWithPropertyAndModelValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyMustAsyncWithPropertyAndModelValidator("John", "Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(PropertyMustAsyncWithPropertyAndModelValidator.Error.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(PropertyMustAsyncWithPropertyAndModelValidator.Error.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"FullName","John", "John", "Doe"}));
        }
    }

    [Test]
    public async Task PropertyMustWithPropertyAndModelValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyMustWithPropertyAndModelValidator("John", "Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task PropertyMustWithPropertyAndModelValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyMustWithPropertyAndModelValidator("John", "Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(PropertyMustWithPropertyAndModelValidator.Error.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(PropertyMustWithPropertyAndModelValidator.Error.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"FullName", "John", "John", "Doe"}));
        }
    }

    #endregion Property Validators
    
    #region Model Validators
 
    [Test]
    public async Task ModelMustAsyncValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_ModelMustAsyncValidator("John", "Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task ModelMustAsyncValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_ModelMustAsyncValidator("John", "Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(ModelMustAsyncValidator.Error.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(ModelMustAsyncValidator.Error.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"FullName","John", "John", "Doe"}));
        }
    }
   
    [Test]
    public async Task ModelMustValidator_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_ModelMustValidator("John", "Doe", "John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task ModelMustValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_ModelMustValidator("John", "Doe", "John");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(ModelMustValidator.Error.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(ModelMustValidator.Error.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"FullName", "John", "John", "Doe"}));
        }
    }
    
    #endregion Model Validators

    #region Rule Modifiers

    [Test]
    public async Task WithFieldNameValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_WithFieldNameValidator(null);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotNull.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotNull.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"CustomName"}));
        }
    }

    [Test]
    public async Task WithMessageValidator_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_WithMessageValidator("Jane");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.Equal.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(WithMessageValidator.Error.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name", "John"}));
        }
    }

    [Test]
    public async Task WhenValidator_ConditionTrue_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_WhenValidator(-1, true);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Value", 0}));
        }
    }

    [Test]
    public async Task WhenValidator_ConditionFalse_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_WhenValidator(-1, false);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task WhenAsyncValidator_ConditionTrue_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_WhenAsyncValidator(-1, true);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.GreaterThan.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Value", 0}));
        }
    }

    [Test]
    public async Task WhenAsyncValidator_ConditionFalse_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_WhenAsyncValidator(-1, false);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task MultipleWhenValidator_BothConditionsTrue_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_MultipleWhenValidator(-1, true, true);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
    }

    [Test]
    public async Task MultipleWhenValidator_OneConditionFalse_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_MultipleWhenValidator(-1, true, false);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task ConditionScopedToSingleRuleValidator_LengthRuleSkipped_ShouldReportOnlyNotEmpty()
    {
        // arrange
        var model = new TestModelFor_WhenWithConditionScopedToSingleRuleValidator("", false);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name"}));
        }
    }

    [Test]
    public async Task ConditionScopedToSingleRuleValidator_LengthRuleRuns_ShouldReportBoth()
    {
        // arrange
        var model = new TestModelFor_WhenWithConditionScopedToSingleRuleValidator("", true);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(2));
        }
        using (Assert.EnterMultipleScope())
        {
            var indexNotEmpty = -1;
            var indexLenght = -1;
            for (var i = 0; i < result.ErrorList.Count; i++)
            {
                if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.NotEmpty.Code) indexNotEmpty = i;
                else if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.Length.Code) indexLenght = i;
            }

            Assert.That(indexNotEmpty, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexNotEmpty].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[indexNotEmpty].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[indexNotEmpty].Arguments, Is.EquivalentTo(new object?[] {"Name"}));

            Assert.That(indexLenght, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexLenght].Code, Is.EqualTo(CatValidatorErrorDefinitions.Length.Code));
            Assert.That(result.ErrorList[indexLenght].Message, Is.EqualTo(CatValidatorErrorDefinitions.Length.Message));
            Assert.That(result.ErrorList[indexLenght].Arguments, Is.EquivalentTo(new object?[] {"Name", 5, 10, 0}));
        }
    }

    #endregion Rule Modifiers

    #region Processor Contract

    [Test]
    public void ValidateAsync_ValidatorRequiredDefault_NoValidatorRegistered_ShouldThrow()
    {
        // arrange
        var model = new TestModelFor_NoValidatorRegistered("John Doe");
        // act & assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await _validatorProcessor.ValidateAsync(model));
    }

    [Test]
    public async Task ValidateAsync_ValidatorRequiredFalse_NoValidatorRegistered_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_NoValidatorRegistered("John Doe");
        // act
        var result = await _validatorProcessor.ValidateAsync(model, validatorRequired: false);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public void Validate_Sync_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyNotNullValidator("John Doe");
        // act
        var result = _validatorProcessor.Validate(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public void Validate_Sync_ShouldFail()
    {
        // arrange
        var model = new TestModelFor_PropertyNotNullValidator(null);
        // act
        var result = _validatorProcessor.Validate(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        }
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ErrorList[0].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotNull.Code));
            Assert.That(result.ErrorList[0].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotNull.Message));
            Assert.That(result.ErrorList[0].Arguments, Is.EquivalentTo(new object?[] {"Name"}));
        }
    }

    #endregion Processor Contract

    #region Argument Guards

    [Test]
    public void InclusiveBetweenValidator_InvalidBounds_ShouldThrow()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenInvalidValidator(5);
        // act & assert
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _validatorProcessor.ValidateAsync(model));
    }

    [Test]
    public void ExclusiveBetweenValidator_InvalidBounds_ShouldThrow()
    {
        // arrange
        var model = new TestModelFor_PropertyExclusiveBetweenInvalidValidator(5);
        // act & assert
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _validatorProcessor.ValidateAsync(model));
    }

    [Test]
    public void LengthValidator_InvalidBounds_ShouldThrow()
    {
        // arrange
        var model = new TestModelFor_PropertyStringLengthInvalidValidator("John Doe");
        // act & assert
        Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _validatorProcessor.ValidateAsync(model));
    }

    [Test]
    public void InclusiveBetweenWithComparerValidator_NullLowerBound_ShouldThrow()
    {
        // arrange
        var model = new TestModelFor_PropertyInclusiveBetweenWithComparerNullBoundValidator("m");
        // act & assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _validatorProcessor.ValidateAsync(model));
    }

    [Test]
    public void MatchesRegexValidator_InvalidPattern_ShouldThrow()
    {
        // arrange
        var model = new TestModelFor_PropertyStringRegexPatternInvalidValidator("John");
        // act & assert
        Assert.ThrowsAsync<ArgumentException>(async () => await _validatorProcessor.ValidateAsync(model));
    }

    #endregion Argument Guards

    #region Nested Validation Edge Cases

    [Test]
    public async Task PropertyValidateValidator_NullNestedObject_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_PropertyValidateValidator("John Doe", null);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public async Task EnumerablePropertyValidateValidator_NullEnumerable_ShouldSucceed()
    {
        // arrange
        var model = new TestModelFor_EnumerablePropertyValidateValidator("John Doe", null);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsSucceeded, Is.True);
        }
    }

    [Test]
    public void PropertyValidateValidator_NoRegisteredNestedValidator_ValidatorRequired_ShouldThrow()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyValidateValidator_NoValidator("Street");
        var model = new TestModelFor_PropertyValidateValidator_NoNestedValidator("John Doe", subModel);
        // act & assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await _validatorProcessor.ValidateAsync(model));
    }

    [Test]
    public async Task PropertyValidateValidator_NoRegisteredNestedValidator_ValidatorNotRequired_ShouldSucceed()
    {
        // arrange
        var subModel = new TestSubModelFor_PropertyValidateValidator_NoValidator("Street");
        var model = new TestModelFor_PropertyValidateValidator_NoNestedValidator("John Doe", subModel);
        // act
        var result = await _validatorProcessor.ValidateAsync(model, validatorRequired: false);
        // assert
        Assert.That(result.IsSucceeded, Is.True);
    }

    [Test]
    public async Task EnumerablePropertyValidateValidator_NullItemInMiddle_ShouldSkipItAndKeepCountingIndexes()
    {
        // arrange
        var subModel1 = new TestSubModelFor_PropertyValidateValidator("", 0);
        var subModel3 = new TestSubModelFor_PropertyValidateValidator("", 0);
        var model = new TestModelFor_EnumerablePropertyValidateValidator("John Doe", [subModel1, null, subModel3]);
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            // the null entry is skipped, subModel1 and subModel3 each report 2 errors
            Assert.That(result.ErrorList, Has.Count.EqualTo(4));
        }
        using (Assert.EnterMultipleScope())
        {
            var streetArguments = result.ErrorList
                .Where(e => e.Code == CatValidatorErrorDefinitions.NotEmpty.Code)
                .Select(e => e.Arguments[0])
                .ToList();
            var numberArguments = result.ErrorList
                .Where(e => e.Code == CatValidatorErrorDefinitions.GreaterThan.Code)
                .Select(e => e.Arguments[0])
                .ToList();

            // the null entry still counts, so the third item keeps index 2
            Assert.That(streetArguments, Is.EquivalentTo(new object?[] {"Addresses[0].Street", "Addresses[2].Street"}));
            Assert.That(numberArguments, Is.EquivalentTo(new object?[] {"Addresses[0].Number", "Addresses[2].Number"}));
        }
    }

    #endregion Nested Validation Edge Cases

    #region Combined Rules

    [Test]
    public async Task CombinedPropertyAndModelRulesValidator_BothFail_ShouldReturnBothErrors()
    {
        // arrange
        var model = new TestModelFor_CombinedPropertyAndModelRulesValidator("", "Doe", "Wrong Name");
        // act
        var result = await _validatorProcessor.ValidateAsync(model);
        // assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.ErrorList, Has.Count.EqualTo(2));
        }
        using (Assert.EnterMultipleScope())
        {
            var indexNotEmpty = -1;
            var indexError = -1;
            for (var i = 0; i < result.ErrorList.Count; i++)
            {
                if (result.ErrorList[i].Code == CatValidatorErrorDefinitions.NotEmpty.Code) indexNotEmpty = i;
                else if (result.ErrorList[i].Code == CombinedPropertyAndModelRulesValidator.Error.Code) indexError = i;
            }

            Assert.That(indexNotEmpty, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexNotEmpty].Code, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Code));
            Assert.That(result.ErrorList[indexNotEmpty].Message, Is.EqualTo(CatValidatorErrorDefinitions.NotEmpty.Message));
            Assert.That(result.ErrorList[indexNotEmpty].Arguments, Is.EquivalentTo(new object?[] {"FirstName"}));

            Assert.That(indexError, Is.Not.EqualTo(-1));
            Assert.That(result.ErrorList[indexError].Code, Is.EqualTo(CombinedPropertyAndModelRulesValidator.Error.Code));
            Assert.That(result.ErrorList[indexError].Message, Is.EqualTo(CombinedPropertyAndModelRulesValidator.Error.Message));
            Assert.That(result.ErrorList[indexError].Arguments, Is.EquivalentTo(new object?[] {"FullName"}));
        }
    }

    #endregion Combined Rules
}