using Cat.EFCore.Entities;
using Cat.EFCore.Entities.SqlServer;
using Cat.EFCore.Extensions;
using Cat.EFCore.Extensions.SqlServer;
using Cat.IntegrationTesting.SqlServer.NUnit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cat.EFCore.IntegrationTests;

public class WidgetStatus : CatReferenceEntityBase
{
    public string Code { get; set; } = "";
}

public class Widget : CatEntityBase
{
    public string Name { get; set; } = "";

    public Guid StatusId { get; set; }

    public WidgetStatus? Status { get; set; }
}

public class Gadget : CatTemporalEntityBase
{
    public string Name { get; set; } = "";
}

public class WidgetDbContext : DbContext
{
    public WidgetDbContext(DbContextOptions<WidgetDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureCatReferenceEntity<WidgetStatus>("WidgetStatus");
        modelBuilder.ConfigureCatEntity<Widget>("Widget", e =>
        {
            e.Property(x => x.Name).HasMaxLength(100);
            e.HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);
        });
        modelBuilder.ConfigureCatTemporalEntity<Gadget>("Gadget", e => e.Property(x => x.Name).HasMaxLength(100));
    }
}

/// <summary>
/// Runs the base entities of Cat.EFCore.Extensions.SqlServer on a real SQL Server, including the temporal tables.
/// The unit tests only check the shape of the model.
/// </summary>
[TestFixture]
public class BaseEntityIntegrationTests : SqlServerDatabaseTests
{
    private static readonly Guid ActiveId = Guid.Parse("11111111-1111-1111-1111-111111111111");

    private WidgetDbContext NewContext() =>
        new(new DbContextOptionsBuilder<WidgetDbContext>().UseSqlServer(ConnectionString).Options);

    [OneTimeSetUp]
    public async Task CreateSchema()
    {
        await using var context = NewContext();

        // A reference table is excluded from the migrations, so a developer creates it by hand, with the rows it holds.
        await context.Database.ExecuteSqlRawAsync("CREATE TABLE dbo.WidgetStatus (Id uniqueidentifier NOT NULL PRIMARY KEY NONCLUSTERED, Code nvarchar(50) NOT NULL)");
        await context.GetService<IRelationalDatabaseCreator>().CreateTablesAsync();
    }

    [SetUp]
    public async Task SetUp()
    {
        await using var context = NewContext();
        await context.Set<Widget>().ExecuteDeleteAsync();
        await context.Database.ExecuteSqlRawAsync("DELETE FROM dbo.WidgetStatus");
        await context.Database.ExecuteSqlAsync($"INSERT INTO dbo.WidgetStatus (Id, Code) VALUES ({ActiveId}, 'active')");
    }

    [Test]
    public async Task Save_LetsTheDatabaseFillTheSequenceId()
    {
        await using var context = NewContext();
        var first = new Widget { Name = "first", StatusId = ActiveId };
        var second = new Widget { Name = "second", StatusId = ActiveId };
        context.AddRange(first, second);

        await context.SaveChangesAsync();

        Assert.That(first.SequenceId, Is.GreaterThan(0));
        Assert.That(second.SequenceId, Is.GreaterThan(first.SequenceId));
    }

    [Test]
    public async Task Create_PutsTheClusteredIndexOnSequenceIdAndTheKeyOnId()
    {
        await using var context = NewContext();

        var indexes = await context.Database
            .SqlQueryRaw<string>(
                "SELECT CONVERT(nvarchar(400), i.name) + ':' + CONVERT(nvarchar(60), i.type_desc) + ':' + CONVERT(nvarchar(400), c.name) COLLATE DATABASE_DEFAULT AS Value FROM sys.indexes i " +
                "JOIN sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id " +
                "JOIN sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id " +
                "WHERE i.object_id = OBJECT_ID('dbo.Widget') AND ic.is_included_column = 0")
            .ToListAsync();

        Assert.That(indexes.Any(i => i.Contains("CLUSTERED:SequenceId") && !i.Contains("NONCLUSTERED")), Is.True, string.Join(", ", indexes));
        Assert.That(indexes.Any(i => i.StartsWith("PK_") && i.Contains("NONCLUSTERED:Id")), Is.True, string.Join(", ", indexes));
    }

    [Test]
    public async Task Save_NeverWritesTheSequenceIdAfterTheFirstSave()
    {
        int sequenceId;
        Guid id;
        await using (var context = NewContext())
        {
            var widget = new Widget { Name = "first", StatusId = ActiveId };
            context.Add(widget);
            await context.SaveChangesAsync();
            sequenceId = widget.SequenceId;
            id = widget.Id;
        }

        await using (var context = NewContext())
        {
            var widget = await context.Set<Widget>().FindByIdAsync(id);
            widget!.Name = "changed";
            widget.SequenceId = 999999;
            await context.SaveChangesAsync();
        }

        await using var readContext = NewContext();
        var saved = await readContext.Set<Widget>().FindByIdAsync(id);
        Assert.That(saved!.Name, Is.EqualTo("changed"));
        Assert.That(saved.SequenceId, Is.EqualTo(sequenceId));
    }

    [Test]
    public async Task Save_WithAnUnknownStatus_IsStoppedByTheForeignKey()
    {
        await using var context = NewContext();
        context.Add(new Widget { Name = "orphan", StatusId = Guid.NewGuid() });

        await Assert.ThrowsAsync<DbUpdateException>(() => context.SaveChangesAsync());
    }

    [Test]
    public async Task Lookups_FindTheEntityByIdAndBySequenceId()
    {
        Guid id;
        int sequenceId;
        await using (var context = NewContext())
        {
            var widget = new Widget { Name = "lookup", StatusId = ActiveId };
            context.Add(widget);
            await context.SaveChangesAsync();
            id = widget.Id;
            sequenceId = widget.SequenceId;
        }

        await using var readContext = NewContext();
        var byId = await readContext.Set<Widget>().FindByIdAsync(id);
        var bySequence = await NewContext().Set<Widget>().FindBySequenceIdAsync(sequenceId);

        Assert.That(byId!.Name, Is.EqualTo("lookup"));
        Assert.That(bySequence!.Id, Is.EqualTo(id));
        Assert.That(await readContext.Set<Widget>().FindByIdAsync(Guid.NewGuid()), Is.Null);
    }

    [Test]
    public async Task TemporalEntity_KeepsEveryVersionOfARowInTheHistoryTable()
    {
        Guid id;
        await using (var context = NewContext())
        {
            var gadget = new Gadget { Name = "v1" };
            context.Add(gadget);
            await context.SaveChangesAsync();
            id = gadget.Id;
        }

        foreach (var name in new[] { "v2", "v3" })
        {
            // SQL Server leaves out a version whose period has no length. A fast machine can save two versions in the same clock tick.
            await Task.Delay(200);
            await using var context = NewContext();
            var gadget = await context.Set<Gadget>().FindByIdAsync(id);
            gadget!.Name = name;
            await context.SaveChangesAsync();
        }

        await using var readContext = NewContext();
        var current = await readContext.Set<Gadget>().SingleAsync(g => g.Id == id);
        var versions = await readContext.Set<Gadget>().TemporalAll().Where(g => g.Id == id).Select(g => g.Name).ToListAsync();
        Assert.That(current.Name, Is.EqualTo("v3"));
        Assert.That(versions, Is.EquivalentTo(new[] { "v1", "v2", "v3" }));
    }

    [Test]
    public async Task TemporalEntity_PutsTheHistoryInTheHistorySchema()
    {
        await using var context = NewContext();

        var tables = await context.Database
            .SqlQueryRaw<string>("SELECT TABLE_SCHEMA + '.' + TABLE_NAME AS Value FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Gadget' ORDER BY 1")
            .ToListAsync();

        Assert.That(tables, Is.EqualTo(new[] { "dbo.Gadget", "History.Gadget" }));
    }
}
