using System.Collections.Concurrent;
using System.Linq.Expressions;
using Cat.Expressions.Abstractions;
using Cat.Expressions.Extensions;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using Cat.Validators.Tests.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Validators.Tests;

[TestFixture]
public class ModuleRegistrationTests
{
    #region AddCatValidatorsModule

    [Test]
    public void AddCatValidatorsModule_RegistersTheProcessorAsScoped()
    {
        var services = new ServiceCollection();
        services.AddCatValidatorsModule(typeof(WithCodeValidator));

        var descriptor = services.Single(s => s.ServiceType == typeof(ICatValidatorProcessor));

        Assert.That(descriptor.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
        Assert.That(descriptor.ImplementationType, Is.EqualTo(typeof(CatValidatorProcessor)));
    }

    [Test]
    public void AddCatValidatorsModule_RegistersTheValidatorsAsScoped()
    {
        var services = new ServiceCollection();
        services.AddCatValidatorsModule(typeof(WithCodeValidator));

        var descriptor = services.Single(s => s.ServiceType == typeof(ICatValidator<TestModelFor_WithCodeValidator>)
                                              && s.ImplementationType == typeof(WithCodeValidator));

        Assert.That(descriptor.Lifetime, Is.EqualTo(ServiceLifetime.Scoped));
    }

    [Test]
    public void AddCatValidatorsModule_SkipsGenericValidators()
    {
        var services = new ServiceCollection();
        services.AddCatValidatorsModule(typeof(WithCodeValidator));

        Assert.That(services.Any(s => s.ImplementationType == typeof(GenericModelValidator<>)), Is.False);
    }

    [Test]
    public void AddCatValidatorsModule_ReturnsTheServiceCollection()
    {
        var services = new ServiceCollection();

        var returned = services.AddCatValidatorsModule(typeof(WithCodeValidator));

        Assert.That(returned, Is.SameAs(services));
    }

    [Test]
    public void AddCatValidatorsModule_ScansEveryGivenAssembly()
    {
        var services = new ServiceCollection();

        // the second type lives in another assembly and has no validators, so only this one adds some
        services.AddCatValidatorsModule(typeof(WithCodeValidator), typeof(ICatValidator<>));

        Assert.That(services.Any(s => s.ImplementationType == typeof(WithCodeValidator)), Is.True);
    }

    #endregion AddCatValidatorsModule

    #region Adding rules

    private class FakePropertyRule : ICatValidatorPropertyRule<TestModelFor_WithCodeValidator, string>
    {
        public ConcurrentBag<Func<TestModelFor_WithCodeValidator, CancellationToken, Task<bool>>> RulesConditionFuncAsyncList { get; } = [];
        public string? FieldName { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }

        public Task<List<ICatValidatorError>> ValidateAsync(TestModelFor_WithCodeValidator model, CancellationToken ct)
        {
            return Task.FromResult(new List<ICatValidatorError>());
        }
    }

    private class FakeModelRule : ICatValidatorModelRule<TestModelFor_WithCodeValidator>
    {
        public ConcurrentBag<Func<TestModelFor_WithCodeValidator, CancellationToken, Task<bool>>> RulesConditionFuncAsyncList { get; } = [];

        public Task<List<ICatValidatorError>> ValidateAsync(TestModelFor_WithCodeValidator model, CancellationToken ct)
        {
            return Task.FromResult(new List<ICatValidatorError>());
        }
    }

    [Test]
    public void AddPropertyRule_ARuleThatDoesNotDeriveFromTheBaseClass_Throws()
    {
        var services = new ServiceCollection();
        services.AddCatCompiledMemberExpressionCache();
        using var provider = services.BuildServiceProvider();
        Expression<Func<TestModelFor_WithCodeValidator, string>> property = m => m.Name;
        var builder = new CatValidatorPropertyRuleBuilder<TestModelFor_WithCodeValidator, string>(
            [],
            property,
            provider.GetRequiredService<ICatCompiledMemberExpressionCache<TestModelFor_WithCodeValidator>>(),
            new CatValidatorProcessor(provider));

        var exception = Assert.Throws<ArgumentException>(() => builder.AddPropertyRule(new FakePropertyRule()));

        Assert.That(exception!.Message, Does.Contain("FakePropertyRule"));
    }

    [Test]
    public void AddRule_ARuleThatDoesNotDeriveFromTheBaseClass_Throws()
    {
        var builder = new CatValidatorModelRuleBuilder<TestModelFor_WithCodeValidator>([]);

        var exception = Assert.Throws<ArgumentException>(() => builder.AddRule(new FakeModelRule()));

        Assert.That(exception!.Message, Does.Contain("FakeModelRule"));
    }

    [Test]
    public void AddRule_ARuleThatDerivesFromTheBaseClass_IsAdded()
    {
        var rules = new ConcurrentQueue<ICatValidatorModelRule<TestModelFor_CustomModelRuleValidator>>();
        var builder = new CatValidatorModelRuleBuilder<TestModelFor_CustomModelRuleValidator>(rules);

        builder.AddRule(new FirstAndSecondDifferRule());

        Assert.That(rules, Has.Count.EqualTo(1));
    }

    #endregion Adding rules
}
