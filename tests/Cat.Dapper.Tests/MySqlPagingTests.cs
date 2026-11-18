using Cat.Dapper.MySql;
using Cat.Dapper.MySql.Extensions;
using Cat.Dapper.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Dapper.Tests;

[TestFixture]
public class MySqlPagingTests
{
    private CatDbSession _session = null!;

    [SetUp]
    public void SetUp() => _session = new CatDbSession(new FakeDbConnectionFactory());

    [TearDown]
    public void TearDown() => _session.Dispose();

    [TestCase(1, 10, 0)]
    [TestCase(3, 10, 20)]
    [TestCase(int.MaxValue, int.MaxValue, int.MaxValue)]
    public void CalculateSkip_GivesTheRowsBeforeThePage(int pageNumber, int pageSize, int expected)
    {
        Assert.That(MySqlPagingExtensions.CalculateSkip(pageNumber, pageSize), Is.EqualTo(expected));
    }

    [Test]
    public void BuildSql_CountsTheStatementAndReadsOnePageInTheGivenOrder()
    {
        var sql = MySqlPagingExtensions.BuildSql("SELECT Id, Total FROM Orders WHERE UserId = @UserId", "Id DESC");

        Assert.Multiple(() =>
        {
            Assert.That(sql, Does.StartWith("SELECT COUNT(*) FROM (SELECT Id, Total FROM Orders WHERE UserId = @UserId) AS CatCount;"));
            Assert.That(sql, Does.Contain("ORDER BY Id DESC"));
            Assert.That(sql, Does.Contain("LIMIT @CatTake OFFSET @CatSkip"));
        });
    }

    [TestCase(0, 10)]
    [TestCase(1, 0)]
    [TestCase(-1, 10)]
    public async Task QueryPagedAsync_PageNumberOrSizeBelowOne_Throws(int pageNumber, int pageSize)
    {
        await Assert.ThatAsync(
            async () => await _session.QueryPagedAsync<int>("SELECT 1 AS Id", "Id", pageNumber, pageSize),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public async Task QueryPagedAsync_NullArguments_Throw()
    {
        await Assert.ThatAsync(
            async () => await MySqlPagingExtensions.QueryPagedAsync<int>(null!, "SELECT 1", "Id", 1, 10),
            Throws.TypeOf<ArgumentNullException>());
        await Assert.ThatAsync(
            async () => await _session.QueryPagedAsync<int>(null!, "Id", 1, 10),
            Throws.TypeOf<ArgumentNullException>());
        await Assert.ThatAsync(
            async () => await _session.QueryPagedAsync<int>("SELECT 1", null!, 1, 10),
            Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void MySqlConnectionFactory_EmptyConnectionString_Throws()
    {
        Assert.Throws<ArgumentException>(() => new MySqlConnectionFactory(" "));
    }

    [Test]
    public void MySqlConnectionFactory_CreateConnection_GivesAClosedConnectionOfTheirOwn()
    {
        var factory = new MySqlConnectionFactory("Server=localhost;Database=demo;");

        using var first = factory.CreateConnection();
        using var second = factory.CreateConnection();

        Assert.Multiple(() =>
        {
            Assert.That(first, Is.Not.SameAs(second));
            Assert.That(first.State, Is.EqualTo(System.Data.ConnectionState.Closed));
        });
    }

    [Test]
    public void AddCatDapperMySql_RegistersTheFactoryAndTheScopedSession()
    {
        var services = new ServiceCollection().AddCatDapperMySql("Server=localhost;Database=demo;");

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        Assert.Multiple(() =>
        {
            Assert.That(provider.GetRequiredService<ICatDbConnectionFactory>(), Is.TypeOf<MySqlConnectionFactory>());
            Assert.That(scope.ServiceProvider.GetRequiredService<ICatDbSession>(), Is.Not.Null);
        });
    }
}
