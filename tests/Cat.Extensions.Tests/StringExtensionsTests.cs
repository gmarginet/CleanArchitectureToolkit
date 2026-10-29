using System.Globalization;
using System.Text.RegularExpressions;
using Cat.String.Extensions;

namespace Cat.Extensions.Tests;

[TestFixture]
public class StringExtensionsTests
{
    private CultureInfo _originalCulture = null!;

    [SetUp]
    public void SetUp()
    {
        _originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
    }

    [TearDown]
    public void TearDown()
    {
        CultureInfo.CurrentCulture = _originalCulture;
    }

    #region NamedFormat

    [Test]
    public void NamedFormat_OnePlaceholder_FillsItIn()
    {
        Assert.That("Hello {name}!".NamedFormat("World"), Is.EqualTo("Hello World!"));
    }

    [Test]
    public void NamedFormat_SeveralPlaceholders_AreFilledInByPosition()
    {
        Assert.That("{first} and {second} and {third}".NamedFormat(1, "two", 3.5), Is.EqualTo("1 and two and 3.5"));
    }

    [Test]
    public void NamedFormat_TheNamesDoNotMatter_OnlyTheOrder()
    {
        Assert.That("{a} {b}".NamedFormat("x", "y"), Is.EqualTo("x y"));
        Assert.That("{b} {a}".NamedFormat("x", "y"), Is.EqualTo("x y"));
    }

    [Test]
    public void NamedFormat_WithAFormatSpecifier_AppliesIt()
    {
        Assert.That("Price: {price:F2}".NamedFormat(12.5m), Is.EqualTo("Price: 12.50"));
    }

    [Test]
    public void NamedFormat_WithAnAlignment_AppliesIt()
    {
        Assert.That("[{name,6}]".NamedFormat("ab"), Is.EqualTo("[    ab]"));
    }

    [Test]
    public void NamedFormat_WithoutPlaceholders_ReturnsTheTextAsItIs()
    {
        Assert.That("plain text".NamedFormat(), Is.EqualTo("plain text"));
    }

    [Test]
    public void NamedFormat_EmptyText_ReturnsEmptyText()
    {
        Assert.That("".NamedFormat(), Is.EqualTo(""));
    }

    [Test]
    public void NamedFormat_PlaceholderAtTheStartAndAtTheEnd_Works()
    {
        Assert.That("{a}-{b}".NamedFormat("x", "y"), Is.EqualTo("x-y"));
    }

    [Test]
    public void NamedFormat_ANullArgument_BecomesAnEmptyString()
    {
        Assert.That("value: {v}".NamedFormat(new object?[] { null }), Is.EqualTo("value: "));
    }

    [Test]
    public void NamedFormat_EscapedBraces_AreKeptAsSingleBraces()
    {
        Assert.That("{{literal}} {x}".NamedFormat(5), Is.EqualTo("{literal} 5"));
    }

    #endregion NamedFormat

    #region CreateRegex

    [Test]
    public void CreateRegex_ValidPattern_MatchesText()
    {
        var regex = @"^\d{4}$".CreateRegex();

        Assert.That(regex.IsMatch("2024"), Is.True);
        Assert.That(regex.IsMatch("20245"), Is.False);
    }

    [Test]
    public void CreateRegex_AppliesTheOptions()
    {
        var regex = "^john$".CreateRegex(RegexOptions.IgnoreCase);

        Assert.That(regex.Options, Is.EqualTo(RegexOptions.IgnoreCase));
        Assert.That(regex.IsMatch("JOHN"), Is.True);
    }

    [Test]
    public void CreateRegex_SetsAMatchTimeout()
    {
        var regex = "a".CreateRegex();

        Assert.That(regex.MatchTimeout, Is.EqualTo(TimeSpan.FromSeconds(2)));
    }

    [Test]
    public void CreateRegex_InvalidPattern_ThrowsAnArgumentExceptionWithThePattern()
    {
        var exception = Assert.Throws<ArgumentException>(() => "(unclosed".CreateRegex());

        Assert.That(exception!.Message, Does.Contain("Invalid regex expression: (unclosed"));
        Assert.That(exception.InnerException, Is.InstanceOf<ArgumentException>());
    }

    #endregion CreateRegex
}
