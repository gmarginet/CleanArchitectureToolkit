using Cat.EFCore.Entities;
using Cat.EFCore.Extensions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cat.EFCore.PostgreSQL.Tests;

public class ModelShapeTests
{
    private IEntityType _entityType = null!;
    private IEntityType _referenceEntityType = null!;
    private IEntityType _customSchemaEntityType = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<ShapeDbContext>()
            .UseNpgsql("Host=localhost;Database=shape;Username=postgres;Password=none")
            .Options;
        using var context = new ShapeDbContext(options);
        var model = context.GetService<IDesignTimeModel>().Model;
        _entityType = model.FindEntityType(typeof(ShapeEntity))!;
        _referenceEntityType = model.FindEntityType(typeof(ShapeReferenceEntity))!;
        _customSchemaEntityType = model.FindEntityType(typeof(ShapeOtherEntity))!;
    }

    [Test]
    public void ConfigureCatEntity_SetsTableAndSchemaWithPublicAsTheDefault()
    {
        Assert.That(_entityType.GetTableName(), Is.EqualTo("Shape"));
        Assert.That(_entityType.GetSchema(), Is.EqualTo("public"));
        Assert.That(_customSchemaEntityType.GetSchema(), Is.EqualTo("sales"));
    }

    [Test]
    public void ConfigureCatEntity_MakesIdThePrimaryKey()
    {
        var key = _entityType.FindPrimaryKey()!;

        Assert.That(key.Properties.Select(p => p.Name), Is.EqualTo(new[] { nameof(CatEntityBase.Id) }));
    }

    [Test]
    public void ConfigureCatEntity_MakesSequenceIdAGeneratedIdentityThatIsNeverWrittenAfterTheFirstSave()
    {
        var property = _entityType.FindProperty(nameof(CatEntityBase.SequenceId))!;

        Assert.That(property.GetValueGenerationStrategy(), Is.EqualTo(NpgsqlValueGenerationStrategy.IdentityAlwaysColumn));
        Assert.That(property.GetAfterSaveBehavior(), Is.EqualTo(PropertySaveBehavior.Ignore));
    }

    [Test]
    public void ConfigureCatEntity_AddsAUniqueIndexOnSequenceId()
    {
        var index = _entityType.GetIndexes().Single(i => i.Properties.Single().Name == nameof(CatEntityBase.SequenceId));

        Assert.That(index.IsUnique, Is.True);
    }

    [Test]
    public void ConfigureCatEntity_StoresTheGuidAsTheNativeUuidType()
    {
        var id = _entityType.FindProperty(nameof(CatEntityBase.Id))!;

        Assert.That(id.GetColumnType(), Is.EqualTo("uuid"));
    }

    [Test]
    public void ConfigureCatReferenceEntity_SetsTableSchemaKeyAndExcludesItFromMigrations()
    {
        Assert.That(_referenceEntityType.GetTableName(), Is.EqualTo("ShapeReference"));
        Assert.That(_referenceEntityType.GetSchema(), Is.EqualTo("identity"));
        Assert.That(_referenceEntityType.IsTableExcludedFromMigrations(), Is.True);
        Assert.That(_referenceEntityType.FindPrimaryKey()!.Properties.Single().Name, Is.EqualTo(nameof(CatReferenceEntityBase.Id)));
    }

    [Test]
    public void ForeignKeyToAReferenceEntity_PointsAtItsId()
    {
        var foreignKey = _entityType.GetForeignKeys().Single();

        Assert.That(foreignKey.PrincipalEntityType, Is.SameAs(_referenceEntityType));
        Assert.That(foreignKey.PrincipalKey.Properties.Single().Name, Is.EqualTo(nameof(CatReferenceEntityBase.Id)));
    }

    private class ShapeEntity : CatEntityBase
    {
        public Guid OwnerId { get; set; }

        public ShapeReferenceEntity? Owner { get; set; }
    }

    private class ShapeOtherEntity : CatEntityBase;

    private class ShapeReferenceEntity : CatReferenceEntityBase;

    private class ShapeDbContext(DbContextOptions<ShapeDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCatReferenceEntity<ShapeReferenceEntity>("ShapeReference", "identity");
            modelBuilder.ConfigureCatEntity<ShapeEntity>("Shape", e => e.HasOne(x => x.Owner).WithMany().HasForeignKey(x => x.OwnerId));
            modelBuilder.ConfigureCatEntity<ShapeOtherEntity>("ShapeOther", "sales");
        }
    }
}
