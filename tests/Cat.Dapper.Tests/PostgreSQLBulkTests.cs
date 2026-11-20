using Cat.Dapper.Abstractions;
using Cat.Dapper.PostgreSQL;

namespace Cat.Dapper.Tests;

[TestFixture]
public class PostgreSQLBulkTests
{
    private sealed class Order
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int? Quantity { get; set; }
    }

    private CatDbSession _session = null!;

    [SetUp]
    public void SetUp() => _session = new CatDbSession(new FakeDbConnectionFactory());

    [TearDown]
    public void TearDown() => _session.Dispose();

    [TestCase("public.Orders", "\"public\".\"Orders\"")]
    [TestCase("Orders", "\"Orders\"")]
    [TestCase("db.public.Orders", "\"db\".\"public\".\"Orders\"")]
    [TestCase(" public . Orders ", "\"public\".\"Orders\"")]
    [TestCase("order_id", "\"order_id\"")]
    public void QuoteName_WrapsEveryPartAndKeepsTheCase(string name, string expected)
    {
        Assert.That(PostgreSQLBulkSql.QuoteName(name), Is.EqualTo(expected));
    }

    [TestCase("Orders\"; DROP TABLE x;--")]
    [TestCase("\"Orders\"")]
    [TestCase("public..Orders")]
    [TestCase("")]
    [TestCase("a.b.c.d")]
    public void QuoteName_BadName_Throws(string name)
    {
        Assert.Throws<ArgumentException>(() => PostgreSQLBulkSql.QuoteName(name));
    }

    [Test]
    public void QuoteColumn_WithADot_Throws()
    {
        Assert.Throws<ArgumentException>(() => PostgreSQLBulkSql.QuoteColumn("a.b"));
    }

    [Test]
    public void BuildCreateStaging_CopiesOnlyTheColumnTypesAndNoRows()
    {
        Assert.Multiple(() =>
        {
            Assert.That(PostgreSQLBulkSql.BuildCreateStaging("s", "public.Orders", new[] { "Id", "Name" }, false),
                Is.EqualTo("CREATE TEMP TABLE \"s\" AS SELECT \"Id\", \"Name\" FROM \"public\".\"Orders\" WITH NO DATA;"));
            Assert.That(PostgreSQLBulkSql.BuildCreateStaging("s", "public.Orders", new[] { "Id" }, true),
                Is.EqualTo("CREATE TEMP TABLE \"s\" ON COMMIT DROP AS SELECT \"Id\" FROM \"public\".\"Orders\" WITH NO DATA;"));
        });
    }

    [Test]
    public void BuildCopy_UsesTheBinaryFormatAndTheColumnOrder()
    {
        Assert.That(PostgreSQLBulkSql.BuildCopy("public.Orders", new[] { "Id", "Name" }),
            Is.EqualTo("COPY \"public\".\"Orders\" (\"Id\", \"Name\") FROM STDIN (FORMAT BINARY)"));
    }

    [Test]
    public void BuildUpdate_JoinsOnAllKeysAndSetsTheColumns()
    {
        var sql = PostgreSQLBulkSql.BuildUpdate("s", "public.Orders", new[] { "A", "B" }, new[] { "Name", "Quantity" });

        Assert.That(sql, Is.EqualTo(
            "UPDATE \"public\".\"Orders\" AS t SET \"Name\" = s.\"Name\", \"Quantity\" = s.\"Quantity\" FROM \"s\" AS s WHERE t.\"A\" = s.\"A\" AND t.\"B\" = s.\"B\";"));
    }

    [Test]
    public void BuildDelete_JoinsOnAllKeys()
    {
        var sql = PostgreSQLBulkSql.BuildDelete("s", "public.Orders", new[] { "A", "B" });

        Assert.That(sql, Is.EqualTo("DELETE FROM \"public\".\"Orders\" AS t USING \"s\" AS s WHERE t.\"A\" = s.\"A\" AND t.\"B\" = s.\"B\";"));
    }

    [Test]
    public void BuildMerge_InsertsAndUpdatesOnConflictAndNeverDeletes()
    {
        var sql = PostgreSQLBulkSql.BuildMerge("s", "public.Orders", new[] { "Id" }, new[] { "Id", "Name" }, new[] { "Name" });

        Assert.Multiple(() =>
        {
            Assert.That(sql, Does.StartWith("INSERT INTO \"public\".\"Orders\" (\"Id\", \"Name\") SELECT s.\"Id\", s.\"Name\" FROM \"s\" AS s"));
            Assert.That(sql, Does.Contain("ON CONFLICT (\"Id\") DO UPDATE SET \"Name\" = EXCLUDED.\"Name\""));
            Assert.That(sql, Does.Contain("RETURNING (xmax = 0) AS \"Inserted\""));
            Assert.That(sql, Does.Not.Contain("DELETE"));
        });
    }

    [Test]
    public void BuildMerge_NoUpdateColumns_DoesNothingOnConflict()
    {
        var sql = PostgreSQLBulkSql.BuildMerge("s", "public.Orders", new[] { "Id" }, new[] { "Id" }, Array.Empty<string>());

        Assert.That(sql, Does.Contain("ON CONFLICT (\"Id\") DO NOTHING"));
    }

    [Test]
    public async Task EmptyRows_GiveZeroWithoutTouchingTheDatabase()
    {
        var empty = new List<Order>();

        Assert.That(await _session.BulkInsertAsync(empty, "public.Orders"), Is.EqualTo(0));
        Assert.That(await _session.BulkUpdateAsync(empty, "public.Orders", new[] { "Id" }), Is.EqualTo(0));
        Assert.That(await _session.BulkDeleteAsync(empty, "public.Orders", new[] { "Id" }), Is.EqualTo(0));
        Assert.That(await _session.BulkDeleteAsync(new List<Guid>(), "public.Orders", "Id"), Is.EqualTo(0));
        var merge = await _session.BulkMergeAsync(empty, "public.Orders", new[] { "Id" });
        Assert.That((merge.Inserted, merge.Updated), Is.EqualTo((0, 0)));
    }

    [Test]
    public async Task NotAnNpgsqlConnection_Throws()
    {
        var rows = new[] { new Order { Id = Guid.NewGuid() } };

        await Assert.ThatAsync(
            async () => await _session.BulkInsertAsync(rows, "public.Orders"),
            Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void BadArguments_Throw()
    {
        var rows = new[] { new Order() };

        Assert.Multiple(() =>
        {
            Assert.That(async () => await PostgreSQLBulkExtensions.BulkInsertAsync(null!, rows, "public.Orders"), Throws.TypeOf<ArgumentNullException>());
            Assert.That(async () => await _session.BulkInsertAsync<Order>(null!, "public.Orders"), Throws.TypeOf<ArgumentNullException>());
            Assert.That(async () => await _session.BulkInsertAsync(rows, "public.Orders\""), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkInsertAsync(rows, "public.Orders", new[] { "Nope" }), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkUpdateAsync(rows, "public.Orders", null!), Throws.TypeOf<ArgumentNullException>());
            Assert.That(async () => await _session.BulkUpdateAsync(rows, "public.Orders", new[] { "Id" }, new[] { "Id" }), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkUpdateAsync(rows, "public.Orders", new[] { "Id", "Name", "Quantity" }), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkDeleteAsync(rows, "public.Orders", new[] { "Nope" }), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkMergeAsync(rows, "public.Orders", new[] { "Id" }, new[] { "Nope" }), Throws.TypeOf<ArgumentException>());
        });
    }
}
