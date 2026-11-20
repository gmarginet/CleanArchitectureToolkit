using NUnit.Framework;

namespace Cat.IntegrationTesting.PostgreSQL.NUnit;

/// <summary>
/// Base class for the tests of one class that need an empty PostgreSQL database. The class gets its own database in the shared container, and the database is dropped when the class is done.
/// </summary>
/// <remarks>
/// When Docker is not available, the tests fail if the <c>CI</c> environment variable is set, and are ignored with a message otherwise.
/// </remarks>
public abstract class PostgreSQLDatabaseTests
{
    private ICatTestDatabase? _database;

    /// <summary>
    /// Gets the connection string of the database of this test class.
    /// </summary>
    protected string ConnectionString => _database?.ConnectionString ?? throw new InvalidOperationException("The database is not created yet.");

    /// <summary>
    /// Creates the database of the test class.
    /// </summary>
    /// <returns>A task that completes when the database exists.</returns>
    [OneTimeSetUp]
    public async Task CreateDatabase()
    {
        try
        {
            _database = await PostgreSQLTestContainer.Shared.CreateDatabaseAsync();
        }
        catch (CatContainerUnavailableException exception) when (!CatTestEnvironment.IsContinuousIntegration)
        {
            Assert.Ignore(CatTestEnvironment.IgnoreMessage(exception.Message));
        }
    }

    /// <summary>
    /// Drops the database of the test class.
    /// </summary>
    /// <returns>A task that completes when the database is gone.</returns>
    [OneTimeTearDown]
    public async Task DropDatabase()
    {
        if (_database is not null) await _database.DisposeAsync();
    }
}
