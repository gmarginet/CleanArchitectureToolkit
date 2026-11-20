using Cat.Db.Errors.SqlServer;
using Cat.IntegrationTesting.SqlServer.NUnit;
using Microsoft.Data.SqlClient;

namespace Cat.EFCore.IntegrationTests;

/// <summary>
/// Raises real SQL Server errors and checks that Cat.Db.Errors.SqlServer recognizes them. The unit tests only use made up error numbers.
/// </summary>
[TestFixture]
public class DbErrorsSqlServerIntegrationTests : SqlServerDatabaseTests
{
    [OneTimeSetUp]
    public async Task CreateTables()
    {
        await ExecuteAsync(
            "CREATE TABLE dbo.Parent (Id int NOT NULL PRIMARY KEY, Name nvarchar(20) NOT NULL UNIQUE); " +
            "CREATE TABLE dbo.Child (Id int NOT NULL PRIMARY KEY, ParentId int NOT NULL REFERENCES dbo.Parent (Id)); " +
            "INSERT INTO dbo.Parent (Id, Name) VALUES (1, 'a'), (2, 'b');");
    }

    private async Task ExecuteAsync(string sql, int timeoutSeconds = 30)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();
        await using var command = new SqlCommand(sql, connection) { CommandTimeout = timeoutSeconds };
        await command.ExecuteNonQueryAsync();
    }

    [Test]
    public async Task IsUniqueViolation_OnADuplicateKeyAndADuplicateUniqueIndex_ReturnsTrue()
    {
        var primaryKey = await Assert.ThrowsAsync<SqlException>(() => ExecuteAsync("INSERT INTO dbo.Parent (Id, Name) VALUES (1, 'x')"));
        var uniqueIndex = await Assert.ThrowsAsync<SqlException>(() => ExecuteAsync("INSERT INTO dbo.Parent (Id, Name) VALUES (9, 'a')"));

        Assert.That(primaryKey.IsUniqueViolation(), Is.True);
        Assert.That(uniqueIndex.IsUniqueViolation(), Is.True);
        Assert.That(primaryKey.IsForeignKeyViolation(), Is.False);
    }

    [Test]
    public async Task IsUniqueViolation_OnAnExceptionThatWrapsTheSqlException_ReturnsTrue()
    {
        var inner = await Assert.ThrowsAsync<SqlException>(() => ExecuteAsync("INSERT INTO dbo.Parent (Id, Name) VALUES (1, 'x')"));

        Assert.That(new InvalidOperationException("wrapped", inner).IsUniqueViolation(), Is.True);
    }

    [Test]
    public async Task IsForeignKeyViolation_OnAChildWithoutAParent_ReturnsTrue()
    {
        var error = await Assert.ThrowsAsync<SqlException>(() => ExecuteAsync("INSERT INTO dbo.Child (Id, ParentId) VALUES (1, 99)"));

        Assert.That(error.IsForeignKeyViolation(), Is.True);
        Assert.That(error.IsUniqueViolation(), Is.False);
    }

    [Test]
    public async Task IsTimeout_OnASlowCommand_ReturnsTrue()
    {
        var error = await Assert.ThrowsAsync<SqlException>(() => ExecuteAsync("WAITFOR DELAY '00:00:05'", timeoutSeconds: 1));

        Assert.That(error.IsTimeout(), Is.True);
        Assert.That(error.IsDeadlock(), Is.False);
    }

    [Test]
    public async Task IsTimeout_OnALockThatIsNotGivenInTime_ReturnsTrue()
    {
        await ExecuteAsync("DROP TABLE IF EXISTS dbo.Waiting; CREATE TABLE dbo.Waiting (Id int NOT NULL PRIMARY KEY, Value int NOT NULL); INSERT INTO dbo.Waiting VALUES (1, 0);");
        await using var holder = new SqlConnection(ConnectionString);
        await holder.OpenAsync();
        await using var transaction = (SqlTransaction)await holder.BeginTransactionAsync();
        await new SqlCommand("UPDATE dbo.Waiting SET Value = 1 WHERE Id = 1", holder, transaction).ExecuteNonQueryAsync();

        var error = await Assert.ThrowsAsync<SqlException>(() => ExecuteAsync("SET LOCK_TIMEOUT 500; UPDATE dbo.Waiting SET Value = 2 WHERE Id = 1;"));

        Assert.That(error.Number, Is.EqualTo(CatSqlServerErrorNumbers.LockRequestTimeout));
        Assert.That(error.IsTimeout(), Is.True);
        Assert.That(error.IsDeadlock(), Is.False);
    }

    [Test]
    public async Task IsDeadlock_OnTwoTransactionsThatWaitForEachOther_ReturnsTrueForTheVictim()
    {
        await ExecuteAsync("DROP TABLE IF EXISTS dbo.Lock; CREATE TABLE dbo.Lock (Id int NOT NULL PRIMARY KEY, Value int NOT NULL); INSERT INTO dbo.Lock VALUES (1, 0), (2, 0);");
        using var bothHoldOneLock = new Barrier(2);

        async Task<Exception?> RunAsync(int first, int second)
        {
            await using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();
            try
            {
                await new SqlCommand($"UPDATE dbo.Lock SET Value = 1 WHERE Id = {first}", connection, transaction).ExecuteNonQueryAsync();
                bothHoldOneLock.SignalAndWait(TimeSpan.FromSeconds(10));
                await new SqlCommand($"UPDATE dbo.Lock SET Value = 1 WHERE Id = {second}", connection, transaction).ExecuteNonQueryAsync();
                await transaction.CommitAsync();
                return null;
            }
            catch (SqlException exception)
            {
                return exception;
            }
        }

        var results = await Task.WhenAll(Task.Run(() => RunAsync(1, 2)), Task.Run(() => RunAsync(2, 1)));

        var victim = results.Single(r => r is not null);
        Assert.That(victim.IsDeadlock(), Is.True);
        Assert.That(victim.IsTimeout(), Is.False);
    }
}
