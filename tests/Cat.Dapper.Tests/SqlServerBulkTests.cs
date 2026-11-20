using Cat.Dapper.Abstractions;
using Cat.Dapper.SqlServer;

namespace Cat.Dapper.Tests;

[TestFixture]
public class SqlServerBulkTests
{
    private enum Status : short
    {
        New = 1,
        Done = 2,
    }

    private sealed class Order
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int? Quantity { get; set; }

        public Status Status { get; set; }

        public Status? OptionalStatus { get; set; }

        public string Computed => Name + "!";

        public string WriteOnly { set { } }
    }

    private CatDbSession _session = null!;

    [SetUp]
    public void SetUp() => _session = new CatDbSession(new FakeDbConnectionFactory());

    [TearDown]
    public void TearDown() => _session.Dispose();

    [TestCase("dbo.Orders", "[dbo].[Orders]")]
    [TestCase("Orders", "[Orders]")]
    [TestCase("srv.db.dbo.Orders", "[srv].[db].[dbo].[Orders]")]
    [TestCase(" dbo . Orders ", "[dbo].[Orders]")]
    public void QuoteName_WrapsEveryPart(string name, string expected)
    {
        Assert.That(SqlServerBulkSql.QuoteName(name), Is.EqualTo(expected));
    }

    [TestCase("Orders]; DROP TABLE x;--")]
    [TestCase("[Orders]")]
    [TestCase("dbo..Orders")]
    [TestCase("")]
    [TestCase("a.b.c.d.e")]
    public void QuoteName_BadName_Throws(string name)
    {
        Assert.Throws<ArgumentException>(() => SqlServerBulkSql.QuoteName(name));
    }

    [Test]
    public void QuoteColumn_WithADot_Throws()
    {
        Assert.Throws<ArgumentException>(() => SqlServerBulkSql.QuoteColumn("a.b"));
    }

    [Test]
    public void BuildCreateStaging_CopiesOnlyTheColumnsAndNoRows()
    {
        var sql = SqlServerBulkSql.BuildCreateStaging("#S", "dbo.Orders", new[] { "Id", "Name" });

        Assert.That(sql, Is.EqualTo("SELECT TOP 0 [Id], [Name] INTO [#S] FROM [dbo].[Orders];"));
    }

    [Test]
    public void BuildUpdate_JoinsOnAllKeysAndSetsTheColumns()
    {
        var sql = SqlServerBulkSql.BuildUpdate("#S", "dbo.Orders", new[] { "A", "B" }, new[] { "Name", "Quantity" });

        Assert.That(sql, Is.EqualTo(
            "UPDATE t SET t.[Name] = s.[Name], t.[Quantity] = s.[Quantity] FROM [dbo].[Orders] AS t INNER JOIN [#S] AS s ON t.[A] = s.[A] AND t.[B] = s.[B];"));
    }

    [Test]
    public void BuildDelete_JoinsOnAllKeys()
    {
        var sql = SqlServerBulkSql.BuildDelete("#S", "dbo.Orders", new[] { "A", "B" });

        Assert.That(sql, Is.EqualTo("DELETE t FROM [dbo].[Orders] AS t INNER JOIN [#S] AS s ON t.[A] = s.[A] AND t.[B] = s.[B];"));
    }

    [Test]
    public void BuildMerge_UsesHoldLockAndOnlyUpdateAndInsert()
    {
        var sql = SqlServerBulkSql.BuildMerge("#S", "dbo.Orders", new[] { "Id" }, new[] { "Id", "Name" }, new[] { "Name" });

        Assert.Multiple(() =>
        {
            Assert.That(sql, Does.Contain("MERGE [dbo].[Orders] WITH (HOLDLOCK) AS t USING [#S] AS s ON t.[Id] = s.[Id]"));
            Assert.That(sql, Does.Contain("WHEN MATCHED THEN UPDATE SET t.[Name] = s.[Name]"));
            Assert.That(sql, Does.Contain("WHEN NOT MATCHED BY TARGET THEN INSERT ([Id], [Name]) VALUES (s.[Id], s.[Name])"));
            Assert.That(sql, Does.Contain("OUTPUT $action INTO @CatActions"));
            Assert.That(sql, Does.Not.Contain("DELETE"));
        });
    }

    [Test]
    public void BuildMerge_NoUpdateColumns_HasNoMatchedClause()
    {
        var sql = SqlServerBulkSql.BuildMerge("#S", "dbo.Orders", new[] { "Id" }, new[] { "Id" }, Array.Empty<string>());

        Assert.That(sql, Does.Not.Contain("WHEN MATCHED"));
    }

    [Test]
    public void BulkColumns_ReadablePropertiesOnly_AndEnumsAsTheirNumber()
    {
        var columns = BulkColumns.ForType(typeof(Order));

        Assert.Multiple(() =>
        {
            Assert.That(columns.Select(c => c.Name), Is.EqualTo(new[] { "Id", "Name", "Quantity", "Status", "OptionalStatus", "Computed" }));
            Assert.That(columns.Single(c => c.Name == "Quantity").FieldType, Is.EqualTo(typeof(int)));
            Assert.That(columns.Single(c => c.Name == "Status").FieldType, Is.EqualTo(typeof(short)));
            Assert.That(columns.Single(c => c.Name == "OptionalStatus").FieldType, Is.EqualTo(typeof(short)));
        });
    }

    [Test]
    public void BulkColumns_Select_MatchesWithoutCase_AndRejectsUnknownAndDoubleNames()
    {
        Assert.That(BulkColumns.Select(typeof(Order), new[] { "name", "ID" }, "c").Select(c => c.Name), Is.EqualTo(new[] { "Name", "Id" }));
        Assert.Throws<ArgumentException>(() => BulkColumns.Select(typeof(Order), new[] { "Nope" }, "c"));
        Assert.Throws<ArgumentException>(() => BulkColumns.Select(typeof(Order), new[] { "Id", "id" }, "c"));
        Assert.Throws<ArgumentException>(() => BulkColumns.Select(typeof(Order), Array.Empty<string>(), "c"));
    }

    [Test]
    public void BulkDataReader_StreamsTheRows_WithNullsAsDbNullAndEnumsAsNumbers()
    {
        var id = Guid.NewGuid();
        var rows = new[]
        {
            new Order { Id = id, Name = "a", Quantity = 3, Status = Status.Done, OptionalStatus = Status.New },
            new Order { Id = Guid.NewGuid(), Name = null, Quantity = null, Status = Status.New },
        };
        var columns = BulkColumns.Select(typeof(Order), new[] { "Id", "Name", "Quantity", "Status", "OptionalStatus" }, "c");

        using var reader = new BulkDataReader<Order>(rows, columns);

        Assert.Multiple(() =>
        {
            Assert.That(reader.FieldCount, Is.EqualTo(5));
            Assert.That(reader.Read(), Is.True);
            Assert.That(reader.GetGuid(0), Is.EqualTo(id));
            Assert.That(reader.GetValue(3), Is.EqualTo((short)2));
            Assert.That(reader.GetValue(4), Is.EqualTo((short)1));
            Assert.That(reader.Read(), Is.True);
            Assert.That(reader.IsDBNull(1), Is.True);
            Assert.That(reader.IsDBNull(2), Is.True);
            Assert.That(reader.IsDBNull(4), Is.True);
            Assert.That(reader.Read(), Is.False);
            Assert.That(reader.RowCount, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task EmptyRows_GiveZeroWithoutTouchingTheDatabase()
    {
        var empty = new List<Order>();

        Assert.That(await _session.BulkInsertAsync(empty, "dbo.Orders"), Is.EqualTo(0));
        Assert.That(await _session.BulkUpdateAsync(empty, "dbo.Orders", new[] { "Id" }), Is.EqualTo(0));
        Assert.That(await _session.BulkDeleteAsync(empty, "dbo.Orders", new[] { "Id" }), Is.EqualTo(0));
        Assert.That(await _session.BulkDeleteAsync(new List<Guid>(), "dbo.Orders", "Id"), Is.EqualTo(0));
        var merge = await _session.BulkMergeAsync(empty, "dbo.Orders", new[] { "Id" });
        Assert.That((merge.Inserted, merge.Updated), Is.EqualTo((0, 0)));
    }

    [Test]
    public async Task NotASqlConnection_Throws()
    {
        var rows = new[] { new Order { Id = Guid.NewGuid() } };

        await Assert.ThatAsync(
            async () => await _session.BulkInsertAsync(rows, "dbo.Orders"),
            Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void BadArguments_Throw()
    {
        var rows = new[] { new Order() };

        Assert.Multiple(() =>
        {
            Assert.That(async () => await SqlServerBulkExtensions.BulkInsertAsync(null!, rows, "dbo.Orders"), Throws.TypeOf<ArgumentNullException>());
            Assert.That(async () => await _session.BulkInsertAsync<Order>(null!, "dbo.Orders"), Throws.TypeOf<ArgumentNullException>());
            Assert.That(async () => await _session.BulkInsertAsync(rows, "dbo.Orders]"), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkInsertAsync(rows, "dbo.Orders", new[] { "Nope" }), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkUpdateAsync(rows, "dbo.Orders", null!), Throws.TypeOf<ArgumentNullException>());
            Assert.That(async () => await _session.BulkUpdateAsync(rows, "dbo.Orders", new[] { "Id" }, new[] { "Id" }), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkDeleteAsync(rows, "dbo.Orders", new[] { "Nope" }), Throws.TypeOf<ArgumentException>());
            Assert.That(async () => await _session.BulkDeleteAsync(new[] { 1 }, "dbo.Orders", "Id; DROP"), Throws.TypeOf<InvalidOperationException>());
            Assert.That(async () => await _session.BulkMergeAsync(rows, "dbo.Orders", new[] { "Id" }, new[] { "Nope" }), Throws.TypeOf<ArgumentException>());
        });
    }

    [Test]
    public void BulkUpdate_EveryPropertyIsAKey_Throws()
    {
        Assert.That(
            async () => await _session.BulkUpdateAsync(new[] { new Order() }, "dbo.Orders", new[] { "Id", "Name", "Quantity", "Status", "OptionalStatus", "Computed" }),
            Throws.TypeOf<ArgumentException>());
    }
}
