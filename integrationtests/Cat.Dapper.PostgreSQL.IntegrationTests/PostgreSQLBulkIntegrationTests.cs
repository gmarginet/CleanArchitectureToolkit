using Cat.Dapper;
using Cat.Dapper.PostgreSQL;
using Cat.IntegrationTesting.PostgreSQL.NUnit;
using Npgsql;

namespace Cat.Dapper.PostgreSQL.IntegrationTests;

/// <summary>
/// Runs the bulk operations and the paging against a real PostgreSQL. The unit tests of Cat.Dapper only check the SQL text.
/// </summary>
[TestFixture]
public class PostgreSQLBulkIntegrationTests : PostgreSQLDatabaseTests
{
    private sealed class Order
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public int Quantity { get; set; }
    }

    private sealed class OrderLine
    {
        public int OrderNumber { get; set; }

        public int LineNumber { get; set; }

        public string Product { get; set; } = "";
    }

    private CatDbSession _session = null!;

    [SetUp]
    public async Task SetUp()
    {
        _session = new CatDbSession(new PostgreSQLConnectionFactory(ConnectionString));
        await ExecuteAsync(
            "DROP TABLE IF EXISTS \"Orders\"; DROP TABLE IF EXISTS \"OrderLines\"; " +
            "CREATE TABLE \"Orders\" (\"Id\" uuid NOT NULL PRIMARY KEY, \"Name\" varchar(50) NOT NULL, \"Quantity\" integer NOT NULL); " +
            "CREATE TABLE \"OrderLines\" (\"OrderNumber\" integer NOT NULL, \"LineNumber\" integer NOT NULL, \"Product\" varchar(50) NOT NULL, PRIMARY KEY (\"OrderNumber\", \"LineNumber\"));");
    }

    [TearDown]
    public void TearDown() => _session.Dispose();

    private static Order NewOrder(string name, int quantity) => new() { Id = Guid.NewGuid(), Name = name, Quantity = quantity };

    private async Task ExecuteAsync(string sql)
    {
        var connection = await _session.GetConnectionAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.Transaction = _session.Transaction;
        await command.ExecuteNonQueryAsync();
    }

    private async Task<T> ScalarAsync<T>(string sql)
    {
        var connection = await _session.GetConnectionAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.Transaction = _session.Transaction;
        return (T)Convert.ChangeType((await command.ExecuteScalarAsync())!, typeof(T));
    }

    private async Task<List<Order>> ReadOrdersAsync()
    {
        var connection = await _session.GetConnectionAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT \"Id\", \"Name\", \"Quantity\" FROM \"Orders\" ORDER BY \"Name\"";
        command.Transaction = _session.Transaction;
        await using var reader = await command.ExecuteReaderAsync();
        var rows = new List<Order>();
        while (await reader.ReadAsync())
        {
            rows.Add(new Order { Id = reader.GetGuid(0), Name = reader.GetString(1), Quantity = reader.GetInt32(2) });
        }

        return rows;
    }

    private Task<int> TemporaryTablesAsync() =>
        ScalarAsync<int>("SELECT COUNT(*) FROM pg_class WHERE relname LIKE 'catbulk\\_%' AND relpersistence = 't'");

    [Test]
    public async Task BulkInsert_CopiesTheRows()
    {
        var orders = new[] { NewOrder("a", 1), NewOrder("b", 2), NewOrder("c", 3) };

        var copied = await _session.BulkInsertAsync(orders, "Orders");

        Assert.That(copied, Is.EqualTo(3));
        var saved = await ReadOrdersAsync();
        Assert.That(saved.Select(o => (o.Name, o.Quantity)), Is.EqualTo(new[] { ("a", 1), ("b", 2), ("c", 3) }));
    }

    [Test]
    public async Task BulkInsert_ManyRows_CopiesEveryRow()
    {
        var orders = Enumerable.Range(0, 2500).Select(i => NewOrder("n" + i, i)).ToList();

        var copied = await _session.BulkInsertAsync(orders, "Orders");

        Assert.That(copied, Is.EqualTo(2500));
        Assert.That(await ScalarAsync<int>("SELECT COUNT(*) FROM \"Orders\""), Is.EqualTo(2500));
    }

    [Test]
    public async Task BulkUpdate_ChangesTheMatchingRowsAndOnlyTheGivenColumns()
    {
        var a = NewOrder("a", 1);
        var b = NewOrder("b", 2);
        var c = NewOrder("c", 3);
        await _session.BulkInsertAsync(new[] { a, b, c }, "Orders");

        var updated = await _session.BulkUpdateAsync(
            new[] { new Order { Id = a.Id, Name = "ignored", Quantity = 10 }, new Order { Id = b.Id, Name = "ignored", Quantity = 20 } },
            "Orders",
            new[] { "Id" },
            new[] { "Quantity" });

        Assert.That(updated, Is.EqualTo(2));
        var saved = (await ReadOrdersAsync()).ToDictionary(o => o.Id);
        Assert.That(saved[a.Id].Quantity, Is.EqualTo(10));
        Assert.That(saved[a.Id].Name, Is.EqualTo("a"));
        Assert.That(saved[b.Id].Quantity, Is.EqualTo(20));
        Assert.That(saved[c.Id].Quantity, Is.EqualTo(3));
        Assert.That(await TemporaryTablesAsync(), Is.Zero);
    }

    [Test]
    public async Task BulkDelete_WithACompositeKey_DeletesOnlyTheMatchingRows()
    {
        var lines = new[]
        {
            new OrderLine { OrderNumber = 1, LineNumber = 1, Product = "x" },
            new OrderLine { OrderNumber = 1, LineNumber = 2, Product = "y" },
            new OrderLine { OrderNumber = 2, LineNumber = 1, Product = "z" },
        };
        await _session.BulkInsertAsync(lines, "OrderLines");

        var deleted = await _session.BulkDeleteAsync(new[] { lines[0], lines[2] }, "OrderLines", new[] { "OrderNumber", "LineNumber" });

        Assert.That(deleted, Is.EqualTo(2));
        Assert.That(await ScalarAsync<string>("SELECT \"Product\" FROM \"OrderLines\""), Is.EqualTo("y"));
        Assert.That(await TemporaryTablesAsync(), Is.Zero);
    }

    [Test]
    public async Task BulkDelete_ByKeyValues_DeletesTheRowsWithThoseKeys()
    {
        var orders = new[] { NewOrder("a", 1), NewOrder("b", 2), NewOrder("c", 3) };
        await _session.BulkInsertAsync(orders, "Orders");

        var deleted = await _session.BulkDeleteAsync(new[] { orders[0].Id, orders[1].Id }, "Orders", "Id");

        Assert.That(deleted, Is.EqualTo(2));
        Assert.That((await ReadOrdersAsync()).Select(o => o.Name), Is.EqualTo(new[] { "c" }));
    }

    [Test]
    public async Task BulkMerge_UpdatesTheRowsThatExistAndInsertsTheOthers()
    {
        var existing = NewOrder("existing", 1);
        var untouched = NewOrder("untouched", 5);
        await _session.BulkInsertAsync(new[] { existing, untouched }, "Orders");

        var result = await _session.BulkMergeAsync(
            new[] { new Order { Id = existing.Id, Name = "changed", Quantity = 2 }, NewOrder("new", 3) },
            "Orders",
            new[] { "Id" });

        Assert.That(result.Inserted, Is.EqualTo(1));
        Assert.That(result.Updated, Is.EqualTo(1));
        var saved = (await ReadOrdersAsync()).ToDictionary(o => o.Name);
        Assert.That(saved.Keys, Is.EquivalentTo(new[] { "changed", "untouched", "new" }));
        Assert.That(saved["changed"].Quantity, Is.EqualTo(2));
        Assert.That(saved["untouched"].Quantity, Is.EqualTo(5));
        Assert.That(await TemporaryTablesAsync(), Is.Zero);
    }

    [Test]
    public async Task BulkOperations_OnARolledBackTransaction_LeaveNothing()
    {
        var existing = NewOrder("existing", 1);
        await _session.BulkInsertAsync(new[] { existing }, "Orders");

        var transaction = await _session.BeginTransactionAsync();
        await _session.BulkInsertAsync(new[] { NewOrder("inside", 2) }, "Orders");
        await _session.BulkUpdateAsync(new[] { new Order { Id = existing.Id, Name = "changed", Quantity = 9 } }, "Orders", new[] { "Id" });
        await _session.BulkDeleteAsync(new[] { existing.Id }, "Orders", "Id");
        await transaction.RollbackAsync();

        var saved = await ReadOrdersAsync();
        Assert.That(saved.Select(o => (o.Name, o.Quantity)), Is.EqualTo(new[] { ("existing", 1) }));
        Assert.That(await TemporaryTablesAsync(), Is.Zero);
    }

    [Test]
    public async Task BulkOperations_OnACommittedTransaction_KeepTheChanges()
    {
        var transaction = await _session.BeginTransactionAsync();
        await _session.BulkInsertAsync(new[] { NewOrder("a", 1), NewOrder("b", 2) }, "Orders");
        await transaction.CommitAsync();

        Assert.That(await ScalarAsync<int>("SELECT COUNT(*) FROM \"Orders\""), Is.EqualTo(2));
    }

    [Test]
    public async Task BulkInsert_WithADuplicateKey_Throws()
    {
        var order = NewOrder("a", 1);

        await Assert.ThrowsAsync<PostgresException>(() => _session.BulkInsertAsync(new[] { order, order }, "Orders"));
    }

    [Test]
    public async Task BulkUpdate_WithAFailingStatement_StillDropsTheTemporaryTable()
    {
        var order = NewOrder("a", 1);
        await _session.BulkInsertAsync(new[] { order }, "Orders");

        // The name column allows 50 characters, so the copy to the temporary table fails.
        await Assert.CatchAsync<NpgsqlException>(() => _session.BulkUpdateAsync(
            new[] { new Order { Id = order.Id, Name = new string('x', 100), Quantity = 1 } },
            "Orders",
            new[] { "Id" }));

        Assert.That(await TemporaryTablesAsync(), Is.Zero);
        Assert.That((await ReadOrdersAsync()).Single().Name, Is.EqualTo("a"));
    }

    [Test]
    public async Task QueryPaged_ReadsOnePageAndTheTotal()
    {
        await _session.BulkInsertAsync(Enumerable.Range(1, 25).Select(i => NewOrder("n" + i.ToString("00"), i)), "Orders");

        var page = await _session.QueryPagedAsync<Order>("SELECT \"Id\", \"Name\", \"Quantity\" FROM \"Orders\"", "\"Quantity\"", 2, 10);

        Assert.That(page.TotalItemCount, Is.EqualTo(25));
        Assert.That(page.TotalPages, Is.EqualTo(3));
        Assert.That(page.PageNumber, Is.EqualTo(2));
        Assert.That(page.List.Select(o => o.Quantity), Is.EqualTo(Enumerable.Range(11, 10)));
    }

    [Test]
    public async Task QueryPaged_LastPageHoldsTheRest_AndAFilterChangesTheTotal()
    {
        await _session.BulkInsertAsync(Enumerable.Range(1, 25).Select(i => NewOrder("n" + i.ToString("00"), i)), "Orders");

        var last = await _session.QueryPagedAsync<Order>("SELECT \"Id\", \"Name\", \"Quantity\" FROM \"Orders\"", "\"Quantity\"", 3, 10);
        var filtered = await _session.QueryPagedAsync<Order>(
            "SELECT \"Id\", \"Name\", \"Quantity\" FROM \"Orders\" WHERE \"Quantity\" > @Min", "\"Quantity\"", 1, 10, new { Min = 20 });

        Assert.That(last.List, Has.Count.EqualTo(5));
        Assert.That(filtered.TotalItemCount, Is.EqualTo(5));
        Assert.That(filtered.List.Select(o => o.Quantity), Is.EqualTo(Enumerable.Range(21, 5)));
    }
}
