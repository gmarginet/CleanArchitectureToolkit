using Microsoft.Data.SqlClient;

namespace Cat.Db.Errors.SqlServer.Tests;

[TestFixture]
public class CatSqlServerErrorExtensionsTests
{
    [TestCase(2627)]
    [TestCase(2601)]
    public void IsUniqueViolation_UniqueNumbers_ReturnsTrue(int number)
    {
        Assert.That(SqlExceptionFactory.Create(number).IsUniqueViolation(), Is.True);
    }

    [TestCase(547)]
    [TestCase(1205)]
    [TestCase(-2)]
    [TestCase(0)]
    public void IsUniqueViolation_OtherNumbers_ReturnsFalse(int number)
    {
        Assert.That(SqlExceptionFactory.Create(number).IsUniqueViolation(), Is.False);
    }

    [Test]
    public void IsForeignKeyViolation_Number547_ReturnsTrue()
    {
        Assert.That(SqlExceptionFactory.Create(547).IsForeignKeyViolation(), Is.True);
        Assert.That(SqlExceptionFactory.Create(2627).IsForeignKeyViolation(), Is.False);
    }

    [Test]
    public void IsDeadlock_Number1205_ReturnsTrue()
    {
        Assert.That(SqlExceptionFactory.Create(1205).IsDeadlock(), Is.True);
        Assert.That(SqlExceptionFactory.Create(2627).IsDeadlock(), Is.False);
    }

    [TestCase(-2)]
    [TestCase(1222)]
    public void IsTimeout_TimeoutNumbers_ReturnsTrue(int number)
    {
        Assert.That(SqlExceptionFactory.Create(number).IsTimeout(), Is.True);
    }

    [Test]
    public void IsTimeout_OtherNumber_ReturnsFalse()
    {
        Assert.That(SqlExceptionFactory.Create(1205).IsTimeout(), Is.False);
    }

    [Test]
    public void IsUniqueViolation_SqlExceptionInsideAnotherException_ReturnsTrue()
    {
        var wrapped = new InvalidOperationException("outer", new InvalidOperationException("middle", SqlExceptionFactory.Create(2627)));

        Assert.That(wrapped.IsUniqueViolation(), Is.True);
    }

    [Test]
    public void FindSqlException_NoSqlException_ReturnsNull()
    {
        Assert.That(new InvalidOperationException("outer", new Exception("inner")).FindSqlException(), Is.Null);
    }

    [Test]
    public void Checks_NullException_ReturnFalse()
    {
        Exception? exception = null;

        Assert.That(exception.FindSqlException(), Is.Null);
        Assert.That(exception.IsUniqueViolation(), Is.False);
        Assert.That(exception.IsForeignKeyViolation(), Is.False);
        Assert.That(exception.IsDeadlock(), Is.False);
        Assert.That(exception.IsTimeout(), Is.False);
    }

    [Test]
    public void FindSqlException_SqlException_ReturnsIt()
    {
        SqlException sqlException = SqlExceptionFactory.Create(2627);

        Assert.That(((Exception)sqlException).FindSqlException(), Is.SameAs(sqlException));
    }
}
