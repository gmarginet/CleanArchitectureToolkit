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

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_ValueIsLess_ReturnsTheValue()
    {
        Assert.That(1.ThrowIfGreaterThanOrEqualTo(2, "value", "limit"), Is.EqualTo(1));
    }

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_ValueIsTooHigh_ReportsTheValueNameAndActualValue()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 3.ThrowIfGreaterThanOrEqualTo(2, "value", "limit"));

        Assert.That(exception!.ParamName, Is.EqualTo("value"));
        Assert.That(exception.ActualValue, Is.EqualTo(3));
        Assert.That(exception.Message, Does.Contain("value must be less than limit"));
    }

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_WithAComparer_ReturnsTheValue()
    {
        Assert.That(5.ThrowIfGreaterThanOrEqualTo(1, new DescendingComparer(), "value", "limit"), Is.EqualTo(5));
    }

    [Test]
    public void ThrowIfGreaterThanOrEqualTo_WithAComparer_ReportsTheValueName()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 1.ThrowIfGreaterThanOrEqualTo(5, new DescendingComparer(), "value", "limit"));

        Assert.That(exception!.ParamName, Is.EqualTo("value"));
        Assert.That(exception.Message, Does.Contain("value must be less than limit"));
    }

    #endregion ThrowIfGreaterThanOrEqualTo

    #region ThrowIfLessThan

    [TestCase(5)]
    [TestCase(6)]
    public void ThrowIfLessThan_ValueIsAtLeastTheMinimum_ReturnsTheValue(int value)
    {
        Assert.That(value.ThrowIfLessThan(5, "myParameter"), Is.EqualTo(value));
    }

    [Test]
    public void ThrowIfLessThan_ValueIsBelowTheMinimum_ReportsTheParameterAndActualValue()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 4.ThrowIfLessThan(5, "myParameter"));

        Assert.That(exception!.ParamName, Is.EqualTo("myParameter"));
        Assert.That(exception.ActualValue, Is.EqualTo(4));
        Assert.That(exception.Message, Does.Contain("myParameter must be 5 or higher"));
    }

    [Test]
    public void ThrowIfLessThan_TypeIsNotComparable_Throws()
    {
        Assert.Throws<ArgumentException>(() => new NotComparable().ThrowIfLessThan(new NotComparable(), "myParameter"));
    }

    [Test]
    public void ThrowIfLessThan_WithAComparer_UsesTheComparer()
    {
        var comparer = new DescendingComparer();

        Assert.That(1.ThrowIfLessThan(5, comparer, "myParameter"), Is.EqualTo(1));
        Assert.That(5.ThrowIfLessThan(5, comparer, "myParameter"), Is.EqualTo(5));
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 9.ThrowIfLessThan(5, comparer, "myParameter"));
        Assert.That(exception!.ParamName, Is.EqualTo("myParameter"));
    }

    #endregion ThrowIfLessThan

    #region ThrowIfLessThanOrEqualTo

    [Test]
    public void ThrowIfLessThanOrEqualTo_ValueIsAboveTheLimit_ReturnsTheValue()
    {
        Assert.That(6.ThrowIfLessThanOrEqualTo(5, "myParameter"), Is.EqualTo(6));
    }

    [TestCase(5)]
    [TestCase(4)]
    public void ThrowIfLessThanOrEqualTo_ValueIsAtOrBelowTheLimit_ReportsTheParameterAndActualValue(int value)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => value.ThrowIfLessThanOrEqualTo(5, "myParameter"));

        Assert.That(exception!.ParamName, Is.EqualTo("myParameter"));
        Assert.That(exception.ActualValue, Is.EqualTo(value));
        Assert.That(exception.Message, Does.Contain("myParameter must be higher than 5"));
    }

    [Test]
    public void ThrowIfLessThanOrEqualTo_TypeIsNotComparable_Throws()
    {
        Assert.Throws<ArgumentException>(() => new NotComparable().ThrowIfLessThanOrEqualTo(new NotComparable(), "myParameter"));
    }

    [Test]
    public void ThrowIfLessThanOrEqualTo_WithAComparer_UsesTheComparer()
    {
        var comparer = new DescendingComparer();

        Assert.That(1.ThrowIfLessThanOrEqualTo(5, comparer, "myParameter"), Is.EqualTo(1));
        Assert.Throws<ArgumentOutOfRangeException>(() => 5.ThrowIfLessThanOrEqualTo(5, comparer, "myParameter"));
        Assert.Throws<ArgumentOutOfRangeException>(() => 9.ThrowIfLessThanOrEqualTo(5, comparer, "myParameter"));
    }

    #endregion ThrowIfLessThanOrEqualTo

    #region ThrowIfGreaterThan

    [TestCase(5)]
    [TestCase(4)]
    public void ThrowIfGreaterThan_ValueIsAtMostTheMaximum_ReturnsTheValue(int value)
    {
        Assert.That(value.ThrowIfGreaterThan(5, "myParameter"), Is.EqualTo(value));
    }

    [Test]
    public void ThrowIfGreaterThan_ValueIsAboveTheMaximum_ReportsTheParameterAndActualValue()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 6.ThrowIfGreaterThan(5, "myParameter"));

        Assert.That(exception!.ParamName, Is.EqualTo("myParameter"));
        Assert.That(exception.ActualValue, Is.EqualTo(6));
        Assert.That(exception.Message, Does.Contain("myParameter must be 5 or lower"));
    }

    [Test]
    public void ThrowIfGreaterThan_TypeIsNotComparable_Throws()
    {
        Assert.Throws<ArgumentException>(() => new NotComparable().ThrowIfGreaterThan(new NotComparable(), "myParameter"));
    }

    [Test]
    public void ThrowIfGreaterThan_WithAComparer_UsesTheComparer()
    {
        var comparer = new DescendingComparer();

        Assert.That(9.ThrowIfGreaterThan(5, comparer, "myParameter"), Is.EqualTo(9));
        Assert.That(5.ThrowIfGreaterThan(5, comparer, "myParameter"), Is.EqualTo(5));
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 1.ThrowIfGreaterThan(5, comparer, "myParameter"));
        Assert.That(exception!.ParamName, Is.EqualTo("myParameter"));
    }

    #endregion ThrowIfGreaterThan
}
