using System.Reflection;
using Cat.EFCore.Entities;
using Cat.EFCore.Extensions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cat.EFCore.Tests;

public class ModelShapeTests
{
    private IEntityType _entityType = null!;
    private IEntityType _referenceEntityType = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<ShapeDbContext>()
            .UseSqlServer("Server=.;Database=Shape;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;
        using var context = new ShapeDbContext(options);
        var model = context.GetService<IDesignTimeModel>().Model;
        _entityType = model.FindEntityType(typeof(ShapeEntity))!;
        _referenceEntityType = model.FindEntityType(typeof(ShapeReferenceEntity))!;
    }

    [Test]
    public void ConfigureCatEntity_SetsTableAndSchema()
    {
        Assert.That(_entityType.GetTableName(), Is.EqualTo("Shape"));
        Assert.That(_entityType.GetSchema(), Is.EqualTo("dbo"));
    }

    [Test]
    public void ConfigureCatEntity_MakesIdTheNonClusteredPrimaryKey()
    {
        var key = _entityType.FindPrimaryKey()!;

        Assert.That(key.Properties.Select(p => p.Name), Is.EqualTo(new[] { nameof(CatEntityBase.Id) }));
        Assert.That(key.IsClustered(), Is.False);
    }

    [Test]
    public void ConfigureCatEntity_MakesSequenceIdAnIdentityColumn()
    {
        var property = _entityType.FindProperty(nameof(CatEntityBase.SequenceId))!;

        Assert.That(SqlServerPropertyExtensions.GetValueGenerationStrategy(property), Is.EqualTo(SqlServerValueGenerationStrategy.IdentityColumn));
        Assert.That(property.GetAfterSaveBehavior(), Is.EqualTo(PropertySaveBehavior.Ignore));
    }

    [Test]
    public void ConfigureCatEntity_AddsAUniqueClusteredIndexOnSequenceId()
    {
        var index = _entityType.GetIndexes().Single(i => i.Properties.Single().Name == nameof(CatEntityBase.SequenceId));

        Assert.That(index.IsUnique, Is.True);
        Assert.That(index.IsClustered(), Is.True);
    }

    [Test]
    public void ConfigureCatReferenceEntity_SetsTableSchemaAndExcludesItFromMigrations()
    {
        Assert.That(_referenceEntityType.GetTableName(), Is.EqualTo("ShapeReference"));
        Assert.That(_referenceEntityType.GetSchema(), Is.EqualTo("identity"));
        Assert.That(_referenceEntityType.IsTableExcludedFromMigrations(), Is.True);
    }

    [Test]
    public void ConfigureCatReferenceEntity_MakesIdTheNonClusteredPrimaryKey()
    {
        var key = _referenceEntityType.FindPrimaryKey()!;

        Assert.That(key.Properties.Select(p => p.Name), Is.EqualTo(new[] { nameof(CatReferenceEntityBase.Id) }));
        Assert.That(key.IsClustered(), Is.False);
    }

    [Test]
    public void NeutralProject_ReferencesNoProviderPackage()
    {
        var neutral = Assembly.Load(typeof(ModelBuilderExtensions).Assembly.GetReferencedAssemblies()
            .Single(a => a.Name == "Cat.EFCore.Extensions"));

        var providers = neutral.GetReferencedAssemblies()
            .Select(a => a.Name!)
            .Where(n => n.StartsWith("Microsoft.EntityFrameworkCore.", StringComparison.Ordinal) && n != "Microsoft.EntityFrameworkCore.Relational")
            .ToList();

        Assert.That(providers, Is.Empty);
    }

    private class ShapeEntity : CatEntityBase;

    private class ShapeReferenceEntity : CatReferenceEntityBase;

    private class ShapeDbContext(DbContextOptions<ShapeDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCatEntity<ShapeEntity>("Shape");
            modelBuilder.ConfigureCatReferenceEntity<ShapeReferenceEntity>("ShapeReference", "identity");
        }
    }
}
