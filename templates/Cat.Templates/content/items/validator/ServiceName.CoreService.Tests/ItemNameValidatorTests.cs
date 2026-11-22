using Cat.UnitTesting.NUnit;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using Microsoft.Extensions.DependencyInjection;
using ServiceName.CoreService.Validators;
using TARGET_NAMESPACE;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameValidatorTests : UnitTestBase
{
    // Fully qualified, because a project that references the Api project sees a second ServiceCollection type.
    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddCatValidatorsModule(typeof(ItemNameValidator));
    }

    [Test]
    public void Validator_ShouldBeFoundByTheModule()
    {
        Assert.That(ServiceProvider.GetService<ICatValidator<ItemName>>(), Is.InstanceOf<ItemNameValidator>());
    }
}
