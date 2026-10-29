using Cat.Expressions.Extensions;
using Cat.NUnit;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using Cat.Validators.Tests.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Validators.Tests;

/// <summary>
/// Sets up the validators module with every validator of this test project.
/// </summary>
public abstract class ValidatorTestBase : UnitTestBase
{
    protected ICatValidatorProcessor Processor => ServiceProvider.GetRequiredService<ICatValidatorProcessor>();

    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddCatCompiledMemberExpressionCache();
        services.AddCatValidatorsModule(typeof(ModelMustAsyncValidator));
    }
}
