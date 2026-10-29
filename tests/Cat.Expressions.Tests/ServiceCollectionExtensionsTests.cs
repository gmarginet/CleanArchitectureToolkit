using Cat.Expressions.Abstractions;
using Cat.Expressions.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Expressions.Tests;

[TestFixture]
public class ServiceCollectionExtensionsTests
{
    public class Person;

    public class Order;

    [Test]
    public void AddCatCompiledMemberExpressionCache_RegistersACacheForAnyType()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatCompiledMemberExpressionCache();
        using var provider = services.BuildServiceProvider();

        Assert.That(provider.GetRequiredService<ICatCompiledMemberExpressionCache<Person>>(), Is.Not.Null);
        Assert.That(provider.GetRequiredService<ICatCompiledMemberExpressionCache<Order>>(), Is.Not.Null);
    }

    [Test]
    public void AddCatCompiledMemberExpressionCache_RegistersASingletonPerType()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatCompiledMemberExpressionCache();
        using var provider = services.BuildServiceProvider();

        var first = provider.GetRequiredService<ICatCompiledMemberExpressionCache<Person>>();
        var second = provider.GetRequiredService<ICatCompiledMemberExpressionCache<Person>>();
        var other = provider.GetRequiredService<ICatCompiledMemberExpressionCache<Order>>();

        Assert.That(second, Is.SameAs(first));
        Assert.That(other, Is.Not.SameAs(first));
    }

    [Test]
    public void AddCatNoCacheCompiledMemberExpressionCache_RegistersTheNoCacheVersion()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatNoCacheCompiledMemberExpressionCache();
        using var provider = services.BuildServiceProvider();

        var cache = provider.GetRequiredService<ICatCompiledMemberExpressionCache<Person>>();

        Assert.That(cache, Is.TypeOf<CatNoCacheCompiledMemberExpressionCache<Person>>());
    }

    [Test]
    public void AddCatCompiledMemberExpressionCache_RegistersTheCachingVersion()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatCompiledMemberExpressionCache();
        using var provider = services.BuildServiceProvider();

        var cache = provider.GetRequiredService<ICatCompiledMemberExpressionCache<Person>>();

        Assert.That(cache, Is.Not.TypeOf<CatNoCacheCompiledMemberExpressionCache<Person>>());
    }
}
