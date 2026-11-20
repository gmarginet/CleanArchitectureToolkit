using Cat.EFCore.Entities;
using Cat.EFCore.Extensions;
using Cat.EFCore.Extensions.PostgreSQL;
using Cat.IntegrationTesting.PostgreSQL.NUnit;
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
    }
}

/// <summary>
/// Runs the base entities of Cat.EFCore.Extensions.PostgreSQL on a real PostgreSQL. The unit tests only check the shape of the model.
/// </summary>
[TestFixture]
public class BaseEntityIntegrationTests : PostgreSQLDatabaseTests
{
    private static readonly Guid ActiveId = Guid.Parse("11111111-1111-1111-1111-111111111111");

    private WidgetDbContext NewContext() =>
        new(new DbContextOptionsBuilder<WidgetDbContext>().UseNpgsql(ConnectionString).Options);

    [OneTimeSetUp]
    public async Task CreateSchema()
    {
        await using var context = NewContext();

        // A reference table is excluded from the migrations, so a developer creates it by hand, with the rows it holds.
        await context.Database.ExecuteSqlRawAsync("CREATE TABLE public.\"WidgetStatus\" (\"Id\" uuid NOT NULL PRIMARY KEY, \"Code\" text NOT NULL)");
        await context.GetService<IRelationalDatabaseCreator>().CreateTablesAsync();
    }

    [SetUp]
    public async Task SetUp()
    {
        await using var context = NewContext();
        await context.Set<Widget>().ExecuteDeleteAsync();
        await context.Set<WidgetStatus>().ExecuteDeleteAsync();
        context.Add(new WidgetStatus { Id = ActiveId, Code = "active" });
        await context.SaveChangesAsync();
    }

    [Test]
    public async Task Save_CreatesTheTableInThePublicSchema()
    {
        await using var context = NewContext();

        var tables = await context.Database
            .SqlQueryRaw<string>("SELECT table_schema || '.' || table_name AS \"Value\" FROM information_schema.tables WHERE table_name IN ('Widget', 'WidgetStatus') ORDER BY 1")
            .ToListAsync();

        Assert.That(tables, Is.EqualTo(new[] { "public.Widget", "public.WidgetStatus" }));
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
}
