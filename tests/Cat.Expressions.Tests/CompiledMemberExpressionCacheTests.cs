using System.Linq.Expressions;
using System.Reflection;
using Cat.Expressions.Abstractions;
using Cat.Expressions.Extensions;
using Cat.NUnit;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Expressions.Tests;

[TestFixture]
public class CompiledMemberExpressionCacheTests : UnitTestBase
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Nickname { get; set; } = "";
    }

    private ICatCompiledMemberExpressionCache<Person> Cache { get; set; } = null!;

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddCatCompiledMemberExpressionCache();
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        Cache = ServiceProvider.GetRequiredService<ICatCompiledMemberExpressionCache<Person>>();
    }

    [Test]
    public void GetOrAdd_MemberExpression_ReturnsAFunctionThatReadsTheMember()
    {
        var getName = Cache.GetOrAdd<string>(p => p.Name);

        Assert.That(getName(new Person { Name = "Anna" }), Is.EqualTo("Anna"));
    }

    [Test]
    public void GetOrAdd_TheSameExpressionTwice_ReturnsTheSameFunction()
    {
        var first = Cache.GetOrAdd<string>(p => p.Name);
        var second = Cache.GetOrAdd<string>(p => p.Name);

        Assert.That(second, Is.SameAs(first));
    }

    [Test]
    public void GetOrAdd_DifferentMembers_ReturnDifferentFunctions()
    {
        var name = Cache.GetOrAdd<string>(p => p.Name);
        var nickname = Cache.GetOrAdd<string>(p => p.Nickname);

        Assert.That(nickname, Is.Not.SameAs(name));
        Assert.That(nickname(new Person { Name = "Anna", Nickname = "A" }), Is.EqualTo("A"));
    }

    [Test]
    public void GetOrAdd_WithAGivenMemberInfo_UsesItForTheCacheKey()
    {
        var member = typeof(Person).GetProperty(nameof(Person.Name))!;

        var first = Cache.GetOrAdd<string>(p => p.Name, member);
        var second = Cache.GetOrAdd<string>(p => p.Name, member);

        Assert.That(second, Is.SameAs(first));
    }

    [Test]
    public void GetOrAdd_ExpressionThatIsNotAMember_IsCompiledEveryTime()
    {
        var first = Cache.GetOrAdd<string>(p => p.Name + "!");
        var second = Cache.GetOrAdd<string>(p => p.Name + "!");

        Assert.That(second, Is.Not.SameAs(first));
        Assert.That(first(new Person { Name = "Anna" }), Is.EqualTo("Anna!"));
    }

    [Test]
    public void GetOrAdd_ValueTypeMember_Works()
    {
        var getId = Cache.GetOrAdd<int>(p => p.Id);

        Assert.That(getId(new Person { Id = 7 }), Is.EqualTo(7));
    }

    [Test]
    public void GetOrAdd_ANullExpression_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => Cache.GetOrAdd<string>(null!));
    }

    [Test]
    public void GetOrAdd_ManyThreadsAtOnce_AllGetAWorkingFunction()
    {
        var functions = Enumerable.Range(0, 50)
            .AsParallel()
            .Select(_ => Cache.GetOrAdd<string>(p => p.Name))
            .ToList();

        Assert.That(functions, Has.Count.EqualTo(50));
        Assert.That(functions.All(f => f(new Person { Name = "x" }) == "x"), Is.True);
    }
}
