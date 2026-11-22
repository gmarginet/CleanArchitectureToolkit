using System.Globalization;
using Cat.Localizations.Abstractions;
using Cat.Localizations.EFCore;
using Cat.Localizations.EFCore.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Localizations.Tests;

public class Category : ICatTranslatable
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = "";
}

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>();
        modelBuilder.AddCatTranslations();
    }
}

[TestFixture]
public class TranslatorTests
{
    private CultureInfo _originalUICulture = null!;
    private SqliteConnection _connection = null!;
    private ServiceProvider _provider = null!;
    private IServiceScope _scope = null!;
    private TestDbContext _db = null!;
    private ICatTranslator _translator = null!;
    private readonly Guid _id = Guid.NewGuid();

    [SetUp]
    public async Task SetUp()
    {
        _originalUICulture = CultureInfo.CurrentUICulture;
        _connection = new SqliteConnection("DataSource=:memory:");
        await _connection.OpenAsync();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddDbContext<TestDbContext>(options => options.UseSqlite(_connection));
        services.AddCatLocalizations<TestDbContext>();
        _provider = services.BuildServiceProvider();
        _scope = _provider.CreateScope();
        _db = _scope.ServiceProvider.GetRequiredService<TestDbContext>();
        await _db.Database.EnsureCreatedAsync();
        _translator = _scope.ServiceProvider.GetRequiredService<ICatTranslator>();
    }

    [TearDown]
    public async Task TearDown()
    {
        CultureInfo.CurrentUICulture = _originalUICulture;
        await _db.DisposeAsync();
        _scope.Dispose();
        _provider.Dispose();
        _connection.Dispose();
    }

    private async Task SaveAsync(string culture, string text)
    {
        await _translator.SetTextAsync<Category>(_id, "Name", culture, text);
        await _db.SaveChangesAsync();
    }

    [Test]
    public async Task GetText_GivesTheTranslationInTheCurrentCulture()
    {
        await SaveAsync("nl", "Boeken");
        CultureInfo.CurrentUICulture = new CultureInfo("nl");

        Assert.That(await _translator.GetTextAsync<Category>(_id, "Name", "Books"), Is.EqualTo("Boeken"));
    }

    [Test]
    public async Task GetText_GivesTheDefaultTextWhenThereIsNoTranslation()
    {
        CultureInfo.CurrentUICulture = new CultureInfo("nl");

        Assert.That(await _translator.GetTextAsync<Category>(_id, "Name", "Books"), Is.EqualTo("Books"));
    }

    [Test]
    public async Task GetText_UsesTheParentCultureWhenTheSpecificOneIsMissing()
    {
        await SaveAsync("nl", "Boeken");
        CultureInfo.CurrentUICulture = new CultureInfo("nl-BE");

        Assert.That(await _translator.GetTextAsync<Category>(_id, "Name", "Books"), Is.EqualTo("Boeken"));
    }

    [Test]
    public async Task GetText_PrefersTheSpecificCultureOverItsParent()
    {
        await SaveAsync("nl", "Boeken");
        await SaveAsync("nl-BE", "Boeken (BE)");
        CultureInfo.CurrentUICulture = new CultureInfo("nl-BE");

        Assert.That(await _translator.GetTextAsync<Category>(_id, "Name", "Books"), Is.EqualTo("Boeken (BE)"));
    }

    [Test]
    public async Task GetText_GivesTheDefaultTextForTheInvariantCulture()
    {
        await SaveAsync("nl", "Boeken");
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

        Assert.That(await _translator.GetTextAsync<Category>(_id, "Name", "Books"), Is.EqualTo("Books"));
    }

    [Test]
    public async Task GetTexts_TranslatesWhatItCanAndKeepsTheDefaultForTheRest()
    {
        var other = Guid.NewGuid();
        await SaveAsync("nl", "Boeken");
        CultureInfo.CurrentUICulture = new CultureInfo("nl");

        var texts = await _translator.GetTextsAsync<Category>(
            new Dictionary<Guid, string> { [_id] = "Books", [other] = "Games" }, "Name");

        Assert.That(texts[_id], Is.EqualTo("Boeken"));
        Assert.That(texts[other], Is.EqualTo("Games"));
    }

    [Test]
    public async Task SetText_ChangesAnExistingTranslationInsteadOfAddingOne()
    {
        await SaveAsync("nl", "Boeken");
        await SaveAsync("nl", "Boekjes");

        var all = await _translator.GetTranslationsAsync<Category>(_id, "Name");

        Assert.That(all, Is.EqualTo(new Dictionary<string, string> { ["nl"] = "Boekjes" }));
    }

    [Test]
    public async Task SetText_WithAnEmptyTextRemovesTheTranslation()
    {
        await SaveAsync("nl", "Boeken");

        await _translator.SetTextAsync<Category>(_id, "Name", "nl", "  ");
        await _db.SaveChangesAsync();

        Assert.That(await _translator.GetTranslationsAsync<Category>(_id, "Name"), Is.Empty);
    }

    [Test]
    public async Task SetText_SavesNothingUntilTheCallerSaves()
    {
        await _translator.SetTextAsync<Category>(_id, "Name", "nl", "Boeken");

        await using var other = new TestDbContext(new DbContextOptionsBuilder<TestDbContext>().UseSqlite(_connection).Options);
        Assert.That(await other.Set<CatTranslation>().CountAsync(), Is.EqualTo(0));
    }
}
