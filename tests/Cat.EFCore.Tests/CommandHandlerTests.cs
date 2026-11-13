using Cat.Commands.Abstractions;
using Cat.EFCore.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.UnitTesting.Responses.NUnit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.Tests;

public class CommandHandlerTests
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
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
        _connection.Dispose();
    }

    [Test]
    public void Constructor_NullContext_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new AddItemHandler(null!));
        Assert.Throws<ArgumentNullException>(() => new AddItemWithResultHandler(null!));
    }

    [Test]
    public async Task Handler_ChangesDataThroughTheContext()
    {
        var response = await new AddItemHandler(_context).HandleAsync(new AddItemCommand("one"));

        Assert.That(response, CatIs.Succeeded);
        Assert.That(await _context.Items.CountAsync(), Is.EqualTo(1));
    }

    [Test]
    public async Task Handler_WithResult_ReturnsTheValue()
    {
        var response = await new AddItemWithResultHandler(_context).HandleAsync(new AddItemWithResultCommand("two"));

        Assert.That(response.Value, Is.EqualTo("two"));
        Assert.That(await _context.Items.CountAsync(), Is.EqualTo(1));
    }

    [Test]
    public async Task Handler_DecidesWhenToSave()
    {
        await new AddItemHandler(_context, save: false).HandleAsync(new AddItemCommand("three"));

        Assert.That(_context.ChangeTracker.Entries(), Has.Exactly(1).Items);
        _context.ChangeTracker.Clear();
        Assert.That(await _context.Items.CountAsync(), Is.EqualTo(0));
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

    private record AddItemCommand(string Name) : ICatCommand;

    private record AddItemWithResultCommand(string Name) : ICatCommand<string>;

    private class AddItemHandler(TestDbContext dbContext, bool save = true)
        : CatEfCommandHandlerBase<TestDbContext, AddItemCommand>(dbContext)
    {
        public override async Task<ICatResponse> HandleAsync(AddItemCommand command, CancellationToken cancellationToken = default)
        {
            DbContext.Items.Add(new Item { Name = command.Name });
            if (save) await DbContext.SaveChangesAsync(cancellationToken);
            return CatResponse.Ok();
        }
    }

    private class AddItemWithResultHandler(TestDbContext dbContext)
        : CatEfCommandHandlerBase<TestDbContext, AddItemWithResultCommand, string>(dbContext)
    {
        public override async Task<ICatResponse<string>> HandleAsync(AddItemWithResultCommand command, CancellationToken cancellationToken = default)
        {
            DbContext.Items.Add(new Item { Name = command.Name });
            await DbContext.SaveChangesAsync(cancellationToken);
            return CatResponse.Ok(command.Name);
        }
    }
}
