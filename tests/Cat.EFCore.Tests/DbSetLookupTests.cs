using Cat.EFCore.Entities;
using Cat.EFCore.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.Tests;

public class DbSetLookupTests
{
    private SqliteConnection _connection = null!;
    private LookupDbContext _context = null!;
    private Guid _idKeyed;
    private Guid _sequenceKeyed;

    [SetUp]
    public void SetUp()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        var options = new DbContextOptionsBuilder<LookupDbContext>().UseSqlite(_connection).Options;
        _context = new LookupDbContext(options);
        _context.Database.EnsureCreated();

        var first = new IdKeyedEntity { SequenceId = 11 };
        var second = new SequenceKeyedEntity { SequenceId = 22 };
        _idKeyed = first.Id;
        _sequenceKeyed = second.Id;
        _context.Add(first);
        _context.Add(second);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
        _connection.Dispose();
    }

    [Test]
    public async Task FindByIdAsync_IdIsTheKey_FindsTheEntityAndTracksIt()
    {
        var found = await _context.IdKeyed.FindByIdAsync(_idKeyed);

        Assert.That(found, Is.Not.Null);
        Assert.That(found!.SequenceId, Is.EqualTo(11));
        Assert.That(_context.ChangeTracker.Entries<IdKeyedEntity>().Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task FindBySequenceIdAsync_IdIsTheKey_QueriesTheDatabase()
    {
        var found = await _context.IdKeyed.FindBySequenceIdAsync(11);

        Assert.That(found?.Id, Is.EqualTo(_idKeyed));
    }

    [Test]
    public async Task FindBySequenceIdAsync_SequenceIdIsTheKey_FindsTheEntity()
    {
        var found = await _context.SequenceKeyed.FindBySequenceIdAsync(22);

        Assert.That(found?.Id, Is.EqualTo(_sequenceKeyed));
    }

    [Test]
    public async Task FindByIdAsync_SequenceIdIsTheKey_QueriesTheDatabase()
    {
        var found = await _context.SequenceKeyed.FindByIdAsync(_sequenceKeyed);

        Assert.That(found?.SequenceId, Is.EqualTo(22));
    }

    [Test]
    public async Task Find_NoMatch_ReturnsNull()
    {
        Assert.That(await _context.IdKeyed.FindByIdAsync(Guid.NewGuid()), Is.Null);
        Assert.That(await _context.IdKeyed.FindBySequenceIdAsync(999), Is.Null);
        Assert.That(await _context.SequenceKeyed.FindByIdAsync(Guid.NewGuid()), Is.Null);
        Assert.That(await _context.SequenceKeyed.FindBySequenceIdAsync(999), Is.Null);
    }

    [Test]
    public async Task FindBySequenceIdAsync_TheEntityIsAlreadyTracked_ReturnsTheTrackedInstanceWithoutAQuery()
    {
        var tracked = await _context.IdKeyed.FindByIdAsync(_idKeyed);
        await _connection.CloseAsync();

        var found = await _context.IdKeyed.FindBySequenceIdAsync(11);

        Assert.That(found, Is.SameAs(tracked));
    }

    [Test]
    public async Task FindByIdAsync_TheEntityIsDeleted_ReturnsNull()
    {
        var tracked = (await _context.SequenceKeyed.FindByIdAsync(_sequenceKeyed))!;
        _context.SequenceKeyed.Remove(tracked);

        Assert.That(await _context.SequenceKeyed.FindByIdAsync(_sequenceKeyed), Is.Null);
    }

    [Test]
    public void NewEntity_GetsATimeOrderedGuidOfVersion7()
    {
        var ids = Enumerable.Range(0, 200).Select(_ => new IdKeyedEntity().Id).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(ids.Distinct().Count(), Is.EqualTo(200));
            Assert.That(ids.All(id => id.ToString()[14] == '7'), Is.True);
            // The string form of a version 7 GUID sorts in creation order.
            Assert.That(ids.Select(id => id.ToString()), Is.Ordered);
        });
    }

    private class IdKeyedEntity : CatEntityBase;

    private class SequenceKeyedEntity : CatEntityBase;

    private class LookupDbContext(DbContextOptions<LookupDbContext> options) : DbContext(options)
    {
        public DbSet<IdKeyedEntity> IdKeyed => Set<IdKeyedEntity>();

        public DbSet<SequenceKeyedEntity> SequenceKeyed => Set<SequenceKeyedEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdKeyedEntity>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.SequenceId).ValueGeneratedNever();
            });

            // The shape that was decided for MySQL: the sequence number is the key and the id an alternate key.
            modelBuilder.Entity<SequenceKeyedEntity>(e =>
            {
                e.HasKey(x => x.SequenceId);
                e.HasAlternateKey(x => x.Id);
                e.Property(x => x.SequenceId).ValueGeneratedNever();
            });
        }
    }
}
