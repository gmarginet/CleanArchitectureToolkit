using System.Linq.Expressions;
using Cat.Expression.Extensions;

namespace Cat.Extensions.Tests;

[TestFixture]
public class ExpressionExtensionsTests
{
    private class Address
    {
        public string Street { get; set; } = "";
    }

    private class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public Address Address { get; set; } = new();
        public string GetName() => Name;
    }

    [Test]
    public void GetMemberInfo_Property_ReturnsThatProperty()
    {
        Expression<Func<Person, string>> expression = p => p.Name;

        var member = expression.GetMemberInfo();

        Assert.That(member, Is.Not.Null);
        Assert.That(member!.Name, Is.EqualTo(nameof(Person.Name)));
        Assert.That(member.DeclaringType, Is.EqualTo(typeof(Person)));
    }

    [Test]
    public void GetMemberInfo_NestedProperty_ReturnsTheLastMember()
    {
        Expression<Func<Person, string>> expression = p => p.Address.Street;

        var member = expression.GetMemberInfo();

        Assert.That(member, Is.Not.Null);
        Assert.That(member!.Name, Is.EqualTo(nameof(Address.Street)));
        Assert.That(member.DeclaringType, Is.EqualTo(typeof(Address)));
    }

    [Test]
    public void GetMemberInfo_PropertyWithAConversion_ReturnsThatProperty()
    {
        Expression<Func<Person, object>> expression = p => p.Id;

        var member = expression.GetMemberInfo();

        Assert.That(member, Is.Not.Null);
        Assert.That(member!.Name, Is.EqualTo(nameof(Person.Id)));
    }

    [Test]
    public void GetMemberInfo_MethodCall_ReturnsNull()
    {
        Expression<Func<Person, string>> expression = p => p.GetName();

        Assert.That(expression.GetMemberInfo(), Is.Null);
    }

    [Test]
    public void GetMemberInfo_TheParameterItself_ReturnsNull()
    {
        Expression<Func<Person, Person>> expression = p => p;

        Assert.That(expression.GetMemberInfo(), Is.Null);
    }

    [Test]
    public void GetMemberInfo_ConstantExpression_ReturnsNull()
    {
        Expression<Func<Person, int>> expression = _ => 5;

        Assert.That(expression.GetMemberInfo(), Is.Null);
    }

    [Test]
    public void GetMemberInfo_MemberOfAnOuterVariable_ReturnsNull()
    {
        var outer = new Person();
        Expression<Func<Person, string>> expression = _ => outer.Name;

        Assert.That(expression.GetMemberInfo(), Is.Null);
    }

    [Test]
    public void GetMemberInfo_StaticMember_ReturnsNull()
    {
        Expression<Func<Person, long>> expression = _ => DateTime.MinValue.Ticks;

        Assert.That(expression.GetMemberInfo(), Is.Null);
    }
}
