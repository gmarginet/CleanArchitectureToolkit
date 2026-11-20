using Cat.EFCore.Entities.SqlServer;
using Cat.EFCore.Extensions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cat.EFCore.Tests;

public class TemporalModelTests
{
    private TemporalDbContext _context = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<TemporalDbContext>()
            .UseSqlServer("Server=.;Database=Temporal;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;
        _context = new TemporalDbContext(options);
    }

    [TearDown]
    public void TearDown() => _context?.Dispose();

    [Test]
    public void ConfigureCatTemporalEntity_MakesTheTableTemporal()
    {
        var entityType = _context.GetService<IDesignTimeModel>().Model.FindEntityType(typeof(TemporalEntity))!;

        Assert.That(entityType.IsTemporal(), Is.True);
        Assert.That(entityType.GetHistoryTableName(), Is.EqualTo("Temporal"));
        Assert.That(entityType.GetHistoryTableSchema(), Is.EqualTo("History"));
    }

    [Test]
    public void ConfigureCatTemporalEntity_CreatesAPeriodInTheScript()
    {
        var script = _context.Database.GenerateCreateScript();

        Assert.That(script, Does.Contain("[ValidFrom] datetime2 GENERATED ALWAYS AS ROW START"));
        Assert.That(script, Does.Contain("[ValidUntil] datetime2 GENERATED ALWAYS AS ROW END"));
        Assert.That(script, Does.Contain("PERIOD FOR SYSTEM_TIME"));
        Assert.That(script, Does.Contain("GENERATED ALWAYS AS ROW START"));
        Assert.That(script, Does.Contain("GENERATED ALWAYS AS ROW END"));
    }

    private class TemporalEntity : CatTemporalEntityBase
    {
        public string Name { get; set; } = string.Empty;
    }

    private class TemporalDbContext(DbContextOptions<TemporalDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ConfigureCatTemporalEntity<TemporalEntity>("Temporal", "dbo");
    }
}
