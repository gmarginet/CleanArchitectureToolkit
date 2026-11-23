using System.Globalization;
using Cat.Localizations.Abstractions;
using Cat.Localizations.EFCore.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Localizations.Tests;

/// <summary>
/// The example of the chapter "Tests" in the module readme. A saved text comes back in its culture, and a culture without a text gets the default.
/// </summary>
[TestFixture]
public class ReadmeExampleTests
{
    [Test]
    public async Task GetText_ShouldGiveTheTranslationAndTheDefaultForAMissingCulture()
    {
        var originalCulture = CultureInfo.CurrentUICulture;
        try
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            await connection.OpenAsync();

            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<TestDbContext>(options => options.UseSqlite(connection));
            services.AddCatLocalizations<TestDbContext>();
            var provider = services.BuildServiceProvider();

            var scope = provider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TestDbContext>();
            await db.Database.EnsureCreatedAsync();
            var translator = scope.ServiceProvider.GetRequiredService<ICatTranslator>();
            var id = Guid.NewGuid();

            await translator.SetTextAsync<Category>(id, "Name", "nl", "Boeken");
            await db.SaveChangesAsync();
            CultureInfo.CurrentUICulture = new CultureInfo("nl");
            var dutch = await translator.GetTextAsync<Category>(id, "Name", "Books");
            CultureInfo.CurrentUICulture = new CultureInfo("fr");
            var french = await translator.GetTextAsync<Category>(id, "Name", "Books");

            Assert.That(dutch, Is.EqualTo("Boeken"));
            Assert.That(french, Is.EqualTo("Books"));

            await db.DisposeAsync();
            scope.Dispose();
            await provider.DisposeAsync();
            await connection.DisposeAsync();
        }
        finally
        {
            CultureInfo.CurrentUICulture = originalCulture;
        }
    }
}
