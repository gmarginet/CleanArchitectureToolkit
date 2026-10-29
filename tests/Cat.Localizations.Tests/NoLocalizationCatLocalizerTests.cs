using System.Globalization;
using Cat.Localizations.Abstractions;
using Cat.Localizations.Extensions;
using Cat.NUnit;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Localizations.Tests;

[TestFixture]
public class NoLocalizationCatLocalizerTests : UnitTestBase
{
    private ICatLocalizer Localizer { get; set; } = null!;

    private CultureInfo _originalCulture = null!;

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddCatNoLocalizationLocalizer();
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        Localizer = ServiceProvider.GetRequiredService<ICatLocalizer>();
    }

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

    [Test]
    public void Indexer_ReturnsTheKeyAsItIs()
    {
        Assert.That(Localizer["Hello"], Is.EqualTo("Hello"));
    }

    [Test]
    public void Indexer_WithAnEmptyKey_ReturnsAnEmptyString()
    {
        Assert.That(Localizer[""], Is.EqualTo(""));
    }

    [Test]
    public void Indexer_WithArguments_FillsInThePlaceholders()
    {
        Assert.That(Localizer["Hello {name}", "World"], Is.EqualTo("Hello World"));
    }

    [Test]
    public void Indexer_WithSeveralArguments_FillsThemInByPosition()
    {
        Assert.That(Localizer["{a} has {count} items", "Cart", 3], Is.EqualTo("Cart has 3 items"));
    }

    [Test]
    public void Indexer_WithAFormatSpecifier_AppliesIt()
    {
        Assert.That(Localizer["Price {price:F2}", 12.5m], Is.EqualTo("Price 12.50"));
    }

    [Test]
    public void Indexer_KeyWithoutPlaceholders_ReturnsTheKey()
    {
        Assert.That(Localizer["Plain text", "ignored"], Is.EqualTo("Plain text"));
    }

    [Test]
    public void AddCatNoLocalizationLocalizer_RegistersASingleton()
    {
        var first = ServiceProvider.GetRequiredService<ICatLocalizer>();
        var second = ServiceProvider.GetRequiredService<ICatLocalizer>();

        Assert.That(second, Is.SameAs(first));
    }
}
