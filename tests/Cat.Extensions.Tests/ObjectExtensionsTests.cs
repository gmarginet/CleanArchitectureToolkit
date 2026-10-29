using Cat.Object.Extensions;

namespace Cat.Extensions.Tests;

[TestFixture]
public class ObjectExtensionsTests
{
    private class NotComparable;

    private class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }

    #region ThrowIfNull

    [Test]
    public void ThrowIfNull_WithAValue_ReturnsTheValue()
    {
        var value = "text";

        Assert.That(value.ThrowIfNull(nameof(value)), Is.SameAs(value));
    }

    [Test]
    public void ThrowIfNull_WithNull_ThrowsAnArgumentNullExceptionWithTheParameterName()
    {
        string? value = null;

        var exception = Assert.Throws<ArgumentNullException>(() => value.ThrowIfNull("myParameter"));

        Assert.That(exception!.ParamName, Is.EqualTo("myParameter"));
    }

    [Test]
    public void ThrowIfNull_WithANullableValueType_ReturnsTheValue()
    {
        int? value = 5;

        Assert.That(value.ThrowIfNull(nameof(value)), Is.EqualTo(5));
    }

    #endregion ThrowIfNull

    #region ThrowIfGreaterThanOrEqualTo

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_LowerBoundIsLess_DoesNotThrow()
    {
        Assert.DoesNotThrow(() => 1.ThrowIfGreaterThanOrEqualTo(2, "lower", "upper"));
    }

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_BoundsAreEqual_Throws()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 2.ThrowIfGreaterThanOrEqualTo(2, "lower", "upper"));

        Assert.That(exception!.Message, Does.Contain("lower must be less than upper"));
    }

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_LowerBoundIsGreater_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => 3.ThrowIfGreaterThanOrEqualTo(2, "lower", "upper"));
    }

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_TypeIsNotComparable_Throws()
    {
        Assert.Throws<ArgumentException>(() => new NotComparable().ThrowIfGreaterThanOrEqualTo(new NotComparable(), "lower", "upper"));
    }

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_WithAComparer_UsesTheComparer()
    {
        var comparer = new DescendingComparer();

        Assert.DoesNotThrow(() => 5.ThrowIfGreaterThanOrEqualTo(1, comparer, "lower", "upper"));
        Assert.Throws<ArgumentOutOfRangeException>(() => 1.ThrowIfGreaterThanOrEqualTo(5, comparer, "lower", "upper"));
        Assert.Throws<ArgumentOutOfRangeException>(() => 3.ThrowIfGreaterThanOrEqualTo(3, comparer, "lower", "upper"));
    }

    #endregion ThrowIfGreaterThanOrEqualTo
}
