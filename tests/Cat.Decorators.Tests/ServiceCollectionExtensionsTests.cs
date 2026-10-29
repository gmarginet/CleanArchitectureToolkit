using Cat.Decorators.Abstractions;
using Cat.Decorators.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Decorators.Tests;

[TestFixture]
public class ServiceCollectionExtensionsTests
{
    [Test]
    public void AddCatDecoratorsModule_RegistersTheFactoryAndTheBuilder()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatDecoratorsModule();
        using var provider = services.BuildServiceProvider();

        Assert.That(provider.GetRequiredService<ICatDecoratorFactory>(), Is.TypeOf<CatDecoratorFactory>());
        Assert.That(provider.GetRequiredService<ICatDecoratorFactoryBuilder>(), Is.TypeOf<CatDecoratorFactoryBuilder>());
    }

    [Test]
    public void AddCatDecoratorsModule_RegistersSingletons()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatDecoratorsModule();
        using var provider = services.BuildServiceProvider();

        var firstFactory = provider.GetRequiredService<ICatDecoratorFactory>();
        var secondFactory = provider.GetRequiredService<ICatDecoratorFactory>();
        var firstBuilder = provider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        var secondBuilder = provider.GetRequiredService<ICatDecoratorFactoryBuilder>();

        Assert.That(firstFactory, Is.SameAs(secondFactory));
        Assert.That(firstBuilder, Is.SameAs(secondBuilder));
    }

    [Test]
    public void AddCatDecoratorsModule_CalledTwice_RegistersEachServiceOnce()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

        services.AddCatDecoratorsModule();
        services.AddCatDecoratorsModule();

        Assert.That(services.Count(s => s.ServiceType == typeof(ICatDecoratorFactory)), Is.EqualTo(1));
        Assert.That(services.Count(s => s.ServiceType == typeof(ICatDecoratorFactoryBuilder)), Is.EqualTo(1));
    }

    [Test]
    public void AddCatDecoratorsModule_TheBuilderAddsDecoratorsToTheSameFactory()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatDecoratorsModule();
        using var provider = services.BuildServiceProvider();

        var factory = provider.GetRequiredService<ICatDecoratorFactory>();
        var builder = provider.GetRequiredService<ICatDecoratorFactoryBuilder>();

        Assert.DoesNotThrow(() => builder.AddDecorator(typeof(IEnumerable<>), typeof(List<>)));
        Assert.That(factory, Is.Not.Null);
    }
}

[TestFixture]
public class CatDecoratorParameterTests
{
    [Test]
    public void Parameter_KeepsTheNameAndTheValue()
    {
        var parameter = new CatDecoratorParameter("prefix", 5);

        Assert.That(parameter.Name, Is.EqualTo("prefix"));
        Assert.That(parameter.Value, Is.EqualTo(5));
    }

    [Test]
    public void Parameters_WithTheSameNameAndValue_AreEqual()
    {
        var parameter = new CatDecoratorParameter("a", 1);
        var same = new CatDecoratorParameter("a", 1);
        var other = new CatDecoratorParameter("a", 2);

        Assert.That(parameter, Is.EqualTo(same));
        Assert.That(parameter, Is.Not.EqualTo(other));
    }

    [Test]
    public void Info_KeepsTheDecoratorTypeAndTheParameters()
    {
        var parameters = new Dictionary<string, object> { ["a"] = 1 };

        var info = new CatDecoratorInfo(typeof(List<>), parameters);

        Assert.That(info.DecoratorGenericTypeDefinition, Is.EqualTo(typeof(List<>)));
        Assert.That(info.DecoratorParameterDictionary, Is.SameAs(parameters));
    }
}
