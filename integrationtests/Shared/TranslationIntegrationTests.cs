using System.Globalization;
using Cat.Localizations.Abstractions;
using Cat.Localizations.EFCore;
using Cat.Localizations.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.EFCore.IntegrationTests;

public class TranslatedCategory : ICatTranslatable
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = "";
}

public class TranslationDbContext : DbContext
{
    public TranslationDbContext(DbContextOptions<TranslationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TranslatedCategory>().Property(x => x.Name).HasMaxLength(100);
        modelBuilder.AddCatTranslations();
    }
}

/// <summary>
/// The tests of the translation table of Cat.Localizations.EFCore. Both database projects compile this file, so the same
/// tests run on SQL Server and on PostgreSQL. A project adds the other part of this class: the base class with its database, and the provider.
/// </summary>
[TestFixture]
public partial class TranslationIntegrationTests
{
    private static bool _created;
    private CultureInfo _originalUICulture = null!;
    private ServiceProvider _provider = null!;
    private IServiceScope _scope = null!;
    private TranslationDbContext _db = null!;
    private ICatTranslator _translator = null!;
    private Guid _id;

    [SetUp]
    public async Task SetUp()
    {
        _originalUICulture = CultureInfo.CurrentUICulture;
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddDbContext<TranslationDbContext>(options => UseDatabase(options, ConnectionString));
        services.AddCatLocalizations<TranslationDbContext>();
        _provider = services.BuildServiceProvider();
        _scope = _provider.CreateScope();
        _db = _scope.ServiceProvider.GetRequiredService<TranslationDbContext>();
        if (!_created)
        {
            await _db.GetService<IRelationalDatabaseCreator>().CreateTablesAsync();
            _created = true;
        }

        await _db.Set<CatTranslation>().ExecuteDeleteAsync();
        _translator = _scope.ServiceProvider.GetRequiredService<ICatTranslator>();
        _id = Guid.NewGuid();
    }

    [TearDown]
    public async Task TearDown()
    {
        CultureInfo.CurrentUICulture = _originalUICulture;
        await _db.DisposeAsync();
        _scope.Dispose();
        _provider.Dispose();
    }

    private async Task SaveAsync(string culture, string text)
    {
        await _translator.SetTextAsync<TranslatedCategory>(_id, "Name", culture, text);
        await _db.SaveChangesAsync();
    }

    [Test]
    public async Task Save_AndRead_RoundTripsATranslationInTheDatabase()
    {
        await SaveAsync("nl", "Boeken");
        CultureInfo.CurrentUICulture = new CultureInfo("nl");

        var text = await _translator.GetTextAsync<TranslatedCategory>(_id, "Name", "Books");

        Assert.That(text, Is.EqualTo("Boeken"));
    }

    [Test]
    public async Task Read_FallsBackToTheParentCultureAndThenToTheDefaultText()
    {
        await SaveAsync("nl", "Boeken");

        CultureInfo.CurrentUICulture = new CultureInfo("nl-BE");
        Assert.That(await _translator.GetTextAsync<TranslatedCategory>(_id, "Name", "Books"), Is.EqualTo("Boeken"));

        CultureInfo.CurrentUICulture = new CultureInfo("fr");
        Assert.That(await _translator.GetTextAsync<TranslatedCategory>(_id, "Name", "Books"), Is.EqualTo("Books"));
    }

    [Test]
    public async Task ReadMany_UsesOneCallAndKeepsDefaultsForMissingTranslations()
    {
        var other = Guid.NewGuid();
        await SaveAsync("nl", "Boeken");
        CultureInfo.CurrentUICulture = new CultureInfo("nl");

        var texts = await _translator.GetTextsAsync<TranslatedCategory>(
            new Dictionary<Guid, string> { [_id] = "Books", [other] = "Games" }, "Name");

        Assert.That(texts[_id], Is.EqualTo("Boeken"));
        Assert.That(texts[other], Is.EqualTo("Games"));
    }

    [Test]
    public async Task Save_TheSameTranslationTwice_ChangesItAndKeepsOneRow()
    {
        await SaveAsync("nl", "Boeken");
        await SaveAsync("nl", "Boekjes");

        Assert.That(await _db.Set<CatTranslation>().CountAsync(x => x.EntityId == _id), Is.EqualTo(1));
        Assert.That((await _translator.GetTranslationsAsync<TranslatedCategory>(_id, "Name"))["nl"], Is.EqualTo("Boekjes"));
    }

    [Test]
    public async Task Save_TwoRowsForTheSameKey_IsStoppedByTheUniqueIndex()
    {
        _db.Add(new CatTranslation { EntityType = nameof(TranslatedCategory), EntityId = _id, Field = "Name", Culture = "nl", Text = "a" });
        _db.Add(new CatTranslation { EntityType = nameof(TranslatedCategory), EntityId = _id, Field = "Name", Culture = "nl", Text = "b" });

        await Assert.ThatAsync(() => _db.SaveChangesAsync(), Throws.TypeOf<DbUpdateException>());
    }

    [Test]
    public async Task Remove_WithAnEmptyText_DeletesTheRow()
    {
        await SaveAsync("nl", "Boeken");

        await _translator.SetTextAsync<TranslatedCategory>(_id, "Name", "nl", null);
        await _db.SaveChangesAsync();

        Assert.That(await _translator.GetTranslationsAsync<TranslatedCategory>(_id, "Name"), Is.Empty);
    }
}
