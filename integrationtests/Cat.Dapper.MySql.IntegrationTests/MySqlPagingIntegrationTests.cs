using Cat.Dapper;
using Cat.Dapper.MySql;
using Cat.IntegrationTesting.MySql.NUnit;

namespace Cat.Dapper.MySql.IntegrationTests;

/// <summary>
/// Runs the paging helper against a real MySQL. The unit tests only check the SQL text.
/// </summary>
[TestFixture]
public class MySqlPagingIntegrationTests : MySqlDatabaseTests
{
    private sealed class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
    }

    private CatDbSession _session = null!;

    [SetUp]
    public async Task SetUp()
    {
        _session = new CatDbSession(new MySqlConnectionFactory(ConnectionString));
        var connection = await _session.GetConnectionAsync();
        await using var command = connection.CreateCommand();
        command.CommandText =
            "DROP TABLE IF EXISTS Items; CREATE TABLE Items (Id int NOT NULL PRIMARY KEY, Name varchar(50) NOT NULL); " +
            "INSERT INTO Items (Id, Name) WITH RECURSIVE numbers (n) AS (SELECT 1 UNION ALL SELECT n + 1 FROM numbers WHERE n < 25) SELECT n, 'n' FROM numbers;";
        await command.ExecuteNonQueryAsync();
    }

    [TearDown]
    public void TearDown() => _session.Dispose();

    [Test]
    public async Task QueryPaged_ReadsOnePageAndTheTotal()
    {
        var page = await _session.QueryPagedAsync<Item>("SELECT Id, Name FROM Items", "Id", 2, 10);

        Assert.That(page.TotalItemCount, Is.EqualTo(25));
        Assert.That(page.TotalPages, Is.EqualTo(3));
        Assert.That(page.PageNumber, Is.EqualTo(2));
        Assert.That(page.List.Select(i => i.Id), Is.EqualTo(Enumerable.Range(11, 10)));
    }

    [Test]
    public async Task QueryPaged_LastPageHoldsTheRest_AndAFilterChangesTheTotal()
    {
        var last = await _session.QueryPagedAsync<Item>("SELECT Id, Name FROM Items", "Id", 3, 10);
        var filtered = await _session.QueryPagedAsync<Item>("SELECT Id, Name FROM Items WHERE Id > @Min", "Id DESC", 1, 10, new { Min = 20 });

        Assert.That(last.List, Has.Count.EqualTo(5));
        Assert.That(filtered.TotalItemCount, Is.EqualTo(5));
        Assert.That(filtered.List.Select(i => i.Id), Is.EqualTo(new[] { 25, 24, 23, 22, 21 }));
    }
}
