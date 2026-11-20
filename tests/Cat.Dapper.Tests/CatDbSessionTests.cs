using System.Data;
using Cat.Dapper.Abstractions;
using Cat.Dapper.Extensions;
using Cat.Dapper.SqlServer.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Dapper.Tests;

[TestFixture]
public class CatDbSessionTests
{
    private FakeDbConnectionFactory _factory = null!;
    private CatDbSession _session = null!;

    [SetUp]
    public void SetUp()
    {
        _factory = new FakeDbConnectionFactory();
        _session = new CatDbSession(_factory);
    }

    [TearDown]
    public void TearDown() => _session.Dispose();

    [Test]
    public void Constructor_NullFactory_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new CatDbSession(null!));
    }

    [Test]
    public async Task GetConnectionAsync_FirstCall_CreatesAndOpensTheConnection()
    {
        var connection = await _session.GetConnectionAsync();

        Assert.Multiple(() =>
        {
            Assert.That(_factory.Created, Has.Count.EqualTo(1));
            Assert.That(connection.State, Is.EqualTo(ConnectionState.Open));
            Assert.That(_factory.Created[0].OpenCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task GetConnectionAsync_SecondCall_ReusesTheSameOpenConnection()
    {
        var first = await _session.GetConnectionAsync();
        var second = await _session.GetConnectionAsync();

        Assert.Multiple(() =>
        {
            Assert.That(second, Is.SameAs(first));
            Assert.That(_factory.Created, Has.Count.EqualTo(1));
            Assert.That(_factory.Created[0].OpenCount, Is.EqualTo(1));
        });
    }

    [Test]
    public void Session_NeverUsed_CreatesNoConnection()
    {
        _session.Dispose();

        Assert.That(_factory.Created, Is.Empty);
    }

    [Test]
    public async Task BeginTransactionAsync_StartsATransactionOnTheConnection()
    {
        var transaction = await _session.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        Assert.Multiple(() =>
        {
            Assert.That(_session.Transaction, Is.SameAs(transaction));
            Assert.That(transaction.IsolationLevel, Is.EqualTo(IsolationLevel.ReadCommitted));
        });
    }

    [Test]
    public async Task BeginTransactionAsync_WhileOneRuns_Throws()
    {
        await _session.BeginTransactionAsync();

        await Assert.ThatAsync(async () => await _session.BeginTransactionAsync(), Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public async Task Transaction_AfterCommit_IsNullAndANewOneCanStart()
    {
        var first = await _session.BeginTransactionAsync();
        first.Commit();

        Assert.That(_session.Transaction, Is.Null);

        var second = await _session.BeginTransactionAsync();
        Assert.That(second, Is.Not.SameAs(first));
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task Transaction_AfterCommitOrRollback_IsNullAlsoWhenTheDriverKeepsTheConnection(bool commit)
    {
        _factory.CompletedTransactionsKeepTheirConnection = true;
        var first = await _session.BeginTransactionAsync();
        Assert.That(_session.Transaction, Is.SameAs(first));

        if (commit) first.Commit(); else first.Rollback();

        Assert.That(_session.Transaction, Is.Null);
        var second = await _session.BeginTransactionAsync();
        Assert.That(second, Is.Not.SameAs(first));
    }

    [Test]
    public async Task Dispose_TransactionNotCommitted_RollsBackAndDisposesTheConnection()
    {
        await _session.BeginTransactionAsync();
        var connection = _factory.Created[0];
        var transaction = connection.LastTransaction!;

        _session.Dispose();

        Assert.Multiple(() =>
        {
            Assert.That(transaction.RolledBack, Is.True);
            Assert.That(transaction.Committed, Is.False);
            Assert.That(connection.IsDisposed, Is.True);
        });
    }

    [Test]
    public async Task Dispose_TransactionCommitted_DoesNotRollBack()
    {
        var transaction = (FakeDbTransaction)await _session.BeginTransactionAsync();
        transaction.Commit();

        _session.Dispose();

        Assert.That(transaction.RolledBack, Is.False);
    }

    [Test]
    public async Task GetConnectionAsync_AfterDispose_Throws()
    {
        _session.Dispose();

        await Assert.ThatAsync(async () => await _session.GetConnectionAsync(), Throws.TypeOf<ObjectDisposedException>());
    }

    [Test]
    public void AddCatDapperSqlServer_RegistersAScopedSessionAndASingletonFactory()
    {
        var services = new ServiceCollection();
        services.AddCatDapperSqlServer("Server=localhost;Database=demo;");

        using var provider = services.BuildServiceProvider();
        using var scopeOne = provider.CreateScope();
        using var scopeTwo = provider.CreateScope();

        var sessionOne = scopeOne.ServiceProvider.GetRequiredService<ICatDbSession>();
        var sessionOneAgain = scopeOne.ServiceProvider.GetRequiredService<ICatDbSession>();
        var sessionTwo = scopeTwo.ServiceProvider.GetRequiredService<ICatDbSession>();

        Assert.Multiple(() =>
        {
            Assert.That(sessionOneAgain, Is.SameAs(sessionOne));
            Assert.That(sessionTwo, Is.Not.SameAs(sessionOne));
            Assert.That(scopeOne.ServiceProvider.GetRequiredService<ICatDbConnectionFactory>(),
                Is.SameAs(scopeTwo.ServiceProvider.GetRequiredService<ICatDbConnectionFactory>()));
        });
    }

    [Test]
    public void AddCatDapperModule_KeepsAFactoryThatIsAlreadyThere()
    {
        var factory = new FakeDbConnectionFactory();
        var services = new ServiceCollection();
        services.AddSingleton<ICatDbConnectionFactory>(factory);
        services.AddCatDapperModule();

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        Assert.That(scope.ServiceProvider.GetRequiredService<ICatDbConnectionFactory>(), Is.SameAs(factory));
    }
}
