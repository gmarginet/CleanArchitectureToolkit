namespace Cat.IntegrationTesting.Tests;

[TestFixture]
public class CatTestEnvironmentTests
{
    [TestCase("true", true)]
    [TestCase("True", true)]
    [TestCase("1", true)]
    [TestCase(" yes ", true)]
    [TestCase("false", false)]
    [TestCase("FALSE", false)]
    [TestCase("0", false)]
    [TestCase("", false)]
    [TestCase("  ", false)]
    [TestCase(null, false)]
    public void IsContinuousIntegrationValue_FollowsTheEnvironmentVariable(string? value, bool expected)
    {
        Assert.That(CatTestEnvironment.IsContinuousIntegrationValue(value), Is.EqualTo(expected));
    }

    [Test]
    public void NewDatabaseName_IsUniqueAndSafeInAnIdentifier()
    {
        var first = CatTestEnvironment.NewDatabaseName();
        var second = CatTestEnvironment.NewDatabaseName();

        Assert.That(first, Is.Not.EqualTo(second));
        Assert.That(first, Does.Match("^cat_[0-9a-f]{32}$"));
    }

    [Test]
    public void IgnoreMessage_HoldsTheReason()
    {
        Assert.That(CatTestEnvironment.IgnoreMessage("No socket."), Does.Contain("No socket."));
    }
}
