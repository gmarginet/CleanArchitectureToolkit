using Npgsql;

namespace Cat.Db.Errors.PostgreSQL.Tests;

[TestFixture]
public class CatPostgreSQLErrorExtensionsTests
{
    private static PostgresException Create(string sqlState) =>
        new("test", "ERROR", "ERROR", sqlState);

    [Test]
    public void Codes_MatchThePostgresErrorCodesOfNpgsql()
    {
        Assert.That(CatPostgreSQLErrorCodes.UniqueViolation, Is.EqualTo(PostgresErrorCodes.UniqueViolation));
        Assert.That(CatPostgreSQLErrorCodes.ForeignKeyViolation, Is.EqualTo(PostgresErrorCodes.ForeignKeyViolation));
        Assert.That(CatPostgreSQLErrorCodes.DeadlockDetected, Is.EqualTo(PostgresErrorCodes.DeadlockDetected));
        Assert.That(CatPostgreSQLErrorCodes.QueryCanceled, Is.EqualTo(PostgresErrorCodes.QueryCanceled));
        Assert.That(CatPostgreSQLErrorCodes.LockNotAvailable, Is.EqualTo(PostgresErrorCodes.LockNotAvailable));
    }

    [Test]
    public void IsUniqueViolation_Code23505_ReturnsTrue()
    {
        Assert.That(Create("23505").IsUniqueViolation(), Is.True);
    }

    [TestCase("23503")]
    [TestCase("40P01")]
    [TestCase("00000")]
    public void IsUniqueViolation_OtherCodes_ReturnsFalse(string sqlState)
    {
        Assert.That(Create(sqlState).IsUniqueViolation(), Is.False);
    }

    [Test]
    public void IsForeignKeyViolation_Code23503_ReturnsTrue()
    {
        Assert.That(Create("23503").IsForeignKeyViolation(), Is.True);
    }

    [Test]
    public void IsForeignKeyViolation_OtherCode_ReturnsFalse()
    {
        Assert.That(Create("23505").IsForeignKeyViolation(), Is.False);
    }

    [Test]
    public void IsDeadlock_Code40P01_ReturnsTrue()
    {
        Assert.That(Create("40P01").IsDeadlock(), Is.True);
        Assert.That(Create("55P03").IsDeadlock(), Is.False);
    }

    [TestCase("57014")]
    [TestCase("55P03")]
    public void IsTimeout_TimeoutCodes_ReturnsTrue(string sqlState)
    {
        Assert.That(Create(sqlState).IsTimeout(), Is.True);
    }

    [TestCase("40P01")]
    [TestCase("23505")]
    public void IsTimeout_OtherCodes_ReturnsFalse(string sqlState)
    {
        Assert.That(Create(sqlState).IsTimeout(), Is.False);
    }

    [Test]
    public void IsTimeout_TimeoutExceptionInsideNpgsqlException_ReturnsTrue()
    {
        var exception = new NpgsqlException("Exception while reading from stream", new TimeoutException("Timeout during reading attempt"));

        Assert.That(exception.IsTimeout(), Is.True);
    }

    [Test]
    public void IsTimeout_NoTimeoutAnywhere_ReturnsFalse()
    {
        Assert.That(new InvalidOperationException("outer", new Exception("inner")).IsTimeout(), Is.False);
    }

    [Test]
    public void IsUniqueViolation_PostgresExceptionInsideAnotherException_ReturnsTrue()
    {
        var wrapped = new InvalidOperationException("outer", new InvalidOperationException("middle", Create("23505")));

        Assert.That(wrapped.IsUniqueViolation(), Is.True);
    }

    [Test]
    public void FindPostgresException_NoPostgresException_ReturnsNull()
    {
        Assert.That(new InvalidOperationException("outer", new Exception("inner")).FindPostgresException(), Is.Null);
    }

    [Test]
    public void Checks_NullException_ReturnFalse()
    {
        Exception? exception = null;

        Assert.That(exception.FindPostgresException(), Is.Null);
        Assert.That(exception.IsUniqueViolation(), Is.False);
        Assert.That(exception.IsForeignKeyViolation(), Is.False);
        Assert.That(exception.IsDeadlock(), Is.False);
        Assert.That(exception.IsTimeout(), Is.False);
    }

    [Test]
    public void FindPostgresException_PostgresException_ReturnsIt()
    {
        var postgresException = Create("23505");

        Assert.That(postgresException.FindPostgresException(), Is.SameAs(postgresException));
    }
}
