using Cat.Db.Errors.PostgreSQL;
using Cat.IntegrationTesting.PostgreSQL.NUnit;
using Npgsql;

namespace Cat.EFCore.IntegrationTests;

/// <summary>
/// Raises real PostgreSQL errors and checks that Cat.Db.Errors.PostgreSQL recognizes them. The unit tests only use made up SQL states.
/// </summary>
[TestFixture]
public class DbErrorsPostgreSqlIntegrationTests : PostgreSQLDatabaseTests
{
    [OneTimeSetUp]
    public async Task CreateTables()
    {
        await ExecuteAsync(
            "CREATE TABLE parent (id int NOT NULL PRIMARY KEY, name text NOT NULL UNIQUE); " +
            "CREATE TABLE child (id int NOT NULL PRIMARY KEY, parent_id int NOT NULL REFERENCES parent (id)); " +
            "INSERT INTO parent (id, name) VALUES (1, 'a'), (2, 'b');");
    }

    private async Task ExecuteAsync(string sql, int timeoutSeconds = 30)
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();
        await using var command = new NpgsqlCommand(sql, connection) { CommandTimeout = timeoutSeconds };
        await command.ExecuteNonQueryAsync();
    }

    [Test]
    public async Task IsUniqueViolation_OnADuplicateKeyAndADuplicateUniqueIndex_ReturnsTrue()
    {
        var primaryKey = await Assert.ThrowsAsync<PostgresException>(() => ExecuteAsync("INSERT INTO parent (id, name) VALUES (1, 'x')"));
        var uniqueIndex = await Assert.ThrowsAsync<PostgresException>(() => ExecuteAsync("INSERT INTO parent (id, name) VALUES (9, 'a')"));

        Assert.That(primaryKey.IsUniqueViolation(), Is.True);
        Assert.That(uniqueIndex.IsUniqueViolation(), Is.True);
        Assert.That(primaryKey.IsForeignKeyViolation(), Is.False);
    }

    [Test]
    public async Task IsUniqueViolation_OnAnExceptionThatWrapsThePostgresException_ReturnsTrue()
    {
        var inner = await Assert.ThrowsAsync<PostgresException>(() => ExecuteAsync("INSERT INTO parent (id, name) VALUES (1, 'x')"));

        Assert.That(new InvalidOperationException("wrapped", inner).IsUniqueViolation(), Is.True);
    }

    [Test]
    public async Task IsForeignKeyViolation_OnAChildWithoutAParent_ReturnsTrue()
    {
        var error = await Assert.ThrowsAsync<PostgresException>(() => ExecuteAsync("INSERT INTO child (id, parent_id) VALUES (1, 99)"));

        Assert.That(error.IsForeignKeyViolation(), Is.True);
        Assert.That(error.IsUniqueViolation(), Is.False);
    }

    [Test]
    public async Task IsTimeout_OnASlowCommand_ReturnsTrue()
    {
        var error = await Assert.ThrowsAsync<NpgsqlException>(() => ExecuteAsync("SELECT pg_sleep(5)", timeoutSeconds: 1));

        Assert.That(error.IsTimeout(), Is.True);
        Assert.That(error.IsDeadlock(), Is.False);
    }

    [Test]
    public async Task IsTimeout_OnAStatementTimeoutOfTheServer_ReturnsTrue()
    {
        var error = await Assert.ThrowsAsync<PostgresException>(() => ExecuteAsync("SET statement_timeout = 500; SELECT pg_sleep(5);"));

        Assert.That(error.SqlState, Is.EqualTo("57014"));
        Assert.That(error.IsTimeout(), Is.True);
    }

    [Test]
    public async Task IsDeadlock_OnTwoTransactionsThatWaitForEachOther_ReturnsTrueForTheVictim()
    {
        await ExecuteAsync("DROP TABLE IF EXISTS lock_rows; CREATE TABLE lock_rows (id int NOT NULL PRIMARY KEY, value int NOT NULL); INSERT INTO lock_rows VALUES (1, 0), (2, 0);");
        using var bothHoldOneLock = new Barrier(2);

        async Task<Exception?> RunAsync(int first, int second)
        {
            await using var connection = new NpgsqlConnection(ConnectionString);
            await connection.OpenAsync();
            await using var transaction = await connection.BeginTransactionAsync();
            try
            {
                await new NpgsqlCommand($"UPDATE lock_rows SET value = 1 WHERE id = {first}", connection, transaction).ExecuteNonQueryAsync();
                bothHoldOneLock.SignalAndWait(TimeSpan.FromSeconds(10));
                await new NpgsqlCommand($"UPDATE lock_rows SET value = 1 WHERE id = {second}", connection, transaction).ExecuteNonQueryAsync();
                await transaction.CommitAsync();
                return null;
            }
            catch (PostgresException exception)
            {
                return exception;
            }
        }

        var results = await Task.WhenAll(Task.Run(() => RunAsync(1, 2)), Task.Run(() => RunAsync(2, 1)));

        var victim = results.Single(r => r is not null);
        Assert.That(victim.IsDeadlock(), Is.True);
    }
}
