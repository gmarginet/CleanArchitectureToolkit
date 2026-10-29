namespace Cat.Responses.Tests;

[TestFixture]
public class CatErrorTests
{
    [Test]
    public void Create_KeepsTheCodeTheMessageAndTheArgumentsInOrder()
    {
        var error = CatError.Create("T-1", "Product {name} costs {price}", "Chair", 25);

        Assert.That(error.Code, Is.EqualTo("T-1"));
        Assert.That(error.Message, Is.EqualTo("Product {name} costs {price}"));
        Assert.That(error.Arguments, Is.EqualTo(new object?[] { "Chair", 25 }));
    }

    [Test]
    public void Create_WithoutArguments_HasNoArguments()
    {
        var error = CatError.Create("T-1", "plain");

        Assert.That(error.Arguments, Is.Empty);
    }

    [Test]
    public void Create_WithANullArgument_KeepsTheNull()
    {
        var error = CatError.Create("T-1", "value {v}", new object?[] { null });

        Assert.That(error.Arguments, Has.Count.EqualTo(1));
        Assert.That(error.Arguments[0], Is.Null);
    }

    [Test]
    public void Create_WithAList_KeepsTheArgumentsInOrder()
    {
        var error = CatError.Create("T-1", "{a} {b}", new List<object?> { 1, "two" });

        Assert.That(error.Arguments, Is.EqualTo(new object?[] { 1, "two" }));
    }

    [Test]
    public void Create_CopiesTheList_SoLaterChangesDoNotLeakIn()
    {
        var list = new List<object?> { 1 };
        var error = CatError.Create("T-1", "{a}", list);

        list.Add(2);

        Assert.That(error.Arguments, Is.EqualTo(new object?[] { 1 }));
    }
}
