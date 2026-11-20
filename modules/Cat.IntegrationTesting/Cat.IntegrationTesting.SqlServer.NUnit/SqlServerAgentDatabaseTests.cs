namespace Cat.IntegrationTesting.SqlServer.NUnit;

/// <summary>
/// Base class for the tests of one class that need change data capture. It works like <see cref="SqlServerDatabaseTests"/>, on the container that runs the SQL Server Agent.
/// </summary>
public abstract class SqlServerAgentDatabaseTests : SqlServerDatabaseTests
{
    /// <summary>
    /// Gets the container with the SQL Server Agent on.
    /// </summary>
    protected override SqlServerTestContainer Container => SqlServerTestContainer.SharedWithAgent;
}