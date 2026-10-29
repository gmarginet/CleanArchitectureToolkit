using Cat.Expressions.Abstractions;
using Cat.Expressions.Extensions;
using Cat.NUnit;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Expressions.Tests;

[TestFixture]
public class NoCacheCompiledMemberExpressionCacheTests : UnitTestBase
{
    public class Person
    {
        public string Name { get; set; } = "";
    }

    private ICatCompiledMemberExpressionCache<Person> Cache { get; set; } = null!;

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddCatNoCacheCompiledMemberExpressionCache();
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        Cache = ServiceProvider.GetRequiredService<ICatCompiledMemberExpressionCache<Person>>();
    }

    [Test]
    public void GetOrAdd_ReturnsAFunctionThatReadsTheMember()
    {
        var getName = Cache.GetOrAdd<string>(p => p.Name);

        Assert.That(getName(new Person { Name = "Anna" }), Is.EqualTo("Anna"));
    }

    [Test]
    public void GetOrAdd_TheSameExpressionTwice_ReturnsANewFunctionEachTime()
    {
        var first = Cache.GetOrAdd<string>(p => p.Name);
        var second = Cache.GetOrAdd<string>(p => p.Name);

        Assert.That(second, Is.Not.SameAs(first));
    }

    [Test]
    public void GetOrAdd_ANullExpression_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => Cache.GetOrAdd<string>(null!));
    }
}
