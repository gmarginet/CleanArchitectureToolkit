using System.Data.Common;
using Cat.Dapper;
using Cat.Dapper.SqlServer;
using Cat.IntegrationTesting.SqlServer.NUnit;
using Microsoft.Data.SqlClient;

namespace Cat.Dapper.SqlServer.IntegrationTests;

/// <summary>
/// Runs the bulk operations against a real SQL Server. The unit tests of Cat.Dapper only check the SQL text.
/// </summary>
[TestFixture]
public class SqlServerBulkIntegrationTests : SqlServerDatabaseTests
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
        _session = new CatDbSession(new SqlServerConnectionFactory(ConnectionString));
        await ExecuteAsync(
            "DROP TABLE IF EXISTS dbo.Orders; DROP TABLE IF EXISTS dbo.OrderLines; " +
            "CREATE TABLE dbo.Orders (Id uniqueidentifier NOT NULL PRIMARY KEY, Name nvarchar(50) NOT NULL, Quantity int NOT NULL); " +
            "CREATE TABLE dbo.OrderLines (OrderNumber int NOT NULL, LineNumber int NOT NULL, Product nvarchar(50) NOT NULL, PRIMARY KEY (OrderNumber, LineNumber));");
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
        command.CommandText = "SELECT Id, Name, Quantity FROM dbo.Orders ORDER BY Name";
        command.Transaction = _session.Transaction;
        await using DbDataReader reader = await command.ExecuteReaderAsync();
        var rows = new List<Order>();
        while (await reader.ReadAsync())
        {
            rows.Add(new Order { Id = reader.GetGuid(0), Name = reader.GetString(1), Quantity = reader.GetInt32(2) });
        }

        return rows;
    }

    private Task<int> TemporaryTablesAsync() =>
        ScalarAsync<int>("SELECT COUNT(*) FROM tempdb.sys.tables WHERE name LIKE '#CatBulk[_]%'");

    [Test]
    public async Task BulkInsert_CopiesTheRows()
    {
        var orders = new[] { NewOrder("a", 1), NewOrder("b", 2), NewOrder("c", 3) };

        var copied = await _session.BulkInsertAsync(orders, "dbo.Orders");

        Assert.That(copied, Is.EqualTo(3));
        var saved = await ReadOrdersAsync();
        Assert.That(saved.Select(o => (o.Name, o.Quantity)), Is.EqualTo(new[] { ("a", 1), ("b", 2), ("c", 3) }));
    }

    [Test]
    public async Task BulkInsert_InBatches_CopiesEveryRow()
    {
        var orders = Enumerable.Range(0, 2500).Select(i => NewOrder("n" + i, i)).ToList();

        var copied = await _session.BulkInsertAsync(orders, "dbo.Orders", batchSize: 1000);

        Assert.That(copied, Is.EqualTo(2500));
        Assert.That(await ScalarAsync<int>("SELECT COUNT(*) FROM dbo.Orders"), Is.EqualTo(2500));
    }

    [Test]
    public async Task BulkUpdate_ChangesTheMatchingRowsAndOnlyTheGivenColumns()
    {
        var a = NewOrder("a", 1);
        var b = NewOrder("b", 2);
        var c = NewOrder("c", 3);
        await _session.BulkInsertAsync(new[] { a, b, c }, "dbo.Orders");

        var updated = await _session.BulkUpdateAsync(
            new[] { new Order { Id = a.Id, Name = "ignored", Quantity = 10 }, new Order { Id = b.Id, Name = "ignored", Quantity = 20 } },
            "dbo.Orders",
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
        await _session.BulkInsertAsync(lines, "dbo.OrderLines");

        var deleted = await _session.BulkDeleteAsync(
            new[] { lines[0], lines[2] },
            "dbo.OrderLines",
            new[] { "OrderNumber", "LineNumber" });

        Assert.That(deleted, Is.EqualTo(2));
        Assert.That(await ScalarAsync<string>("SELECT Product FROM dbo.OrderLines"), Is.EqualTo("y"));
        Assert.That(await TemporaryTablesAsync(), Is.Zero);
    }

    [Test]
    public async Task BulkDelete_ByKeyValues_DeletesTheRowsWithThoseKeys()
    {
        var orders = new[] { NewOrder("a", 1), NewOrder("b", 2), NewOrder("c", 3) };
        await _session.BulkInsertAsync(orders, "dbo.Orders");

        var deleted = await _session.BulkDeleteAsync(new[] { orders[0].Id, orders[1].Id }, "dbo.Orders", "Id");

        Assert.That(deleted, Is.EqualTo(2));
        Assert.That((await ReadOrdersAsync()).Select(o => o.Name), Is.EqualTo(new[] { "c" }));
    }

    [Test]
    public async Task BulkMerge_UpdatesTheRowsThatExistAndInsertsTheOthers()
    {
        var existing = NewOrder("existing", 1);
        var untouched = NewOrder("untouched", 5);
        await _session.BulkInsertAsync(new[] { existing, untouched }, "dbo.Orders");

        var result = await _session.BulkMergeAsync(
            new[] { new Order { Id = existing.Id, Name = "changed", Quantity = 2 }, NewOrder("new", 3) },
            "dbo.Orders",
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
        await _session.BulkInsertAsync(new[] { existing }, "dbo.Orders");

        var transaction = await _session.BeginTransactionAsync();
        await _session.BulkInsertAsync(new[] { NewOrder("inside", 2) }, "dbo.Orders");
        await _session.BulkUpdateAsync(new[] { new Order { Id = existing.Id, Name = "changed", Quantity = 9 } }, "dbo.Orders", new[] { "Id" });
        await _session.BulkDeleteAsync(new[] { existing.Id }, "dbo.Orders", "Id");
        await transaction.RollbackAsync();

        var saved = await ReadOrdersAsync();
        Assert.That(saved.Select(o => (o.Name, o.Quantity)), Is.EqualTo(new[] { ("existing", 1) }));
        Assert.That(await TemporaryTablesAsync(), Is.Zero);
    }

    [Test]
    public async Task BulkOperations_OnACommittedTransaction_KeepTheChanges()
    {
        var transaction = await _session.BeginTransactionAsync();
        await _session.BulkInsertAsync(new[] { NewOrder("a", 1), NewOrder("b", 2) }, "dbo.Orders");
        await transaction.CommitAsync();

        Assert.That(await ScalarAsync<int>("SELECT COUNT(*) FROM dbo.Orders"), Is.EqualTo(2));
    }

    [Test]
    public async Task BulkInsert_WithADuplicateKey_Throws()
    {
        var order = NewOrder("a", 1);

        await Assert.ThrowsAsync<SqlException>(() => _session.BulkInsertAsync(new[] { order, order }, "dbo.Orders"));
    }

    [Test]
    public async Task BulkUpdate_WithAFailingStatement_StillDropsTheTemporaryTable()
    {
        var order = NewOrder("a", 1);
        await _session.BulkInsertAsync(new[] { order }, "dbo.Orders");

        // The name column allows 50 characters, so the copy to the temporary table or the update fails.
        await Assert.ThrowsAsync<InvalidOperationException>(() => _session.BulkUpdateAsync(
            new[] { new Order { Id = order.Id, Name = new string('x', 100), Quantity = 1 } },
            "dbo.Orders",
            new[] { "Id" }));

        Assert.That(await TemporaryTablesAsync(), Is.Zero);
    }
}
