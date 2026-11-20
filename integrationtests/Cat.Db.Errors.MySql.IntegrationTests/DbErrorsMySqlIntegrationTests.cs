using Cat.Db.Errors.MySql;
using Cat.IntegrationTesting.MySql.NUnit;
using MySqlConnector;

namespace Cat.Db.Errors.MySql.IntegrationTests;

/// <summary>
/// Raises real MySQL errors and checks that Cat.Db.Errors.MySql recognizes them. The unit tests only use made up error numbers.
/// </summary>
[TestFixture]
public class DbErrorsMySqlIntegrationTests : MySqlDatabaseTests
{
    [OneTimeSetUp]
    public async Task CreateTables()
    {
        await ExecuteAsync(
            "CREATE TABLE parent (id int NOT NULL PRIMARY KEY, name varchar(20) NOT NULL UNIQUE) ENGINE=InnoDB; " +
            "CREATE TABLE child (id int NOT NULL PRIMARY KEY, parent_id int NOT NULL, FOREIGN KEY (parent_id) REFERENCES parent (id)) ENGINE=InnoDB; " +
            "INSERT INTO parent (id, name) VALUES (1, 'a'), (2, 'b'); " +
            "INSERT INTO child (id, parent_id) VALUES (1, 1);");
    }

    private async Task ExecuteAsync(string sql, int timeoutSeconds = 30)
    {
        await using var connection = new MySqlConnection(ConnectionString);
        await connection.OpenAsync();
        await using var command = new MySqlCommand(sql, connection) { CommandTimeout = timeoutSeconds };
        await command.ExecuteNonQueryAsync();
    }

    [Test]
    public async Task IsUniqueViolation_OnADuplicateKeyAndADuplicateUniqueIndex_ReturnsTrue()
    {
        var primaryKey = await Assert.ThrowsAsync<MySqlException>(() => ExecuteAsync("INSERT INTO parent (id, name) VALUES (1, 'x')"));
        var uniqueIndex = await Assert.ThrowsAsync<MySqlException>(() => ExecuteAsync("INSERT INTO parent (id, name) VALUES (9, 'a')"));

        Assert.That(primaryKey.IsUniqueViolation(), Is.True);
        Assert.That(uniqueIndex.IsUniqueViolation(), Is.True);
        Assert.That(primaryKey.IsForeignKeyViolation(), Is.False);
    }

    [Test]
    public async Task IsUniqueViolation_OnAnExceptionThatWrapsTheMySqlException_ReturnsTrue()
    {
        var inner = await Assert.ThrowsAsync<MySqlException>(() => ExecuteAsync("INSERT INTO parent (id, name) VALUES (1, 'x')"));

        Assert.That(new InvalidOperationException("wrapped", inner).IsUniqueViolation(), Is.True);
    }

    [Test]
    public async Task IsForeignKeyViolation_OnAChildWithoutAParentAndOnAParentThatIsReferenced_ReturnsTrue()
    {
        var noParent = await Assert.ThrowsAsync<MySqlException>(() => ExecuteAsync("INSERT INTO child (id, parent_id) VALUES (2, 99)"));
        var referenced = await Assert.ThrowsAsync<MySqlException>(() => ExecuteAsync("DELETE FROM parent WHERE id = 1"));

        Assert.That(noParent.IsForeignKeyViolation(), Is.True);
        Assert.That(referenced.IsForeignKeyViolation(), Is.True);
        Assert.That(noParent.IsUniqueViolation(), Is.False);
    }

    [Test]
    public async Task IsTimeout_OnASlowCommand_ReturnsTrue()
    {
        // SLEEP returns quietly when the server cancels it, so the test uses a query that keeps the server busy.
        var error = await Assert.ThrowsAsync<MySqlException>(() => ExecuteAsync(
            "SELECT COUNT(*) FROM information_schema.columns a, information_schema.columns b, information_schema.columns c", timeoutSeconds: 1));

        Assert.That(error.IsTimeout(), Is.True);
        Assert.That(error.IsDeadlock(), Is.False);
    }

    [Test]
    public async Task IsTimeout_OnALockThatIsNotGivenInTime_ReturnsTrue()
    {
        await ExecuteAsync("DROP TABLE IF EXISTS locks; CREATE TABLE locks (id int NOT NULL PRIMARY KEY, value int NOT NULL) ENGINE=InnoDB; INSERT INTO locks VALUES (1, 0);");
        await using var holder = new MySqlConnection(ConnectionString);
        await holder.OpenAsync();
        await using var transaction = await holder.BeginTransactionAsync();
        await new MySqlCommand("UPDATE locks SET value = 1 WHERE id = 1", holder, transaction).ExecuteNonQueryAsync();

        var error = await Assert.ThrowsAsync<MySqlException>(() => ExecuteAsync("SET SESSION innodb_lock_wait_timeout = 1; UPDATE locks SET value = 2 WHERE id = 1;"));

        Assert.That(error.IsTimeout(), Is.True);
    }

    [Test]
    public async Task IsDeadlock_OnTwoTransactionsThatWaitForEachOther_ReturnsTrueForTheVictim()
    {
        await ExecuteAsync("DROP TABLE IF EXISTS dead; CREATE TABLE dead (id int NOT NULL PRIMARY KEY, value int NOT NULL) ENGINE=InnoDB; INSERT INTO dead VALUES (1, 0), (2, 0);");
        using var bothHoldOneLock = new Barrier(2);

        async Task<Exception?> RunAsync(int first, int second)
        {
            await using var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();
            try
            {
                await new MySqlCommand($"UPDATE dead SET value = 1 WHERE id = {first}", connection, transaction).ExecuteNonQueryAsync();
                bothHoldOneLock.SignalAndWait(TimeSpan.FromSeconds(10));
                await new MySqlCommand($"UPDATE dead SET value = 1 WHERE id = {second}", connection, transaction).ExecuteNonQueryAsync();
                await transaction.CommitAsync();
                return null;
            }
            catch (MySqlException exception)
            {
                return exception;
            }
        }

        var results = await Task.WhenAll(Task.Run(() => RunAsync(1, 2)), Task.Run(() => RunAsync(2, 1)));

        var victim = results.Single(r => r is not null);
        Assert.That(victim.IsDeadlock(), Is.True);
    }
}
