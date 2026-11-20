using Cat.IntegrationTesting.SqlServer.NUnit;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.IntegrationTests;

/// <summary>
/// The SQL Server part of the store tests. The tests are in the shared file.
/// </summary>
public partial class EfCoreStoreIntegrationTests : SqlServerDatabaseTests
{
    private static void UseDatabase(DbContextOptionsBuilder options, string connectionString) => options.UseSqlServer(connectionString);
}
