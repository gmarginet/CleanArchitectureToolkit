using Cat.EFCore.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.Tests;

public class QueryHandlerTests
{
    private SqliteConnection _connection = null!;
    private TestDbContext _context = null!;

    [SetUp]
    public void SetUp()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        _context = new TestDbContext(new DbContextOptionsBuilder<TestDbContext>().UseSqlite(_connection).Options);
        _context.Database.EnsureCreated();
        for (var i = 1; i <= 25; i++) _context.Items.Add(new Item { Id = i, Name = $"Item {i:00}" });
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
    public async Task ToPagedListAsync_ReturnsTheRequestedPageAndTheTotals()
    {
        var page = await _context.Items.OrderBy(x => x.Id).ToPagedListAsync(2, 10);

        Assert.That(page.List.Select(x => x.Id), Is.EqualTo(Enumerable.Range(11, 10)));
        Assert.That(page.PageNumber, Is.EqualTo(2));
        Assert.That(page.PageSize, Is.EqualTo(10));
        Assert.That(page.TotalItemCount, Is.EqualTo(25));
        Assert.That(page.TotalPages, Is.EqualTo(3));
    }

    [Test]
    public async Task ToPagedListAsync_LastPageHoldsTheRest()
    {
        var page = await _context.Items.OrderBy(x => x.Id).ToPagedListAsync(3, 10);

        Assert.That(page.List, Has.Count.EqualTo(5));
    }

    [Test]
    public async Task ToPagedListAsync_PageBeyondTheEnd_IsEmptyWithTheTotal()
    {
        var page = await _context.Items.OrderBy(x => x.Id).ToPagedListAsync(9, 10);

        Assert.That(page.List, Is.Empty);
        Assert.That(page.TotalItemCount, Is.EqualTo(25));
    }

    [Test]
    public async Task ToPagedListAsync_HugePageNumber_IsEmptyAndDoesNotOverflow()
    {
        var page = await _context.Items.OrderBy(x => x.Id).ToPagedListAsync(int.MaxValue, 100);

        Assert.That(page.List, Is.Empty);
        Assert.That(page.TotalItemCount, Is.EqualTo(25));
    }

    [TestCase(0, 10)]
    [TestCase(1, 0)]
    public async Task ToPagedListAsync_InvalidNumbers_Throw(int pageNumber, int pageSize)
    {
        await Assert.ThatAsync(
            () => _context.Items.ToPagedListAsync(pageNumber, pageSize),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public async Task Handler_ReadsWithoutTrackingByDefault()
    {
        var handler = new ItemListHandler(_context);

        var response = await handler.HandleAsync(new ItemListQuery());

        Assert.That(response.Value, Has.Count.EqualTo(25));
        Assert.That(_context.ChangeTracker.Entries(), Is.Empty);
    }

    [Test]
    public async Task Handler_CanSwitchTrackingOn()
    {
        var handler = new TrackingItemListHandler(_context);

        await handler.HandleAsync(new ItemListQuery());

        Assert.That(_context.ChangeTracker.Entries(), Has.Exactly(25).Items);
    }

    private class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    private class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
    {
        public DbSet<Item> Items => Set<Item>();
    }

    private class ItemListQuery : ICatQuery<IList<Item>>;

    private class ItemListHandler(TestDbContext dbContext)
        : CatEfQueryHandlerBase<TestDbContext, ItemListQuery, IList<Item>>(dbContext)
    {
        public override async Task<ICatResponse<IList<Item>>> HandleAsync(ItemListQuery query, CancellationToken cancellationToken = default)
        {
            var items = await Set<Item>().OrderBy(x => x.Id).ToListAsync(cancellationToken);
            return CatResponse.Ok<IList<Item>>(items);
        }
    }

    private class TrackingItemListHandler(TestDbContext dbContext) : ItemListHandler(dbContext)
    {
        protected override bool TrackChanges => true;
    }
}
