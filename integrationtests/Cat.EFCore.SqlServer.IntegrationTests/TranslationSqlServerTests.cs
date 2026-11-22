using Cat.IntegrationTesting.SqlServer.NUnit;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.IntegrationTests;

/// <summary>
/// The SQL Server part of the translation tests. The tests are in the shared file.
/// </summary>
public partial class TranslationIntegrationTests : SqlServerDatabaseTests
{
    private static void UseDatabase(DbContextOptionsBuilder options, string connectionString) => options.UseSqlServer(connectionString);
}
