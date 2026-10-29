using System.Collections;
using Cat.Enumerable.Extensions;

namespace Cat.Extensions.Tests;

[TestFixture]
public class EnumerableExtensionsTests
{
    private static IEnumerable Numbers(int count)
    {
        for (var i = 0; i < count; i++) yield return i;
    }

    [Test]
    public void IsEmpty_EmptyList_ReturnsTrue()
    {
        Assert.That(new List<int>().IsEmpty(), Is.True);
    }

    [Test]
    public void IsEmpty_ListWithItems_ReturnsFalse()
    {
        Assert.That(new List<int> { 1 }.IsEmpty(), Is.False);
    }

    [Test]
    public void IsEmpty_EmptyArray_ReturnsTrue()
    {
        Assert.That(Array.Empty<string>().IsEmpty(), Is.True);
    }

    [Test]
    public void IsEmpty_NonGenericCollection_Works()
    {
        Assert.That(new ArrayList().IsEmpty(), Is.True);
        Assert.That(new ArrayList { 1 }.IsEmpty(), Is.False);
    }

    [Test]
    public void IsEmpty_EmptyString_ReturnsTrue()
    {
        Assert.That("".IsEmpty(), Is.True);
        Assert.That("a".IsEmpty(), Is.False);
    }

    [Test]
    public void IsEmpty_EmptyIteratorSequence_ReturnsTrue()
    {
        Assert.That(Numbers(0).IsEmpty(), Is.True);
    }

    [Test]
    public void IsEmpty_IteratorSequenceWithItems_ReturnsFalse()
    {
        Assert.That(Numbers(3).IsEmpty(), Is.False);
    }

    [Test]
    public void IsEmpty_LinqQuery_Works()
    {
        var query = new[] { 1, 2, 3 }.Where(x => x > 5);

        Assert.That(query.IsEmpty(), Is.True);
    }
}
