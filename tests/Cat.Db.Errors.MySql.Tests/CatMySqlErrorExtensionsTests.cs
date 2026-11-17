using MySqlConnector;

namespace Cat.Db.Errors.MySql.Tests;

[TestFixture]
public class CatMySqlErrorExtensionsTests
{
    private static MySqlException Create(int number) => MySqlExceptionFactory.Create(number);

    [Test]
    public void Numbers_MatchTheMySqlConnectorErrorCodes()
    {
        Assert.That(CatMySqlErrorNumbers.DuplicateEntry, Is.EqualTo((int)MySqlErrorCode.DuplicateKeyEntry));
        Assert.That(CatMySqlErrorNumbers.RowIsReferenced, Is.EqualTo((int)MySqlErrorCode.RowIsReferenced2));
        Assert.That(CatMySqlErrorNumbers.NoReferencedRow, Is.EqualTo((int)MySqlErrorCode.NoReferencedRow2));
        Assert.That(CatMySqlErrorNumbers.Deadlock, Is.EqualTo((int)MySqlErrorCode.LockDeadlock));
        Assert.That(CatMySqlErrorNumbers.LockWaitTimeout, Is.EqualTo((int)MySqlErrorCode.LockWaitTimeout));
        Assert.That(CatMySqlErrorNumbers.CommandTimeout, Is.EqualTo((int)MySqlErrorCode.CommandTimeoutExpired));
    }

    [Test]
    public void IsUniqueViolation_Number1062_ReturnsTrue()
    {
        Assert.That(Create(1062).IsUniqueViolation(), Is.True);
    }

    [TestCase(1451)]
    [TestCase(1452)]
    [TestCase(1213)]
    [TestCase(0)]
    public void IsUniqueViolation_OtherNumbers_ReturnsFalse(int number)
    {
        Assert.That(Create(number).IsUniqueViolation(), Is.False);
    }

    [TestCase(1451)]
    [TestCase(1452)]
    public void IsForeignKeyViolation_ForeignKeyNumbers_ReturnsTrue(int number)
    {
        Assert.That(Create(number).IsForeignKeyViolation(), Is.True);
    }

    [Test]
    public void IsForeignKeyViolation_OtherNumber_ReturnsFalse()
    {
        Assert.That(Create(1062).IsForeignKeyViolation(), Is.False);
    }

    [Test]
    public void IsDeadlock_Number1213_ReturnsTrue()
    {
        Assert.That(Create(1213).IsDeadlock(), Is.True);
        Assert.That(Create(1205).IsDeadlock(), Is.False);
    }

    [TestCase(-1)]
    [TestCase(1205)]
    public void IsTimeout_TimeoutNumbers_ReturnsTrue(int number)
    {
        Assert.That(Create(number).IsTimeout(), Is.True);
    }

    [TestCase(1213)]
    [TestCase(1062)]
    public void IsTimeout_OtherNumbers_ReturnsFalse(int number)
    {
        Assert.That(Create(number).IsTimeout(), Is.False);
    }

    [Test]
    public void IsUniqueViolation_MySqlExceptionInsideAnotherException_ReturnsTrue()
    {
        var wrapped = new InvalidOperationException("outer", new InvalidOperationException("middle", Create(1062)));

        Assert.That(wrapped.IsUniqueViolation(), Is.True);
    }

    [Test]
    public void FindMySqlException_NoMySqlException_ReturnsNull()
    {
        Assert.That(new InvalidOperationException("outer", new Exception("inner")).FindMySqlException(), Is.Null);
    }

    [Test]
    public void Checks_NullException_ReturnFalse()
    {
        Exception? exception = null;

        Assert.That(exception.FindMySqlException(), Is.Null);
        Assert.That(exception.IsUniqueViolation(), Is.False);
        Assert.That(exception.IsForeignKeyViolation(), Is.False);
        Assert.That(exception.IsDeadlock(), Is.False);
        Assert.That(exception.IsTimeout(), Is.False);
    }

    [Test]
    public void FindMySqlException_MySqlException_ReturnsIt()
    {
        var mySqlException = Create(1062);

        Assert.That(mySqlException.FindMySqlException(), Is.SameAs(mySqlException));
    }
}
